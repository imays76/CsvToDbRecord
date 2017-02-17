Move your CSV documents to your DB tables easily.
![](example.png)

# How to use

Prepare your CSV files. For example, 
```
test/
  player.csv
  monster.csv
```
Prepare your tables. For example,
```
  player { Name, Score, Passcode }
  monster { NameX, ScoreX, PassCodeX } 
```

NOTE: You may use any field type.

Prepare your config file `csv-to-db-config.yaml`. For example,
```
Server: ".\\" # your server location name
User-ID: "" # user id. 
Password: "" # password. If you set user id and password to "", then this app will do DB login with trusted connection option.
Database:	"CsvToDbRecord-test" # DB instance name where your records are to be put to.
CSV-Filter: "*.csv" # CSV file filter for looking for your CSV files.
```

Copy CsvToDbRecord.exe to the same folder and run it.
The work result will be printed on your console window.

# How to build
Open Visual Studio or something, and build this.

I have not built it with Mono, but I hope it works with it. Try by yourself with Linux or Mac.

# What you can learn from this source code 

* Accessing ODBC with .Net
* Accessing YAML with https://yamlserializer.codeplex.com/ 
