using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorting
{
    public partial class Form1 : Form
    {
        Form2 form2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            string title = "Merge Sort";
            myForm2(title, 0);
        }

        private void btnInsertion_Click(object sender, EventArgs e)
        {
            string title = "Insertion Sort";
            myForm2(title, 1);
        }

        private void btnQuick_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Don't use quick sort algorithm in big array of numbers the program will crash", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string title = "Quick Sort";
            myForm2(title, 2);
        }
        private void myForm2(String title, int myid)
        {
            form2 = new Form2(myid);
            form2.Show();
            form2.Text = title;

        }
    }
}
