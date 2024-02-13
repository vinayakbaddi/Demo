---------- FOlder 
use TestDB
drop table #another_table_name

create table #another_table_name
(groupid int , folderid int) 

DECLARE @GroupId INT = 1;
DECLARE @CurrentGroupSize BIGINT = 0;
DECLARE @MaxGroupSize BIGINT = CAST(2 AS BIGINT) * 1024 * 1024 * 1024; -- 2GB in bytes

DECLARE @FolderId INT;
DECLARE @loanno INT;

DECLARE @FolderSize BIGINT;

DECLARE folder_cursor CURSOR FOR
SELECT 
    folderid, loanno,
    SUM(size) AS folder_size
FROM 
    FrbFolder
GROUP BY 
    folderid, loanno
ORDER BY 
    loanno;

OPEN folder_cursor;
FETCH NEXT FROM folder_cursor INTO @FolderId, @loanno, @FolderSize;

WHILE @@FETCH_STATUS = 0
BEGIN
    --IF (@CurrentGroupSize + @FolderSize) >= @MaxGroupSize
	IF (@CurrentGroupSize ) >= @MaxGroupSize
    BEGIN
        SET @GroupId = @GroupId + 1; -- Move to the next group
        SET @CurrentGroupSize = 0; -- Reset the current group size
    END
	--print 'before insert ' | @CurrentGroupSize
    INSERT INTO #another_table_name (groupid, folderid)
    VALUES (@GroupId, @FolderId);

    SET @CurrentGroupSize = @CurrentGroupSize + @FolderSize;
	--print 'after insert ' | @CurrentGroupSize 
    FETCH NEXT FROM folder_cursor INTO @FolderId,@loanno, @FolderSize;
END

CLOSE folder_cursor;
DEALLOCATE folder_cursor;

select *, f.size/(1024*1024)  from #another_table_name a
inner join FRBFolder f on f.folderid = a.folderid 
----

-------------------------
--- summing
WITH RecursiveCTE AS (
    SELECT id, folder, lid, size, size AS total_size, 1 AS group_id
    FROM YourTable
    WHERE size <= 2147483648 -- 2GB in bytes

    UNION ALL

    SELECT t.id, t.folder, t.lid, t.size, 
           CASE WHEN r.total_size + t.size <= 2147483648 THEN r.total_size + t.size ELSE t.size END AS total_size,
           CASE WHEN r.total_size + t.size <= 2147483648 THEN r.group_id ELSE r.group_id + 1 END AS group_id
    FROM YourTable t
    INNER JOIN RecursiveCTE r ON t.id > r.id AND r.total_size + t.size <= 2147483648
)

SELECT id, folder, lid, total_size, group_id
FROM RecursiveCTE
ORDER BY group_id, id;
-------------end

-----------another query
-- Create a CTE to calculate cumulative sum of size for each folder
WITH FolderSizes AS (
    SELECT 
        folderid, 
        folder, 
        loanno, 
        size,
        SUM(size) OVER (PARTITION BY folder ORDER BY loanno) AS cumulative_size
    FROM 
        your_table_name
)

-- Select and insert into another table with grouping
INSERT INTO another_table_name (groupid, folderid)
SELECT 
    (ROW_NUMBER() OVER (ORDER BY folderid) - 1) / 1000 AS groupid, -- Assuming each group should sum up to 2GB (1000 folders)
    folderid
FROM 
    FolderSizes
GROUP BY 
    (ROW_NUMBER() OVER (ORDER BY folderid) - 1) / 1000, -- Assuming each group should sum up to 2GB (1000 folders)
    folderid

--------------

--------------------------
SELECT 
    f.folder_id,
    f.folder_name,
    COALESCE(success_count, 0) AS success_count,
    COALESCE(failure_count, 0) AS failure_count,
    COALESCE(unknown_count, 0) AS unknown_count
FROM 
    folders_table f
LEFT JOIN (
    SELECT 
        folder_id,
        COUNT(*) AS success_count
    FROM 
        files_table
    WHERE 
        status = 'success'
    GROUP BY 
        folder_id
) success ON f.folder_id = success.folder_id
LEFT JOIN (
    SELECT 
        folder_id,
        COUNT(*) AS failure_count
    FROM 
        files_table
    WHERE 
        status = 'failure'
    GROUP BY 
        folder_id
) failure ON f.folder_id = failure.folder_id
LEFT JOIN (
    SELECT 
        folder_id,
        COUNT(*) AS unknown_count
    FROM 
        files_table
    WHERE 
        status = 'unknown'
    GROUP BY 
        folder_id
) unknown ON f.folder_id = unknown.folder_id
ORDER BY 
    COALESCE(success_count, 0) DESC,
    COALESCE(failure_count, 0) DESC,
    COALESCE(unknown_count, 0) DESC,
    f.folder_id;
