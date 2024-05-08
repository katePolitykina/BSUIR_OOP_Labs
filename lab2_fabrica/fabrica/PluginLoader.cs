using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CosmeticsBase;

namespace fabrica
{
    public class PluginLoader
    {
        public static List<Factory> LoadPlugin( String fileName)
        { 
            if (!String.IsNullOrEmpty(fileName))
            {
                Assembly pluginAssembly;
                try
                {
                    pluginAssembly = Assembly.LoadFrom(fileName);
                }catch { 
                    return null;
                }
                List<Factory> list = new List<Factory>();
                try
                {
                    var types = pluginAssembly.GetTypes().Where(type => typeof(Factory).IsAssignableFrom(type));
                    foreach (var type in types)
                 {
                    if (Activator.CreateInstance(type) is Factory factory)
                    {
                        list.Add(factory);
                    }
                 }
                //    var types = pluginAssembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Factory)));
                }
                catch (ReflectionTypeLoadException ex)
                {
                    foreach (Exception innerEx in ex.LoaderExceptions)
                    {
                        Console.WriteLine(innerEx.Message);
                        // Дополнительная обработка исключения, если это необходимо
                    }
                    return null;
                }
                 
                return list;
            }else { return null; }

          
        }
    }
}
