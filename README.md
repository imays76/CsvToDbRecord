# CsvToDbRecord

Move your CSV documents to your DB tables.

# How to use

Prepare your CSV files. For example, 
test/
  player.csv
  monster.csv
  
Prepare your tables. For example,
  player { Name, Score, Passcode }
  monster { NameX, ScoreX, PassCodeX } 

NOTE: You may use any field type.

Prepare your config file `csv-to-db-config.yaml`. For example,
```
Database:	"CsvToDbRecord-test" # Your database name
CSV-Filter: "*.csv" # Your CSV file filter
```

Copy CsvToDbRecord.exe to the same folder and run it.
The work result will be printed on your console window.
