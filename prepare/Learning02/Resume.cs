using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop02 {
  public class Resume {
    private string applicantName = "";
    private List<Job> jobHistory = new List<Job>();

    public String ApplicantName { get { return applicantName; } set { applicantName = value; } }

    public List<Job> JobHistory { get { return jobHistory; } set { jobHistory = value; } }

    public string FormatResumeDetailsForDisplay() {
      StringBuilder formattedResume = new StringBuilder();
        formattedResume.AppendLine($"Name: {applicantName}");
        formattedResume.AppendLine("Jobs:");
      foreach (Job currentJob in JobHistory) {
        formattedResume.AppendLine(currentJob.FormatJobDetailsForDisplay());
      }
      return formattedResume.ToString();
    }

  }
}
