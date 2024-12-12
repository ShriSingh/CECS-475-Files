// Adding a database context
using Microsoft.EntityFrameworkCore;

namespace TodoApi2.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options): base(options)
    {

    }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;

    // New Addition
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TodoItem>().HasData(
            new TodoItem
            {
                Id = 1,
                Name = "Quiz 5",
                IsComplete = false,
                CompletionDate = new DateOnly(2024, 12, 09),
            },

            new TodoItem
            {
                Id = 2,
                Name = "Quiz 6",
                IsComplete = false,
                CompletionDate = new DateOnly(2024, 12, 09),
            },

            new TodoItem
            {
                Id = 3,
                Name = "Exam 2",
                IsComplete = false,
                CompletionDate = new DateOnly(2024, 12, 11),
            }
        );
    }
}
