using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Kennels.Common
{
    public static class CommonUtilities
    {
        #region Public Methods
        public static void RecursiveLoopControls(Control ctrl)
        {
            foreach (Control _ctrl in ctrl.Controls)
            {
                if (_ctrl.GetType().Equals(typeof(TextBox)))
                {
                    TextBox tb = _ctrl as TextBox;

                    if (tb != null)
                    {
                        tb.TextChanged += new EventHandler((sender, eventArgs) => ValidateTextBox(tb));
                    }
                }
                else if (_ctrl.GetType().Equals(typeof(ComboBox)))
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

        public static void ToggleCombBoxesTextBoxesButtonsEnabled(Control ctrl, bool enabled, string[] exceptions)
        {
            List<string> _exceptions = new List<string>(exceptions);

            foreach (Control _ctrl in ctrl.Controls)
            {
                if (_ctrl.GetType().Equals(typeof(TextBox)) || _ctrl.GetType().Equals(typeof(ComboBox)) || _ctrl.GetType().Equals(typeof(Button)))
                {
                    if (!_exceptions.Contains(_ctrl.Name))
                        _ctrl.Enabled = enabled;
                }
                else
                    ToggleCombBoxesTextBoxesButtonsEnabled(_ctrl,  enabled, exceptions);
            }
        }

        public static byte[] ImageToByteArray(Image img)
        {
            ImageConverter converter = new ImageConverter();

            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public static Image ByteArrayToImage(byte[] bytes)
        {
            ImageConverter converter = new ImageConverter();

            return (Image)converter.ConvertFrom(bytes);
        }
        #endregion

        #region Helper Methods
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
        #endregion
    }
}
