using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;
using TaskManagement.Contracts.Mappings;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;
using TaskStatus = TaskManagement.Domain.Enums.TaskStatus;

namespace TaskManagement.Contracts.Dtos;

public class CreateTaskDto: IMapFrom<TaskEntity>
{
    [Required]
    [StringLength(255)]
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public DateTime?  DueDate { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TaskPriority TaskPriority { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TaskStatus Status { get; set; }
    
    public string Note { get; set; }

}