using Newtonsoft.Json;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    class AdminRating
    {


        public string Rating { get; set; }



        public List<AdminRating> RatingList(string Path)  // read data from the files(byte stream) and converts bytes into objects and return the list of the objects.
        {
            string d = Utility.ReadFromTextFile(Path);
            if (d != null)
            {
                List<AdminRating> lst = JsonConvert.DeserializeObject<List<AdminRating>>(d); // to reads object from byte stream
                return lst;
            }
            return null;
        }

    }
}
