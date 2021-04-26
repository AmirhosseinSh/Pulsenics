using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class DirectoryFileInfo
    {
        private string filePath;
        private DateTime dataModified;
        public string FilePath { get { return filePath; } set { filePath = value; } }
        public DateTime DateModified { get { return dataModified; } set { dataModified = value; } }


        public DirectoryFileInfo(string path, DateTime lastModified)
        {
            this.FilePath = path;
            this.DateModified = lastModified;
        }
    }

    
}
