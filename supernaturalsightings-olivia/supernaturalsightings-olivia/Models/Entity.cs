using System;
using Microsoft.CodeAnalysis;

namespace supernaturalsightings_olivia.Models
{
	public class Entity
	{
        public int Id { get; }
        static private int nextId = 1;

        public string Name { get; set; }
        public Location Location { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public Entity()
        {
            Id = nextId;
            nextId++;
        }

        public Entity(string name, Location location, string description, string type) : this()
        {
            Name = name;
            Location= location;
            Description = description;
            Type = type;
        }

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

