using System.Net;
using System.Text;
using Newtonsoft.Json;
using TaskManagement.Contracts.Dtos;

namespace TaskManagement.Web.Services;

public class TaskService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<TaskService> _logger;

    public TaskService(IHttpClientFactory httpClientFactory, ILogger<TaskService> logger)
    {
        _httpClient = httpClientFactory.CreateClient("api");
        _logger = logger;
    }

    public async Task<List<TaskDto>> GetAllTasksAsync()
    {
        var response = await _httpClient.GetAsync("api/Tasks");

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<List<TaskDto>>(content);
    }

    public async Task<TaskDto> GetByIdAsync(Guid id)
    {
        var response = await _httpClient.GetAsync($"api/Tasks/{id}");

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<TaskDto>(content);
    }

    public async Task<TaskDto> CreateAsync(CreateTaskDto dto)
    {
        var stringContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("/api/Tasks", stringContent);

        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<TaskDto>(content);
    }

    public async Task<TaskDto> UpdateAsync(UpdateTaskDto dto)
    {
        var stringContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync($"/api/Tasks/{dto.Id}", stringContent);

        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<TaskDto>(content);
    }

    public async Task DeleteAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"/api/Tasks/{id}");

        response.EnsureSuccessStatusCode();
    }
}