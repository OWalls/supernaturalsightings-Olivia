using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.CodeAnalysis;
using supernaturalsightings_olivia.Models;
//using Location = supernaturalsightings_olivia.Models.Location;

namespace supernaturalsightings_olivia.Areas.Identity.Data
{
	public class EntityData
	{
        private static readonly string DATA_FILE = "Areas/Identity/Data/entities.csv";

        static bool IsDataLoaded;

        static List<Entity> AllEntities;
        static private List<Entity> AllNames = new List<Entity>();
        static private List<Entity> AllCities = new List<Entity>();
        static private List<Entity> AllStates = new List<Entity>();
        static private List<Entity> AllDescriptions = new List<Entity>();
        static private List<Entity> AllTypes = new List<Entity>();

        //returns all the data from the file
        static public List<Entity> FindAll()
        {
            LoadData();

            return new List<Entity>(AllEntities);
        }

        //lets you search for a specific value in a specified category
        static public List<Entity> FindByColumnAndValue(string column, string value)
        {
            LoadData();

            List<Entity> entities = new List<Entity>();

            if (value.ToLower().Equals("all"))
            {
                return FindAll();
            }

            if (column.Equals("all"))
            {
                entities = FindByValue(value);
                return entities;
            }

            for (int i = 0; i < AllEntities.Count; i++)
            {
                Entity entity = AllEntities[i];
                string aValue = GetValue(entity, column);

                if (aValue != null && aValue.ToLower().Contains(value.ToLower()))
                {
                    entities.Add(entity);
                }
            }

            return entities;
        }

        //lets you search by property - used in the FindByColumnAndValue function above.
        static public string GetValue(Entity entity, string category)
        {
            string theValue;

            if (category.Equals("name"))
            {
                theValue = entity.Name;
            }
            else if (category.Equals("city"))
            {
                theValue = entity.City;
            }
            else if (category.Equals("state"))
            {
                theValue = entity.State;
            }
            else if (category.Equals("description"))
            {
                theValue = entity.Description;
            }
            else
            {
                theValue = entity.Type;
            }

            return theValue;
        }

        //loops through each entity to look for a search term - used in the FindByColumnAndValue function.
        static public List<Entity> FindByValue(string value)
        {

            LoadData();

            List<Entity> entities = new List<Entity>();

            for (int i = 0; i < AllEntities.Count; i++)
            {

                if (AllEntities[i].Name.ToLower().Contains(value.ToLower()))
                {
                    entities.Add(AllEntities[i]);
                }
                else if (AllEntities[i].City.ToLower().Contains(value.ToLower()))
                {
                    entities.Add(AllEntities[i]);
                }
                else if (AllEntities[i].State.ToLower().Contains(value.ToLower()))
                {
                    entities.Add(AllEntities[i]);
                }
                else if (AllEntities[i].Description.ToLower().Contains(value.ToLower()))
                {
                    entities.Add(AllEntities[i]);
                }
                else if (AllEntities[i].Type.ToLower().Contains(value.ToLower()))
                {
                    entities.Add(AllEntities[i]);
                }

            }

            return entities;
        }

        //used in LoadData below to create a new Location object
        //static private object FindExistingObject(List<Entity> objectList, string value1, string value2)
        //{
        //    for (int i = 0; i < objectList.Count; i++)
        //    {
        //        object item = objectList[i];

        //        if (item.ToString().ToLower().Equals(value1.ToLower()))
        //        {
        //            return item;
        //        }
        //    }
        //    return null;
        //}

        //loads data from the csv file
        static private void LoadData()
        {
            //check to make sure there's data
            if (AllEntities == null || AllEntities.Count == 0)
            {
                IsDataLoaded = false;
            }

            if (IsDataLoaded)
            {
                return;
            }

            //grab all of the rows out of the spreadsheet
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

            //put the headers in their own array and out of the way
            string[] headers = rows[0];
            rows.Remove(headers);

            AllEntities = new List<Entity>();

            //loop through the rows of data, transforming them into Entities and add them to a list
            for (int i = 0; i < rows.Count; i++)
            {
                string[] row = rows[i];
                string aName = row[0];
                string aCity = row[1];
                string aState = row[2];
                string aDescription = row[3];
                string aType = row[4];

                //Location newLocation = (Location)FindExistingObject(AllLocations, aCity, aState);

                Entity newEntity = new Entity(aName, aCity, aState, aDescription, aType);

                AllEntities.Add(newEntity);
            }

            IsDataLoaded = true;
        }

        //transforms the rows in the csv into an array of strings - used in the LoadData function
        private static string[] CSVRowToStringArray(string row, char fieldSeparator = ',', char stringSeparator = '\"')
        {
            bool isBetweenQuotes = false;
            StringBuilder valueBuilder = new StringBuilder();
            List<string> rowValues = new List<string>();

            //loops through one char at a time looking for separators
            for (int i = 0; i < row.ToCharArray().Length; i++)
            {
                char c = row.ToCharArray()[i];

                if ((c == fieldSeparator && !isBetweenQuotes))
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

            rowValues.Add(valueBuilder.ToString());
            valueBuilder.Clear();

            return rowValues.ToArray();
        }

        //use this to display all the Entities
        static public List<Entity> GetAllEntities()
        {
            LoadData();
            AllEntities.Sort(new DataSorter());
            return AllEntities;
        }

        //use this to display all Name values (not sure if we need this, really, but I made it in case)
        static public List<Entity> GetAllNames()
        {
            LoadData();
            AllNames.Sort(new DataSorter());
            return AllNames;
        }

        //formerly the GetAllLocations method
        static public List<Entity> GetAllCities()
        {
            LoadData();
            AllCities.Sort(new DataSorter());
            return AllCities;
        }

        static public List<Entity> GetAllStates()
        {
            LoadData();
            AllStates.Sort(new DataSorter());
            return AllStates;
        }

        //use this to display all descriptions.
        static public List<Entity> GetAllDescriptions()
        {
            LoadData();
            AllDescriptions.Sort(new DataSorter());
            return AllDescriptions;
        }

        //use this to display all Types... all 3 of them!
        static public List<Entity> GetAllTypes()
        {
            LoadData();
            AllTypes.Sort(new DataSorter());
            return AllTypes;
        }

    }

}


