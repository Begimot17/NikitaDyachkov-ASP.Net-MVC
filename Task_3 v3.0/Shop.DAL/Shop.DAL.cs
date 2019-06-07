using Shop.DAL.Contracts;
using Shop.DAL.Models;
using Shop.DAL.Models.Product_children;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Shop.DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FileWatcher fileWatcher = new FileWatcher();
            fileWatcher.Run(@DirectoryManager.DirManager("C:\\"));
            Console.ReadLine();
        }
    }
}
