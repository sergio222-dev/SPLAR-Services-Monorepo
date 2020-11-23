using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;

namespace SPLAR.Shared.Commons
{
    public static class UtilsExtensions
    {
    }

    public static class Utils
    {
        public static string GetRootDir(this IWebHostEnvironment env)
        {
            var sDirName = AppDomain.CurrentDomain.BaseDirectory;
            var oFileInfo = new FileInfo(sDirName);
            var oParentDir = oFileInfo.Directory.Parent.Parent.Parent;
            return oParentDir.FullName;
        }

        public static List<Assembly> GetAllAssemblies(this Assembly oAssembly)
        {
            var sAssemblyPath = Path.GetDirectoryName(oAssembly.Location);
            var oLstAssemblies = new List<Assembly>();
            
            foreach (var sAssemblyName in Directory.GetFiles(sAssemblyPath, "*.dll"))
                oLstAssemblies.Add(Assembly.LoadFile(sAssemblyName));

            return oLstAssemblies;
        }
    }
}