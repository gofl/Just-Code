using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevenshteinUI.Model
{
    public class Levenshtein
    {
        private int[,] table = null;
        private int m = 0;
        private int n = 0;

        public double Similarity(string str1, string str2)
        {
            double similarity = 100 - (((double)Distance(str1, str2) / Math.Max(str1.Length, str2.Length)) * 100);

            //double similarity = 1 / (double)(1 + Distance(str1, str2));

            return similarity;
        }

        public int Distance(string str1, string str2)
        {
            m = str1.Length;
            n = str2.Length;

            table = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
                table[i, 0] = i;

            for (int j = 0; j <= n; j++)
                table[0, j] = j;


            for (int j = 0; j <= n; j++)
            {
                for (int i = 0; i <= m; i++)
                {
                    if ((i - 1) >= 0 && (j - 1) >= 0)
                    {
                        if (str1.Substring(i - 1, 1) == str2.Substring(j - 1, 1))
                        {
                            table[i, j] = table[i - 1, j - 1];
                        }
                        else
                        {
                            table[i, j] = Math.Min(table[i - 1, j] + 1, Math.Min(table[i, j - 1] + 1, table[i - 1, j - 1] + 1));
                        }
                    }
                }
            }

            return table[m, n];
        }

        public void Print()
        {
            if (table != null)
            {
                for (int j = 0; j <= n; j++)
                {
                    for (int i = 0; i <= m; i++)
                    {
                        if ((i - 1) >= 0 && (j - 1) >= 0)
                            Console.Write(table[i, j] + "\t");
                    }
                    Console.Write("\n");
                }
            }
        }

        public int[,] Table
        {
            get { return this.table; }
        }
    }
}
