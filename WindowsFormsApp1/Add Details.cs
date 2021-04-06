using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;



namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {

        string cPath = "D:\\Islington\\Final Year\\Application Development\\Coursework 1(Feedback System)\\18030011 Rajiv Kumar Nayak\\him.txt";
        DataTable table = new DataTable();
        List<string> criteria = new List<string>();
        bool forCheck = false;


        public Form2()
        {
            InitializeComponent();
            
        }




        // it is for criteria.
        private void btnCriteria_Click(object sender, EventArgs e)
        {
            string check = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCriteria.Text).Trim();

            // check if the given value is empty  or repeated and if not, it saves in the files and display in the grid view. 
            if (string.IsNullOrEmpty(check))
            {
                MessageBox.Show("Please Type the Criteria");
            }
            else if (!(check.Equals("Food Quality") || check.Equals("Cleanliness") || check.Equals("Order Accuracy") || check.Equals("Restaurant Ambiance") || check.Equals("Staff Friendliness") || check.Equals("Value Of Money")))
            {
                MessageBox.Show("Error: Incorrect spelling Criteria.");
            }
            else if (criteria.Contains(check))
            {

                MessageBox.Show("This Criteria already exists: " + check);
            }
            else
            {
                AdminCriteria ac = new AdminCriteria();
                ac.Criteria = check;


                // to convert object to byte stream.
                ac.saveCriteria(ac, cPath);

                // to show in the gridview.
                List<AdminCriteria> listReview = ac.CriteriaList(cPath);

                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(AdminCriteria));
                DataRow row = table.NewRow();
                foreach (var item in listReview)
                {
                    foreach (PropertyDescriptor prop in properties) // criteria
                    {
                        string rowName = (string)prop.GetValue(item); // name of row


                        DataRow[] rowExist = table.Select("Criteria = '" + rowName + "'");
                        if (rowExist.Length == 0)
                        {
                            row["Criteria"] = (string)prop.GetValue(item);
                            table.Rows.Add(row);
                        }
                    }
                }

                GridAdmin.DataSource = table;
                GridAdmin.AutoResizeColumns();
                criteria.Add(check);
                txtCriteria.Text = "";
                forCheck = true;
            }

        }



        // it is to show the customer panel when clicked on submit button.
        private void adminBtn_Click_1(object sender, EventArgs e)
        {
            String criteria = txtCriteria.Text;
            if (forCheck == false)
            {
                MessageBox.Show("Error: no criteria added.");
            }
            else
            {
                this.Hide();
                Feedback cs = new Feedback(true);
                cs.Show();

            }
        }

        // it is to empty the files of rating and criteria when loading the admin panel and adding the constant column. 
        private void AdminForm_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Criteria", typeof(string));
            table.Columns.Add("Excellent", typeof(string));
            table.Columns.Add("Good", typeof(string));
            table.Columns.Add("Average", typeof(string));
            table.Columns.Add("Dissatisfied", typeof(string));

            // to empty the file when loading the admin form
            File.WriteAllText(cPath, string.Empty);
        }


        

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Report ac = new Report();
            ac.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chart ac = new Chart();
            ac.Show();
        }

        private void reports()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CRITERIA");
            dt.Columns.Add("TOTAL RATING");

            CustomerReview cr = new CustomerReview();
            List<CustomerReview> customerReviews = cr.CustomerList();
            if (customerReviews.Count != 0)
            {


                var result = customerReviews.GroupBy(x => x != null) // grouping with not null in order to add the ratings
                            .Select(l => new
                            {
                                Cleanliness = l.Sum(x => x.Cleanliness),
                                Food_Quality = l.Sum(x => x.Food_Quality),
                                Order_Accuracy = l.Sum(x => x.Order_Accuracy),
                                Restaurant_Ambiance = l.Sum(x => x.Restaurant_Ambiance),
                                Staff_Friendliness = l.Sum(x => x.Staff_Friendliness),
                                Value_of_Money = l.Sum(x => x.Value_of_Money)
                            }).ToList();


                DataRow rows = dt.NewRow();
                rows["CRITERIA"] = "Food QUALITY";
                rows["TOTAL RATING"] = result[0].Food_Quality;
                dt.Rows.Add(rows);

                rows = dt.NewRow();
                rows["CRITERIA"] = "CLEANLINESS";
                rows["TOTAL RATING"] = result[0].Cleanliness;
                dt.Rows.Add(rows);

                rows = dt.NewRow();
                rows["CRITERIA"] = "ORDER ACCURACY";
                rows["TOTAL RATING"] = result[0].Order_Accuracy;
                dt.Rows.Add(rows);

                rows = dt.NewRow();
                rows["CRITERIA"] = "RESTAURANT AMBIANCE";
                rows["TOTAL RATING"] = result[0].Restaurant_Ambiance;
                dt.Rows.Add(rows);

                rows = dt.NewRow();
                rows["CRITERIA"] = "STAFF FRIENDLINESS";
                rows["TOTAL RATING"] = result[0].Staff_Friendliness;
                dt.Rows.Add(rows);

                rows = dt.NewRow();
                rows["CRITERIA"] = "VALUE OF MONEY";
                rows["TOTAL RATING"] = result[0].Value_of_Money;
                dt.Rows.Add(rows);
                //overAllReportGrid.DataSource = dt;
                //overAllReportGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void homeAdmin_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminCheck ad = new AdminCheck();
            ad.Show();
        }
    }
}





