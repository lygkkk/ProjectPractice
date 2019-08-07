using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjectPractice.DelegateEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Test1();
            test.Lygkkk = 12;
            test.Name = "zj";
            var tmp = test;
            tmp.Lygkkk = 25;
            tmp.Name = "lyg";

            test.Close += Test_Close;
            test.Close += Test_Close1;
            test.Test3();
            Console.ReadKey();
        }

        private static void Test_Close(string result)
        {
            Console.WriteLine(result);
        }
        private static void Test_Close1(string result)
        {
            Console.WriteLine(result);
        }
    }

    public class Test1
    {
        public delegate List<User> ConstomDelegate<T>(List<T> user);
        private delegate void Opendelegate();
        public delegate void Closedelegate(string result);
        public event Closedelegate Close;

        public int Lygkkk { get; set; }
        public string Name { get; set; }
        public void Test2()
        {
            var userList = new List<UserInfo> {
                new UserInfo{ Id=Guid.NewGuid(), Name="张三"},
                new UserInfo{ Id=Guid.NewGuid(), Name="张三1"},
                new UserInfo{ Id=Guid.NewGuid(), Name="张三2"},
            };

            TotalUserInfo(userList, e =>
            {
                var users = new List<User>();
                foreach (var item in e)
                {
                    users.Add(new User { Name = item.Name });
                }
                return users;
            });
        }
        public void Test3()
        {
            var userList = new List<Product> {
                new Product{ Id=Guid.NewGuid(),  ProductName="pingguo", UnitPrice=15},
                new Product{ Id=Guid.NewGuid(), ProductName="pingguo",UnitPrice=18},
                new Product{ Id=Guid.NewGuid(), ProductName="pingguo",UnitPrice=20},
            };

            TotalUserInfo(userList, e =>
            {
                var users = new List<User>();
                foreach (var item in e)
                {
                    users.Add(new User { Name = item.ProductName });
                }
                return users;
            });
        }
        private void TotalUserInfo<T>(List<T> entityList, ConstomDelegate<T> constom)
        {
            var ss = JsonConvert.SerializeObject(entityList);

            var userList = constom(entityList);
            var str = JsonConvert.SerializeObject(userList);

            var write = new StreamWriter("test1.json");
            write.WriteLine(str);
            write.WriteLine(ss);
            write.Close();
            Close?.Invoke(ss);
        }
    }
    public class Product
    {
        public Guid Id { get; set; }
        public int UnitPrice { get; set; }
        public string ProductName { get; set; }
    }
    public class UserInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
    public class User
    {
        public string Name { get; set; }
    }
}
