using System;
using Newtonsoft.Json.Linq;

namespace supernaturalsightings_olivia.Models
{
	public class Location
	{
		public string City { get; set; }
		public string State { get; set; }

		public Location(string city, string state)
		{
			City = city;
			State = state;
		}

        public override string ToString()
        {
            return City + ", " + State;
        }
    }
}

