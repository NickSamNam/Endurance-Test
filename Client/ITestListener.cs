using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public interface ITestListener
    {
        void OnStateChanged(string state, int time);
    }
}
