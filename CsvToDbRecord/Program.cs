using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToDbRecord
{
    class Program
    {

        static void Main(string[] args)
        {
            CsvToRecord v = new CsvToRecord();

            v.m_DBName = "CsvToDbRecord-test";
            v.m_tableName = "Player";
            
            v.Process();
        }
    }
}
