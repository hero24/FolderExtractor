using System;
using System.IO;
// If you want a thing done well, do it yourself. ~ Napoleon Bonaparte
namespace FolderExtractor
{
    class Extractor
    {
        /*
         * Extract files from folder by moving them to specified subfolder 
         */
        static void Main(string[] args)
        {
            if(args.Length < 2)
            {
                Console.WriteLine("Not ennough arguments");
                Console.WriteLine("USAGE: FolderExtractor.exe phrase_to_search folder_to_move_to");
                return;
            }
            DirectoryInfo directory = new DirectoryInfo(".");
            DirectoryInfo moveTo = new DirectoryInfo(args[1]);
            if(!moveTo.Exists)
            {
                try
                {
                    moveTo.Create();
                }
                catch(Exception e)
                {
                    Console.WriteLine("There was a problem while creating new directory, program will now exit");
                    return;
                }
            }
            FileInfo[] files = directory.GetFiles("*" + args[0] + "*");
            foreach(FileInfo file in files)
            {
                try
                {
                    Console.WriteLine(file.ToString());
                    file.MoveTo(".\\" + args[1] + "\\" + file.ToString());
                }
                catch(Exception e)
                {
                    Console.WriteLine("There was a problem with movement of {0} file", file.ToString());
                }
            }
        }
    }
}
