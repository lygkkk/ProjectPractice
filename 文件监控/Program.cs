using System;
using System.IO;
using System.Linq;
using System.Security.Permissions;

namespace 文件监控
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            //Run();
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private static void Run()
        {
            string[] args = Environment.GetCommandLineArgs();
            string p = @"C:\Users\Administrator\Desktop\";
            // If a directory is not specified, exit program.
            //if (args.Length != 2)
            //{
            //    // Display the proper way to call the program.
            //    Console.WriteLine("Usage: Watcher.exe (directory)");
            //    return;
            //}

            // Create a new FileSystemWatcher and set its properties.
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = p;

                // Watch for changes in LastAccess and LastWrite times, and
                // the renaming of files or directories.
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                // Only watch text files.
                //watcher.Filter = "*.txt";

                // Add event handlers.
                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;

                // Begin watching.
                watcher.EnableRaisingEvents = true;

                // Wait for the user to quit the program.
                Console.WriteLine("Press 'q' to quit the sample.");
                while (Console.Read() != 'q') ;
            }
        }

        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            FileAttributes attributes;
            if (File.Exists(e.FullPath))
            {
                attributes = File.GetAttributes(e.FullPath);
                if ((attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    // Specify what is done when a file is changed, created, or deleted.
                    Console.WriteLine($"文件名: {e.FullPath} {e.ChangeType}");
                }
            }
        }


        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            FileAttributes attributes;
            if (File.Exists(e.FullPath))
            {
                attributes = File.GetAttributes(e.FullPath);
                if ((attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    // Specify what is done when a file is renamed.
                    Console.WriteLine($"文件名: {e.OldFullPath} 被替换成 {e.FullPath}");
                }
            }
        }
            
    }
}
