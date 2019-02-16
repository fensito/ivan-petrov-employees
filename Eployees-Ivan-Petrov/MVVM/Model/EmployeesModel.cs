using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using static Eployees_Ivan_Petrov.MVVM.DataTypes.EmployeeData;
using Eployees_Ivan_Petrov.MVVM.Model;
using System.Collections;
using System.Windows;

namespace Eployees_Ivan_Petrov.MVVM.Model
{
    public class EmployeesModel
    {
        private ObservableCollection<Data> data;

        public void ReadXML(string filePath)
        {
            try
            {
                var xdoc = XDocument.Load(filePath);

                // Parsing Data via LINQ
                var employees = from employee in xdoc.Descendants("Employee")
                                select new
                                {
                                    EployeeId = employee.Element("EmplID").Value,
                                    ProjectId = employee.Element("ProjectID").Value,
                                    DateFrom = employee.Element("DateFrom").Value,
                                    DateTo = employee.Element("DateTo").Value
                                };

                data = new ObservableCollection<Data>();

                //
                foreach (var employee in employees)
                {
                    DateTime dateTo;
                    bool success = DateTime.TryParse(employee.DateTo, out dateTo);
                    if (!success)
                    {
                        dateTo = DateTime.Now;
                    }

                    //Add data to object in DataStructure
                    data.Add(
                        new Data
                        {
                            DateFrom = DateTime.Parse(employee.DateFrom),
                            DateTo = dateTo,
                            EmplId = int.Parse(employee.EployeeId),
                            ProjectId = int.Parse(employee.ProjectId)
                        });
                }
            }

            catch
            {
                MessageBoxResult result = MessageBox.Show("An error occured ,Do you want to close this window?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
            }
        }

        public IEnumerable GetFilteredEmployees()
        {
            var employeesQuery = this.data
           .GroupBy(r => r.ProjectId)
           .Select(g => new
           {
               Key = g.Key,
               Items = g.OrderBy(r => r.DateFrom - r.DateTo).Select(x =>
                    new ViewModel
                    {
                        Employee = x.EmplId,
                        ProjectId = x.ProjectId,
                        DateFrom = x.DateFrom,
                        DateTo = x.DateTo,
                        WorkedTime = (x.DateTo - x.DateFrom).Days.ToString() + " " + "Days Worked"
                    }
                   )
                   .Take(2)
           }
                ).SelectMany(g => g.Items);
            return employeesQuery;
        }
    }
}
