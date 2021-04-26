using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class UserFile
    {
        private string fileName;
        private string filePath;
        private DateTime date_created;
        private DateTime date_modified;

        public string FileName { get { return fileName; } set { fileName = value; } }
        public string FilePath { get { return filePath; } set { filePath = value; } }
        public DateTime DateCreated { get { return date_created; } set { date_created = value; } }
        public DateTime DateModified { get { return date_modified; } set { date_modified = value; } }

        public UserFile ()
        {
            FileName = "";
            FilePath = "";
            DateCreated = new DateTime();
            DateModified = new DateTime();
        }

        public UserFile(string name, string path, DateTime dateCreated, DateTime dateModified)
        {
            FileName = name;
            FilePath = path;
            DateCreated = dateCreated;
            DateModified = dateModified;
        }
    }
}
