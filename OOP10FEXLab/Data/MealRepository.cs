using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using MySql.Data.MySqlClient;
using OOP10FEXLab.Models;

namespace OOP10FEXLab.Data
{
    /// <summary>
    /// Loads the package meals.
    /// 1. From the instructor's database: SELECT package_name FROM package_tbl (the provided sample query).
    ///    package_tbl only has the package name, so the code, category, price and inclusions of each
    ///    package are taken from Data\meals.txt by matching the name.
    /// 2. If the database cannot be reached (or has none of our packages), from Data\meals.txt only.
    /// meals.txt line format: Code|Category|Name|Price|Inclusions
    /// </summary>
    public class MealRepository
    {
        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "meals.txt");
        private readonly DatabaseConnection database = DatabaseConnection.CreateDefault();

        /// <summary>Where the last GetAll() loaded the menu from: "database" or "meals.txt".</summary>
        public string Source { get; private set; }

        public List<Meal> GetAll()
        {
            List<Meal> fileMeals = File.Exists(filePath) ? ReadFile() : new List<Meal>();

            try
            {
                List<string> names = ReadPackageNames();

                // Keep the database's packages, in the database's order, using the details from meals.txt.
                List<Meal> meals = new List<Meal>();
                foreach (string name in names)
                {
                    Meal meal = fileMeals.FirstOrDefault(m => string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
                    if (meal != null && !meals.Contains(meal)) meals.Add(meal);
                }

                if (meals.Count > 0)
                {
                    Source = "database";
                    return meals;
                }
            }
            catch (Exception)
            {
                // Database not reachable (wrong network, server off, MySql.Data missing): use meals.txt below.
            }

            if (!File.Exists(filePath))
                throw new FileNotFoundException("The database could not be reached and meals.txt was not found.", filePath);

            Source = "meals.txt";
            return fileMeals;
        }

        // ---- Instructor's sample query: fill the list from package_tbl ----
        private List<string> ReadPackageNames()
        {
            List<string> names = new List<string>();

            using (MySqlConnection conn = database.CreateConnection())
            {
                conn.Open();
                string sql = "SELECT package_name FROM package_tbl";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        names.Add(reader.GetString("package_name").Trim());
                    }
                }
            }

            return names;
        }

        private List<Meal> ReadFile()
        {
            List<Meal> meals = new List<Meal>();

            foreach (string line in File.ReadAllLines(filePath))
            {
                if (line.Trim() == "" || line.StartsWith("#") || line.StartsWith("Code|")) continue;

                string[] f = line.Split('|');
                decimal price;

                // Skip a line with missing fields or a price that is not a number, instead of crashing the kiosk.
                if (f.Length < 5 || !decimal.TryParse(f[3].Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out price)) continue;

                meals.Add(new Meal
                {
                    Code = f[0].Trim(),
                    Category = f[1].Trim(),
                    Name = f[2].Trim(),
                    Price = price,
                    Inclusions = f[4].Trim()
                });
            }

            return meals;
        }
    }
}
