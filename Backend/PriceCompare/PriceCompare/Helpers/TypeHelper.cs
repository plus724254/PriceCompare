using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PriceCompare.Helpers
{
    public static class TypeHelper
    {
        public static List<Type> GetImplementTypesFromBaseType(Type type)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p))
                .ToList();
        }

        public static List<(string AssemblyName, string Name)> GetImplementNamesFromBaseType(Type type)
        {
            return GetImplementTypesFromBaseType(type)
                .Select(x => (x.Assembly.GetName().Name, x.Name))
                .ToList();
        }

        public static T CreateInstanceByType<T>(Type type)
        {
            return (T)Activator.CreateInstance(type);
        }
    }
}
