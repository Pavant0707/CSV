using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV
{
    public class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Country { get; set; }

    }
    public class Program
    {
        static void WriteToCsv(String filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    using (File.Create(filePath))
                    {

                    }
                }
                List<Person> list = new List<Person>
                {
                    new Person{Name="virat",Id=1,Country="india"},
                    new Person{Name="ram",Id=2,Country="India"}
                };
                var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                };
                using (StreamWriter writer = new StreamWriter(filePath))
                using (CsvWriter csv = new CsvWriter(writer, configPersons))
                {
                    csv.WriteRecords(list);
                }
                Console.WriteLine("jai sri rama");
            }
            catch
            {
                throw;
            }
        }
        static void readcsv(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = false,
                    };
                    using (StreamReader reader = new StreamReader(filePath))
                    using (CsvReader reader1 = new CsvReader(reader, configPersons))
                    {
                        IEnumerable<Person> records = reader1.GetRecords<Person>();

                        foreach (Person p in records)
                        {
                            Console.WriteLine(p.Id);
                        }
                    }
                }
            }
            catch { }
        }

        static void Main(string[] args)
        {
            String str = @"C:\FileProg"; string filename = "data.csv";
            String filePath = Path.Combine(str, filename);
            WriteToCsv(filePath);
            readcsv(filePath);

        }

    }
}
     
