using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning04 {
  public class MathAssignment : Assigment {
    string textbookSection;
    string problems;
    public MathAssignment(string textbookSection, string problems, string studentName, string topic) :base(studentName, topic) {
      this.textbookSection = textbookSection;
      this.problems = problems;
    }

    public string GetHomeworkList() {
      return $"{textbookSection} {problems}";
    }
  }
}
