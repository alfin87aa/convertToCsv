using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convertToCsv
{
    internal class Program
    {
        public class MBFinal
        {
           public string CostCentreID {  get; set; }
           public string GLAccountNo { get; set; }
           public int MonthPeriod { get; set; }
           public double Amount { get; set; }
        }

        static void Main(string[] args)
        {
            var sparator = "\t";

            var MBFinals = new List<MBFinal> { 
                new MBFinal {CostCentreID = "F-104-1160", GLAccountNo = "7130002000", MonthPeriod = 1, Amount=200000},
                new MBFinal {CostCentreID = "F-104-1160", GLAccountNo = "7130002000", MonthPeriod = 2, Amount=100000},
                new MBFinal {CostCentreID = "F-104-1160", GLAccountNo = "7130002000", MonthPeriod = 3, Amount=37000000},
                new MBFinal {CostCentreID = "F-104-1160", GLAccountNo = "7130002000", MonthPeriod = 4, Amount=72000000},
                new MBFinal {CostCentreID = "F-104-1160", GLAccountNo = "7130002000", MonthPeriod = 5, Amount=941000000},
                new MBFinal {CostCentreID = "F-104-1160", GLAccountNo = "7130002000", MonthPeriod = 6, Amount=200000},
                new MBFinal {CostCentreID = "F-104-1160", GLAccountNo = "7130002000", MonthPeriod = 7, Amount=200000},
                new MBFinal {CostCentreID = "F-104-1160", GLAccountNo = "7130002000", MonthPeriod = 8, Amount=200000},
                new MBFinal {CostCentreID = "F-104-1160", GLAccountNo = "7130002000", MonthPeriod = 9, Amount=200000},
                new MBFinal {CostCentreID = "F-104-1160", GLAccountNo = "7130002000", MonthPeriod = 10, Amount=200000},
                new MBFinal {CostCentreID = "F-104-1160", GLAccountNo = "7130002000", MonthPeriod = 11, Amount=200000},
            };

            string headerLine = string.Join(sparator, MBFinals[0].GetType().GetProperties().Select(p => p.Name));

            var dataLines = from mbFinal in MBFinals
                            let dataLine = string.Join(sparator, mbFinal.GetType()
                            .GetProperties().Select(p => p.GetValue(mbFinal)))
                            select dataLine;

            var csvData = new List<string>();
            csvData.Add(headerLine);
            csvData.AddRange(dataLines);

            string csvFilePath = @"D://MBFINAL_20230411_0001.csv";
            System.IO.File.WriteAllLines(csvFilePath, csvData);
        }
    }
}
