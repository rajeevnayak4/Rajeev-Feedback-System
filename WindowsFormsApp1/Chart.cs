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
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
            BindChart();
        }

        private void BindChart()
        {
            CustomerReview cr = new CustomerReview();
            List<CustomerReview> customerReviews = cr.CustomerList();

            if (comChart.Text == "Food Quality")
            {
                var chartResult = customerReviews.GroupBy(x => x.Food_Quality)
                   .Select(l => new  // dynamic object

                   {
                       FoodQuality = l.First().Food_Quality,
                       count = l.Count()
                   }).ToList();

                foreach (var item in chartResult)
                {
                    chart2.Series["Customers"].Points.AddXY(item.FoodQuality.ToString(), item.count);
                }

                chart2.Titles.Add("Food Quality");

            }
            else if (comChart.Text == "Cleanliness")
            {
                var chartResult = customerReviews.GroupBy(x => x.Cleanliness)
                    .Select(l => new
                    {
                        Cleanliness = l.First().Cleanliness,
                        count = l.Count()
                    }).ToList();

                foreach (var item in chartResult)
                {
                    chart2.Series["Customers"].Points.AddXY(item.Cleanliness.ToString(), item.count);
                }

                chart2.Titles.Add("Cleanliness");
            }
            else if (comChart.Text == "Staff Friendliness")
            {
                var chartResult = customerReviews.GroupBy(x => x.Staff_Friendliness)
                    .Select(l => new
                    {
                        StaffFriendliness = l.First().Staff_Friendliness,
                        count = l.Count()
                    }).ToList();

                foreach (var item in chartResult)
                {
                    chart2.Series["Customers"].Points.AddXY(item.StaffFriendliness.ToString(), item.count);
                }

                chart2.Titles.Add("Staff Friendliness");

            }
            else if (comChart.Text == "Value Of Money")
            {
                var chartResult = customerReviews.GroupBy(x => x.Value_of_Money)
                    .Select(l => new
                    {
                        ValueOfMoney = l.First().Value_of_Money,
                        count = l.Count()
                    }).ToList();

                foreach (var item in chartResult)
                {
                    chart2.Series["Customers"].Points.AddXY(item.ValueOfMoney.ToString(), item.count);
                }

                chart2.Titles.Add("Value Of Money");

            }
            else if (comChart.Text == "Restaurant Ambiance")
            {
                var chartResult = customerReviews.GroupBy(x => x.Restaurant_Ambiance)
                    .Select(l => new
                    {
                        RestaurantAmbience = l.First().Restaurant_Ambiance,
                        count = l.Count()
                    }).ToList();

                foreach (var item in chartResult)
                {
                    chart2.Series["Customers"].Points.AddXY(item.RestaurantAmbience.ToString(), item.count);
                }

                chart2.Titles.Add("Restaurant Ambience");

            }
            else
            {
                var chartResult = customerReviews.GroupBy(x => x.Order_Accuracy)
                   .Select(l => new
                   {
                       OrderAccuracy = l.First().Order_Accuracy,
                       count = l.Count()
                   }).ToList();

                foreach (var item in chartResult)
                {
                    chart2.Series["Customers"].Points.AddXY(item.OrderAccuracy.ToString(), item.count);
                }

                chart2.Titles.Add("Order Accuracy");

            }
            chart2.ChartAreas[0].AxisX.Title = "Rating";


        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        
            private void criteriaSearch_Click(object sender, EventArgs e)
            {
                if (comChart.SelectedIndex < 0)
                {
                    MessageBox.Show("Select the Criteria");
                }
                else
                {
                    chart2.Series[0].Points.Clear(); 
                    chart2.Titles.Clear();
                    BindChart();
                }
            }

        private void Chart1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 ad = new Form2();
            ad.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report ad = new Report();
            ad.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminCheck ad = new AdminCheck();
            ad.Show();
        }
    }
}
