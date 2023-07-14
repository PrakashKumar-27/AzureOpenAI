using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string[] designations = { "Software Engineer", "Senior Software Engineer", "Tech Lead", "Manager" };
        string[] locations = { "Chennai", "Bangalore", "Hyderabad", "Delhi", "Pune" };
        int minSalary = 700000;
        int maxSalary = 3000000;

        Random random = new Random();

        using (StreamWriter writer = new StreamWriter("tax_slab_data.csv"))
        {
            writer.WriteLine("Salary,Location,Designation,TaxSlab");

            for (int i = 0; i < 1000; i++)
            {
                int salary = random.Next(minSalary, maxSalary + 1);
                string location = locations[random.Next(locations.Length)];
                string designation = designations[random.Next(designations.Length)];
                string taxSlab = GetTaxSlab(salary);

                writer.WriteLine($"{salary},{location},{designation},{taxSlab}");
            }
        }

        Console.WriteLine("Tax slab data file created successfully.");
    }

    static string GetTaxSlab(int salary)
    {
        if (salary <= 1000000)
            return "Slab A";
        else if (salary <= 2000000)
            return "Slab B";
        else
            return "Slab C";
    }
}
