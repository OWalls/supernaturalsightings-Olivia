using Microsoft.CodeAnalysis;
using System.Xml.Linq;

namespace supernaturalsightings_olivia.Models;

public class Review
{
    public int Id { get; set; }
    static private int nextId = 1;

    public string Username { get; set; } //name
    public Location Location { get; set; }
    public string Description { get; set; }
    public EncounterType EncounterType { get; set; } //positionType
    public int ReviewId { get; set; } //
    public ReviewCategory ReviewCategory { get; set; } //coreCompetency

    public Review()
    {
        Id = nextId;
        nextId++;

    }
    public Review(string username, Location location, EncounterType encounterType, ReviewCategory reviewCategory) : this()
    {
        Username = username;
        Location = location;
        EncounterType = encounterType;
        ReviewCategory = reviewCategory;

    }

    public override string ToString()
    {
        string output = " ";
        if (Username.Equals(" "))
        {
            Username = "Data not available";
        }
        if (Location.Value.Equals("") || Location.Value == null)
        {
            Location.Value = "Data not available";

        }
        if (ReviewCategory.Value.Equals("") || ReviewCategory.Value == null)
        {
            ReviewCategory.Value = "Data not available";
        }
        if (EncounterType.Value.Equals("") || EncounterType.Value == null)
        {
            EncounterType.Value = "Data not available";
        }

        output = string.Format("\nID: %d\n" +
                "Username: %s\n" +
                "Entity: %s\n" +
                "Location: %s\n" +
                "Encounter Type: %s\n" +
                "Review Category: %s\n", Id, Username, Location, EncounterType, ReviewCategory);
        return output;
    }

    public override bool Equals(object? obj)
    {
        return obj is Review review &&
               Id == review.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

}
