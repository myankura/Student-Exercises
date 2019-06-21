using System;
using System.Collections.Generic;
using System.Linq;
using StudentExercises.Data;
using StudentExercises.Models;

namespace StudentExercises
{
    class Program
    {
        static void Main(string[] args)
        {

            Repository repository = new Repository();

            List<Exercise> exercises = repository.GetAllExercises();
            List<Exercise> jsExercises = repository.GetAllJavaScriptExercises();
            List<Instructor> instructorsAndCohort = repository.GetAllInstructorsWithCohort();
            

            //Console.WriteLine(exercises);
            PrintExerciseReport("All exercises", exercises);
            Console.WriteLine();

            PrintJSExerciseReport("All JavaScript Exercises", jsExercises);
            Console.WriteLine();

            PrintInstructorCohortReport("Who's leading this cohort anyway?", instructorsAndCohort);
            Console.WriteLine();

            //Part 3 Add a new exercise

            //Exercise fetchingData = new Exercise
            //{
            //    ExerciseName = "Fetching Data",
            //    Language = "JavaScript",
            //};

            //repository.AddExercise(fetchingData);

            //exercises = repository.GetAllExercises();
            //PrintExerciseReport("All Exercises after adding the new exercise", exercises);

            //Part 5 Add a new instructor and assign them to an existing cohort
            //Instructor instructorMcInstructorface = new Instructor
            //{
            //    FirstName = "Instructor",
            //    LastName = "McInstructorface",
            //    SlackHandle = "i.mcinstructorface",
            //    Speciality = "Instructing",
            //    CohortId = 3
            //};

            //repository.AddInstructor(instructorMcInstructorface);

            //instructorsAndCohort = repository.GetAllInstructorsWithCohort();
            //PrintInstructorCohortReport("All instructors after adding Instructor McInstructorface", instructorsAndCohort);

            //Part 6 Assign an existing assignment to an existing student
            //Exercise assignedEx = new Exercise
            //{
            //    Id = 1
            //};

            //Student studentToAssign = new Student
            //{
            //    Id = 5
            //};

            //repository.AssignExistingExerciseToExistingStudent(studentToAssign, assignedEx);
        }

        //Part 1 Print a report of all exercises in the DB
        public static void PrintExerciseReport(string title, List<Exercise> exercises)
        {
            
            Console.WriteLine(title);
            exercises.ForEach(e => Console.WriteLine($"{e.Id}: {e.ExerciseName} uses {e.Language}"));
        }

        //Part 2 Print a report of all JavaScript Exercises in the DB
        public static void PrintJSExerciseReport(string title, List<Exercise> jsExercises)
        {
            
            Console.WriteLine(title);
            jsExercises.ForEach(e => Console.WriteLine($"{e.Id}: {e.ExerciseName} uses {e.Language}"));
        }

        //Part 4 Print a report of all instructors and the cohort they are leading
        public static void PrintInstructorCohortReport(string title, List<Instructor> instructorsAndCohort)
        {
            Console.WriteLine(title);
            instructorsAndCohort.ForEach(i => Console.WriteLine($"{i.Id}: {i.FirstName} {i.LastName} is leading {i.Cohort.CohortName}"));
        }


        
    }
}
