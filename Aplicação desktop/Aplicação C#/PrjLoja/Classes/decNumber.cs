using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrjLoja
{
    class decNumber
    {
        public static void DecNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 44 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == 44 || e.KeyChar == 46)
            {
                TextBox txt = (TextBox)sender;
                if (txt.Text.Contains(",") || txt.Text.Contains("."))
                    e.Handled = true;
            }
        }
    }
}
