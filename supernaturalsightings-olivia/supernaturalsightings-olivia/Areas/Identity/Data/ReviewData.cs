using supernaturalsightings_olivia.Areas.Identity.Data;
using supernaturalsightings_olivia.Models;
using System.Text;

namespace supernaturalsightings_olivia.Areas.Identity.Data
{
    public class ReviewData
    {
        static private string DATA_FILE = "entities.csv";

        static bool IsDataLoaded;

        static List<Review> AllReviews;
        static private List<ReviewField> AllUsername = new();
        static private List<ReviewField> AllLocations = new();
        static private List<ReviewField> AllEncounterTypes = new();
        static private List<ReviewField> AllReviewCategories = new();

        static public List<Review> FindAll()
        {
            LoadData();

            return new List<Review>(AllReviews);
        }

        static public List<Review> FindByColumnAndValue(string column, string value)
        {

            // load data, if not already loaded
            LoadData();

            List<Review> reviews = new List<Review>();

            if (value.ToLower().Equals("all"))
            {
                return FindAll();
            }

            if (column.Equals("all"))
            {
                reviews = FindByValue(value);
                return reviews;
            }

            for (int i = 0; i < AllReviews.Count; i++)
            {
                Review review = AllReviews[i];
                string aValue = GetFieldValue(review, column);

                if (aValue != null && aValue.ToLower().Contains(value.ToLower()))
                {
                    reviews.Add(review);
                }
            }

            return reviews;
        }

        static public string GetFieldValue(Review review, string fieldName)
        {
            string theValue;
            if (fieldName.Equals("username"))
            {
                theValue = review.Username;
            }
            else if (fieldName.Equals("location"))
            {
                theValue = review.Location.ToString();
            }
            else if (fieldName.Equals("encounterType"))
            {
                theValue = review.EncounterType.ToString();
            }
            else
            {
                theValue = review.ReviewCategory.ToString();
            }

            return theValue;
        }

        static public List<Review> FindByValue(string value)
        {

            // load data, if not already loaded
            LoadData();

            List<Review> jobs = new List<Review>();

            for (int i = 0; i < AllReviews.Count; i++)
            {

                if (AllReviews[i].Username.ToLower().Contains(value.ToLower()))
                {
                    jobs.Add(AllReviews[i]);
                }
                else if (AllReviews[i].Location.ToString().ToLower().Contains(value.ToLower()))
                {
                    jobs.Add(AllReviews[i]);
                }
                else if (AllReviews[i].EncounterType.ToString().ToLower().Contains(value.ToLower()))
                {
                    jobs.Add(AllReviews[i]);
                }
                else if (AllReviews[i].ReviewCategory.ToString().ToLower().Contains(value.ToLower()))
                {
                    jobs.Add(AllReviews[i]);
                }

            }

            return jobs;
        }

        static private object FindExistingObject(List<ReviewField> fieldlist, string value)
        {
            for (int i = 0; i < fieldlist.Count; i++)
            {
                object item = fieldlist[i];
                if (item.ToString().ToLower().Equals(value.ToLower()))
                {
                    return item;
                }
            }
            return null;
        }

        static private void LoadData()
        {
            if (AllReviews == null || AllReviews.Count == 0)
            {
                IsDataLoaded = false;
            }

            if (IsDataLoaded)
            {
                return;
            }

            List<string[]> rows = new List<string[]>();


            using (StreamReader reader = File.OpenText(DATA_FILE))
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    string[] rowArray = CSVRowToStringArray(line);
                    if (rowArray.Length > 0)
                    {
                        rows.Add(rowArray);
                    }
                }
            }

            string[] headers = rows[0];
            rows.Remove(headers);

            AllReviews = new List<Review>();

            // Parse each row array 
            for (int i = 0; i < rows.Count; i++) // (string[] row in rows)
            {
                string[] row = rows[i];
                string aUsername = row[0];
                //string anEmployer = row[1];
                string aLocation = row[1];
                string aEncounterType = row[2];
                string aReviewCategory = row[3];


                Location newLocation = (Location)FindExistingObject(AllLocations, aLocation);
                EncounterType newEncounterType = (EncounterType)FindExistingObject(AllEncounterTypes, aEncounterType);
                ReviewCategory newReviewCategory = (ReviewCategory)FindExistingObject(AllReviewCategories, aReviewCategory);



                if (newLocation == null)
                {
                    newLocation = new Location(aLocation);
                    AllLocations.Add(newLocation);
                }

                if (newEncounterType == null)
                {
                    newEncounterType = new EncounterType(aEncounterType);
                    AllEncounterTypes.Add(newEncounterType);
                }

                if (newReviewCategory == null)
                {
                    newReviewCategory = new ReviewCategory(aReviewCategory);
                    AllReviewCategories.Add(newReviewCategory);
                }

                Review newReview = new Review(aUsername, newLocation, newEncounterType, newReviewCategory);

                AllReviews.Add(newReview);
            }

            IsDataLoaded = true;
        }

        private static string[] CSVRowToStringArray(string row, char fieldSeparator = ',', char stringSeparator = '\"')
        {
            bool isBetweenQuotes = false;
            StringBuilder valueBuilder = new StringBuilder();
            List<string> rowValues = new List<string>();

            // Loop through the row string one char at a time
            for (int i = 0; i < row.ToCharArray().Length; i++) // (char c in row.ToCharArray())
            {
                char c = row.ToCharArray()[i];

                if (c == fieldSeparator && !isBetweenQuotes)
                {
                    rowValues.Add(valueBuilder.ToString());
                    valueBuilder.Clear();
                }
                else
                {
                    if (c == stringSeparator)
                    {
                        isBetweenQuotes = !isBetweenQuotes;
                    }
                    else
                    {
                        valueBuilder.Append(c);
                    }
                }
            }

            // Add the final value
            rowValues.Add(valueBuilder.ToString());
            valueBuilder.Clear();

            return rowValues.ToArray();
        }



        static public List<ReviewField> GetAllLocations()
        {
            LoadData();
            AllLocations.Sort(new UsernameSorter());
            return AllLocations;
        }

        static public List<ReviewField> GetAllPositionTypes()
        {
            LoadData();
            AllEncounterTypes.Sort(new UsernameSorter());
            return AllEncounterTypes;
        }

        static public List<ReviewField> GetAllReviewCategories()
        {
            LoadData();
            AllReviewCategories.Sort(new UsernameSorter());
            return AllReviewCategories;
        }

        internal static List<ReviewField> GetAllUsernames()
        {
            throw new NotImplementedException();
        }

        internal static dynamic GetAllEncounterTypes()
        {
            throw new NotImplementedException();
        }
    }

}
