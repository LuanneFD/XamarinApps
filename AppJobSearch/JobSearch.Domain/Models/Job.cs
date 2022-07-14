using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JobSearch.Domain.Models
{
  public class Job
  {
    [Key]
    public int Id { get; set; }

    [Display(Name = "Company", ResourceType = typeof(Utility.Language.Fields))]
    [Required(ErrorMessageResourceType = typeof(Utility.Language.Messages), ErrorMessageResourceName = "MSG_E001")]
    public string Company { get; set; }

    [Display(Name = "JobTitle", ResourceType = typeof(Utility.Language.Fields))]
    [Required(ErrorMessageResourceType = typeof(Utility.Language.Messages), ErrorMessageResourceName = "MSG_E001")]
    public string JobTitle { get; set; }

    [Display(Name = "CityState", ResourceType = typeof(Utility.Language.Fields))]
    [Required(ErrorMessageResourceType = typeof(Utility.Language.Messages), ErrorMessageResourceName = "MSG_E001")]
    public string CityState { get; set; }

    [Display(Name = "Salary", ResourceType = typeof(Utility.Language.Fields))]
    [Required(ErrorMessageResourceType = typeof(Utility.Language.Messages), ErrorMessageResourceName = "MSG_E001")]
    public double Salary { get; set; }

    [Display(Name = "ContractType", ResourceType = typeof(Utility.Language.Fields))]
    [Required(ErrorMessageResourceType = typeof(Utility.Language.Messages), ErrorMessageResourceName = "MSG_E001")]
    public string ContractType { get; set; }

    [Display(Name = "TecnologyTools", ResourceType = typeof(Utility.Language.Fields))]
    [Required(ErrorMessageResourceType = typeof(Utility.Language.Messages), ErrorMessageResourceName = "MSG_E001")]
    public string TecnologyTools { get; set; }

    public string CompanyDescription { get; set; }

    [Display(Name = "JobDescription", ResourceType = typeof(Utility.Language.Fields))]
    [Required(ErrorMessageResourceType = typeof(Utility.Language.Messages), ErrorMessageResourceName = "MSG_E001")]
    public string JobDescription { get; set; }
    public string Benefits { get; set; }

    [Display(Name = "InteressedSendEmailTo", ResourceType = typeof(Utility.Language.Fields))]
    [Required(ErrorMessageResourceType = typeof(Utility.Language.Messages), ErrorMessageResourceName = "MSG_E001")]
    [EmailAddress(ErrorMessageResourceType = typeof(Utility.Language.Messages), ErrorMessageResourceName = "MSG_E002")]
    public string InteressedSendEmailTo { get; set; }

    public DateTime PublicationDate { get; set; }
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
  }
}
