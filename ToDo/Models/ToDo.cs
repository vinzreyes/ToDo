// Path: Models/ToDo.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{

    public enum PriorityLevel
    {
        Low,
        Medium,
        High
    }

    public class ToDo
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Details { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public bool IsDone { get; set; }

        [Required]
        public PriorityLevel Priority { get; set; }
    }
}
