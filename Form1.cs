using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace oop1
{
    public partial class Form1 : Form
    {
        public int ButtonCount = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text.Count().ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var btn = new Button()
            {
                Text = "Жмяк",
                Width = multiplyBtn.Width,
                Height = multiplyBtn.Height
            };
            btn.Location = new Point(multiplyBtn.Location.X + (multiplyBtn.Width + 10) * ButtonCount, multiplyBtn.Location.Y);
            btn.Click += new EventHandler(this.button1_Click);
            this.Controls.Add(btn);
            ButtonCount++;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ChangeColorCb.Checked)
                this.BackColor = Color.Aqua;
            else
                this.BackColor = Form.DefaultBackColor;

            if(progressBar1.Value <= 90)
                progressBar1.Value += 10;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label2.Text = string.Format("Координаты курсора на форме х:{0} у:{1}", e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            label3.Text = string.Format("Координаты курсора на панели х:{0} у:{1}", e.X, e.Y); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Add(comboBox1.SelectedItem);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var state = checkedListBox.GetItemChecked(tabControl1.SelectedIndex);
            checkedListBox.SetItemChecked(tabControl1.SelectedIndex, !state);
            checkedListBox.SelectedIndex = tabControl1.SelectedIndex;
        }

        private void splitContainer1_Paint(object sender, PaintEventArgs e)
        {
            listBox2.Items.Add("я перерисовался");

            label6.Text = splitContainer1.Panel1.Width.ToString();
            label7.Text = splitContainer1.Panel2.Width.ToString();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            var lbl = new Label();
            lbl.Text = "Клик!!!";
            lbl.AutoSize = true;
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.ForeColor = Color.BlueViolet;
            lbl.Location = e.Location;
            lbl.MouseDown += new MouseEventHandler(this.panel1_MouseDown);

            if((sender as Label) != null)
            {
                var point = lbl.Location;
                point.Offset((sender as Label).Location);
                lbl.Location = point;
            }
                

            panel1.Controls.Add(lbl);
            lbl.BringToFront();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Типо открылся ok.ru");
        }

        Point startDrag = new Point(0, 0);
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                pictureBox1.Location = new Point(pictureBox1.Location.X + e.Location.X - startDrag.X, pictureBox1.Location.Y + e.Location.Y - startDrag.Y);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startDrag = e.Location;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                e.Handled = false;
            if (e.Handled)
                label4.Text = (int.Parse(label4.Text) + 1).ToString();
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = new Form1()
            {
                Owner = this,
                Text = "Новая форма"
            };
            form.ShowDialog();
        }
    }
}
