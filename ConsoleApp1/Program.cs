using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // get folders starting with the current to the root
            Console.WriteLine("All folders above the current folder.");
            AppDomain.CurrentDomain.BaseDirectory.ParentFolderList(false)
                .ForEach(Console.WriteLine);

            Console.WriteLine();
            // get folder one level up, parent of the current folder.
            Console.WriteLine("Immediate parent");
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory.ParentFolder(1));
            Console.ReadLine();
        }
    }
    /// <summary>
    /// This class should reside in it's own file.
    /// </summary>
    public static class Extensions
    {
        public static string ParentFolder(this string folderName, int level)
        {
            var folderList = new List<string>();

            while (!string.IsNullOrEmpty(folderName))
            {
                var directoryInfo = Directory.GetParent(folderName);
                if (directoryInfo == null)
                {
                    break;
                }
                folderName = Directory.GetParent(folderName).FullName;
                folderList.Add(folderName);
            }

            if (folderList.Count > 0 && level > 0)
            {
                if (level - 1 <= folderList.Count - 1)
                {
                    return folderList[level - 1];
                }
                else
                {
                    return folderName;
                }
            }
            else
            {
                return folderName;
            }
        }
        public static List<string> ParentFolderList(this string folderName, bool sort)
        {
            var folderList = new List<string>();

            while (!string.IsNullOrEmpty(folderName))
            {
                var directoryInfo = Directory.GetParent(folderName);
                if (directoryInfo == null)
                {
                    break;
                }

                folderName = Directory.GetParent(folderName).FullName;
                folderList.Add(folderName);
            }

            if (sort)
            {
                folderList.Sort();
            }

            return folderList;
        }
    }

}
