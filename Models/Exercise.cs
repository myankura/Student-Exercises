using System;
using System.Collections.Generic;

namespace StudentExercises.Models
{

    //Define class
    public class Exercise
    {

        //Constructor for Exercise
        //public Exercise( string exercise, string language)
        //{
        //    ExerciseName = exercise;
        //    Language = language;
        //}

        //create properties
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public string Language { get; set; }

        ////create a list of students
        public List<Student> StudentList { get; set; } = new List<Student>();
    }
}