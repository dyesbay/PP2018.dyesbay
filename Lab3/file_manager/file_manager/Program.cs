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

        const int consres = 23;
        static int lbound = 0;
        static int upbound = consres;
        static DirectoryInfo bufferdir;
        static bool ifFileCopy = false;
        static bool ifDirCopy = false;
        static bool ifFileMove = false;
        static bool ifDirMove = false;
        static string source = " ";
        static string target;
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
                        ifDirCopy = false;
                        ifFileMove = false;
                        ifDirMove = false;

                    }
                    else
                    {
                        ifDirCopy = true;
                        ifFileCopy = false;
                        bufferdir = listdirs[pos];
                        source = maindir.FullName;

                    }
                }
                if (button.Key == ConsoleKey.X && listdirs.Length + listfiles.Length > 0)
                {
                    if (pos + 1 > listdirs.Length)
                    {
                        source = maindir.FullName;
                        bufferfile = listfiles[pos - listdirs.Length];
                        ifFileCopy = false;
                        ifDirCopy = false;
                        ifFileMove = true;
                        ifDirMove = false;

                    }
                    else
                    {
                        ifDirCopy = false;
                        ifFileCopy = false;
                        ifFileMove = false;
                        ifDirMove = true;

                        bufferdir = listdirs[pos];
                        source = maindir.FullName;

                    }
                }
                if (button.Key == ConsoleKey.V && ifFileCopy && File.Exists(bufferfile.FullName))
                {
                    target = maindir.FullName;
                    string filename = bufferfile.Name;
                    string sourcefile = Path.Combine(source, filename);
                    string targetfile = Path.Combine(target, filename);
                    File.Copy(sourcefile, targetfile, true);


                }
                /*if (button.Key == ConsoleKey.V && ifDirCopy && Directory.Exists(bufferdir.FullName))
                {
                    target = maindir.FullName;
                    string dirname = bufferdir.Name;
                    string sourcedir = System.IO.Path.Combine(source, dirname);
                    string targetdir = System.IO.Path.Combine(target, dirname);
                    System.IO.Directory.Copy(sourcedir, targetdir, true);


                }*/
                if (button.Key == ConsoleKey.V && ifFileMove && File.Exists(bufferfile.FullName))
                {
                    target = maindir.FullName;
                    string filename = bufferfile.Name;
                    string sourcefile = Path.Combine(source, filename);
                    string targetfile = Path.Combine(target, filename);
                    System.IO.File.Move(sourcefile, targetfile);


                }
                if (button.Key == ConsoleKey.V && ifDirMove && Directory.Exists(bufferdir.FullName))
                {
                    target = maindir.FullName;
                    string dirname = bufferdir.Name;
                    string sourcedir = Path.Combine(source, dirname);
                    string targetdir = Path.Combine(target, dirname);
                    Directory.Move(sourcedir, targetdir);


                }
                if (button.Key == ConsoleKey.Delete)
                {
                    if (pos + 1 > listdirs.Length)
                    {
                        File.Delete( listfiles[pos - listdirs.Length].FullName);
                        
                    }
                    else
                    {
                        Directory.Delete(listdirs[pos].FullName);

                    }
                }






            }


        }
    }
}
