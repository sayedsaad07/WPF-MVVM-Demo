using WPFMVVMv_NET4_0.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMVVMv_NET4_0.ViewModel
{
    public interface IModelView
    {
       Patient UpdateSelectedItem(Patient originalcopy, Patient updatedCopy);
    }
}
