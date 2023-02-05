//using Google.Apis.SecretManager.v1.Data;
using supernaturalsightings_olivia.Areas.Identity.Data;

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
    public class RandomLocationListModel : EntityData
    {
        public string State { get; set; }
        public string City { get; set; }
    }
}