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
}
