using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SmartPartsFrame.Model
{
    class FileSystemModel
    {
        public FileInfo[] GetFiles(DirectoryInfo di)
        {
            if (di.Exists)
                return di.GetFiles();
            else
                return new FileInfo[]{};
        }

        public DirectoryInfo[] GetDirectories(DirectoryInfo di)
        {
            if (di.Exists)
                return di.GetDirectories();
            else
                return new DirectoryInfo[] { };
        }


        public string[] GetFileNames(DirectoryInfo di)
        {
            FileSystemInfo[] ff = GetFiles(di);
            return GetFileSystemInfo(ff);
        }

        public string[] GetDirectoryNames(DirectoryInfo di)
        {
            FileSystemInfo[] ff = GetDirectories(di);
            return GetFileSystemInfo(ff);
        }

        private string[] GetFileSystemInfo(FileSystemInfo[] ff)
        {
            string[] result = new string[ff.Length];
            for (int i = 0; i < ff.Length; i++)
            {
                result[i] = ff[i].Name;
            }
            return result;
        }
    }
}
