using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ConsoleApp1
{
    class Program
    {
        

        public static void StoreOptionsInIsolatedStorage()
        {
            const string OPTIONSFOLDER = "C:/Users/DemonsRun/Desktop/Projekt/varja/obobo";
            const string OPTIONSFILE = "C:/Users/DemonsRun/Desktop/Projekt/varja/obobo/vvvk.txt";
            //IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain, null, null);
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForDomain();

            if (!Directory.Exists(OPTIONSFOLDER))
            {
                Console.WriteLine("Creating Folder!");
                isoStore.CreateDirectory(OPTIONSFOLDER);
            }

            if (isoStore.FileExists(OPTIONSFILE))
            {
                Console.WriteLine("The file already exists!");
                using (IsolatedStorageFileStream isoStream =
                    new IsolatedStorageFileStream(OPTIONSFILE, FileMode.Open, isoStore))
                {
                    using (StreamReader reader = new StreamReader(isoStream))
                    {
                        Console.WriteLine("Reading contents:");
                        Console.WriteLine(reader.ReadToEnd());
                        reader.Close();
                    }
                    isoStream.Dispose();
                }
                
            }
            else
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(OPTIONSFILE, FileMode.CreateNew, isoStore))
                {
                    using (StreamWriter writer = new StreamWriter(isoStream))
                    {
                        writer.WriteLine("Hello Isolated Storage");
                        Console.WriteLine("You have written to the file.");
                        writer.Close();
                    }
                    isoStream.Dispose();
                }
            }
        }



        
        private static void CheckDirectories(string source, string destination)
        {
            if (!Directory.Exists(source))
            {
                throw new DirectoryNotFoundException();
            }
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }
        }

        public static bool verify(string source, string destination)
        {
            bool v = true;
            try
            {
                CheckDirectories(source, destination);
            }
            catch (DirectoryNotFoundException dirEx)
            {
                Console.WriteLine("Directory not found: " + dirEx.Message);
                v =false;
            }

            return v;
        }
        public static void BackUpFiles(string source, string destination)
        {
            if (verify(source, destination))
            {

                DirectoryInfo sourceInfo = new DirectoryInfo(source);
                DirectoryInfo destInfo = new DirectoryInfo(destination);

                ArchiveFiles(sourceInfo, destInfo);
            }
            else return;
        }

        private static void ArchiveFiles(DirectoryInfo sourceInfo, DirectoryInfo destInfo)
        {
            FileInfo[] fileList = sourceInfo.GetFiles();
            foreach (FileInfo fL in fileList)
            {
                fL.CopyTo(Path.Combine(destInfo.FullName, fL.Name), true);
            }
            DirectoryInfo[] childFolderList = sourceInfo.GetDirectories();
            foreach (DirectoryInfo chfL in childFolderList)
            {
                DirectoryInfo nextDest = destInfo.CreateSubdirectory(chfL.Name);
                ArchiveFiles(chfL, nextDest);
            }
        }
        static void Main(string[] args)
        {
            

            BackUpFiles(@"C:\Users\DemonsRun\Desktop\Projekt_PHP_HTML_CSS_JAVASCRIPT",
                    @"C:\Users\DemonsRun\Desktop\Projekt\varja");

            StoreOptionsInIsolatedStorage();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
