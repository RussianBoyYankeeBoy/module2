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
    public partial class Form4 : Form
    {
        public static string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\Zhalaldin\\Desktop\\dataBase.mdb;";
        OleDbConnection connection = new OleDbConnection(connectionString);
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dt = new DataTable();
        public Form4()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Description";
            dataGridView1.Columns[3].Name = "Contacts";
            dataGridView1.Columns[4].Name = "Address";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            retrieve();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }
        private void retrieve()
        {
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM company";
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
        private void clearTxt()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void populate(string id, string name, string description, string phone, string address)
        {
            dataGridView1.Rows.Add(id, name, description, phone, address);
        }
        private void add(string name, string desctiption, string phone, string address)
        {
            string sql = "INSERT INTO company (name, description, contact, address) VALUES(@Name, @desctiption, @contact, @Address)";
            cmd = new OleDbCommand(sql, connection);
            // add params
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@desctiption", desctiption);
            cmd.Parameters.AddWithValue("@contact", phone);
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
        private void update(int id, string name, string description, string phone, string address)
        {
            string sql = "UPDATE company SET name='" + name + "', description='" + description + "', contact= '" + phone + "', address= '" + address + "' WHERE Код = " + id + ";";
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
        private void delete(int id)
        {
            string sql = "DELETE FROM company WHERE Код =" + id + ";";
            cmd = new OleDbCommand(sql, connection);
            try
            {
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
        // add
        private void button1_Click(object sender, EventArgs e)
        {
            add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            retrieve();
        }
        // delete
        private void button4_Click(object sender, EventArgs e)
        {
            string selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = int.Parse(selected);
            delete(id);
        }
        // update
        private void button5_Click(object sender, EventArgs e)
        {
            string selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = int.Parse(selected);
            update(id, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
        }
        // search
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM company WHERE name LIKE '" + textBox6.Text + "%'";
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
        // filter
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM company WHERE address LIKE '" + textBox7.Text + "%'";
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
        // sort
        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM company ORDER BY " + comboBox1.SelectedItem.ToString();
            cmd = new OleDbCommand(sql, connection);
            try
            {
                connection.Open();
                adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows) populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                connection.Close();
                dt.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
    }
}
