using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Blibli
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string path = Directory.GetCurrentDirectory();

            var vs = Directory.GetDirectories(path);
            var files = new string[] { };
            foreach (var item in vs)
            {
                var twodir = Directory.GetDirectories(item);
                var inintFIle = Directory.GetFiles(item).Where(x => Path.GetExtension(x) == ".ini").FirstOrDefault();
                if (inintFIle == null)
                    continue;
                var initStr = File.ReadAllLines(inintFIle, Encoding.GetEncoding("GB2312"));
                foreach (var str in initStr)
                {

                    if (str.Contains("=") && str.Split('=')[0] == "InfoTip")
                    {
                        var wremove = (str.Split('=')[1].Replace("/", "-")).Replace("\\", "-");
                        var s = Path.GetFileNameWithoutExtension(item);
                        var targetFile = item.Replace(s, wremove);

                        if (item != targetFile)
                            Directory.Move(item, targetFile);
                        var allDirectory = Directory.GetDirectories(targetFile);
                        foreach (var childdir in allDirectory)
                        {

                            var InfoFIle = Directory.GetFiles(childdir).Where(x => Path.GetExtension(x) == ".info").FirstOrDefault();
                            var renameFile = Directory.GetFiles(childdir).Where(x => Path.GetExtension(x) == ".mp4").FirstOrDefault();
                            if (string.IsNullOrEmpty(renameFile))
                                continue;
                            var vdeosMode = JsonConvert.DeserializeObject<VdeosMode>(File.ReadAllText(InfoFIle, Encoding.GetEncoding("utf-8")));
                            var oldName = Path.GetFileNameWithoutExtension(renameFile);
                            File.Move(renameFile, childdir + "_"+ vdeosMode.PartName+ ".mp4");
                            Directory.Delete(childdir,true);
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(",", vs));
            Console.ReadKey();
        }
        public static void ListFiles(FileSystemInfo info)
        {
            if (!info.Exists) return;

            DirectoryInfo dir = info as DirectoryInfo;
            //不是目录
            if (dir == null) return;

            FileSystemInfo[] files = dir.GetFileSystemInfos();
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = files[i] as FileInfo;
                //是文件
                if (file != null)
                    Console.WriteLine(file.FullName + "\t " + file.Length);
                //对于子目录，进行递归调用
                else
                    ListFiles(files[i]);
            }
        }
    }
}
