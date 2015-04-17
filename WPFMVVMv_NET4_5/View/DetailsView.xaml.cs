using WPFMVVMApplcation.Model;
using WPFMVVMApplcation.ViewModel;
using System.Windows;

namespace WPFMVVMApplcation.View
{
    /// <summary>
    /// Interaction logic for PatientDetails.xaml
    /// </summary>
    public partial class DetailsView : Window
    {
        public DetailsView(Member member, IModelView parentViewModel)
        {
            InitializeComponent();
            this.DataContext = new DetailsViewModel(member , parentViewModel , this);
        }
    }
}
