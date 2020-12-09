using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using LumenWorks.Framework.IO.Csv;
using WordCloud;

namespace fake_news_classifier
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //read csv files
            int index = Environment.CurrentDirectory.IndexOf("bin");
            string current_dir_path = Environment.CurrentDirectory.Substring(0, index - 1);
            var trueCsvTable = ReadCsvFile(Path.Combine(current_dir_path, @"csv-files", "True.csv"));
            var fakeCsvTable = ReadCsvFile(Path.Combine(current_dir_path, @"csv-files", "Fake.csv"));
            //add classified collumns to both datatables
            trueCsvTable = AddClassifiedColumn(trueCsvTable, "true");
            fakeCsvTable = AddClassifiedColumn(fakeCsvTable, "fake");
            //combine both datatables
            var csvTables = trueCsvTable;
            csvTables.Merge(fakeCsvTable);
            //shuffle datatable
            csvTables = ShuffleDataTable(csvTables);
            //search for null values
            csvTables = SearchForNullValues(csvTables);
            //add article column
            csvTables = AddArticleColumn(csvTables);
            //create datatable with article and classified
            DataTable finalDataTable = CreateNewDataTable(csvTables);
            //lower case article column
            finalDataTable = LowerCaseArticleColumn(finalDataTable);
            //remove punctuation from article column
            finalDataTable = RemovePunctuationArticleColumn(finalDataTable);
            //remove stopwords from article column
            finalDataTable = RemoveStopwordsArticleColumn(finalDataTable);
            var firstRow = finalDataTable.Rows[1];
            foreach (var item in firstRow.ItemArray)
            {
                Console.WriteLine(item);
            }
        }

        public static DataTable ReadCsvFile(string filePath)
        {
            var csvTable = new DataTable();
            using (var csvReader = new CsvReader(new StreamReader(File.OpenRead(filePath)), true))
            {
                csvTable.Load(csvReader);
            }
            return csvTable;
        }

        public static DataTable AddClassifiedColumn(DataTable dataTable, string classifiedValue)
        {
            DataColumn column = dataTable.Columns.Add("classified", typeof(String));
            column.SetOrdinal(4);
            foreach(DataRow row in dataTable.Rows)
            {
                row["classified"] = classifiedValue;
            }
            return dataTable;
        }

        public static void PrintDataTable(DataTable dataTable)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static DataTable ShuffleDataTable(DataTable dataTable)
        {
            DataTable dataTableTmp = dataTable.Copy();
            if (!dataTableTmp.Columns.Contains("SortBy"))
                dataTableTmp.Columns.Add("SortBy", typeof(Int32));
            Random rnd = new Random();
            foreach (DataRow row in dataTableTmp.Rows)
            {
                row["SortBy"] = rnd.Next(1, 45000);
            }
            DataView dv = dataTableTmp.DefaultView;
            dv.Sort = "SortBy";
            DataTable sortedDT = dv.ToTable();
            return sortedDT;
        }

        public static DataTable SearchForNullValues(DataTable dataTable)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var dataArray = dataRow.ItemArray;
                for (int i = 0; i < dataArray.Length; i++)
                {
                    if (dataArray[i] == DBNull.Value)
                    {
                        dataArray[i] = dataTable.Columns[i].ColumnName;
                    }
                }
            }
            return dataTable;
        }

        public static DataTable AddArticleColumn(DataTable dataTable)
        {
            DataColumn column = dataTable.Columns.Add("article", typeof(String));
            column.SetOrdinal(5);
            foreach (DataRow row in dataTable.Rows)
            {
                row["article"] = row["title"] + " " + row["text"] + " " + row["subject"];
            }
            return dataTable;
        }

        public static DataTable CreateNewDataTable(DataTable dataTable)
        {
            DataView view = new DataView(dataTable);
            return view.ToTable("newDataTable", false, "article", "classified");
        }

        public static DataTable LowerCaseArticleColumn(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                row["article"] = row["article"].ToString().ToLower();
            }
            return dataTable;
        }

        public static DataTable RemovePunctuationArticleColumn(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                var sb = new StringBuilder();
                foreach (char c in row["article"].ToString())
                {
                    if (!char.IsPunctuation(c))
                        sb.Append(c);
                }

                row["article"] = sb.ToString();
            }
            return dataTable;
        }

        public static string RemoveStopwordsFromArticle(string input)
        {
            var words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder builder = new StringBuilder();
            foreach (string currentWord in words)
            {
                if (!StopWordsList.Stopwords.Contains(currentWord))
                {
                    builder.Append(currentWord).Append(' ');
                }
            }
            return builder.ToString().Trim();
        }

        public static DataTable RemoveStopwordsArticleColumn(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                row["article"] = RemoveStopwordsFromArticle(row["article"].ToString());
            }
            return dataTable;
        }

        public static string JoinAllWordsArticleColumns(DataTable dataTable)
        {
            StringBuilder builder = new StringBuilder();
            foreach (DataRow row in dataTable.Rows)
            {
                builder.Append(row["article"].ToString());
            }
            return builder.ToString();
        }

        public static void CreateWordcloud(DataTable dataTable)
        {
            string allWords = JoinAllWordsArticleColumns(dataTable);
            string[] allWordsList = allWords.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            /*WordCloud.WordCloud wordcloud = new WordCloud.WordCloud(1024, 768, true);
            wordcloud.Draw(allWordsList);*/
        }
    }
}
