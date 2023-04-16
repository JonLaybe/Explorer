using Explorer.Model.Directories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Explorer.Model
{
    public class GetInfo
    {
        public List<Disk> GetDisk() // получение дисков
        {
            List<Disk> list = new List<Disk>();

            foreach (var item in DriveInfo.GetDrives())
            {

                try
                {
                    list.Add(new Disk()
                    {
                        Name = item.Name,
                        Type = item.DriveType.ToString(),
                        Size = item.TotalSize,
                        FreeSapce = item.TotalFreeSpace,
                    });
                }
                catch { }
            }

            return list;
        }
        public Dir GetDir(string path) // получение директории
        {
            Dir dir = new Dir();
            dir.NameDir = path;

            if (Directory.Exists(path))
            {
                string[] dirs = Directory.GetDirectories(path);
                foreach (string item in dirs)
                    dir.ListObjectDirectories.Add(new ObjectDirectorie()
                    {
                        Name = item.Substring(item.LastIndexOf('\\') + 1),
                        Type = "Folder",
                        Image = "/Assets/Folder.png",
                    });
                string[] files = Directory.GetFiles(path);
                foreach (string item in files)
                    dir.ListObjectDirectories.Add(new ObjectDirectorie()
                    {
                        Name = item.Substring(item.LastIndexOf('\\') + 1),
                        Type = "File",
                        Image = "/Assets/File.jpg",
                    });
            }

            NotifyDirectorie.ChangedDirectorie(path);

            return dir;
        }
    }
}
