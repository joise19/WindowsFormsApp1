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
    public partial class Form7 : Form
    {
        CL dr = new CL();
        TR fn = new TR();   
        TP kn   = new TP();
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            dr.Read_Clients();
            fn.Read_Tours();
            kn.Read_Trips();

            int s1 =0 ; int s2 =0 ; int s3=0;
            foreach (var c in dr.clients)
            {
                var sv = from s in kn.trips
                         join p in fn.tours on s.Fk_trip equals p.Id_tour
                         where s.Fk_client == c.Id_client
                         select new
                         {
                             s1 = s.Id_tour,
                            
                             s3 = p.Price,
                             s4 = p.Price 
                         };

                int kp = sv.Count();
                int kt = sv.Sum(p => p.s4);
                double sp = sv.Average(p => p.s3);
                int ss = sv.Sum(p => p.s4);

                dataGridView1.Rows.Add(c.Id_client.ToString(), c.Name, 
                    kp.ToString(), kt.ToString(), sp.ToString(), ss.ToString() );

                s1 += kp; s2 += kt; s3 += ss;
            }
            textBox1.Text = s1.ToString();
            textBox2.Text = s2.ToString();
            textBox3.Text = s3.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[4], ListSortDirection.Ascending);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
