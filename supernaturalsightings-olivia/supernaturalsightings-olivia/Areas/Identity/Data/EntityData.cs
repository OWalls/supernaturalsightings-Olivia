//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;
//using Microsoft.CodeAnalysis;
//using supernaturalsightings_olivia.Models;
//using supernaturalsightings_olivia.Areas.Identity.Data;
//using Microsoft.EntityFrameworkCore;

//namespace supernaturalsightings_olivia.Areas.Identity.Data
//{
//    public class EntityData
//    {
//        private static readonly string DATA_FILE = "Areas/Identity/Data/entities.csv";

//        //static bool IsDataLoaded;

//        //static List<Entity> AllEntities;
//        //static private List<Entity> AllNames = new List<Entity>();
//        //static private List<Entity> AllCities = new List<Entity>();
//        //static private List<Entity> AllStates = new List<Entity>();
//        //static private List<Entity> AllDescriptions = new List<Entity>();
//        //static private List<Entity> AllTypes = new List<Entity>();

//        //returns all the data from the file
//        static public List<Entity> FindAll()
//        {
//            LoadData();

//            return new List<Entity>(DataParser.AllEntities);
//        }

//        //lets you search for a specific value in a specified category
//        //static public List<Entity> FindByColumnAndValue(string column, string value)
//        //{
//        //    LoadData();

//        //    List<Entity> entities = new List<Entity>();

//        //    if (value.ToLower().Equals("all"))
//        //    {
//        //        return FindAll();
//        //    }

//        //    if (column.Equals("all"))
//        //    {
//        //        entities = FindByValue(value);
//        //        return entities;
//        //    }

//        //    for (int i = 0; i < AllEntities.Count; i++)
//        //    {
//        //        Entity entity = AllEntities[i];
//        //        string aValue = GetValue(entity, column);

//        //        if (aValue != null && aValue.ToLower().Contains(value.ToLower()))
//        //        {
//        //            entities.Add(entity);
//        //        }
//        //    }

//        //    return entities;
//        //}

//        //lets you search by property - used in the FindByColumnAndValue function above.
//        static public string GetValue(Entity entity, string column)
//        {
//            string theValue;

//            if (column.Equals("name"))
//            {
//                theValue = entity.Name;
//            }
//            else if (column.Equals("city"))
//            {
//                theValue = entity.City;
//            }
//            else if (column.Equals("state"))
//            {
//                theValue = entity.State;
//            }
//            else if (column.Equals("description"))
//            {
//                theValue = entity.Description;
//            }
//            else
//            {
//                theValue = entity.Type;
//            }

//            return theValue;
//        }

//        //loops through each entity to look for a search term - used in the FindByColumnAndValue function.
//        static public List<Entity> FindByValue(string value)
//        {

//            LoadData();

//            List<Entity> entities = new List<Entity>();

//            for (int i = 0; i < AllEntities.Count; i++)
//            {

//                if (AllEntities[i].Name.ToLower().Contains(value.ToLower()))
//                {
//                    entities.Add(AllEntities[i]);
//                }
//                else if (AllEntities[i].City.ToLower().Contains(value.ToLower()))
//                {
//                    entities.Add(AllEntities[i]);
//                }
//                else if (AllEntities[i].State.ToLower().Contains(value.ToLower()))
//                {
//                    entities.Add(AllEntities[i]);
//                }
//                else if (AllEntities[i].Description.ToLower().Contains(value.ToLower()))
//                {
//                    entities.Add(AllEntities[i]);
//                }
//                else if (AllEntities[i].Type.ToLower().Contains(value.ToLower()))
//                {
//                    entities.Add(AllEntities[i]);
//                }

//            }

//            return entities;
//        }

       
//        //loads data from the csv file
//        static private void LoadData()
//        {
//            //check to make sure there's data
//            if (AllEntities == null || AllEntities.Count == 0)
//            {
//                IsDataLoaded = false;
//            }

//            if (IsDataLoaded)
//            {
//                return;
//            }

//            //grab all of the rows out of the spreadsheet
//            List<string[]> rows = new List<string[]>();

