using Google.Apis.SecretManager.v1.Data;

//namespace supernaturalsightings_olivia.Models
//{
//    public class RandomLocationListModel
//    {
//        public string State { get; set; }
//        public string City { get; set; }
//    }
//}

namespace supernaturalsightings_olivia
{
    class RandomLocationListModel : Location
    {
        public string State { get; set; }
        public string City { get; set; }
    }
}