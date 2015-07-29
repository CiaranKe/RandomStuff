SELECT b.txt
      ,count(Duration) as totalcount
      ,min(Duration)   as min_Duration 
      ,max(Duration)   as max_Duration
      ,avg(Duration)   as avg_Duration
      ,sum(limit1)     as above5sec
      ,sum(limit2)     as above10sec
      ,sum(limit3)     as above25sec
      ,sum(limit4)     as above50sec
FROM (
      SELECT a.Duration as Duration
            ,SUBSTRING ( a.t , 6 , ISNULL(NULLIF ( CHARINDEX ( ' ' ,  a.t, 6), 0),LEN(a.t))-6) as txt
            ,CASE WHEN a.Duration > 5000  THEN 1 ELSE 0  END as limit1
            ,CASE WHEN a.Duration > 10000 THEN 1 ELSE 0  END as limit2
            ,CASE WHEN a.Duration > 25000 THEN 1 ELSE 0  END as limit3
            ,CASE WHEN a.Duration > 50000 THEN 1 ELSE 0  END as limit4
      FROM (
            SELECT Duration as Duration
                  ,REPLACE(REPLACE(REPLACE(SUBSTRING(textdata, PATINDEX ( '%exec%' ,  textdata),100),'@RETURN_STATUS_P = ',''),'[DBO].',''),'[dbo].','') as t
            FROM   ::fn_trace_gettable('F:\Profiler\20050518\profilertrace_20050518.trc', default)
            WHERE  textdata like '%exec %'
            AND    Duration IS NOT NULL
           ) as a
     ) as b
GROUP BY b.txt
ORDER BY avg(Duration) DESC

