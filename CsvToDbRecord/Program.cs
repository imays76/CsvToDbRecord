using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Yaml.Serialization;

namespace CsvToDbRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // look for yaml file
                var yamlSerializer = new YamlSerializer();
                var o = yamlSerializer.DeserializeFromFile("csv-to-db-config.yaml");
            }
            catch(Exception e)
            {
                Console.WriteLine("** Open csv-to-db-config.yaml failed.");
                Console.WriteLine(e.ToString());
                return;
            }

            CsvToRecord v = new CsvToRecord();

            v.m_DBName = "CsvToDbRecord-test";
            v.m_tableName = "Player";

            v.Process();
        }
    }
}
