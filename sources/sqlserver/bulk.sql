BULK INSERT {TableName}
   FROM '{PathToCsvFile}'
   WITH 
      (
         FIELDTERMINATOR =';',
         ROWTERMINATOR ='\n'
      );