//            using (StreamReader reader = File.OpenText(DATA_FILE))
//            {
//                while (reader.Peek() >= 0)
//                {
//                    string line = reader.ReadLine();
//                    string[] rowArray = CSVRowToStringArray(line);
//                    if (rowArray.Length > 0)
//                    {
//                        rows.Add(rowArray);
//                    }
//                }
//            }

//            //put the headers in their own array and out of the way
//            string[] headers = rows[0];
//            rows.Remove(headers);

//            AllEntities = new List<Entity>();

//            //loop through the rows of data, transforming them into Entities and add them to a list
//            for (int i = 0; i < rows.Count; i++)
//            {
//                string[] row = rows[i];
//                string aName = row[0];
//                string aCity = row[1];
//                string aState = row[2];
//                string aDescription = row[3];
//                string aType = row[4];

//                //Location newLocation = (Location)FindExistingObject(AllLocations, aCity, aState);

//                Entity newEntity = new Entity(aName, aCity, aState, aDescription, aType);

//                AllEntities.Add(newEntity);
//            }

//            IsDataLoaded = true;
//        }

//        //transforms the rows in the csv into an array of strings - used in the LoadData function
//        private static string[] CSVRowToStringArray(string row, char fieldSeparator = ',', char stringSeparator = '\"')
//        {
//            bool isBetweenQuotes = false;
//            StringBuilder valueBuilder = new StringBuilder();
//            List<string> rowValues = new List<string>();

//            //loops through one char at a time looking for separators
//            for (int i = 0; i < row.ToCharArray().Length; i++)
//            {
//                char c = row.ToCharArray()[i];

//                if ((c == fieldSeparator && !isBetweenQuotes))
//                {
//                    rowValues.Add(valueBuilder.ToString());
//                    valueBuilder.Clear();
//                }
//                else
//                {
//                    if (c == stringSeparator)
//                    {
//                        isBetweenQuotes = !isBetweenQuotes;
//                    }
//                    else
//                    {
//                        valueBuilder.Append(c);
//                    }
//                }
//            }

//            rowValues.Add(valueBuilder.ToString());
//            valueBuilder.Clear();

//            return rowValues.ToArray();
//        }

//        //use this to display all the Entities
//        static public List<Entity> GetAllEntities()
//        {
//            LoadData();
//            AllEntities.Sort(new DataSorter());
//            return AllEntities;
//        }

//        //use this to display all Name values (not sure if we need this, really, but I made it in case)
//        static public List<Entity> GetAllNames()
//        {
//            LoadData();
//            AllNames.Sort(new DataSorter());
//            return AllNames;
//        }

//        //formerly the GetAllLocations method
//        static public List<Entity> GetAllCities()
//        {
//            LoadData();
//            AllCities.Sort(new DataSorter());
//            return AllCities;
//        }

//        static public List<Entity> GetAllStates()
//        {
//            LoadData();
//            AllStates.Sort(new DataSorter());
//            return AllStates;
//        }

//        //use this to display all descriptions.
//        static public List<Entity> GetAllDescriptions()
//        {
//            LoadData();
//            AllDescriptions.Sort(new DataSorter());
//            return AllDescriptions;
//        }

//        //use this to display all Types... all 3 of them!
//        static public List<Entity> GetAllTypes()
//        {
//            LoadData();
//            AllTypes.Sort(new DataSorter());
//            return AllTypes;
//        }

//    }

//}

using supernaturalsightings_olivia.Models;


namespace supernaturalsightings_olivia.Areas.Identity.Data
{

    public class EntityData
    {
        private static readonly string DATA_FILE = "Areas/Identity/Data/entities.csv";
        //Returns all the data from the file
        static public List<Entity> FindAll()
        {
            DataParser.LoadData();

            return new List<Entity>(DataParser.AllEntities);
        }

        //Search for entities by an indicated search type and an input search term.
        static public List<Entity> FindByColumnAndValue(string column, string value)
        {

            DataParser.LoadData();

            List<Entity> entities = new List<Entity>();

            for (int i = 0; i < DataParser.AllEntities.Count; i++)
            {
                Entity entity = DataParser.AllEntities[i];
                string aValue = GetValue(entity, column);

                if (aValue != null && aValue.ToLower().Contains(value.ToLower()))
                {
                    entities.Add(entity);
                }
            }
            return entities;
        }

