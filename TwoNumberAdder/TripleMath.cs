using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TwoNumberAdder
{
    public partial class Form1 : Form
    {
        private double number_1, number_2, number_3;
        private double sumOfThree, avgOfThree, prdOfThree;

        public Form1()
        {
            InitializeComponent();

            RoundButton calBtn = new RoundButton();
            calBtn.Text = "Calculate";
            calBtn.Location = new Point(30, 200);
            calBtn.Size = new Size(100, 40);
            calBtn.Click += calBtn_Click;
            this.Controls.Add(calBtn);
            this.AcceptButton = calBtn;

            RoundButton clrBtn = new RoundButton();
            clrBtn.Text = "Clear";
            clrBtn.Location = new Point(150, 200);
            clrBtn.Size = new Size(100, 40);
            clrBtn.Click += clrBtn_Click;
            this.Controls.Add(clrBtn);

            SetTextBoxRoundedCorners(textBox1, 10);
            SetTextBoxRoundedCorners(textBox2, 10);
            SetTextBoxRoundedCorners(textBox3, 10);
            SetTextBoxRoundedCorners(textBox4, 10);
            SetTextBoxRoundedCorners(textBox5, 10);
            SetTextBoxRoundedCorners(textBox6, 10);

            textBox1.Resize += (s, args) => SetTextBoxRoundedCorners(textBox1, 10);
            textBox2.Resize += (s, args) => SetTextBoxRoundedCorners(textBox2, 10);
            textBox3.Resize += (s, args) => SetTextBoxRoundedCorners(textBox3, 10);
            textBox4.Resize += (s, args) => SetTextBoxRoundedCorners(textBox4, 10);
            textBox5.Resize += (s, args) => SetTextBoxRoundedCorners(textBox5, 10);
            textBox6.Resize += (s, args) => SetTextBoxRoundedCorners(textBox6, 10);

            ToolTip toolTip = new ToolTip
            {
                AutoPopDelay = 2000,
                InitialDelay = 200,
                ReshowDelay = 200,
                ShowAlways = true
            };

            textBox1.TextChanged += textBox1_TextChanged;
            textBox2.TextChanged += textBox2_TextChanged;
            textBox4.TextChanged += textBox4_TextChanged;

            textBox1.KeyPress += textBox1_KeyPress;
            textBox2.KeyPress += textBox2_KeyPress;
            textBox4.KeyPress += textBox4_KeyPress;

            toolTip.SetToolTip(textBox1, "Enter the first number");
            toolTip.SetToolTip(textBox2, "Enter the second number");
            toolTip.SetToolTip(textBox4, "Enter the third number");
        }

        private void inputMethod()
        {
            try
            {
                number_1 = double.Parse(textBox1.Text);
                number_2 = double.Parse(textBox2.Text);
                number_3 = double.Parse(textBox4.Text);
            }
            catch
            {
                MessageBox.Show("Please enter valid numeric values.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            ApplyRoundedCorners(panel1, 20);
            ApplyRoundedCorners(panel2, 20);
            ApplyRoundedCorners(panel3, 20);
            ApplyRoundedCorners(panel4, 20);
            ApplyRoundedCorners(panel5, 20);
            ApplyRoundedCorners(panel6, 20);
        }

        private void calculateResults()
        {
            try
            {
                sumOfThree = number_1 + number_2 + number_3;
                avgOfThree = sumOfThree / 3;
                prdOfThree = number_1 * number_2 * number_3;
            }
            catch
            {
                MessageBox.Show("An error occurred during calculation.", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Text.Equals("");
                textBox5.Text.Equals("");
                textBox6.Text.Equals("");
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
            if (textBox4.Text.ToString().Equals(""))
            {
                label13.Visible = true;
            }
            else
            {
                label13.Visible = false;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            if (textBox2.Text.ToString().Equals(""))
            {
                label12.Visible = true;
            }
            else
            {
                label12.Visible = false;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (textBox1.Text.ToString().Equals(""))
            {
                label11.Visible = true;
            }
            else { 
                label11.Visible = false;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                label17.Text = "Only digits are allowed!";
                label17.ForeColor = Color.Red;
            }
            else
            {
                label17.Text = "";
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                label18.Text = "Only digits are allowed!";
                label18.ForeColor = Color.Red;
            }
            else
            {
                label18.Text = "";
            }
        }

        private void calBtn_Click(object sender, EventArgs e)
        {
            inputMethod();
            calculateResults();
            textBox6.Text = sumOfThree.ToString();
            textBox5.Text = avgOfThree.ToString();
            textBox3.Text = prdOfThree.ToString();
        }

        private void clrBtn_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            number_1 = number_2 = number_3 = sumOfThree = avgOfThree = prdOfThree = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
                this.BackColor = Color.White;
                foreach (Control ctrl in this.Controls)
                {
                    ctrl.BackColor = Color.White;
                    ctrl.ForeColor = Color.Black;
                }
                
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(30, 30, 30);
            foreach (Control ctrl in this.Controls)
            {
                ctrl.BackColor = Color.FromArgb(45, 45, 45);
                ctrl.ForeColor = Color.White;
                calBtn.BackColor = Color.SteelBlue;
                clrBtn.BackColor = Color.FromArgb(242, 22, 62);
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                label19.Text = "Only digits are allowed!";
                label19.ForeColor = Color.Red;
            }
            else
            {
                label19.Text = "";
            }
        }
        private void ApplyRoundedCorners(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddArc(panel.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddArc(panel.Width - radius * 2, panel.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(0, panel.Height - radius * 2, radius * 2, radius * 2, 90, 90);

            path.CloseAllFigures();

            panel.Region = new Region(path);
        }

        #region TextBox Border Rounding

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        private void SetTextBoxRoundedCorners(TextBox textBox, int radius)
        {
            textBox.BorderStyle = BorderStyle.None;
            textBox.Region = Region.FromHrgn(CreateRoundRectRgn(
                0, 0, textBox.Width, textBox.Height, radius, radius));

            textBox.BackColor = Color.White;

            textBox.Padding = new Padding(radius / 2);
        }
        #endregion
    }
}
