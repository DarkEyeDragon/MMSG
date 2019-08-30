using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSG.Command
{
    public interface ICommand
    {
        void Send(string command);
    }
}
