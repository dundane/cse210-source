using Develop02;

class Program {
  static void Main(string[] args) {

    Job job1 = new Job();

    job1.JobTitle = "Software Development Engineer in Test";
    job1.Company = "Microsoft";
    job1.StartYear = 2000;
    job1.EndYear = 2005;
    Console.WriteLine(job1.FormatJobDetailsForDisplay());

    Job job2 = new Job();

    job2.JobTitle = "Software Development Manager";
    job2.Company = "1-800 Contacts";
    job2.StartYear = 2015;
    job2.EndYear = 2018;
    Console.WriteLine(job2.FormatJobDetailsForDisplay());

    Resume jaredDoerrResume = new Resume();
    jaredDoerrResume.ApplicantName = "Jared Doerr";
    jaredDoerrResume.JobHistory.Add(job1);
    jaredDoerrResume.JobHistory.Add(job2);
    Console.WriteLine(jaredDoerrResume.JobHistory[0].JobTitle);

    Console.Write(jaredDoerrResume.FormatResumeDetailsForDisplay());

  }
}