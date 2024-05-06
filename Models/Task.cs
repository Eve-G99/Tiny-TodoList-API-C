//Models/Task.cs

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TaskApi.Models
{
     [BsonIgnoreExtraElements]
    public class Task
    {
        public static DateTime TruncateToSeconds(DateTime dateTime) {
            dateTime.AddMicroseconds(-dateTime.Millisecond);
            return dateTime;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id { get; set; }

        [BsonElement("taskDescription")]
        public string TaskDescription { get; set; } = string.Empty;// Initialize empty

        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; } = TruncateToSeconds(DateTime.Now);

        [BsonElement("dueDate")]
        public DateTime DueDate { get; set; }

        [BsonElement("completed")]
        public bool Completed { get; set; } = false;
    }
}
