using WPFMVVMApplcation.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WPFMVVMApplcation.Model
{
    /// <summary>
    /// patient class 
    /// patient has name and age fields
    /// </summary>
    public class Member : CommonBase, ICloneable
    {
        private string _name;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value && IsValidName(value))
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }
        public bool IsValidName(string value)
        {
            if (string.IsNullOrEmpty(value) == false)
                return System.Text.RegularExpressions.Regex.IsMatch(value, "^[A-Za-z][A-Za-z ]*$");
            else
                return true;
        }
        private int _age;

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>
        /// The age.
        /// </value>
        public int Age
        {
            get { return _age; }
            set
            {
               if (_age != value)
                {
                    if (IsValidAge(value))
                    {
                        _age = value;
                        NotifyPropertyChanged("Age");
                    }
                    else //invalid age
                        _age = -1;
                }
            }
        }
        public bool IsValidAge(int value)
        {
            return value >= 1 && value <= 99;
        }
        public object Clone()
        {
            var cloneCopy = new Member();
            cloneCopy.Name = this.Name;
            cloneCopy.Age = this.Age;
            return cloneCopy;
        }

        public override bool Equals(object obj)
        {
            if (this == null && obj == null)
                return true;
            if (this == null || obj == null)
                return false;
            if (obj is Member)
            {
                Member compareto = (Member)obj;
                if (this.Name == compareto.Name && this.Age == compareto.Age)
                    return true;
            }
            return false;
        }
    }
}
