using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelaResortUI
{
    interface ISetupForm
    {
        bool TrySubmitChanges();
        void PreView();
    }
}
