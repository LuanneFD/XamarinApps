using JobSearch.Api.Database;
using JobSearch.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearch.Api.Controllers
{
  [Route("api/Jobs")]
  [ApiController]
  public class JobsController : Controller
  {
    private readonly int numberOfRegistryByPage = 5;
    private readonly JobSearchContext _data;
    public JobsController(JobSearchContext data)
    {
      _data = data;
    }

    [HttpGet]
    public IEnumerable<Job> GetJobs(string word, string cityState,int numberOfPage=1)
    {
      if (word == null) word = "";
      if (cityState == null) cityState = "";

      return _data.Jobs
      .Where(a =>
        a.PublicationDate >= DateTime.Now.AddDays(-15) &&
        a.CityState.ToLower().Contains(cityState.ToLower()) &&
        (a.JobTitle.ToLower().Contains(word.ToLower()) || a.TecnologyTools.ToLower().Contains(word.ToLower())) &&
        a.Company.ToLower().Contains(word.ToLower())
      )
      .Skip(numberOfRegistryByPage * (numberOfPage-1)) //pula 5 registros
      .Take(numberOfRegistryByPage) //mostra o próximos 5 registros
      .ToList<Job>();

      //25 total de registros e 5 por página
      //Skip -> (5 * (1-1)) = 0, ou seja, na primeira página não pula nenhum registro e mostra os primeiros 5.
      //Skip -> (5 * (2-1)) = 5, ou seja, na segunda página pula 5 registros e mostra os próximos 5.
    }

    [HttpGet("{idJob}")]
    public IActionResult GetJob(int idJob)
    {
      Job jobdb = _data.Jobs.Find(idJob);

      if (jobdb == null)
      {
        return NotFound();
      }
      return new JsonResult(jobdb);
    }

    [HttpPost]
    public IActionResult AddJob(Job job)
    {
      job.PublicationDate = DateTime.Now.Date;
      _data.Jobs.Add(job);
      _data.SaveChanges();

      return CreatedAtAction("GetJob", new { idJob = job.Id }, job);
    }
  }
}
