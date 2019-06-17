using System;

namespace StudentExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //create exercises
            Exercise lists = new Exercise(1, "Lists", "C#");

            Exercise classes = new Exercise(2, "Classes", "C#");

            Exercise dictionaries = new Exercise(3, "Dictionaries", "C#");

            Exercise dailyJournal = new Exercise(4, "Daily Journal", "JavaScript");

            //create cohorts
            Cohort c31 = new Cohort(31, "C31");

            Cohort c32 = new Cohort(32, "C32");

            Cohort c33 = new Cohort(33, "C33");

            //create students
            Student juan = new Student(1, "Juan", "Solo", "juan.solo");

            Student ken = new Student(2, "Ken", "M", "ken.m");

            Student mike = new Student(3, "Mike", "Jones", "mike.jones");

            Student billy = new Student(4, "Billy", "Mays", "billy.mays");

            //create instructors
            Instructor andy = new Instructor(1, "Andy", "Collins", "andy.collins", "Jokes");

            Instructor jisie = new Instructor(2, "Jisie", "David", "jisie", "Frontend development");

            Instructor joe = new Instructor(3, "Joe", "Sheppard", "joe.shep", "Dad Jokes");

            //add students to cohort
            c31.StudentList.Add(juan);
            juan.Cohort = c31;

            c31.StudentList.Add(ken);
            ken.Cohort = c31;

            c31.StudentList.Add(mike);
            mike.Cohort = c31;

            c31.StudentList.Add(billy);
            billy.Cohort = c31;

            //assign instructors to a cohort
            c31.InstructorList.Add(andy);
            andy.Cohort = c31;

            c31.InstructorList.Add(jisie);
            jisie.Cohort = c33;

            c31.InstructorList.Add(joe);
            joe.Cohort = c32;

            //assign exercises to students
            andy.AssignExercise(juan, lists);
            andy.AssignExercise(juan, classes);
            andy.AssignExercise(billy, dictionaries);
            andy.AssignExercise(ken, lists);
            andy.AssignExercise(ken, dailyJournal);
            andy.AssignExercise(mike, dailyJournal);
            andy.AssignExercise(billy, classes);
            andy.AssignExercise(mike, dictionaries);

            jisie.AssignExercise(mike, lists);
            jisie.AssignExercise(ken, classes);
            jisie.AssignExercise(juan, dictionaries);
            jisie.AssignExercise(ken, lists);
            jisie.AssignExercise(juan, dailyJournal);
            jisie.AssignExercise(mike, dailyJournal);
            jisie.AssignExercise(billy, classes);
            jisie.AssignExercise(mike, dictionaries);

            joe.AssignExercise(juan, lists);
            joe.AssignExercise(juan, classes);
            joe.AssignExercise(billy, dictionaries);
            joe.AssignExercise(ken, lists);
            joe.AssignExercise(ken, dailyJournal);
            joe.AssignExercise(mike, dailyJournal);
            joe.AssignExercise(billy, classes);
            joe.AssignExercise(mike, dictionaries);
        }
    }
}
