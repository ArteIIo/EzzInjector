using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EzzInjector.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<Type> GetLoadableClassesTypes(this Assembly assembly)
        {
            try
            {
                return assembly.GetTypes().Where(t => t != null
                    && t.IsClass
                    && !t.IsAbstract);
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null
                    && t.IsClass
                    && !t.IsAbstract);
            }
        }
    }
}
