using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    [Serializable]
  public  class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Fees { get; set; }
    }
}
