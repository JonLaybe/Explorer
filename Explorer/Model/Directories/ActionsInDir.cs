using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Model.Directories
{
    public class ActionsInDir
    {
        public void DeleteObject(string path, string type)
        {
            if (path != null && type != null)
            {
                if (type == "File")
                    File.Delete(path);
                else if (type == "Folder")
                    Directory.Delete(path);
            }
        }
    }
}
