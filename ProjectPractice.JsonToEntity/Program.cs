using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjectPractice.JsonToEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonStr = "";
            StreamReader sr = new StreamReader("jsconfig1.json", Encoding.Default);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                jsonStr += line;
            }

            var json = JsonConvert.DeserializeObject<List<CompanyInfo<List<Employee>>>>(jsonStr);
        }
    }

    class CompanyInfo<T>
    {
        public string CompanyName { get; set; }
        public T Employees { get; set; }
    }

    class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
