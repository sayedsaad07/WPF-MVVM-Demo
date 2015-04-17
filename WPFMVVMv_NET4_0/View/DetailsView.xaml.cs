using WPFMVVMv_NET4_0.Model;
using WPFMVVMv_NET4_0.ViewModel;
using System.Windows;

namespace WPFMVVMv_NET4_0.View
{
    /// <summary>
    /// Interaction logic for PatientDetails.xaml
    /// </summary>
    public partial class DetailsView : Window
    {
        public DetailsView(Patient member, IModelView parentViewModel)
        {
            InitializeComponent();
            this.DataContext = new DetailsViewModel(member , parentViewModel , this);
        }
    }
}
