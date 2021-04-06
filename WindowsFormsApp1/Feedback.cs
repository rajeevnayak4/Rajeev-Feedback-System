using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Feedback : Form
    {

        AdminRating af = new AdminRating();
        AdminCriteria ac = new AdminCriteria();
        CustomerReview cr = new CustomerReview();

        public bool checks;

        // checks is to valid and display either default critera and rating or critera and rating given by admin. 
        public Feedback(bool a)
        {
            checks = a;
            InitializeComponent();
        }


        private void Customer_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            if (checks == true)
            {

                table.Columns.Add("Criteria", typeof(string));

                // Ratings
                table.Columns.Add("Excellent", typeof(bool));
                table.Columns.Add("Good", typeof(bool));
                table.Columns.Add("Average", typeof(bool));
                table.Columns.Add("Dissatisfied", typeof(bool));
                custGrid.DataSource = table;
                custGrid.AutoResizeColumns();

                //criteria
                List<AdminCriteria> listReview = ac.CriteriaList("D:\\Islington\\Final Year\\Application Development\\Coursework 1(Feedback System)\\18030011 Rajiv Kumar Nayak\\him.txt");
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(AdminCriteria));
                foreach (var item in listReview)
                {
                    foreach (PropertyDescriptor prop in properties)
                    {
                        DataRow row = table.NewRow();
                        row["Criteria"] = (string)prop.GetValue(item);
                        table.Rows.Add(row);
                    }
                }
                custGrid.DataSource = table;
                custGrid.AutoResizeColumns();
            }
            else
            {
                // for default criteria and ratings.
                //  column name for table.
                table.Columns.Add("Criteria");


                //for default Rating
                List<AdminRating> listReviews = af.RatingList("D:\\Islington\\Final Year\\Application Development\\Coursework 1(Feedback System)\\18030011 Rajiv Kumar Nayak\\him1.txt");
                PropertyDescriptorCollection propertiess = TypeDescriptor.GetProperties(typeof(AdminRating));
                foreach (var item in listReviews)
                {
                    foreach (PropertyDescriptor prop in propertiess)
                    {
                        table.Columns.Add((string)prop.GetValue(item), typeof(bool));
                    }
                }
                custGrid.DataSource = table;
                custGrid.AutoResizeColumns();

                //for default criteria
                List<AdminCriteria> listReview = ac.CriteriaList("D:\\Islington\\Final Year\\Application Development\\Coursework 1(Feedback System)\\18030011 Rajiv Kumar Nayak\\him2.txt");
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(AdminCriteria));

                foreach (var item in listReview)
                {
                    foreach (PropertyDescriptor prop in properties)
                    {
                        DataRow row = table.NewRow();
                        row["Criteria"] = (string)prop.GetValue(item);
                        table.Rows.Add(row);
                    }
                }
                custGrid.DataSource = table;
                custGrid.AutoResizeColumns();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            bool check = true;
            DataTable dt = (DataTable)custGrid.DataSource; // collect data from the customer gridview.
            // customer check
            if (txtCustomerName.Text == "" || txtContactNumber.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Fill the form");
                check = false;
            }
            

            // to check if the gridview check box is selected or not
            string GridData = " ";
            if (check == true)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int counts = 0;
                    for (int j = 1; j < dt.Columns.Count; j++)
                    {
                        GridData = dt.Rows[i].ItemArray[j].ToString();
                        if (GridData == "True")
                        {
                            counts++;
                        }
                        if (counts == 1)
                        {
                            break;
                        }
                    }

                    if (counts == 0)
                    {
                        MessageBox.Show("Rating not selected");
                        check = false;
                        break;
                    }
                }
            }

            // it executes when the above validation is successful.
            if (check == true)
            {
                cr.CustomerName = txtCustomerName.Text;
                cr.CustomerContact = txtContactNumber.Text;
                cr.CustomerEmail = txtEmail.Text;
                cr.DateTime = DateTime.Now.ToString();

                // creating new table to allocate rating with the respective value.
                DataTable dtRating = new DataTable();
                dtRating.Columns.Add("Rating", typeof(string));
                dtRating.Columns.Add("Rate", typeof(int));
                DataRow dr = dtRating.NewRow();
                dr["Rating"] = "Excellent";
                dr["Rate"] = "5";
                dtRating.Rows.Add(dr);
                dr = dtRating.NewRow();
                dr["Rating"] = "Good";
                dr["Rate"] = "3";
                dtRating.Rows.Add(dr);
                dr = dtRating.NewRow();
                dr["Rating"] = "Average";
                dr["Rate"] = "2";
                dtRating.Rows.Add(dr);
                dr = dtRating.NewRow();
                dr["Rating"] = "Dissatisfied";
                dr["Rate"] = "1";
                dtRating.Rows.Add(dr);


                // it is to check the selected criteria and assigning the respective values.

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 1; j < dt.Columns.Count; j++)
                    {

                        string s = dt.Rows[i].ItemArray[j].ToString(); // true /false value.
                        if (s == "True")
                        {
                            string columnNames = dt.Columns[j].ToString(); //column name
                            string rowsName = dt.Rows[i][0].ToString(); // name of row.

                            int rate = 0;
                            // datarow represent the row of data
                            DataRow[] result = dtRating.Select("Rating='" + columnNames + "'"); // retrive the rate for the selected column name

                            if (result.Length > 0)   // it gives the rating according to the columnname selected.
                            {
                                rate = Convert.ToInt32(result[0].ItemArray[1]);
                            }

                            switch (rowsName)
                            {
                                case "Food Quality":
                                    cr.Food_Quality = rate;
                                    break;
                                case "Staff Friendliness":
                                    cr.Staff_Friendliness = rate;
                                    break;
                                case "Cleanliness":

                                    cr.Cleanliness = rate;

                                    break;
                                case "Order Accuracy":
                                    cr.Order_Accuracy = rate;

                                    break;
                                case "Restaurant Ambiance":
                                    cr.Restaurant_Ambiance = rate;

                                    break;
                                case "Value Of Money":
                                    cr.Value_of_Money = rate;

                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                string flag = cr.SaveReview(cr);  // it is save customer review in the file
                MessageBox.Show("Thankyou for Rating.");
                if (flag == "success")
                {
                    txtCustomerName.Text = "";
                    txtContactNumber.Text = "";
                    txtEmail.Text = "";
                    foreach (DataGridViewRow row in custGrid.Rows)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                            if (row.Cells[i].Value.ToString() == "True")
                            {
                                row.Cells[i].Value = false;
                            }
                    }
                }


            }
        }


     

        // for checking when clicked on the gridview cell.
        private void custGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int count = 0;
            int index = 0;
            if (e.ColumnIndex > 0)
            {
                foreach (DataGridViewRow row in custGrid.Rows) // food quality, false, false, false, false
                {
                    if (row.Index == e.RowIndex)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                            if (row.Cells[i].Value.ToString() == "True")
                            {
                                count++;
                                index = i;
                            }
                        if (count >= 1)
                        {
                            row.Cells[index].Value = false;
                            break;
                        }
                    }

                }

            }

        }

        // for character only
        private void txtCustomerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //for number only
        private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // it checks after the email is typed in the textbox.
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text != null)
            {
                Regex Email = new Regex("^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");
                if (!Email.IsMatch(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Invalid Email");
                }
            }
        }

        private void custGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void otherBtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}







