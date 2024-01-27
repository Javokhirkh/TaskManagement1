using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManagement.Domain.Enums;
using TaskStatus = TaskManagement.Domain.Enums.TaskStatus;

namespace TaskManagement.Domain.Entities;

[Table("tasks", Schema = "public")]
public class TaskEntity
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
    
    [Required]
    [Column("title")]
    [StringLength(255)]
    public string Title { get; set; }
    
    [Column("description")]
    public string Description { get; set; }
    
    [Column ("due_date",TypeName = "timestamp without time zone")]
    public DateTime?  DueDate { get; set; }
    
    [Column("task_priority")]
    public TaskPriority TaskPriority { get; set; }
    
    [Column("status")]
    public TaskStatus Status { get; set; }
    
    [Column("note")]
    public string Note { get; set; }

    [Column("created_at",TypeName = "timestamp with time zone")]
    public DateTimeOffset CreatedAt { get; set; }
    
    [Column("updated_at",TypeName = "timestamp with time zone")]
    public DateTimeOffset? UpdatedAt { get; set; }
}