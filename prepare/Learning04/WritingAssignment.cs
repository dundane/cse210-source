using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning04 {
  public class WritingAssignment : Assigment {
    string title;
    public WritingAssignment(string title, string studentName, string topic) : base(studentName, topic) {
      this.title = title;
    }


    public string GetWritingInformation() {   
    return $"{title} by {studentName}";
    }
  }
}
