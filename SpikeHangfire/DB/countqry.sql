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
