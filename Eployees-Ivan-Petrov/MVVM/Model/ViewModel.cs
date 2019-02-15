using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eployees_Ivan_Petrov.MVVM.Model
{
   public class ViewModel
    {
        public int Employee { get; set; }
        public int ProjectId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string WorkedTime { get; set; }
    }
}
