using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning04 {

  public class Assigment {
    protected string studentName;
    private string topic;

    public Assigment(string studentName, string topic) {
      this.studentName = studentName;
      this.topic = topic;
    }

    public string GetSummary() { 
      return $"{studentName} : {topic}"; 
    }

  }
}
