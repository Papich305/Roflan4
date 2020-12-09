using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Papich4
{
    public partial class Form1 : Form
    {
        List<TS> TSsList = new List<TS>();
        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void btnRefill_Click(object sender, EventArgs e)
        {
            this.TSsList.Clear();
            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3)
                {
                    case 0:
                        this.TSsList.Add(Bike.Generate ());
                        break;
                    case 1:
                        this.TSsList.Add(Car.Generate ());
                        break;
                    case 2:
                        this.TSsList.Add(Air.Generate ());
                        break;
                }
            }
            ShowInfo();
        }

        private void ShowInfo()
        {
            int velsCount = 0;
            int avtosCount = 0;
            int airsCount = 0;

            foreach (var typ in this.TSsList)
            {
                if (typ is Bike)
                {
                    velsCount += 1;
                }
                else if (typ is Car)
                {
                    avtosCount += 1;
                }
                else if (typ is Air)
                {
                    airsCount += 1;
                }
            }
            txtInfo.Text = "Велосипед Автомобиль Самолёт";
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("        {0}                   {1}                {2}", velsCount, avtosCount, airsCount);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (this.TSsList.Count == 0)
            {
                txtOut.Text = "Транспорта больше нет";
                pictureBox1.Image = imageList1.Images[3];
                return;
            }

            var tp = this.TSsList[0];
            string str = TSsList[0].ToString();
            string[] words = str.Split('.');
            foreach (var word in words)
            {
                if (words[1] == "Bike")
                {
                    pictureBox1.Image = imageList1.Images[2];
                }
                else
                {
                    if (words[1] == "Car")
                    {
                        pictureBox1.Image = imageList1.Images[1];
                    }
                    else
                    {
                        pictureBox1.Image = imageList1.Images[0];
                    }
                }
            }

                this.TSsList.RemoveAt(0);

            txtOut.Text = tp.GetInfo();

            ShowInfo();
        }
    }
}
