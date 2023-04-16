using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Model
{
    public class Disk
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public long Size { get; set; }
        public long FreeSapce { get; set; }

        public Disk()
        {
            Name = "Disk";
            Type = "TypeDisk";
            Size = 0;
            FreeSapce = 0;
        }
    }
}
