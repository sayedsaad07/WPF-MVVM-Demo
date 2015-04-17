using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Input;

namespace WPFMVVMv_NET4_0.View.Behaviors
{
    public class AgeTextBoxBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
        }
        void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            bool isvalid = false;
            bool defaultValidKeys = e.Key == Key.Back
                || e.Key == Key.Tab
                || (e.KeyboardDevice.Modifiers == ModifierKeys.Shift & e.Key == Key.Tab)
                ? true : false;
            if ((e.Key >= Key.D1 && e.Key <= Key.D9) 
                || (e.Key >= Key.NumPad1 && e.Key <= Key.NumPad9)
                || defaultValidKeys)
                isvalid = true;

            if (isvalid == false)
                e.Handled = true;
        }

    }
}
