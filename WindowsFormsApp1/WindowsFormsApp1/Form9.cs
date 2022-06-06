using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form9 : Form
    {
        SqlConnection connection = new SqlConnection("Server = localhost; Database=myDB;Trusted_Connection=True;");
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataTable dt = new DataTable();

        public Form9()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "id";
            dataGridView1.Columns[1].Name = "contact_name";
            dataGridView1.Columns[2].Name = "company_id";
            dataGridView1.Columns[3].Name = "salary";
            dataGridView1.Columns[4].Name = "description";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // SELECTION MODE
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            // FOR FILL dataGridView
            retrieve();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }
        private void populate(string id, string name, string surName, string age, string address)
        {
            dataGridView1.Rows.Add(id, name, surName, age, address);
        }
        private void retrieve()
        {
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM more_information;";
            cmd = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter(cmd);
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
        //add
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO more_information (id, contact_name, company_id, salary, description) " +
                "VALUES(@id, @Name, @surName, @age, @address);";
            cmd = new SqlCommand(sql, connection);
            // add params
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@surName", textBox3.Text);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@age", textBox4.Text);
            cmd.Parameters.AddWithValue("@address", textBox5.Text);
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
            retrieve();

        }
        private void clearTxt()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
        // delete
        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM more_information WHERE id =" + textBox1.Text + ";";
            cmd = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter(cmd);
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
        // update
        private void button5_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE more_information SET contact_name='" + textBox2.Text + "', company_id='" + textBox3.Text + "', salary= '" + textBox4.Text + "', description= '" + textBox5.Text + "' WHERE id = " + textBox1.Text + ";";
            cmd = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter(cmd);

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
        // search
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM more_information WHERE contact_name LIKE '" + textBox6.Text + "%'";
            cmd = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter(cmd);
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
        // sorting
        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM more_information ORDER BY " + comboBox1.SelectedItem.ToString();
            cmd = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter(cmd);
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
        //filter by salary
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM more_information WHERE salary > " + textBox7.Text + ";";
            cmd = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter(cmd);
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
    }
}
