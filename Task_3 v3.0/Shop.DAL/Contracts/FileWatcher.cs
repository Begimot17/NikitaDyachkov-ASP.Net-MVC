using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Contracts
{
    class FileWatcher
    {
        public  void Run(string file)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = file;
            watcher.Created += OnChanged;
            watcher.Deleted += OnDelete;
            watcher.Renamed += OnRenamed;
            watcher.EnableRaisingEvents = true;
        }
        private static void OnDelete(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("Delete File : " + e.Name + "\r\nFile Action : " + e.ChangeType + "\r\nDelete File from path : " + e.FullPath + "\r\n");
        }
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("New File is : " + e.Name + " \r\nAnd type : " + e.ChangeType + " \r\nPath of file : " + e.FullPath + "\r\n");
        }
    }
}

