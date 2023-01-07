using System;
using Microsoft.CodeAnalysis;

namespace supernaturalsightings_olivia.Models
{
	public class Entity
	{
        //I'm not sure if we NEED an I.D. field for each entity, but I made one just in case.
        public int Id { get; }
        static private int nextId = 1;

        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public Entity()
        {
            Id = nextId;
            nextId++;
        }

        public Entity(string name, string city, string state, string description, string type) : this()
        {
            Name = name;
            City = city;
            State = state;
            Description = description;
            Type = type;
        }

        //Not sure if we really need these either, but I made them for good measure.
        public override bool Equals(object obj)
        {
            return obj is Entity entity &&
                   Id == entity.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}

