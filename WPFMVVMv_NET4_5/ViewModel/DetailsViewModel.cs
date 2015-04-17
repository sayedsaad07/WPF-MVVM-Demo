using WPFMVVMApplcation.Shared;
using WPFMVVMApplcation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFMVVMApplcation.View;

namespace WPFMVVMApplcation.ViewModel
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
        private Member _originalcopy;
        private Member _currentMember;
        public Member CurrentMember
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
        public DetailsViewModel(Member member, IModelView parentViewModel, DetailsView view)
        {
            _View = view;
            SaveCommand = new RelayCommand(Save, CanSave);
            CancelCommand = new RelayCommand(Cancel, CanCancel);
            if (member != null)
            {
                _originalcopy = member;
                CurrentMember = member.Clone() as Member;
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
            this._parentViewModel.UpdateSelectedItem(_originalcopy, CurrentMember.Clone() as Member);
            _View.Close();
        }
        #endregion
    }
}
