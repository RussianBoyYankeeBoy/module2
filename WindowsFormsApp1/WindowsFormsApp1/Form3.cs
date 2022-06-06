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
    public partial class Form3 : Form
    {
        //initialize sql connection
        static string connectionString = "host=localhost; database =forc#; username=root; password=1234;";
        MySqlConnection connection = new MySqlConnection(connectionString);
        //initialize all classes
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        public Form3()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "id";
            dataGridView1.Columns[1].Name = "name";
            dataGridView1.Columns[2].Name = "surname";
            dataGridView1.Columns[3].Name = "email";
            dataGridView1.Columns[4].Name = "post";
            dataGridView1.Columns[5].Name = "department_id";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // SELECTION MODE
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            // for fill dataGridView
            retrieve();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }
        private void retrieve()
        {
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM employees;";
            cmd = new MySqlCommand(sql, connection);
            try
            {
                connection.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
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
        private void add(string name, string surName, string email, string post, string department_id)
        {
            string sql = "INSERT INTO employees (name, surname, email, post, department_id) VALUES(@Name, @surName, @email, @post, @department_id);";
            cmd = new MySqlCommand(sql, connection);
            // add params
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@surName", surName);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@post", post);
            cmd.Parameters.AddWithValue("@department_id", department_id);
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

        private void update(int id, string name, string surname, string email, string post, string department_id)
        {
            string sql = "UPDATE employees SET name='" + name + "', surname='" + surname + "', email= '" + email + "', post= '" + post + "', department_id = '" + department_id + "' WHERE id = " + id + ";";
            cmd = new MySqlCommand(sql, connection);
            try
            {
                connection.Open();
                adapter = new MySqlDataAdapter(cmd);

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
            string sql = "DELETE FROM employees WHERE id =" + id + ";";
            cmd = new MySqlCommand(sql, connection);
            try
            {
                connection.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.DeleteCommand = connection.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;

                if (MessageBox.Show("Sure for ?", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (cmd.ExecuteNonQuery() > 0) MessageBox.Show("Successfully deleted");
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
            textBox5.Text = "";
        }
        // add
        private void button1_Click(object sender, EventArgs e)
        {
            add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            retrieve();
        }
        // delete
        private void button4_Click(object sender, EventArgs e)
        {
            string selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = int.Parse(selected);
            delete(id);
        }
        // refresh
        private void button5_Click(object sender, EventArgs e)
        {
            string selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = int.Parse(selected);
            update(id, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
        }
        // find
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM employees WHERE surname LIKE '" + textBox6.Text + "%'";
            cmd = new MySqlCommand(sql, connection);
            try
            {
                connection.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
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
        // sort
        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM employees ORDER BY " + comboBox1.SelectedItem.ToString();
            cmd = new MySqlCommand(sql, connection);
            try
            {
                connection.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows) populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                dt.Rows.Clear();
                connection.Close();
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
            string sql = "SELECT * FROM employees WHERE name LIKE '" + textBox7.Text + "%'";
            cmd = new MySqlCommand(sql, connection);
            try
            {
                connection.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows) populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                dt.Rows.Clear();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
        private void populate(string id, string name, string surName, string email, string post, string department_id)
        {
            dataGridView1.Rows.Add(id, name, surName, email, post, department_id);
        }
    }
}
