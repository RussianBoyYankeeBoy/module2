using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 employees = new Form2();
            employees.Show();
        }
        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 mysqlEmp = new Form3();
            mysqlEmp.Show();
        }

        private void компанииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 compForm4 = new Form4();
            compForm4.Show();
        }

        private void интервьюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 interAccess = new Form5();
            interAccess.Show();
        }

        private void companiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 depMysql = new Form6();
            depMysql.Show();
        }

        private void contactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 contMysql = new Form7();
            contMysql.Show();
        }

        private void employeesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form8 empSQL = new Form8();
            empSQL.Show();
        }

        private void moreinformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
        }

        private void departmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 depForm10 = new Form10();
            depForm10.Show();
        }
    }
}
