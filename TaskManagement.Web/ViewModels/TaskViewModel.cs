using TaskManagement.Contracts.Dtos;

namespace TaskManagement.Web.ViewModels;

public class TaskViewModel
{
    public int No { get; set; }
    public TaskDto Task { get; set; }
}