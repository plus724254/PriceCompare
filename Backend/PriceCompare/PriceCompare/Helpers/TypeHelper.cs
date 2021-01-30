using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PriceCompare.Helpers
{
    public static class TypeHelper
    {
        public static List<Type> GetImplementTypesFromInterface(Type @interface)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => @interface.IsAssignableFrom(p))
                .ToList();
        }

        public static List<(string AssemblyName, string Name)> GetImplementNamesFromInterface(Type @interface)
        {
            return GetImplementTypesFromInterface(@interface)
                .Select(x => (x.Assembly.GetName().Name, x.Name))
                .ToList();
        }

        public static T CreateInstanceByType<T>(Type type)
        {
            return (T)Activator.CreateInstance(type);
        }
    }
}
