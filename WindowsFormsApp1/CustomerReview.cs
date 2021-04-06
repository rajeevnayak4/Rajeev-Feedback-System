using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace WindowsFormsApp1
{
    class CustomerReview
    {
        string path = "D:\\Islington\\Final Year\\Application Development\\Coursework 1(Feedback System)\\18030011 Rajiv Kumar Nayak\\him12.txt";

        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerGender { get; set; }

        public String DateTime { get; set; }

        public int Food_Quality { get; set; }

        public int Staff_Friendliness { get; set; }

        public int Cleanliness { get; set; }

        public int Order_Accuracy { get; set; }
        public int Restaurant_Ambiance { get; set; }

        public int Value_of_Money { get; set; }

        // it is to save the customer review in the file.
        public string SaveReview(CustomerReview cr)
        {

            string data = JsonConvert.SerializeObject(cr, Formatting.None);
            Utility.WriteToTextFile(path, data);
            return "success";
        }

        // it is to read the customer review from the file.
        public List<CustomerReview> CustomerList()
        {
            string d = Utility.ReadFromTextFile(path);
            if (d != null)
            {
                List<CustomerReview> lst = JsonConvert.DeserializeObject<List<CustomerReview>>(d);
                return lst;
            }
            return null;
        }

    }
}
