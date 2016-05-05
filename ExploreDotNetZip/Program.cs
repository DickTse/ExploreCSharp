/*
 * This project explores compressing/decompressing files using DotNetZip.
 * For more details about DotNetZip, please refer to dotnetzip.codeplex.com
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ionic.Zip;

namespace ExploreDotNetZip
{
    class Program
    {
        static void Main(string[] args)
        {
            // Compress files into a zip file.
            using (ZipFile zip = new ZipFile())
            {
                string[] files = Directory.GetFiles(args[0]);
                foreach (string file in files)
                    zip.AddFile(file, "");
                zip.Save(args[1]);
            }
            Console.WriteLine(String.Format("Files in {0} are compressed into {1} successfully.", args[0], args[1]));
            Console.Read();

            // Decompress files from a zip file.
            using (ZipFile zip = ZipFile.Read(args[1]))
            {
                zip.ExtractAll(args[2], ExtractExistingFileAction.OverwriteSilently);
            }
            Console.WriteLine(String.Format("Zip file {0} is decompressed into {1} successfully.", args[1], args[2]));
            Console.Read();

        }
    }
}
