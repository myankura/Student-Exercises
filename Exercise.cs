using System;
using System.Collections.Generic;

namespace StudentExercises
{

    //Define class
    class Exercise
    {

        //Constructor for Exercise
        public Exercise(int id, string exercise, string language)
        {
            Id = id;
            ExerciseName = exercise;
            Language = language;
        }

        //create properties
        public int Id { get; set; }

        public string ExerciseName { get; set; }

        public string Language { get; set; }

        //create a list of students
        public List<Student> StudentList { get; set; } = new List<Student>();
    }
}