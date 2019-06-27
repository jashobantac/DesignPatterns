using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace TestFramework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ReadFile();
        }

        private static void ReadFile()
        {
            string[] logFileContent = File.ReadAllLines("NEC.AAI.Egate.Enrollment_New.log");
            List<Transaction> transactions = LoadTransaction(logFileContent);
        }

        private static List<Transaction> LoadTransaction(string[] logFileContent)
        {
            Transaction previousTransaction = null;
            int lineNumber = 0;
            int transactionNumber = 1;
            List<Transaction> transactions = new List<Transaction>();
            // Logic to get all transactions.
            foreach (string line in logFileContent)
            {
                lineNumber++;
                if (line.Contains("Validating PNR "))
                {
                    if (line.EndsWith("."))
                    {
                        continue;
                    }
                    string transactionLine = line;
                    string pnr = GetPnr(transactionLine);
                    Transaction transaction = new Transaction
                    {
                        TransactionId = transactionNumber,
                        Name = pnr,
                        TransactionLine = line,
                        LineNumber = lineNumber,
                        StartTime = GetTime(transactionLine)
                    };
                    if (previousTransaction != null)
                    {
                        previousTransaction.EndTime = transaction.StartTime;
                    }

                    previousTransaction = transaction;
                    transactionNumber++;
                    transactions.Add(transaction);
                }
            }
            return transactions;
        }

        private static string GetPnr(string transactionLine)
        {
            string[] lineItems = transactionLine.Split(' ');
            if (lineItems.Length > 0)
            {
                return lineItems[lineItems.Length - 1];
            }
            return string.Empty;
        }

        private static DateTime? GetTime(string transactionLine)
        {
            string[] lineItems = transactionLine.Split(' ');
            if (lineItems.Length > 2)
            {
                string timeComponent = lineItems[0] + " " + lineItems[1];
                if (DateTime.TryParseExact(timeComponent, "yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime transactionTime))
                {
                    return transactionTime;
                }
            }
            return null;
        }
    }
}
