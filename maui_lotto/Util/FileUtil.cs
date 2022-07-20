using maui_lotto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maui_lotto.Util
{
    public static class FileUtil
    {
        static string cacheDir = FileSystem.Current.CacheDirectory;
        public static string Load(string fileName)
        {            
            string path = $"{cacheDir}\\{fileName}";
            if (File.Exists(path) == false)
                return null;

            return File.ReadAllText(path);
        }

        public static void Write(string fileName, string text)
        {
            string path = $"{cacheDir}\\{fileName}";
            File.WriteAllText(path, text);
        }









    }
}
