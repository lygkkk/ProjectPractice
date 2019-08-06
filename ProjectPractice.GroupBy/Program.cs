using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.GroupBy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of pets.
            IEnumerable<Pet> petsList = new List<Pet>
            {
                new Pet { Name="Barley", City = "HZ", Age=8.3 },
                new Pet { Name="Boots", City = "SH",Age=4.9 },
                new Pet { Name="Whiskers", City = "BJ", Age=1.5 },
                new Pet { Name="Daisy", City = "FY", Age=4.3 },
                new Pet { Name="lyg", City = "HZ", Age=8.3 },

            };

            // Group Pet.Age values by the Math.Floor of the age.
            // Then project an anonymous type from each group
            // that consists of the key, the count of the group's
            // elements, and the minimum and maximum age in the group.
            //    var query = petsList.GroupBy(
            //        p =>
            //        {
            //            if (p.City.Equals("HZ") || p.City.Equals("FY")) return "浙江";
            //            if (p.City.Equals("SH")) return "上海";
            //            return "北京";
            //        //}, pet => pet, (s, pets) => new {s, , pets} );

            //    // Iterate over each anonymous type.
            //    foreach (var result in query)
            //    {
            //        //Console.WriteLine($"{result.s}---{result.City}---{result.pets}");
            //    }
        }
    }

    class Pet
    {
        public string Name { get; set; }
        public string City { get; set; }
        public double Age { get; set; }
    }
}
