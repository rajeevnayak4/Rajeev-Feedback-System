using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;


namespace WindowsFormsApp1
{
    class Utility
    {
        public static void WriteToTextFile(string path, string data, bool append = true, int count = 1) // for writing to the file.
        {
            if (!File.Exists(path))
            {
                var file = File.Create(path);
                file.Close();
            }

            // Stream = continuous flow of data.
            using (StreamWriter writer = new StreamWriter(path, append: append))
            {

                if (count != 0)
                {
                    data = data + ",";
                }

                writer.WriteLine(data);


            }
        }


        public static string ReadFromTextFile(string path)   // for reading the file.
        {
            if (File.Exists(path))
            {
                string data;
                using (StreamReader r = new StreamReader(path))
                {
                    data = r.ReadToEnd();
                }
                if (data != " ")
                {
                    data = "[" + data + "]";
                }
                return data;
            }

            return null;
        }

        // only to bind the  reports in grid.
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            DataTable dt = new DataTable();
            PropertyDescriptorCollection propertiess = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in propertiess)
                dt.Columns.Add(prop.Name);

            if (data != null)
            {
                foreach (var item in data)
                {
                    DataRow row = dt.NewRow();
                    foreach (PropertyDescriptor prop in propertiess)
                        row[prop.Name] = prop.GetValue(item);
                    dt.Rows.Add(row);
                }
            }

            return dt;
        }


    }

}
