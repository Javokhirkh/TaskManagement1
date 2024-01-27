using TaskManagement.Contracts.Dtos;
using TaskManagement.Web.ViewModels;

namespace TaskManagement.Web.Extensions;

public static class Numerator
{
    public static List<TaskViewModel> Numerate(List<TaskDto> list)
    {
        var no = 1;
        var result = new List<TaskViewModel>();

        foreach (var item in list)
        {
            var viewModel = new TaskViewModel()
            {
                No = no,
                Task = item
            };
            
            result.Add(viewModel);

            no++;
        }

        return result;
    }
}