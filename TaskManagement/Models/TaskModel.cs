﻿namespace TaskManagement.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public string State {  get; set; }
        public string UserId { get; set; }
    }
}
