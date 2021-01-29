using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace Reflect
{
    class Program
    {
        public static Dictionary<Type, object> _container { get; set; }
        static void Main(string[] args)
        {



            GetMethodWithCall();



        }

        static void GetMethodWithCall()
        {
            string strClass = "Test";           // 命名空间+类名
            string strMethod = "Method";        // 方法名

            //Type type;                          // 存储类
            //Object obj;                         // 存储类的实例

            var type = typeof(Test);      // 通过类名获取同名类
            var obj = System.Activator.CreateInstance(type);       // 创建实例

            MethodInfo method = type.GetMethod(strMethod, new Type[] { });      // 获取无参方法信息
            object[] parameters = null;
            method.Invoke(obj, parameters);                           // 调用方法，参数为空

            // 注意获取重载方法，需要指定参数类型
            method = type.GetMethod(strMethod, new Type[] { typeof(string) });      // 获取1个参数的方法信息
            parameters = new object[] { "hello" };
            method.Invoke(obj, parameters);                             // 调用方法，有参数

            method = type.GetMethod(strMethod, new Type[] { typeof(string), typeof(string) });      // 获取2个参数的方法信息
            parameters = new object[] { "hello", "你好" };
            string result = (string)method.Invoke(obj, parameters);     // 调用方法，有参数，有返回值
            Console.WriteLine("Method 返回值：" + result);                // 输出返回值

            // 获取静态方法类名
            string className = MethodBase.GetCurrentMethod().ReflectedType.FullName;
            Console.WriteLine("当前静态方法类名：" + className);

            Console.ReadKey();

        }

        static void GetAllType()
        {
            _container = new Dictionary<Type, object>();
            var assembly = Assembly.GetExecutingAssembly();
            var interfaces = assembly.GetTypes().Where(e => e.IsInterface);
            var types = assembly.GetTypes().Where(e => e.IsClass && !e.IsAbstract);

            foreach (var itemInterface in interfaces)
            {
                var type = types.FirstOrDefault(e => itemInterface.IsAssignableFrom(e));
                var obj = assembly.CreateInstance(type.FullName);
                _container.Add(itemInterface, obj);
            }

            foreach (var itemConstract in types)
            {
                var constracts = itemConstract.GetConstructors();
                var maxParameterConstract = constracts.FirstOrDefault();
                var count = 0;
                foreach (var constract in constracts)
                {
                    if (constract.GetParameters().Length > count)
                    {
                        maxParameterConstract = constract;
                        count = constract.GetParameters().Length;
                    }
                }

                var parameters = maxParameterConstract.GetParameters();
                var list = new List<object>();

                foreach (var property in parameters)
                {
                    if (_container.ContainsKey(property.ParameterType))
                    {
                        list.Add(_container[property.ParameterType]);
                    }
                }

                var obj = maxParameterConstract.Invoke(list.ToArray());
            }
        }
    }

    class Test
    {
        // 无参数，无返回值方法
        public void Method()
        {
            Console.WriteLine("Method（无参数） 调用成功！");
        }

        // 有参数，无返回值方法
        public void Method(string str)
        {
            Console.WriteLine("Method（有参数） 调用成功！参数 ：" + str);
        }

        // 有参数，有返回值方法
        public string Method(string str1, string str2)
        {
            Console.WriteLine("Method（有参数，有返回值） 调用成功！参数 ：" + str1 + ", " + str2);
            string className = this.GetType().FullName;         // 非静态方法获取类名
            return className;
        }
    }

}
