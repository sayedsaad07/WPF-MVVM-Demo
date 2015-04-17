using WPFMVVMApplcation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMVVMApplcation.ViewModel
{
    public interface IModelView
    {
       Member UpdateSelectedItem(Member originalcopy, Member updatedCopy);
    }
}
