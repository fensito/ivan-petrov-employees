using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eployees_Ivan_Petrov.MVVM.DataTypes
{
    public class EmployeeData
    {
        public ObservableCollection<Data> Employee { get; set; }

        public class Data
        {
            public int EmplId { get; set; }
            public int ProjectId { get; set; }
            public DateTime DateFrom { get; set; }
            public DateTime DateTo { get; set; }
           public string WorkedTime { get; set; }
        }
    }
    
}
