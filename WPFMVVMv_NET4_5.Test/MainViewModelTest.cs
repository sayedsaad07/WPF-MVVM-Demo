using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPFMVVMApplcation.ViewModel;
using WPFMVVMApplcation.Model;

namespace WPFMVVMApplcation.TEST
{
    [TestClass]
    public class MainViewModelTest
    {
        private IModelView _mainViewModel;
        public MainViewModelTest()
        {
            _mainViewModel = new MainViewModel();
        }
        [TestMethod]
        //The goal here is to test the updated/edited version.
        public void UpdateSelectedItem_NoEdit_Test()
        {
            //input 
            //NOTE: Original member has to be in the prepopulated patients list
            Member original = new Member() { Name = "Sayed Saad", Age = 27 };
            Member updated = new Member() { Name = "Sayed Saad", Age = 27 };
            //actual
            var actual = _mainViewModel.UpdateSelectedItem(original, updated);
            var expected = updated;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        //The goal here is to test the updated/edited version.
        public void UpdateSelectedItem_HasEdit_Test()
        {
            //input 
            //NOTE: Original member has to be in the prepopulated patients list
            Member original = new Member() { Name = "Sayed Saad", Age = 27 };
            Member updated = new Member() { Name = "Sayed", Age = 27 };
            //actual
            var actual = _mainViewModel.UpdateSelectedItem(original, updated);
            var expected = updated;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        //The goal here is to test the updated/edited version.
        public void UpdateSelectedItem_invalidAgeEdit_Test()
        {
            //input 
            //NOTE: Original member has to be in the prepopulated patients list
            Member original = new Member() { Name = "Sayed Saad", Age = 27 };
            Member updated = new Member() { Name = "Sayed", Age = 999 };
            //actual
            var actual = _mainViewModel.UpdateSelectedItem(original, updated);
            var expected = original;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        //The goal here is to test the updated/edited version.
        public void UpdateSelectedItem_Namehasspecialchars_Test()
        {
            //input 
            //NOTE: Original member has to be in the prepopulated patients list
            Member original = new Member() { Name = "Sayed Saad", Age = 27 };
            Member updated = new Member() { Name = "Sayed_Saad", Age = 27 };
            //actual
            var actual = _mainViewModel.UpdateSelectedItem(original, updated);
            var expected = original;
            Assert.AreEqual(actual, expected);
        }


        [TestMethod]
        //The goal here is to test the updated/edited version.
        public void UpdateSelectedItem_NameHasDigits_Test()
        {
            //input 
            //NOTE: Original member has to be in the prepopulated patients list
            Member original = new Member() { Name = "Sayed Saad", Age = 27 };
            Member updated = new Member() { Name = "Sayed 12484", Age = 27 };
            //actual
            var actual = _mainViewModel.UpdateSelectedItem(original, updated);
            var expected = original;
            Assert.AreEqual(actual, expected);
        }
    }
}
