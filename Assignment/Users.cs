namespace Assignment
{
    public class Users: UserFile
    {
        private string name;
        private string family;
        private string number;
        private string email;
        
        //private string filePath;

        public Users(string name, string family, string number, string email, UserFile fileInfo)
        {            
            this.Name = name;
            this.Family = family;
            this.Number = number;
            this.Email = email;
            this.FileName = fileInfo.FileName;
            this.FilePath = fileInfo.FilePath;
            this.DateCreated = fileInfo.DateCreated;
            this.DateModified = fileInfo.DateModified;
        }

        public string Name { get { return name; } set { name = value; } }
        public string Family { get { return family; } set { family = value; } }
        public string Number { get { return number; } set { number = value; } }
        public string Email { get { return email; } set { email = value; } }        
        

        //public string FilePath { get { return filePath; } set { filePath = value; } }
    }
}