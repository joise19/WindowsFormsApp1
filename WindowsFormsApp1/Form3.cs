using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        TP kn = new TP();
        TR fn = new TR();
        CL dr = new CL();
        int k;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            kn.Read_Trips();
            fn.Read_Tours();
            dr.Read_Clients();

            foreach (Trips kind in kn.trips)
            {
                int fk_c = kind.Fk_client;
                int n_c = dr.clients.FindIndex(p => p.Id_client == fk_c);
                int fk_t = kind.Fk_trip;
                int n_t = fn.tours.FindIndex(p => p.Id_tour == fk_t);
                

                if (n_t != -1 && n_c != -1)
                    dataGridView1.Rows.Add(
                        kind.Id_tour, kind.Data_trip.ToString().Substring(0, 10),
                        kind.Fk_client, dr.clients[n_c].Name, kind.Fk_trip, fn.tours[n_t].TourName, kind.Days);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            k = dataGridView1.CurrentRow.Index;
            int fk_c = int.Parse(dataGridView1.Rows[k].Cells[2].Value.ToString());
            int n_c = dr.clients.FindIndex(p => p.Id_client == fk_c);

            int fk_t = int.Parse(dataGridView1.Rows[k].Cells[4].Value.ToString());
            int n_t = fn.tours.FindIndex(p => p.Id_tour == fk_t);
            if (n_c != -1)
                comboBox1.DataSource = dr.clients;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id_client";
                comboBox1.SelectedIndex = n_c;
            if (n_t != -1)
                comboBox2.DataSource = fn.tours;
                comboBox2.DisplayMember = "TourName";
                comboBox2.ValueMember = "Id_tour";
                comboBox2.SelectedIndex = n_t;

            textBox1.Text = dataGridView1.Rows[k].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[k].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[k].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[k].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[k].Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            kn.Save_Tours();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            k = dataGridView1.CurrentRow.Index;
            int x = int.Parse(dataGridView1.Rows[k].Cells[0].Value.ToString());
            int y = kn.trips.FindIndex(p => p.Id_tour == x);
            dataGridView1.Rows.RemoveAt(k);
            kn.trips.RemoveAt(y);
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            button4.Visible = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }

        /*     private void button5_Click(object sender, EventArgs e)
             {
                 var temp = dataGridView1.Rows.Count - 1;
                 if (DateTime.TryParse(textBox2.Text, out DateTime result1) &&
                     (textBox5.Text.Equals("+") || textBox5.Text.Equals("-")))
                 {
                     int nd = comboBox1.SelectedIndex;
                     int kd = dr.drivers[nd].Id_driver;
                     int nf = comboBox2.SelectedIndex;
                     int kf = fn.fines[nf].Id_fine;
                     dataGridView1.Rows.Add(int.Parse(dataGridView1.Rows[temp].Cells[0].Value.ToString()) + 1,
                         textBox2.Text, kd.ToString(), comboBox1.Text, kf.ToString(), comboBox2.Text, textBox5.Text );
                     button5.Visible = false;
                     button4.Visible = true;

                     bool l = textBox5.Text == "+"? true : false;

                     Kind_of_crime t = new Kind_of_crime(int.Parse(dataGridView1.Rows[temp].Cells[0].Value.ToString()) + 1,
                         DateTime.Parse(textBox2.Text), kd, kf, l);
                     kn.kinds_of_crimes.Add(t);
                 }
             }
*/
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
             {
       /*          for (int i = 0; i < dataGridView1.Rows.Count; i++)
                 {
                     if (dataGridView1.Rows[i].Cells[4].Value.ToString() == comboBox1.Text.ToString())
                     {
                         textBox7.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                         textBox6.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                         textBox5.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                         textBox3.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                         textBox2.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                         textBox1.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                         textBox4.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
                     }
                 }
       */
    }

    private void button1_Click_1(object sender, EventArgs e)
        {
            int nd = comboBox1.SelectedIndex;
            int kd = dr.clients[nd].Id_client;
            int nf = comboBox2.SelectedIndex;
            int kf = fn.tours[nf].Id_tour;

            if (DateTime.TryParse(textBox2.Text, out DateTime result1))
                dataGridView1.Rows[k].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[k].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[k].Cells[2].Value = kd.ToString();
                dataGridView1.Rows[k].Cells[3].Value = comboBox1.Text;
                dataGridView1.Rows[k].Cells[4].Value = kf.ToString();
                dataGridView1.Rows[k].Cells[5].Value = comboBox2.Text;
                dataGridView1.Rows[k].Cells[6].Value = textBox5.Text;


            int x = kn.trips.FindIndex(p => p.Id_tour == int.Parse(textBox1.Text));
            kn.trips[x].Id_tour = int.Parse(textBox1.Text);
            kn.trips[x].Data_trip = DateTime.Parse(textBox2.Text);
            kn.trips[x].Fk_client = kd;
            kn.trips[x].Fk_trip = kf;
            /*
                        foreach (Kind_of_crime x in kn.kinds_of_crimes)
                        {
                            if (x.Id_crime == int.Parse(textBox7.Text))
                            {
                                x.Id_crime = int.Parse(textBox7.Text);
                                x.Data_crime = DateTime.Parse(textBox6.Text);
                                x.Fk_driver = kv;
                                x.Fk_fine = int.Parse(textBox3.Text);
                                x.Check = bool.Parse(textBox4.Text);
                                break;
                            }
                        }
            */
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            kn.Save_Tours();
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
