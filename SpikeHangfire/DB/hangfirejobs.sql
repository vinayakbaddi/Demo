DECLARE @TotalDurationInSeconds INT;
DECLARE @TotalJobsCount INT;

-- Calculate total duration and total number of jobs
SELECT 
    @TotalDurationInSeconds = SUM(DATEDIFF(SECOND, CreatedAt, ExpireAt)),
    @TotalJobsCount = COUNT(*)
FROM 
    Hangfire.Job
WHERE 
    ExpireAt IS NOT NULL;

-- Calculate average duration in minutes
SELECT 
    ISNULL(@TotalDurationInSeconds / NULLIF(@TotalJobsCount * 60, 0), 0) AS AverageDurationInMinutes;


DECLARE @TotalDurationInSeconds INT;
DECLARE @TotalJobsCount INT;

-- Calculate total duration and total number of jobs
SELECT 
    @TotalDurationInSeconds = SUM(CAST(Json_Value(State, '$.PerformanceDuration') AS INT)),
    @TotalJobsCount = COUNT(*)
FROM 
    Hangfire.Job
WHERE 
    State LIKE '%Succeeded%';

-- Calculate average duration in minutes
SELECT 
    ISNULL(@TotalDurationInSeconds / NULLIF(@TotalJobsCount * 60, 0), 0) AS AverageDurationInMinutes;
