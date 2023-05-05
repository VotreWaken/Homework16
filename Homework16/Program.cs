using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace Homework16
{
    public class Program
    {
        static public void Main(string[] args)
        {
            Fraction[] fractionArr = new Fraction[3];
            FillFractions(fractionArr);
            ShowFractions(fractionArr);
            SerializeFractions(fractionArr);
            DeSerialize(fractionArr);
        }
        static public void FillFractions(Fraction[] fractionArr)
        {
            for (int i = 0; i < 3; i++)
            {
                string[] input = Console.ReadLine().Split('/');
                int numerator = int.Parse(input[0]);
                int denominator = int.Parse(input[1]);
                fractionArr[i] = (new Fraction(numerator, denominator));
            }
        }

        static public void ShowFractions(Fraction[] fractionArr)
        {
            foreach (var item in fractionArr)
            {
                Console.WriteLine(item);
            }
        }

        static public void SerializeFractions(Fraction[] fractionArr)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Fraction[]));
            FileStream file = new FileStream("Fractions.xml", FileMode.Create);
            serializer.Serialize(file, fractionArr);
            file.Close();
        }
        static public void DeSerialize(Fraction[] fractionArr)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Fraction[]));
            FileStream file = new FileStream("Fractions.xml", FileMode.Open);
            Fraction[] desializer = ((Fraction[])serializer.Deserialize(file));

            file.Close();
        }
        public class Fraction
        {
            public int numerator { get; set; }
            public int denominator { get; set; }

            public Fraction(int numerator, int denominator)
            {
                this.numerator = numerator;
                this.denominator = denominator;
            }
            public Fraction()
            {
                this.numerator = 0;
                this.denominator = 0;
            }
            public override string ToString()
            {
                return numerator + "/" + denominator;
            }
        }
    }
}
