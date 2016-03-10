using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kennels.Common
{
    public static class CommonUtilities
    {
        public static void AddControlEventHandlers(Form form)
        {
            RecursiveLoopControls(form);
        }


        public static void RecursiveLoopControls(Control ctrl)
        {
            foreach (Control _ctrl in ctrl.Controls)
            {
                if (_ctrl.GetType() == typeof(TextBox) || _ctrl.GetType() == typeof(ComboBox))
                {
                    TextBox tb = _ctrl as TextBox;

                    if (tb != null)
                    {
                        tb.TextChanged += new EventHandler((sender, eventArgs) => ValidateTextBox(tb)); 
                    }
                }
                else if (_ctrl.GetType() == typeof(ComboBox))
                {
                    ComboBox cb = _ctrl as ComboBox;

                    if (cb != null)
                    {
                        cb.TextChanged += new EventHandler((sender, eventArgs) => ValidateComboBox(cb));
                    }
                }
                else
                    RecursiveLoopControls(_ctrl);
            }
        }

        public static void ValidateTextBox(TextBox ctrl)
        {
            if (string.IsNullOrEmpty(ctrl.Text))
                ctrl.BackColor = Color.Red;
            else
                ctrl.BackColor = Color.Empty;
        }

        public static void ValidateComboBox(ComboBox ctrl)
        {
            if (ctrl.SelectedIndex == -1)
                ctrl.BackColor = Color.Red;
            else
                ctrl.BackColor = Color.Empty;
        }
    }
}
