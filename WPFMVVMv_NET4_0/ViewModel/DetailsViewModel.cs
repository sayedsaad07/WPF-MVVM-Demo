using WPFMVVMv_NET4_0.Shared;
using WPFMVVMv_NET4_0.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFMVVMv_NET4_0.View;

namespace WPFMVVMv_NET4_0.ViewModel
{
    public class DetailsViewModel : CommonBase
    {
        #region commands
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        #endregion
        #region fields & properties
        private DetailsView _View;
        private IModelView _parentViewModel;
        private Patient _originalcopy;
        private Patient _currentMember;
        public Patient CurrentMember
        {
            get { return _currentMember; }
            set
            {
                _currentMember = value;
                NotifyPropertyChanged("CurrentMember");
            }
        }
        #endregion
        #region Constructor
        public DetailsViewModel(Patient patient, IModelView parentViewModel, DetailsView view)
        {
            _View = view;
            SaveCommand = new RelayCommand(Save, CanSave);
            CancelCommand = new RelayCommand(Cancel, CanCancel);
            if (patient != null)
            {
                _originalcopy = patient;
                CurrentMember = patient.Clone() as Patient;
            }
            _parentViewModel = parentViewModel;
        }
        #endregion
        #region commands execution
        private bool CanCancel(object obj)
        {
            return true;
        }

        private void Cancel(object obj)
        {
            _View.Close();
        }

        private bool CanSave(object obj)
        {
            return true;
        }

        public void Save(object obj)
        {
            this._parentViewModel.UpdateSelectedItem(_originalcopy, CurrentMember.Clone() as Patient);
            _View.Close();
        }
        #endregion
    }
}
