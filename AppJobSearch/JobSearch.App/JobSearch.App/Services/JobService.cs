using JobSearch.App.Models;
using JobSearch.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.App.Services
{
  public class JobService : Service
  {
    public async Task<IEnumerable<Job>> GetJobs(string word, string cityState, int numberOfPage = 1)
    {
      string requestUri = $"{BaseApiUrl}/api/Jobs?word={word}&cityState={cityState}&numberOfPage={numberOfPage}";
      HttpResponseMessage response = await _client.GetAsync(requestUri);
      List<Job> list = null;
      if (response.IsSuccessStatusCode)
      {
        list = await response.Content.ReadAsAsync<List<Job>>();
      }
      return list;
    }

    public async Task<Job> GetJob(int idJob)
    {
      HttpResponseMessage response = await _client.GetAsync($"{BaseApiUrl}/api/Jobs/{idJob}");
      Job job = null;
      if (response.IsSuccessStatusCode)
      {
        job = await response.Content.ReadAsAsync<Job>();
      }
      return job;
    }

    public async Task<ResponseService<Job>> AddJob(Job job)
    {
      HttpResponseMessage response = await _client.PostAsJsonAsync($"{BaseApiUrl}/api/Jobs", job);

      ResponseService<Job> responseService = new ResponseService<Job>
      {
        IsSuccess = response.IsSuccessStatusCode,
        StatusCode = (int)response.StatusCode
      };

      if (response.IsSuccessStatusCode)
      {
        responseService.Data = await response.Content.ReadAsAsync<Job>();
      }
      else
      {
        string problemResponse = await response.Content.ReadAsStringAsync();
        var errors = JsonConvert.DeserializeObject<ResponseService<Job>>(problemResponse);
        responseService.Errors = errors.Errors;
      }
      return responseService;
    }
  }
}
