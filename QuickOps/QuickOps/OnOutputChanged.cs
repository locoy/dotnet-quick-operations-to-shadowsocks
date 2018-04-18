using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickOps
{
    class OnOutputChanged
    {
        public delegate void tempChange(object sender, EventArgs e);
        public event tempChange OnOutputChange;
        string temp;
        public string Temp
        {
            get
            {
                return temp;
            }
            set
            {
                if (temp != value)
                {
                    OnOutputChange(this, new EventArgs());
                }
                temp = value;
            }
        }
    }
}
