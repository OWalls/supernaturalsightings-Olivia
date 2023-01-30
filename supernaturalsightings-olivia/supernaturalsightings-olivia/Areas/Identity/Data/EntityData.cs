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
