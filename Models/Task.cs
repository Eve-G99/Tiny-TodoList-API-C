//Models/Task.cs

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TaskApi.Models
{
     [BsonIgnoreExtraElements]
    public class Task
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("taskDescription")]
        public string TaskDescription { get; set; } = string.Empty;// Initialize empty

        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [BsonElement("dueDate")]
        public DateTime DueDate { get; set; }

        [BsonElement("completed")]
        public bool Completed { get; set; } = false;
    }
}
