using Explorer.Model.Directories;
using Explorer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Model
{
    public class Dir // подкаталоги
    {
        public string NameDir { get; set; }
        public List<ObjectDirectorie> ListObjectDirectories { get; set; }

        public Dir()
        {
            ListObjectDirectories = new List<ObjectDirectorie>();
        }
    }
}
