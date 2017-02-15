using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToDbRecord
{
    public class CsvToRecord
    {
        public string m_DBName;
        public string m_tableName;
        public string m_connectionString;

        public void Process()
        {
            try
            {
                // connection 
                m_connectionString = $"driver={{SQL Server}};server=.;database={m_DBName};trusted_connection=yes";
                var c = new OdbcConnection(m_connectionString);
                c.Open();

                // CSV 각 Row에 대해서 채우도록 하자.
                var document = File.ReadAllLines($"{m_tableName}.csv");
                int lineNum = 0; // 현재 처리중인 라인 번호. 0부터 시작.

                var columnNames = new List<string>();
                var columnNamesWithComma = "";

                foreach (var line in document)
                {
                    // 컬럼 추출 후에
                    var columns = line.Split(',');

                    if (lineNum == 0)
                    {
                        // column 이름들만 가져오자.
                        foreach (var column in columns)
                        {
                            columnNames.Add(column);
                        }
                        columnNamesWithComma = StringListToCommaString(columnNames);
                    }
                    else
                    {
                        // column 실제 값들을 얻어와서
                        var columnValues = new List<string>();

                        foreach (var column in columns)
                        {
                            columnValues.Add(column);
                        }

                        // 쿼리 구문을 만든다.
                        var valuesWithComma = StringListToCommaString(columnValues);

                        var query = $"insert into {m_tableName} ({columnNamesWithComma}) value ({valuesWithComma}) ";

                        // 쿼리 실행
                        var cmd = new OdbcCommand();
                        cmd.Connection = c;
                        cmd.CommandText = query;
                        int n = cmd.ExecuteNonQuery();
                        Debug.Assert(n == 1);

                        lineNum++;
                    }

                }
            }
            catch (Exception e)
            {

            }
        }

        // [a,b,c] => "a,b,c"
        static string StringListToCommaString(List<string> stringList)
        {
            string ret = "";
            foreach (var str in stringList)
            {
                ret += str + ",";
            }
            // 맨 마지막 콤마는 제거하자.
            ret = ret.Remove(ret.Length - 1);

            return ret;
        }
    }
}
