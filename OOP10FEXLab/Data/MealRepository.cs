using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using OOP10FEXLab.Models;

namespace OOP10FEXLab.Data
{
    /// <summary>
    /// Reads the package meals from Data\meals.txt.
    /// Line format: Code|Category|Name|Price|Inclusions
    /// (Replace this class's code with the professor's database code to load from a database instead.)
    /// </summary>
    public class MealRepository
    {
        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "meals.txt");

        public List<Meal> GetAll()
        {
            List<Meal> meals = new List<Meal>();

            foreach (string line in File.ReadAllLines(filePath))
            {
                if (line.Trim() == "" || line.StartsWith("#") || line.StartsWith("Code|")) continue;

                string[] f = line.Split('|');
                if (f.Length < 5) continue;

                meals.Add(new Meal
                {
                    Code = f[0].Trim(),
                    Category = f[1].Trim(),
                    Name = f[2].Trim(),
                    Price = decimal.Parse(f[3].Trim(), CultureInfo.InvariantCulture),
                    Inclusions = f[4].Trim()
                });
            }

            return meals;
        }
    }
}
