using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Yaml;
using System.Yaml.Serialization;

namespace CsvToDbRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            // yaml file을 열고, database name 등 사용자의 설정을 읽는다.
            string dbName;
            string CSVFilter;
            try
            {
                // look for yaml file
                var n = YamlMapping.FromYamlFile("csv-to-db-config.yaml");
                var m = (YamlMapping)n[0];
                dbName = ((YamlScalar)m["Database"]).Value;
                CSVFilter = ((YamlScalar)m["CSV-Filter"]).Value;
            }
            catch(Exception e)
            {
                Console.WriteLine("** Open csv-to-db-config.yaml failed.");
                Console.WriteLine(e.ToString());
                return;
            }

            // 조건에 맞는 파일들을 찾아서, DB record에 넣는다.
            var files = Directory.GetFiles(".", CSVFilter);
            foreach (var fileName in files)
            {
                var pureName = Path.GetFileNameWithoutExtension(fileName);

                CsvToRecord v = new CsvToRecord();

                v.m_DBName = dbName;
                v.m_tableName = pureName;

                v.Process();
                
                // 에러가 났으면
                if(v.m_error!=null)
                {
                    // 에러를 출력하자.
                    Console.WriteLine($"**Failed to write to DB for {v.m_tableName}. {v.m_error.ToString()}");
                }
                else
                {
                    Console.WriteLine($"DB write ok: {v.m_tableName}");
                }
            }
        }
    }
}
