using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace file_manager
{
    class Program
    {
        static FileInfo bufferfile;

        static bool ifFileCopy = false;
        const int consres = 23;
        static int upbound = consres;
        static string source = " ";
        static DirectoryInfo bufferdir;
        static string target;
        static int lbound = 0;
        static void showlist(DirectoryInfo currentdir, int cursor)
        {
            Console.BackgroundColor = ConsoleColor.Black;

            DirectoryInfo[] listdirs = currentdir.GetDirectories();
            FileInfo[] listfiles = currentdir.GetFiles();
            int index = 0;
            int amount = listdirs.Length + listfiles.Length;
            Console.ForegroundColor = ConsoleColor.White;
            while (index < listdirs.Length )
            {
                if (index == cursor)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                if (index >= lbound && index <= upbound)
                    Console.WriteLine(listdirs[index].Name);

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                index++;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            while (index < amount)
            {
                if (index == cursor)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                if (index >= lbound && index <= upbound)
                    Console.WriteLine(listfiles[index - listdirs.Length].Name);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Black;
                index++;
            }


        }

        static void Main(string[] args)
        {

            int pos = 0;
            DirectoryInfo maindir = new DirectoryInfo(@"C:\Users\User\Documents\Visual Studio 2015\Samples");
            while (true)
            {
                Console.Clear();
                DirectoryInfo[] listdirs = maindir.GetDirectories();
                FileInfo[] listfiles = maindir.GetFiles();
                
                showlist(maindir, pos);
                ConsoleKeyInfo button = Console.ReadKey();
                if (button.Key == ConsoleKey.DownArrow && pos < listdirs.Length + listfiles.Length - 1)
                {
                    pos++;
                    if (pos > upbound)
                    {
                        upbound++;
                        lbound++;
                    }
                    
                }
                if (button.Key == ConsoleKey.UpArrow && pos >= 1)
                {
                    pos--;
                    if (pos < lbound)
                    {
                        upbound--;
                        lbound--;
                    }
                }
                    if (button.Key == ConsoleKey.Escape)
                    break;
                if (button.Key == ConsoleKey.Enter && listdirs.Length + listfiles.Length >0)
                {
                    if (pos < listdirs.Length)
                    {
                        maindir = listdirs[pos];
                        pos = 0;
                        upbound = consres;
                        lbound = 0;
                    }
                    else 
                    {
                        StreamReader sr = new StreamReader(listfiles[pos-listdirs.Length].FullName);
                        string s = sr.ReadToEnd();
                        Console.Clear();
                        Console.WriteLine(s);
                        Console.ReadKey(); 

                    }

                }
                if (button.Key == ConsoleKey.Backspace)
                {
                    maindir = maindir.Parent;
                    pos = 0;
                    upbound = consres;
                    lbound = 0;
                } 
                if  (button.Key == ConsoleKey.C && listdirs.Length + listfiles.Length > 0)
                {
                    if (pos + 1 > listdirs.Length)
                    {
                        source = maindir.FullName;
                        bufferfile = listfiles[pos - listdirs.Length];
                        ifFileCopy = true;

                    }
                    else
                    {
                        ifFileCopy = false;
                    }
                }
                if (button.Key == ConsoleKey.V && ifFileCopy)
                {
                    target = maindir.FullName;
                    string filename = bufferfile.Name;
                    string sourcefile = System.IO.Path.Combine(source, filename);
                    string targetfile = System.IO.Path.Combine(target, filename);
                    System.IO.File.Copy(sourcefile, targetfile, true);


                }





            }


        }
    }
}
