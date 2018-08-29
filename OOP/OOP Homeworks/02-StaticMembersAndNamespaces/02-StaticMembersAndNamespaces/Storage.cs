namespace _02_StaticMembersAndNamespaces
{
    using System;
    using System.IO;

    public class Storage
    {
        public static void LoadPaths()
        {
            using (var fs = File.Open("file.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                //var sw = new StreamWriter(fs);
                var sr = new StreamReader(fs);

                Console.WriteLine(sr.ReadToEnd());
            }
        }

        public static void SavePath(Path3D p)
        {
            using (var fs = File.Open("file.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                var sw = new StreamWriter(fs);

                foreach (var point in p.Path)
                {
                    sw.Write(point);
                }

                sw.Flush();
                sw.Close();
            }
        }
    }
}