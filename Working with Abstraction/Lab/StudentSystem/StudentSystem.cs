namespace StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class StudentSystem
    {
        public StudentSystem()
        {
            this.Repo = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Repo { get; private set; }
        

        public void ParseCommand()
        {
            string[] studentInfo = Console.ReadLine().Split();

            if (studentInfo[0] == "Create")
			{
				CreateStudent(studentInfo);
			}
			else if (studentInfo[0] == "Show")
            {
                var name = studentInfo[1];
                if (Repo.ContainsKey(name))
                {
                    var student = Repo[name];
                    Console.WriteLine(student);
                }

            }
            else if (studentInfo[0] == "Exit")
            {
                Environment.Exit(0);
            }
        }

		private void CreateStudent(string[] studentInfo)
		{
			var name = studentInfo[1];
			var age = int.Parse(studentInfo[2]);
			var grade = double.Parse(studentInfo[3]);
			if (!Repo.ContainsKey(name))
			{
				var student = new Student(name, age, grade);
				Repo[name] = student;
			}
		}
	}
}