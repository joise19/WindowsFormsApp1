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
    public partial class Form5 : Form
    {
        CL dR = new CL();
        TR fN = new TR();
        TP kN = new TP();
        public Form5()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            dR.Read_Clients();
            fN.Read_Tours();
            kN.Read_Trips();
            dataGridView1.DataSource = dR.clients;
            dataGridView1.Columns[0].HeaderText = "Код";
            dataGridView1.Columns[1].HeaderText = "Клиент";
            dataGridView1.Columns[2].HeaderText = "Дата рождения";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            if (dataGridView1.Rows.Count > 0)
            {
                int ns = dataGridView1.CurrentRow.Index;
                int kk = int.Parse(dataGridView1.Rows[ns].Cells[0].Value.ToString());
                foreach (Trips ss in kN.trips)
                {
                    if (ss.Fk_client == kk)
                    {
                        int kt = ss.Fk_trip;
                        int nt = fN.tours.FindIndex(t => t.Id_tour == kt);
                        string np = fN.tours[nt].TourName;
                        int pp = fN.tours[nt].Price;
                        
                        dataGridView2.Rows.Add(ss.Id_tour.ToString(),
                            ss.Data_trip.ToString().Substring(0,10),
                            ss.Fk_trip, np, pp.ToString(), ToString());
                    }
                }
            }
        }
    }
}
