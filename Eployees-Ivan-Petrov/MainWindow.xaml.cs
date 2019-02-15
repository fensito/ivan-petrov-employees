using Eployees_Ivan_Petrov.MVVM.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace Eployees_Ivan_Petrov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeesModel Model; 

        public MainWindow()
        {
            //Initialization
            InitializeComponent();
        }

        private void btnBrowseFile_Click(object sender, RoutedEventArgs e)
        {
            //Create a OpenFileDialog 
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "XML Files (*.xml)|*.xml";
            dlg.FilterIndex = 0;
            dlg.DefaultExt = "xml";

            //Fire show Dialog method
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            { 
                //Display filename
                string filename = dlg.FileName;
                fileLabel.Text = filename;

                // Open document 
                //Create a helper and run the method to parse XML
                Model = new EmployeesModel();
                Model.ReadXML(filename);

                //Fill up DataGrid
                this.DataGrid.EmployeesGrid.ItemsSource = Model.GetFilteredEmployees();
            }
        }
    }
}
