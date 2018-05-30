using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LabControls
{
    public partial class ColorSelector : UserControl
    {
        public ColorSelector()
        {
            InitializeComponent();
        }

        private void ColorSelector_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                switch (e.KeyChar)
                {
                    case char ch when char.IsControl(ch):
                        e.Handled = false;
                        break;

                    case char ch when !char.IsDigit(e.KeyChar):
                        e.Handled = true;
                        break;

                    default:
                        e.Handled = false;
                        break;

                }
            }
            else
            {
                string allowedLetters = "abcdefABCDEF";
                {
                    switch (e.KeyChar)
                    {
                        case char ch when char.IsControl(ch):
                            e.Handled = false;
                            break;

                        case char ch when !char.IsDigit(e.KeyChar) && !allowedLetters.Contains(e.KeyChar):
                            e.Handled = true;
                            break;

                        default:
                            e.Handled = false;
                            break;

                    }
                }
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Red.Text = Convert.ToString(Convert.ToInt32(Red.Text), 16);
            Green.Text = Convert.ToString(Convert.ToInt32(Green.Text), 16);
            Blue.Text = Convert.ToString(Convert.ToInt32(Blue.Text), 16);
            }
            catch (Exception)
            {

            }
}

        private void radioButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Red.Text = Convert.ToString(Convert.ToInt32(Red.Text, 16), 10);
                Green.Text = Convert.ToString(Convert.ToInt32(Green.Text, 16), 10);
                Blue.Text = Convert.ToString(Convert.ToInt32(Blue.Text, 16), 10);
            }
            catch (Exception)
            {

            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (((TextBox)sender).Text == "")
                {
                    ((TextBox)sender).AppendText("0");
                }
                try
                {
                    if (Convert.ToInt32(((TextBox)sender).Text) >= 255)
                    {
                        ((TextBox)sender).Text = "255";
                    }
                }
                catch (Exception)
                {
                    ((TextBox)sender).Text = "0";
                }
                if (Convert.ToInt32(((TextBox)sender).Text) <= 0)
                {
                    ((TextBox)sender).Text = "0";
                }
                if (Convert.ToInt32(Convert.ToString(Convert.ToInt32(Red.Text, 16), 10), 10) > 0 &&
                    ((TextBox)sender).Text[0] == '0')
                {
                    ((TextBox)sender).Text = ((TextBox)sender).Text.Remove(0, 1);
                }
                Color newColor = Color.Black;
                switch (((TextBox)sender).Name)
                {
                    case "Red":
                        newColor = Color.FromArgb(Convert.ToInt32(Red.Text, 10), panel1.BackColor.G, panel1.BackColor.B);
                        break;
                    case "Green":
                        newColor = Color.FromArgb(panel1.BackColor.R, Convert.ToInt32(Green.Text, 10), panel1.BackColor.B);
                        break;
                    case "Blue":
                        newColor = Color.FromArgb(panel1.BackColor.R, panel1.BackColor.G, Convert.ToInt32(Blue.Text, 10));
                        break;
                }
                panel1.BackColor = newColor;
            }
            else
            {
                if (((TextBox)sender).Text == "")
                {
                    ((TextBox)sender).AppendText("0");
                }
                try
                {
                    if (Convert.ToInt32(Convert.ToString(Convert.ToInt32(((TextBox)sender).Text, 16), 10), 10) >= 255)
                    {
                        ((TextBox)sender).Text = "FF";
                    }
                }
                catch (Exception)
                {
                    ((TextBox)sender).Text = "0";
                }
                if (Convert.ToInt32(Convert.ToString(Convert.ToInt32(((TextBox)sender).Text, 16), 10), 10) <= 0)
                {
                    ((TextBox)sender).Text = "0";
                }
                if (Convert.ToInt32(Convert.ToString(Convert.ToInt32(((TextBox)sender).Text, 16), 10), 10) > 0 &&
                    ((TextBox)sender).Text[0] == '0')
                {
                    ((TextBox)sender).Text = ((TextBox)sender).Text.Remove(0, 1);
                }
                Color newColor = Color.Black;
                switch (((TextBox)sender).Name)
                {
                    case "Red":
                        newColor = Color.FromArgb(Convert.ToInt32(Red.Text, 16), panel1.BackColor.G, panel1.BackColor.B);
                        break;
                    case "Green":
                        newColor = Color.FromArgb(panel1.BackColor.R, Convert.ToInt32(Green.Text, 16), panel1.BackColor.B);
                        break;
                    case "Blue":
                        newColor = Color.FromArgb(panel1.BackColor.R, panel1.BackColor.G, Convert.ToInt32(Blue.Text, 16));
                        break;
                }
                panel1.BackColor = newColor;
            }
                ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }
    }
}
