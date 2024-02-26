USE TestDB
GO

DROP TABLE IF EXISTS #another_table_name;

CREATE TABLE #another_table_name (
    groupid INT,
    folderid INT,
    size BIGINT
);

DECLARE @GroupId INT = 1;
DECLARE @CurrentGroupSize BIGINT = 0;
DECLARE @MaxGroupSize BIGINT = CAST(3 AS BIGINT) * 1024 * 1024 * 1024; -- 3GB in bytes
DECLARE @MinGroupSize BIGINT = CAST(2 AS BIGINT) * 1024 * 1024 * 1024; -- 2GB in bytes

DECLARE @FolderId INT;
DECLARE @loanno INT;
DECLARE @FolderSize BIGINT;

DECLARE folder_cursor CURSOR FOR
SELECT 
    folderid, loanno, SUM(size) AS folder_size
FROM 
    FrbFolder
GROUP BY 
    loanno,folderid
ORDER BY 
    loanno;

OPEN folder_cursor;
FETCH NEXT FROM folder_cursor INTO @FolderId, @loanno, @FolderSize;

WHILE @@FETCH_STATUS = 0
BEGIN
print 'fetching folderid ' -- + @FolderId;
print  @FolderId

    IF (@CurrentGroupSize + @FolderSize > @MaxGroupSize)
    BEGIN
        IF (@CurrentGroupSize >= @MinGroupSize)
        BEGIN
            SET @GroupId = @GroupId + 1; -- Move to the next group
            SET @CurrentGroupSize = 0; -- Reset the current group size
			print 'inside begin'
        END
        ELSE
        BEGIN
            -- If adding the current folder would exceed max group size but the current group size is less than 2GB,
            -- we skip adding this folder to the current group and move to the next group
            --FETCH NEXT FROM folder_cursor INTO @FolderId, @loanno, @FolderSize;
			--print @FolderId
			print+ N' skippnig '

            --CONTINUE;
        END
    END

    INSERT INTO #another_table_name (groupid, folderid, size)
    VALUES (@GroupId, @FolderId, @FolderSize);

    SET @CurrentGroupSize = @CurrentGroupSize + @FolderSize;

    FETCH NEXT FROM folder_cursor INTO @FolderId, @loanno, @FolderSize;
END

CLOSE folder_cursor;
DEALLOCATE folder_cursor;

-- Displaying the result
SELECT 
    a.*,f.loanno,F.FOLDER,
    CAST(a.size / (1024.0 * 1024 * 1024) AS DECIMAL(18, 2)) AS GB
FROM 
    #another_table_name a
INNER JOIN 
    FRBFolder f ON f.folderid = a.folderid
	order by groupid
---- Aggregating the results by group
SELECT 
    groupid,
    COUNT(folderid) AS num_folders,
    CAST((SUM(size) / (1024.0 * 1024 * 1024)) AS DECIMAL(18, 2)) AS total_size_in_GB
FROM 
    #another_table_name
GROUP BY 
    groupid
ORDER BY 
    groupid;
--select * from FRBFolder