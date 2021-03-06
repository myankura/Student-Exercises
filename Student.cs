using System;
using System.Collections.Generic;

namespace StudentExercises 
{

    //Define class
    class Student : NSSPerson
    {
        //Constructor for Student
        public Student(int id, string firstName, string lastName, string slack, int cohortId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            SlackHandle = slack;
            CohortId = cohortId;
        }

        //create properties
        public int Id { get; set; }
        public int CohortId { get; set; }


        //Create a list of assignments the student is currently working on
        public List<Exercise> ExerciseList { get; set; } = new List<Exercise>();
    }
}