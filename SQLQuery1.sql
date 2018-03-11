BULK INSERT dbo.PrototypeModels
    FROM 'C:\Users\Kenton\Desktop\CS451 Project\Make Fake Data\Make Fake Data\dummydata.csv'
    WITH
    (
    FIRSTROW = 2,
    FIELDTERMINATOR = ',',  --CSV field delimiter
    ROWTERMINATOR = '\n',   --Use to shift the control to next row
    ERRORFILE = 'C:\Users\Kenton\Desktop\CS451 Project\Make Fake Data\Make Fake Data\error.csv',
    TABLOCK
    )