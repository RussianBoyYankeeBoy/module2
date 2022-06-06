using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public static string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\Zhalaldin\\Desktop\\dataBase.mdb;";
        OleDbConnection connection = new OleDbConnection(connectionString);
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dt = new DataTable();
        public Form2()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "LastName";
            dataGridView1.Columns[3].Name = "Phone";
            dataGridView1.Columns[4].Name = "Address";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            retrieve();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }
        private void add(string name, string lastName, string phone, string address)
        {
            string sql = "INSERT INTO сотрудники (name, lastName, phone, address) VALUES(@Name, @LastName, @Phone, @Address)";
            cmd = new OleDbCommand(sql, connection);
            // add params
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Address", address);

            try
            {
                connection.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    clearTxt();
                    MessageBox.Show("Successfully inserted");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
        private void populate(string id, string name, string lastName, string phone, string address)
        {
            dataGridView1.Rows.Add(id, name, lastName, phone, address);
        }
        private void retrieve()
        {
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM Сотрудники";
            cmd = new OleDbCommand(sql, connection);
            try
            {
                connection.Open();
                adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                }
                connection.Close();
                dt.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
        private void update(int id, string name, string lastName, string phone, string address)
        {
            string sql = "UPDATE Сотрудники SET name='" + name + "', lastName='" + lastName + "', phone= '" + phone + "', address= '" + address + "' WHERE Код = " + id + ";";
            cmd = new OleDbCommand(sql, connection);
            try
            {
                connection.Open();
                adapter = new OleDbDataAdapter(cmd);

                adapter.UpdateCommand = connection.CreateCommand();
                adapter.UpdateCommand.CommandText = sql;

                if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    clearTxt();
                    MessageBox.Show("Successfully updated");
                }
                connection.Close();
                retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
        private void delete(int id) {
            string sql = "DELETE FROM сотрудники WHERE Код =" + id + ";";
            cmd = new OleDbCommand(sql, connection);
            try  {
                connection.Open();
                adapter = new OleDbDataAdapter(cmd);
                adapter.DeleteCommand = connection.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;

                if (MessageBox.Show("Sure for ?", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Successfully deleted");
                    }
                }
                connection.Close();
                retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
        private void clearTxt()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            add(textBox4.Text, textBox3.Text, textBox2.Text, textBox1.Text);
            retrieve();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = int.Parse(selected);
            delete(id);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = int.Parse(selected);
            update(id, textBox4.Text, textBox3.Text, textBox2.Text, textBox1.Text);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM Сотрудники WHERE name LIKE '" + textBox5.Text + "%'";
            cmd = new OleDbCommand(sql, connection);
            try
            {
                connection.Open();
                adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                }
                connection.Close();
                dt.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM Сотрудники WHERE phone LIKE '" + textBox6.Text + "%'";
            cmd = new OleDbCommand(sql, connection);
            try
            {
                connection.Open();
                adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows) populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                dt.Rows.Clear();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
        private void button6_Click(object sender, EventArgs e) {
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM Сотрудники ORDER BY " + comboBox1.SelectedItem.ToString();
            cmd = new OleDbCommand(sql, connection);
            try {
                connection.Open();
                adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows) populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                connection.Close();
                dt.Rows.Clear();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
    }
}
