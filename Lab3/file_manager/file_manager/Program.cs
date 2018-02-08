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


        //show everything inside the chosen directory, folder and files are sorted separately 
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

        static void redactFile (FileInfo file)
        {
            Console.Clear();
            StreamReader sr = new StreamReader(file.FullName);
            string inside = sr.ReadToEnd();
            sr.Close();
            int x, y;
            string[] lines = inside.Split('\n');
            y = lines.Length - 1;
            x = lines[y].Length - 2;
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();

                for (int i =0; i<lines.Length; i++ )
                {
                    for (int j= 0; j <lines[i].Length; j++)
                    {
                        if (i==y && j==x)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        Console.Write(lines[i][j]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write('\n');
                }


                ConsoleKeyInfo button = Console.ReadKey();
                if (button.Key == ConsoleKey.UpArrow && y >= 1)
                {
                    y--;

                    if (x >= lines[y].Length-1)
                        x = lines[y].Length - 2;
                    /*if (pos < lbound)
                    {
                        upbound--;
                        lbound--;
                    }*/
                }
                if (button.Key == ConsoleKey.DownArrow && y< lines.Length-1)
                {
                    y++;
                    if (x >= lines[y].Length-1)
                        x = lines[y].Length - 2;
                    /*if (pos < lbound)
                    {
                        upbound--;
                        lbound--;
                    }*/
                }
                if (button.Key == ConsoleKey.LeftArrow )
                {
                    x--;
                    if (x < 0)
                    {
                        if (y > 0)
                        {
                            y--;
                            x = lines[y].Length-2;
                        }
                        else
                            x++;
                    } 
                    /*if (pos < lbound)
                    {
                        upbound--;
                        lbound--;
                    }*/
                }
                if (button.Key == ConsoleKey.RightArrow )
                {
                    x++;
                    if (x >= lines[y].Length-1)
                    {
                        if (y < lines.Length - 1)
                        {
                            y++;
                            x = 0;
                        }
                        else
                            x--;

                    }
                    /*if (pos < lbound)
                    {
                        upbound--;
                        lbound--;
                    }*/
                }

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
                // script for moving the cursor through the files
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

                //script for openig the file or directory
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
                        /*StreamReader sr = new StreamReader(listfiles[pos-listdirs.Length].FullName);
                        string s = sr.ReadToEnd();
                        Console.Clear();
                        Console.WriteLine(s);
                        Console.ReadKey();*/
                        redactFile(listfiles[pos - listdirs.Length]);
                     

                    }

                }

                //going back to parent directory
                if (button.Key == ConsoleKey.Backspace)
                {
                    maindir = maindir.Parent;
                    pos = 0;
                    upbound = consres;
                    lbound = 0;
                } 

                //copying the file to buffer
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
                // "cutting" the file or folder
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

                //pasting the copy of a file
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

                //moving the file
                if (button.Key == ConsoleKey.V && ifFileMove && File.Exists(bufferfile.FullName))
                {
                    target = maindir.FullName;
                    string filename = bufferfile.Name;
                    string sourcefile = Path.Combine(source, filename);
                    string targetfile = Path.Combine(target, filename);
                    System.IO.File.Move(sourcefile, targetfile);


                }

                //moving the directory
                if (button.Key == ConsoleKey.V && ifDirMove && Directory.Exists(bufferdir.FullName))
                {
                    target = maindir.FullName;
                    string dirname = bufferdir.Name;
                    string sourcedir = Path.Combine(source, dirname);
                    string targetdir = Path.Combine(target, dirname);
                    Directory.Move(sourcedir, targetdir);


                }

                // deleting the directory
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

                //script for creating new file
                if (button.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    while (true)
                    {
                        Console.WriteLine("Creating new file...");
                        Console.WriteLine("Name your file: ");
                        string fname = Console.ReadLine();
                        string fpath = Path.Combine(maindir.FullName, fname);
                        if (!File.Exists(fpath))
                        {
                            using (FileStream fs = File.Create(fpath))
                            {
                                for (byte i = 0; i < 2; i++)
                                {
                                    fs.WriteByte(i);
                                }
                            }

                            break;
                        }
                        else
                        {
                            Console.WriteLine("File with such name already exists.");
                        }
                    }
                }
                    if (button.Key == ConsoleKey.F)
                    {
                        Console.Clear();
                        Console.WriteLine("Creating new folder...");
                        Console.WriteLine("Name your folder: ");
                        string dname = Console.ReadLine();
                        string dpath = Path.Combine(maindir.FullName, dname);
                        if (!Directory.Exists(dpath))
                        {
                            Directory.CreateDirectory(dpath);
                        }
                    }

                




            }


        }
    }
}
