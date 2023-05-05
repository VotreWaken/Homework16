using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SecondTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Journal journal = new Journal();

            Console.WriteLine("Enter Name:");
            journal.Name = Console.ReadLine();

            Console.WriteLine("Enter publishing:");
            journal.Publisher = Console.ReadLine();

            Console.WriteLine("Enter Date (00.00.0000):");
            journal.Date = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Page Count:");
            journal.PageCount = int.Parse(Console.ReadLine());

            Console.WriteLine(journal.ToString());

            XmlSerializer serializer = new XmlSerializer(typeof(Journal));
            FileStream file = new FileStream("Journal.xml", FileMode.Create);
            serializer.Serialize(file, journal);
            file.Close();

            XmlSerializer serializer2 = new XmlSerializer(typeof(Journal));
            FileStream file2 = new FileStream("Journal.xml", FileMode.Open);
            Journal desializer = ((Journal)serializer2.Deserialize(file2));
            file2.Close();

            Console.WriteLine(desializer);
        }

        public class Journal
        {
            public string Name { get; set; }
            public string Publisher { get; set; }
            public DateTime Date { get; set; }
            public int PageCount { get; set; }

            public override string ToString()
            {
                return
                    $"Name: {Name}" +
                    $"\nPublishing: {Publisher}" +
                    $"\nDate: {Date:dd.MM.yyyy}" +
                    $"\nPages: {PageCount}";
            }

        }
    }
}
