using System;
using System.Collections.Generic;

namespace StudentExercises.Models
{

    //Define class
    public class Instructor : NSSPerson
    {

        //Constructor for Instructor
        //public Instructor(int id, string firstName, string lastName, string slack, string speciality, int cohortId)
        //{
        //    Id = id;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    SlackHandle = slack;
        //    Speciality = speciality;
        //    CohortId = cohortId;
        //}


        //create properties
        public int Id { get; set; }
        public string Speciality { get; set; }
        public int CohortId { get; set; }

        //create a method for assigning exercises to students.
        public void AssignExercise(Student student, Exercise exercise){
            //Assign the student an exercise
            exercise.StudentList.Add(student);
            student.ExerciseList.Add(exercise);
        }
    }
}