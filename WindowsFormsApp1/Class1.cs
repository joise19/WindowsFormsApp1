using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using System.Security.Policy;

namespace WindowsFormsApp1
{
    internal class Client
    {
        int id_client;
        string name;
        DateTime data_client;
        public Client(int id, string n, DateTime db)
        {
            id_client = id;
            name = n;
            data_client = db;
        }
        public int Id_client
        { get { return id_client; } set { id_client = value; } }
        public string Name
        { get { return name; } set {  name = value; } }
        public DateTime Data_client
        { get { return data_client; } set { data_client = value;} }
    }
    internal class Tour
    {
        int id_tour;
        string tour_name;
        int price;
        public Tour(int id, string n, int pr) 
        {
            id_tour = id;
            tour_name = n;
            price = pr;
        }
        public int Id_tour
        { get { return id_tour; } set { id_tour = value; } }
        public string TourName
        { get { return tour_name;} set { tour_name = value; } }
        public int Price
        { get { return price; } set {  price = value; } }
    }
    internal class Trips
    {
        int id_trip;
        DateTime data_trip;
        int fk_client;
        int fk_trip;
        int count = 0;
        int days;

        public Trips(int id,DateTime data, int fk1, int fk2, int count_days)
        {
            id_trip = id;
            data_trip = data;
            fk_client = fk1;
            fk_trip = fk2;
            days = count_days;

        }
        public int Id_tour
        { get { return id_trip; } set { id_trip = value; } }
        public DateTime Data_trip
        { get { return data_trip; } set { data_trip = value; } }
        
        public int Fk_client
        { get { return fk_client; } set { fk_client = value; } }
        public int Fk_trip
        { get { return fk_trip; } set { fk_trip = value; } }
        public int Days
        { get { return days; } set {  days = value; } }
    }
    internal class CL
    {
        public List<Client> clients = new List<Client>();
        char[] d = { '\t' };
        public void Read_Clients()
        {
            string[] sc = File.ReadAllLines("clients.txt");
            foreach (string s in sc)
            {
                string[] sl = s.Split(d, StringSplitOptions.RemoveEmptyEntries);

                DateTime dd = DateTime.Parse(sl[2]);
                Client cc = new Client(int.Parse(sl[0]), sl[1], dd);
                clients.Add(cc);
            }
        }
        public void Save_Clients()
        {
            var temp = new List<string>();
            foreach (Client x in clients)
            {
                string str = x.Id_client.ToString() + '\t' + x.Name.ToString() + '\t' + x.Data_client.ToString().Substring(0,10);
                temp.Add(str);
            }
            File.Delete("clients.txt");
            File.AppendAllLines("clients.txt", temp);
        }
    }
    internal class TR
    {
        public List<Tour> tours = new List<Tour>();
        char[] d = { '\t' };
        public void Read_Tours()
        {
            string[] sc = File.ReadAllLines("tours.txt");
            foreach (string s in sc)
            {
                string[] sl = s.Split(d, StringSplitOptions.RemoveEmptyEntries);

                Tour cc = new Tour(int.Parse(sl[0]), sl[1], int.Parse(sl[2]));
                tours.Add(cc);
            }
        }
        public void Save_Tours()
        {
            var temp = new List<string>();
            foreach (Tour f in tours)
            {
                string str = f.Id_tour.ToString() + '\t' + f.TourName.ToString() + '\t' + f.Price.ToString();
                temp.Add(str);
            }
            File.Delete("tours.txt");
            File.AppendAllLines("tours.txt", temp);
        }
    }
    internal class TP
    {
        public List<Trips> trips = new List<Trips>();
        char[] d = { '\t' };
        public void Read_Trips()
        {
            string[] sc = File.ReadAllLines("trips.txt");
            foreach (string s in sc)
            {
                string[] sl = s.Split(d, StringSplitOptions.RemoveEmptyEntries);

                DateTime dd = DateTime.Parse(sl[1]);
                Trips cc = new Trips (int.Parse(sl[0]), dd , int.Parse(sl[2]), int.Parse(sl[3]), int.Parse(sl[4]));
                trips.Add(cc);
            }
        }
        public void Save_Tours()
        {
            var temp = new List<string>();
            foreach (Trips k in trips)
            {
                string str = k.Id_tour.ToString() + '\t'
                    + k.Data_trip.ToString().Substring(0, 10) + '\t'
                    + k.Fk_client.ToString() + '\t' + k.Fk_trip.ToString() +'\t' + k.Days.ToString();

                temp.Add(str);
            }
            File.Delete("trips.txt");
            File.AppendAllLines("trips.txt", temp);
        }
    }
}
