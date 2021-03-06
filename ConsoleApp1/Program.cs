﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Abstract.Models;
using System.Windows.Forms;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        public static List<int> Data
        {
            get
            {
                return new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            }
        }
        static void Main(string[] args)
        {
            Form1 form1 = new Form1();
            Type type = form1.GetType();
            string xx = type.GUID.ToString();
            form1.Show();
            //string ls = "12345上山打老虎";
            //UserInfo user = new UserInfo();
            //List<UserInfo> list = new List<UserInfo> { 
            //    new UserInfo{ Age = 18, Name = "zj" },
            //    new UserInfo{ Age = 50, Name = "ct" },
            //};
            //var x = list.Select(e => {
            //    if (e.Age == 50)
            //    {
            //        return e;
            //    }
            //    return null;
            //});
            //var f = Directory.GetFiles(@"f:\", "*", SearchOption.TopDirectoryOnly);

            //TestArgs(args);


            //MessageBox.Show("参数对了");
            //UserInfo userInfos = new UserInfo();

            //var ui = userInfos.GetType().GetProperties();

            //foreach (var item in ui)
            //{
            //    //判断是否是泛型
            //    if (item.PropertyType.IsGenericType)
            //    {
            //        //获取泛型的真实类型
            //        var type = item.PropertyType.GetGenericArguments()[0];
            //        //创建实例
            //        var o = Activator.CreateInstance(type);

            //        //var t = o.GetType().GetProperties();
            //        foreach (var item1 in type.GetProperties())
            //        {
            //            Console.WriteLine(item1.Name);
            //        }
            //    }

            //}

            //JudePropertyType<UserInfo>();
        }
        /// <summary>
        /// 没啥子
        /// </summary>
        /// <param name="args">参数呀</param>
        public static void TestArgs(string[] args)
        {
            if (args.Length == 0)
                throw new ArgumentException("参数太少了");
        }

        public static IEnumerable<int> FilterWithoutYield
        {
            get
            {
                foreach (var i in Data)
                {
                    if (i > 4)
                        yield return i;
                }
            }
        }

        public static IEnumerable<int> GetList(int[] nums)
        {
            foreach (var num in nums)
            {
                yield return num;
            }
        }

        private static void JudePropertyType<T>()
        {
            T obj = Activator.CreateInstance<T>();
            PropertyInfo[] pinfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo pf in pinfo)
            {
                if (pf.PropertyType.IsClass && pf.PropertyType.IsGenericType)
                {
                    Type type = pf.PropertyType;
                    Type[] genericArgTypes = type.GetGenericArguments();
                    Type objType = Type.GetType(genericArgTypes[0].FullName, true);
                    var objs = Activator.CreateInstance(objType);
                    PropertyInfo[] properties = objType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    foreach (PropertyInfo pi in properties)
                    {
                        Console.WriteLine(pi.Name);
                    }
                }
            }
        }
    }

        class UserInfo
    {
        public string Name { get; set; }
        public int Age { get; set; }
        //public IList<ProductInfo> productInfos { get; set; }
    }

    class ProductInfo
    {
        public string Name { get; set; }
        public string Fenlei { get; set; }
    }

    public abstract class SqlHelp
    {
        public string Provider { get; set; }
        public abstract void Select();
        public abstract void Add();
        public abstract void Modify();
    }

    public class SqlserverHelp : SqlHelp
    {
        public override void Add()
        {
            Console.WriteLine("我是sqlserver,我要新增数据");
        }

        public override void Modify()
        {
            Console.WriteLine("我是sqlserver,我要修改数据");
        }

        public override void Select()
        {
            Console.WriteLine("我是sqlserver,我要查询数据");
        }
    }

    public class MysqlHelp : SqlHelp, IDelAble
    {
        public override void Add()
        {
            Console.WriteLine("我是mysql,我要新增数据");
        }

        public void DelData()
        {
            Console.WriteLine("我是mysql,我要删除数据");
        }

        public override void Modify()
        {
            Console.WriteLine("我是mysql,我要修改数据");
        }

        public override void Select()
        {
            Console.WriteLine("我是mysql,我要查询数据");
        }
    }

    interface IDelAble
    {
        void DelData();
    }


}
