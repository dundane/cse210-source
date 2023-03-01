using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop02 {
  public class Job {
    //underscore is not actually the convention for member variables that is made up.
    //That is not something anyone who actually writes code does.
    //also you shouldn't actually access member variables directly.  That is VERY bad practice.
    //So I am doing it correctly.  This is how you should teach it.
    private string company;
    private string jobTitle;
    private int startYear;
    private int endYear;

    public string Company { get { return company; } set { company = value; }  }
    public string JobTitle { get { return jobTitle; } set { jobTitle = value; } }
    public int EndYear { get { return endYear; } set { endYear = value; } }
    public int StartYear { get { return startYear; } set { startYear = value; } }

    public string FormatJobDetailsForDisplay() {
      //You should seperate business logic from display logic so not writing to console just formatting.
      return $"{jobTitle} ({company}) {startYear.ToString()} - {endYear.ToString()}";
    }

  }
}
