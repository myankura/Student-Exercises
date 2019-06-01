using System;
using System.Collections.Generic;

namespace StudentExercises
{

    //Define class
    class Student
    {
        //Constructor for Student
        public Student(int id, string firstName, string lastName, string slack)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            SlackHandle = slack;
        }

        //create properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SlackHandle { get; set; }

        public Cohort Cohort { get; set; }

        //Create a list of assignments the student is currently working on
        public List<Exercise> ExerciseList { get; set; } = new List<Exercise>();
    }
}