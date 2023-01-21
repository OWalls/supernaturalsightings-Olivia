using supernaturalsightings_olivia.Models;


namespace supernaturalsightings_olivia.Areas.Identity.Data
{
	public class EntityData
	{

        //returns all the data from the file
        static public List<Entity> FindAll()
        {
            DataParser.LoadData();

            return new List<Entity>(DataParser.AllEntities);
        }

        //lets you search for a specific value in a specified category
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

        //An overlaod of the previous function that allows the search by entity type.
        static public List<Entity> FindByColumnAndValue(string column, string value, List<string> type)
        {
            DataParser.LoadData();

            List<Entity> entities1 = new List<Entity>();
            List<Entity> entities2 = new List<Entity>();

            if (type.Count > 0)
            {
                entities1 = FindByType(type);
            }
            else
            {
                entities1 = FindAll();
            }

            //Then it loops through the new list to see if it matches the other search criteria to create a smaller list.
            for (int i = 0; i < entities1.Count; i++)
            {
                Entity entity = entities1[i];
                string aValue = GetValue(entity, column);
                Console.WriteLine("Line 61: " + aValue);

                if (aValue != null && aValue.ToLower().Contains(value.ToLower()))
                {
                    entities2.Add(entity);
                }
            }
            return entities2;
        }

        //Finds just a list by whatever entities are selected.
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

        //lets you search by property - used in the FindByColumnAndValue function above.
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

        //loops through each entity to look for a search term - used in the FindByColumnAndValue function.
        static public List<Entity> FindByValue(string value)
        {
            DataParser.LoadData();
            List<Entity> entities = new List<Entity>();
            List<Entity> allEntities = DataParser.AllEntities;

            for (int i = 0; i < allEntities.Count; i++)
            {
                Console.WriteLine("FindByValue(): " + i);
                if (allEntities[i].Name.ToLower().Contains(value.ToLower()))
                {
                    entities.Add(allEntities[i]);
                }
                else if (allEntities[i].City.ToLower().Contains(value.ToLower()))
                {
                    entities.Add(allEntities[i]);
                }
                else if (allEntities[i].State.ToLower().Contains(value.ToLower()))
                {
                    entities.Add(allEntities[i]);
                }
                else if (allEntities[i].Description.ToLower().Contains(value.ToLower()))
                {
                    entities.Add(allEntities[i]);
                }
                else if (allEntities[i].Type.ToLower().Contains(value.ToLower()))
                {
                    entities.Add(allEntities[i]);
                }
            }
            return entities;
        }
    }
}


