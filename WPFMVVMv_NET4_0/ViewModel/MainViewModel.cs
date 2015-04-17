using WPFMVVMv_NET4_0.Shared;
using WPFMVVMv_NET4_0.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFMVVMv_NET4_0.View;

namespace WPFMVVMv_NET4_0.ViewModel
{
    public class MainViewModel : CommonBase, IModelView
    {
        #region Commands
        public ICommand EditSelectedItemCommand
        { get; set; }

        #endregion
        #region properties

        private ObservableCollection<Patient> _patientList;

        public ObservableCollection<Patient> PatientList
        {
            get { return _patientList; }
            set
            {
                _patientList = value;
                NotifyPropertyChanged("PatientList");
            }
        }

        private Patient _selectedItem;

        public Patient SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                NotifyPropertyChanged("SelectedItem");
            }
        }
        #endregion
        #region constructor
        public MainViewModel()
        {
            //define edit command
            EditSelectedItemCommand = new RelayCommand(ExecuteEditCommand, CanExecuteEditCommand);
            List<Patient> patients = LoadPatientList();
            //set default selection value
            SelectedItem = patients[0];
        }

        private List<Patient> LoadPatientList()
        {
            List<Patient> patients = new List<Patient>();
            patients.Add(new Patient() { Name = "Sayed Saad", Age = 27 });
            patients.Add(new Patient() { Name = "Aysel Saad", Age = 1 });
            patients.Add(new Patient() { Name = "Nehad Mousa", Age = 25 });
            PatientList = new ObservableCollection<Patient>(patients);
            return patients;
        }
        #endregion
        #region Edit Command Execution
        private bool CanExecuteEditCommand(object obj)
        {
            return SelectedItem != null ? true : false;
        }

        private void ExecuteEditCommand(object obj)
        {
            DetailsView view = new DetailsView(SelectedItem, this);
            view.ShowDialog();
        }
        #endregion
        #region IViewModel

        public Patient UpdateSelectedItem(Patient originalcopy, Patient updatedCopy)
        {
            if (this.PatientList.Contains(originalcopy) == true)
            {
                int idx = this.PatientList.IndexOf(originalcopy);
                this.PatientList.RemoveAt(idx);
                bool isValidInput = updatedCopy.Age == -1 || string.IsNullOrEmpty(updatedCopy.Name) ? false : true;
                if (isValidInput == false)
                    updatedCopy = originalcopy.Clone() as Patient;

                this.PatientList.Insert(idx, updatedCopy);
                this.SelectedItem = updatedCopy;
                return updatedCopy;
            }
            return null;
        }
        #endregion
    }
}
