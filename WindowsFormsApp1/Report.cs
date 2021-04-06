using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Linq;

namespace WindowsFormsApp1
{
    public partial class Report : Form
    {
        DataTable dt = new DataTable();
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            CustomerReview cr = new CustomerReview();
            List<CustomerReview> customerReviews = cr.CustomerList();
            DataTable dt = Utility.ConvertToDataTable(customerReviews);
            customerReviewGrid.DataSource = dt;
            customerReviewGrid.AutoResizeColumns();


            foreach (DataGridViewColumn column in customerReviewGrid.Columns)  // to disable the column sorting.
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        // to show the admin panel from report panel
        private void adminPanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 a = new Form2();
            a.Show();
        }


        // ascending sorting
        private void SortUpBtn_Click(object sender, EventArgs e)
        {
            List<string> Name = new List<string>();
            CustomerReview cr = new CustomerReview();
            List<CustomerReview> customerReviews = cr.CustomerList();
            string temp;
            List<CustomerReview> sortList = new List<CustomerReview>();


            var res = customerReviews.Select(x => x.CustomerName).ToList(); // collects all the names of customer

            for (int i = 0; i < customerReviews.Count; i++) // to sort the name in ascending order
            {
                for (int j = 0; j < customerReviews.Count - 1; j++)
                {

                    if (res[j].CompareTo(res[j + 1]) > 0)
                    {
                        temp = res[j + 1];
                        res[j + 1] = res[j];
                        res[j] = temp;
                    }
                }
            }

            for (int i = 0; i < customerReviews.Count; i++) // to add the sorted value in the new list to display in grid view
            {
                for (int j = 0; j < customerReviews.Count; j++)
                {
                    if (customerReviews[j].CustomerName.Equals(res[i]))
                    {
                        sortList.Add(customerReviews[j]);
                        break;
                    }
                }
            }

            DataTable dt = Utility.ConvertToDataTable(sortList);
            customerReviewGrid.Refresh();
            customerReviewGrid.DataSource = dt;

        }


        //descending soring
        

        private void customerReviewGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            Chart ad = new Chart();
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

