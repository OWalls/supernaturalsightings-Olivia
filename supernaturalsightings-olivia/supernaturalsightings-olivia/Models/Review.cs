﻿using Microsoft.CodeAnalysis;
using System.Xml.Linq;


namespace supernaturalsightings_olivia.Models;

public class Review //: Entity
{
    //Changed Id to EntityId -Tanya
  //  public int EntityId { get; set; }
    // static private int nextId = 1;
    //State from Entity
    public int Id { get; set; }
    public string Username { get; set; } //name
    public string ReviewTitle { get; set; }
    public string ReviewComment { get; set;}
  //  public List<WeirdRating> WeirdRatings { get; set; }

   // public int ReviewId { get; set; } //
  //  public ReviewCategory ReviewCategory { get; set; } //coreCompetency

    public Review()
    {

    }
    public Review(string username, string reviewTitle, string reviewComment) : this() //ReviewCategory newReviewCategory
    {
        Username = username;
        ReviewTitle = reviewTitle;
        ReviewComment = reviewComment;
      //  ReviewCategory = newReviewCategory;

    }

    //public Review(string aUsername, Location newLocation, EncounterType newEncounterType, ReviewCategory newReviewCategory)
    //{
    //}

    public override string ToString()
    {
        string output = " ";
        if (Username.Equals(" "))
        {
            Username = "Data not available";
    
        }
       // if (ReviewCategory.Value.Equals("") || ReviewCategory.Value == null)
       // {
       //     ReviewCategory.Value = "Data not available";
     

        output = string.Format("\nID: %d\n" +
                "Username: %s\n" +
                "Review Title: %s\n" +
                "Review Comment: %s\n" + Id, Username, ReviewTitle, ReviewComment);// ReviewCategory);
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
