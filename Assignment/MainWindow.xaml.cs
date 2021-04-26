using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserFile fileInfo = new UserFile();
        public BindingList<Users> UsersList = new BindingList<Users>();
        public BindingList<DirectoryFileInfo> DirectoryFiles = new BindingList<DirectoryFileInfo>();
        public static string ProjectFilePath = @"C:\Pulsenics";
        public DirectoryInfo _directoryInfo = new DirectoryInfo(ProjectFilePath);
        public MainWindow()
        {
            InitializeComponent();
            //UsersList.Add(new Users("Amir", "Shahshahani","51481294", "amir.sh.elec@gmail.com", new UserFile()));
            //UsersList.Add(new Users("Amir", "Shah", "+15148129452", "amir_sh_elec@gmail.com", new UserFile()));
            //UsersList.Add(new Users("Am", "Shah", "5148129452", "amir.sh.elec@yahoo.com", new UserFile()));
            //users_list_view.ItemsSource = UsersList;

            
            FileInfo[] filesLists = _directoryInfo.GetFiles(SearchBox.Text + "*", SearchOption.AllDirectories);
            foreach (var _file in filesLists.ToList())
            {
                DirectoryFileInfo _info = new DirectoryFileInfo(_file.Name, File.GetLastWriteTime(_file.FullName));
                DirectoryFiles.Add(_info);
            }
            DirectoryFiles_list_view.ItemsSource = null;
            DirectoryFiles_list_view.ItemsSource = DirectoryFiles;
            
        }

        private void NewUser_Attach_Click(object sender, RoutedEventArgs e)
        {            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = ProjectFilePath;
            var aa = openFileDialog.ShowDialog();
            fileInfo.FileName = openFileDialog.SafeFileName;
            fileInfo.FilePath = openFileDialog.FileName;
            fileInfo.DateCreated = File.GetCreationTime(fileInfo.FilePath);
            fileInfo.DateModified = File.GetLastWriteTime(fileInfo.FilePath);
            //fileInfo.DateCreated = openFileDialog
        }

        private void NewUser_Add_Click(object sender, RoutedEventArgs e)
        {
            UsersList.Add(new Users(NewUser_Name.Text, NewUser_Family.Text, NewUser_Number.Text, NewUser_Email.Text, new UserFile(fileInfo.FileName,fileInfo.FilePath,fileInfo.DateCreated,fileInfo.DateModified)));
            users_list_view.ItemsSource = null;
            users_list_view.ItemsSource = UsersList;
            NewUser_Number.Text = "+1";
            NewUser_Name.Text = "";
            NewUser_Family.Text = "";
            NewUser_Email.Text = "";
            DirectoryFiles_list_view.ItemsSource = null;
            DirectoryFiles_list_view.ItemsSource = DirectoryFiles;
        }

        private void RefreshList_Click(object sender, RoutedEventArgs e)
        {
            foreach(Users __users in UsersList)
            {
                __users.DateModified = File.GetLastWriteTime(__users.FilePath);
            }
            users_list_view.ItemsSource = null;
            users_list_view.ItemsSource = UsersList;
        }


        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FileInfo[] filesLists = _directoryInfo.GetFiles(SearchBox.Text + "*", SearchOption.AllDirectories);
            DirectoryFiles.Clear();
            foreach (var _file in filesLists.ToList())
            {
                DirectoryFileInfo _info = new DirectoryFileInfo(_file.Name, File.GetLastWriteTime(_file.FullName));
                DirectoryFiles.Add(_info);
            }
            DirectoryFiles_list_view.ItemsSource = null;
            DirectoryFiles_list_view.ItemsSource = DirectoryFiles;
        }
    }
}
