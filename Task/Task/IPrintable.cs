using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.People;

namespace Task
{
    public interface IPrintable
    {
        public void Print(Candidate person);
        public void Print(Employee person);
    }
}
