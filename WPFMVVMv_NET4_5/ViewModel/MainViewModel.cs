using WPFMVVMApplcation.Shared;
using WPFMVVMApplcation.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFMVVMApplcation.View;

namespace WPFMVVMApplcation.ViewModel
{
    public class MainViewModel : CommonBase, IModelView
    {
        #region Commands
        public ICommand EditSelectedItemCommand
        { get; set; }

        #endregion
        #region properties

        private ObservableCollection<Member> _patientList;

        public ObservableCollection<Member> PatientList
        {
            get { return _patientList; }
            set
            {
                _patientList = value;
                NotifyPropertyChanged("PatientList");
            }
        }

        private Member _selectedItem;

        public Member SelectedItem
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
            List<Member> patients = LoadPatientList();
            //set default selection value
            SelectedItem = patients[0];
        }

        private List<Member> LoadPatientList()
        {
            List<Member> patients = new List<Member>();
            patients.Add(new Member() { Name = "Sayed Saad", Age = 27 });
            patients.Add(new Member() { Name = "Aysel Saad", Age = 1 });
            patients.Add(new Member() { Name = "Nehad Mousa", Age = 25 });
            PatientList = new ObservableCollection<Member>(patients);
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

        public Member UpdateSelectedItem(Member originalcopy, Member updatedCopy)
        {
            if (this.PatientList.Contains(originalcopy) == true)
            {
                int idx = this.PatientList.IndexOf(originalcopy);
                this.PatientList.RemoveAt(idx);
                bool isValidInput = updatedCopy.Age == -1 || string.IsNullOrEmpty(updatedCopy.Name) ? false : true;
                if (isValidInput == false)
                    updatedCopy = originalcopy.Clone() as Member;

                this.PatientList.Insert(idx, updatedCopy);
                this.SelectedItem = updatedCopy;
                return updatedCopy;
            }
            return null;
        }
        #endregion
    }
}
