using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.IO.IsolatedStorage;

namespace WriteMe
{
    class Program
    {
        static void Main(string[] args)
        {
            //createFile();
            //EncryptStream();
            //ReadWriteBinary();
            //TextReadWrite();
            //ListDir();
            StoreIt();

        }

        public static void StoreIt()
        {
            IsolatedStorageFileStream isfs = new IsolatedStorageFileStream("ReadMe.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(isfs);
            Console.WriteLine(isfs);
            sw.WriteLine("Hello World");
            sw.Close();
            isfs.Close();
        }

        public static void ListDir()
        {
            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
            Console.WriteLine(di.FullName);
            FileSystemInfo[] fsis = di.GetFileSystemInfos();
            foreach (FileSystemInfo fsi in fsis)
            {
                Console.WriteLine(fsi.Name);
                Console.WriteLine("--------------------------------------");
            }
        }

        private static void TextReadWrite()
        {
            Stream s = new FileStream("ReadMe.txt", FileMode.Create);
            string str = "hello ";
            double d = 23.456;
            int i = 569;
            TextWriter bw = new StreamWriter(s);
            bw.Write(str);
            bw.Write(d);
            bw.Write(i);
            bw.Flush();
            s.Close();
            s = new FileStream("ReadMe.txt", FileMode.Open);
            TextReader br = new StreamReader(s);
            Console.WriteLine(br.ReadLine());
            s.Close();
        }

        private static void ReadWriteBinary()
        {
            Stream s = new FileStream("ReadMe.txt", FileMode.Create);
            string str = "hello";
            double d = 23.456;
            int i = 569;
            BinaryWriter bw = new BinaryWriter(s);
            bw.Write(str);
            bw.Write(d);
            bw.Write(i);
            bw.Flush();
            s.Close();
            s = new FileStream("ReadMe.txt", FileMode.Open);
            BinaryReader br = new BinaryReader(s);
            Console.WriteLine(br.ReadString());
            Console.WriteLine(br.ReadDouble());
            Console.WriteLine(br.ReadInt32());
            s.Close();
        }

        private static void EncryptStream()
        {
            Stream s = new FileStream("ReadMe.txt", FileMode.Open, FileAccess.Read);
            ICryptoTransform ict = new ToBase64Transform();
            CryptoStream cs = new CryptoStream(s, ict, CryptoStreamMode.Read);
            TextReader tr = new StreamReader(cs);
            String data = tr.ReadToEnd();
            Console.WriteLine(data);
        }

        private static void createFile()
        {
            Stream s = new FileStream("Readme.txt", FileMode.Create);
            s.WriteByte(72);
            s.WriteByte(101);
            s.WriteByte(108);
            s.WriteByte(108);
            s.WriteByte(111);
            s.WriteByte(32);
            s.WriteByte(87);
            s.WriteByte(111);
            s.WriteByte(114);
            s.WriteByte(108);
            s.WriteByte(100);
            s.Close();
        }
    }
}
