using ExercicioArquivos.Entities;
using System;
using System.Globalization;
using System.IO;

namespace ExercicioArquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the full path: ");
            string sourceFilePath = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(sourceFilePath);

                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath); // Pegando o nome das pastas.
                string targetFolderPath = sourceFolderPath + @"\out"; // Pasta onde será salvo o arquivo.
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(targetFolderPath);

                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (String line in lines)
                    {
                        string[] fields = line.Split(",");
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);

                        Product prod = new Product(name, price, quantity);

                        sw.WriteLine(prod.description + ", " + prod.sum(price, quantity).ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro: " + e);
            }
        }
    }
}
