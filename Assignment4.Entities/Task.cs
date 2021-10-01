using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Assignment4.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Assignment4.Entities
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public User? AssignedTo { get; set; }
        public string? Description { get; set; }
        public State State { get; set; }
        public ICollection<Tag> Tags { get; set; }

        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                        .Property(e => e.State)
                        .HasConversion(new EnumToStringConverter<State>());
        }
    }
}
