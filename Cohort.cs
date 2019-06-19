using System;
using System.Collections.Generic;

namespace StudentExercises
{

    //Define class
    class Cohort
    {
        //Constructor for Cohort
        public Cohort(int id, string cohortName)
        {
            Id = id;
            CohortName = cohortName;
        }

        //create properties
        public int Id { get; set; }
        public string CohortName { get; set; }

        //Create a list of students
        public List<Student> StudentList { get; set; } = new List<Student>();

        //Create a list of instructors
        public List<Instructor> InstructorList { get; set; } = new List<Instructor>();
    }
}