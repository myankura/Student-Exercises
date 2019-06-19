using System;
using System.Collections.Generic;
using System.Linq;

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
            Exercise chickenMonkey = new Exercise(5, "Chicken Monkey", "JavaScript");

            //add exercises to list
            List<Exercise> exercises = new List<Exercise>() {
                lists, classes, dictionaries, dailyJournal, chickenMonkey
            };

            //create cohorts
            Cohort c31 = new Cohort(31, "C31");
            Cohort c32 = new Cohort(32, "C32");
            Cohort c33 = new Cohort(33, "C33");

            //add cohorts to list
            List<Cohort> cohorts = new List<Cohort>(){
                c31, c32, c33
            };


            //create students
            Student juan = new Student(1, "Juan", "Solo", "juan.solo", 31);
            Student ken = new Student(2, "Ken", "M", "ken.m", 32);
            Student mike = new Student(3, "Mike", "Jones", "mike.jones", 33);
            Student billy = new Student(4, "Billy", "Mays", "billy.mays", 31);
            Student tom = new Student(5, "Tom", "Foolery", "tom", 31);

            //add students to list
            List<Student> students = new List<Student>() {
                juan, ken, mike, billy, tom
            };

            //create instructors
            Instructor andy = new Instructor(1, "Andy", "Collins", "andy.collins", "Jokes", 31);
            Instructor jisie = new Instructor(2, "Jisie", "David", "jisie", "Sneaking up on people in a boot.", 33);
            Instructor joe = new Instructor(3, "Joe", "Sheppard", "joe.shep", "Dad Jokes", 32);

            List<Instructor> instructors = new List<Instructor>() {
                jisie, joe, andy
            };

            //add students to cohort
            c31.StudentList.Add(juan);
            c31.StudentList.Add(ken);
            c31.StudentList.Add(mike);
            c31.StudentList.Add(billy);
            c32.StudentList.Add(tom);

            //assign instructors to a cohort
            c31.InstructorList.Add(andy);
            c31.InstructorList.Add(jisie);
            c31.InstructorList.Add(joe);

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

            //1. List exercises for the JavaScript language by using the Where() LINQ method.
            IEnumerable<Exercise> jsExercises =
                from exercise in exercises
                where exercise.Language is "JavaScript"
                select exercise;

            Console.WriteLine("The following exercises use JavaScript:");

            foreach (Exercise ex in jsExercises)
            {
                Console.WriteLine($"{ex.Id}. {ex.ExerciseName}");
            }
            Console.WriteLine();

            //2. List students in a particular cohort by using the Where() LINQ method.
            IEnumerable<Student> chrt31Students =
                from student in students
                where student.CohortId is 31
                select student;

            Console.WriteLine("The following students are in Cohort 31:");

            foreach (Student c in chrt31Students)
            {
                Console.WriteLine($"{c.FirstName} {c.LastName}");
            }
            Console.WriteLine();

            //3. List instructors in a particular cohort by using the Where() LINQ method.
            IEnumerable<Instructor> c31Instructor =
                from instructor in instructors
                where instructor.CohortId is 31
                select instructor;

            Console.WriteLine("The following instructor(s) is/are leading Cohort 31:");

            foreach (Instructor i in c31Instructor)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName}");
            }
            Console.WriteLine();

            //4. Sort the students by their last name.
            IEnumerable<Student> stuLastNames =
                from student in students
                orderby student.LastName descending
                select student;

            Console.WriteLine("This list orders students by last name descending:");
            foreach (Student stu in stuLastNames)
            {
                Console.WriteLine($"{stu.LastName} {stu.FirstName}");
            }
            Console.WriteLine();

            //5. Display any students that aren't working on any exercises 
            //(Make sure one of your student instances don't have any exercises. Create a new student if you need to.)
            IEnumerable<Student> stuWithNoExercises =
                from ex in students
                where ex.ExerciseList.Count() == 0 
                select ex;

            Console.WriteLine("The following students are not currently working on any exercises:");
            foreach (Student ex in stuWithNoExercises)
            {
                Console.WriteLine($"{ex.FirstName} {ex.LastName}");
            }
            Console.WriteLine();

            //6. Which student is working on the most exercises? Make sure one of your 
            //students has more exercises than the others.
            Student mostEx = students.OrderByDescending(s => s.ExerciseList.Count).First();
            Console.WriteLine("The student with the most exercises is:");
            Console.WriteLine($"{mostEx.FirstName} {mostEx.LastName}");
            Console.WriteLine();

            //Create a report of all the exercises students are currently working on.
            foreach (Student stu in students)
            {
                Console.WriteLine();
                Console.WriteLine($"{stu.FirstName} {stu.LastName} is currently working on:");
                foreach(Exercise stuEx in stu.ExerciseList)
                {
                    Console.WriteLine($"{stuEx.ExerciseName}");
                }
            }

            //7. How many students in each cohort?
            Console.WriteLine();
            Console.WriteLine("Count the number of students in each cohort");
            foreach(Cohort stu in cohorts)
            {
                Console.WriteLine($"{stu.CohortName} has {stu.StudentList.Count()} students");
            }
        }
    }
}
