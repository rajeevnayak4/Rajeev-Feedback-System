using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp1
{
    class AdminCriteria
    {
        public string Criteria { get; set; }

        public void saveCriteria(AdminCriteria ac, string Path)  // converts data to the json serialize object and call the writetotextfile method to store in the file.
        {

            string data = Newtonsoft.Json.JsonConvert.SerializeObject(ac, Formatting.None);  // coverting object into bytes stream
            Utility.WriteToTextFile(Path, data);
        }

        public List<AdminCriteria> CriteriaList(string Path)   // read data from the files(byte stream) and converts bytes into objects and return the list of the objects.
        {
            string d = Utility.ReadFromTextFile(Path);
            if (d != null)
            {
                List<AdminCriteria> lst = JsonConvert.DeserializeObject<List<AdminCriteria>>(d);  // to reads object from byte stream
                return lst;
            }
            return null;
        }
    }
}