        //Searches by types of entity selected, type of search, and a search term. Used in the Search Controller.
        static public List<Entity> FindByColumnValueAndType(string column, string value, List<string> type)
        {
            DataParser.LoadData();

            List<Entity> entities1 = new List<Entity>();
            List<Entity> entities2 = new List<Entity>();

            //Checks to see if the user selected any checkboxes and adds entties of those types to the first list.
            if (type.Count > 0)
            {
                entities1 = FindByType(type);
            }
            else
            {
                entities1 = FindAll();
            }

            //Then it loops through the new list to see if it matches the other search criteria to create a second list.
            for (int i = 0; i < entities1.Count; i++)
            {
                Entity entity = entities1[i];
                string aValue = GetValue(entity, column);

                if (aValue != null && aValue.ToLower().Contains(value.ToLower()))
                {
                    entities2.Add(entity);
                }
            }
            return entities2;
        }

        //Searches for entities by the selected types. Used in FindByColumnValueAndType() above and in the SearchController.
        static public List<Entity> FindByType(List<string> type)
        {
            DataParser.LoadData();
            List<Entity> entities = new List<Entity>();

            for (int i = 0; i < DataParser.AllEntities.Count; i++)
            {
                Entity entity = DataParser.AllEntities[i];

                for (int j = 0; j < type.Count; j++)
                {
                    if (type[j].ToLower() == entity.Type.ToLower())
                    {
                        entities.Add(entity);
                    }
                }
            }
            return entities;
        }

        //Searches for any entity that matches a search term. Used in the SearchController.
        static public List<Entity> FindByValue(string value)
        {
            DataParser.LoadData();
            List<Entity> entitiesList = new List<Entity>();
            List<Entity> allEntities = DataParser.AllEntities;

            for (int i = 0; i < allEntities.Count; i++)
            {
                if (allEntities[i].Name.ToLower().Contains(value.ToLower()))
                {
                    entitiesList.Add(allEntities[i]);
                }
                else if (allEntities[i].City.ToLower().Contains(value.ToLower()))
                {
                    entitiesList.Add(allEntities[i]);
                }
                else if (allEntities[i].State.ToLower().Contains(value.ToLower()))
                {
                    entitiesList.Add(allEntities[i]);
                }
                else if (allEntities[i].Description.ToLower().Contains(value.ToLower()))
                {
                    entitiesList.Add(allEntities[i]);
                }
                else if (allEntities[i].Type.ToLower().Contains(value.ToLower()))
                {
                    entitiesList.Add(allEntities[i]);
                }
            }
            return entitiesList;
        }

        //Retrieves the value of a specified field from a single entity.
        //Used in the FindByColumnAndValue() and FindByColumnValueAndType() functions above.
        static public string GetValue(Entity entity, string column)
        {
            string theValue;

            if (column.ToLower().Equals("name"))
            {
                theValue = entity.Name;
            }
            else if (column.ToLower().Equals("city"))
            {
                theValue = entity.City;
            }
            else if (column.ToLower().Equals("state"))
            {
                theValue = entity.State;
            }
            else if (column.ToLower().Equals("description"))
            {
                theValue = entity.Description;
            }
            else
            {
                theValue = entity.Type;
            }
            return theValue;
        }

        // Jacque added for favorites list
        static public Entity? FindEntityById(int id)
        {
            DataParser.LoadData();
            if (DataParser.AllEntities.Count() < id) return null;

            return DataParser.AllEntities[id - 1];
        }

        //Jacque added for adding sightings
        static public void AddNewSighting(Entity newEntity)
        {
            DataParser.LoadData();
            DataParser.AllEntities.Add(newEntity);
            using (StreamWriter sw = File.AppendText(DATA_FILE))
            {
                sw.WriteLine();
                sw.Write(String.Format("{0},{1},{2},{3},{4}", newEntity.Name, newEntity.City, newEntity.State, newEntity.Description, newEntity.Type));
            }
        }

    }
}
