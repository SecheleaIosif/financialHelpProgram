using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Data.SqlClient; 

namespace financialHelpProgram
{
    public partial class Form1 : Form
    {
        // global variable initialising
        int money = 0; 
        int luna = System.DateTime.Now.Month - 1;
        int an = System.DateTime.Now.Year; 
        string[] months = new string[12] {"January", "February", "March", "April", "May", "June", "July", 
            "August", "September", "October", "November", "December"} ;
        

        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //visual initialising
            label13.SendToBack();
            label8_Click(sender, e); label9_Click(sender, e); label10_Click(sender, e); label11_Click(sender, e);
            label7.Text = months[luna];
            label6.Text = Convert.ToString(an);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // fill data tables with data from dataset
            money = Convert.ToInt32(money - pCsTableAdapter.sumPCPrices());

            this.specsTableAdapter.Fill(this.financialHelpDataBaseDataSet.specs);
            this.pCsTableAdapter.Fill(this.financialHelpDataBaseDataSet.PCs);
            this.employeesTableAdapter.Fill(this.financialHelpDataBaseDataSet.employees);
            this.projectsTableAdapter1.Fill(this.financialHelpDataBaseDataSet.projects);
            this.expensesTableAdapter.Fill(this.financialHelpDataBaseDataSet.expenses);

            label8_Click(sender, e); label9_Click(sender, e); label10_Click(sender, e); label11_Click(sender, e); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int SumPCPrices = 0;
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                SumPCPrices += Convert.ToInt32(dataGridView4.Rows[Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value)].Cells[5].Value);
            }
            money = money - SumPCPrices;

            // refreshes balance labels
            label8_Click(sender, e); label9_Click(sender, e); label10_Click(sender, e); label11_Click(sender, e);

            SumPCPrices = 0;
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                SumPCPrices += Convert.ToInt32(dataGridView4.Rows[Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value)].Cells[5].Value);
            }
            money = money + SumPCPrices;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            label11.Text = Convert.ToString(money);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            int SumIncomeProjects = 0; int i = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                SumIncomeProjects += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                i++;
            }

            int SumIncomeEmployees = 0; i = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                SumIncomeEmployees += Convert.ToInt32(dataGridView2.Rows[i].Cells[6].Value);
                i++;
            }

            int SumExpenses = 0; i = 0;
            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                SumExpenses += Convert.ToInt32(dataGridView5.Rows[i].Cells[2].Value);
                i++;
            }

            label10.Text = Convert.ToString(money + SumIncomeProjects - SumIncomeEmployees - SumExpenses);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            int SumIncomeProjects = 0; int i = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                SumIncomeProjects += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                i++;
            }
            label9.Text = Convert.ToString(SumIncomeProjects); 
        }

        private void label8_Click(object sender, EventArgs e)
        {
            int SumIncomeEmployees = 0; int i = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                SumIncomeEmployees += Convert.ToInt32(dataGridView2.Rows[i].Cells[6].Value);
                i++;
            }

            int SumExpenses = 0; i = 0;
            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                SumExpenses += Convert.ToInt32(dataGridView5.Rows[i].Cells[2].Value);
                i++;
            }

            label8.Text = Convert.ToString(SumIncomeEmployees + SumExpenses);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int SumIncomeProjects = 0; int i = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                SumIncomeProjects += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                i++;
            }

            int SumIncomeEmployees = 0; i = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                SumIncomeEmployees += Convert.ToInt32(dataGridView2.Rows[i].Cells[6].Value);
                i++;
            }

            int SumExpenses = 0; i = 0;
            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                SumExpenses += Convert.ToInt32(dataGridView5.Rows[i].Cells[2].Value);
                i++;
            }
            
            money = money + SumIncomeProjects - SumExpenses - SumIncomeEmployees;

            if (luna == 11){
                luna = 0; 
                an = an + 1;
            }
            else {
                luna = luna + 1; 
            }

            label7.Text = months[luna];
            label6.Text = Convert.ToString(an);

            label8_Click(sender, e); label9_Click(sender, e); label10_Click(sender, e); label11_Click(sender, e); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int n;
            if(int.TryParse(textBox1.Text, out n))
            {
                money = money - Convert.ToInt32(textBox1.Text);
                label10_Click(sender, e); label11_Click(sender, e);
                MessageBox.Show("Transaction succeded.");
            }
            else
            {
                MessageBox.Show ("Introduced value can only be of numeric type.");
            }

            textBox1.Text = "type value";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int n;
            if(int.TryParse(textBox1.Text, out n))
            {
                money = money + Convert.ToInt32(textBox1.Text);
                label10_Click(sender, e); label11_Click(sender, e);
                MessageBox.Show("Transaction succeded.");
            }
            else
            {
                MessageBox.Show("Introduced value can only be of numeric type.");
            }

            textBox1.Text = "type value";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
