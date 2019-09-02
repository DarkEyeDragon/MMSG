using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSG.Instances
{
    public class OutputHandler
    {
        public Process Process { get; set; }
        public bool FilterOutput { get; set; }

        public HashSet<SubscriptionArgs> Types { get; set; }

        public event EventHandler<SubscriptionArgs> Subscription;

        public OutputHandler(Process process)
        {
            Process = process;
            process.OutputDataReceived += (sender, args) =>
            {
                ValidateOutput(args.Data);
            };
        }

        public void ValidateOutput(string data)
        {
            foreach (var type in Types)
            {
                //TODO implement filter
            }
        }


        public void OnSubscriptionMet(SubscriptionArgs e)
        {
            
            EventHandler<SubscriptionArgs> handler = Subscription;

            handler?.Invoke(this, e);
        }

        public void Subscribe(SearchType type, string filter)
        {
            Types.Add(new SubscriptionArgs(type, filter));
        }

        public void Subscribe(SubscriptionArgs args)
        {
            Types.Add(args);
        }


    }
}
