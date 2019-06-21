using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using StudentExercises.Models;

namespace StudentExercises.Data
{
    public class Repository
    {
        public SqlConnection Connection
        {
            get
            {
                // This is "address" of the database
                string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StudentExercises;Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }

        public List<Exercise> GetAllExercises()
        {
            // We must "use" the database connection.
            //  Because a database is a shared resource (other applications may be using it too) we must
            //  be careful about how we interact with it. Specifically, we Open() connections when we need to
            //  interact with the database and we Close() them when we're finished.
            //  In C#, a "using" block ensures we correctly disconnect from a resource even if there is an error.
            //  For database connections, this means the connection will be properly closed.
            using (SqlConnection conn = Connection)
            {
                // Note, we must Open() the connection, the "using" block doesn't do that for us.
                conn.Open();

                // We must "use" commands too.
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // Here we setup the command with the SQL we want to execute before we execute it.
                    cmd.CommandText = @"SELECT 
                                        Id, 
                                        ExerciseName,
                                        Language
                                        FROM Exercise";

                    // Execute the SQL in the database and get a "reader" that will give us access to the data.
                    SqlDataReader reader = cmd.ExecuteReader();

                    // A list to hold the cohorts we retrieve from the database.
                    List<Exercise> exercises = new List<Exercise>();

                    // Read() will return true if there's more data to read
                    while (reader.Read())
                    {
                        // The "ordinal" is the numeric position of the column in the query results.
                        //  For our query, "Id" has an ordinal value of 0 and "CohortName" is 1.
                        int idColumnPosition = reader.GetOrdinal("Id");
                        // We user the reader's GetXXX methods to get the value for a particular ordinal.
                        int idValue = reader.GetInt32(idColumnPosition);

                        int exerciseNameColumnPosition = reader.GetOrdinal("ExerciseName");
                        string exerciseNameValue = reader.GetString(exerciseNameColumnPosition);

                        int languageColumnPosition = reader.GetOrdinal("Language");
                        string languageValue = reader.GetString(languageColumnPosition);


                        //
                        Exercise exercise = new Exercise
                        {
                            Id = idValue,
                            ExerciseName = exerciseNameValue,
                            Language = languageValue
                        };

                        // ...and add that cohort object to our list.
                        exercises.Add(exercise);
                    }

                    // We should Close() the reader. Unfortunately, a "using" block won't work here.
                    reader.Close();

                    // Return the list of cohorts who whomever called this method.
                    return exercises;
                }
            }
        }

        //Find all the exercises in the database where the language is JavaScript.
        public List<Exercise> GetAllJavaScriptExercises()
        {

            using (SqlConnection conn = Connection)
            {
                // Note, we must Open() the connection, the "using" block doesn't do that for us.
                conn.Open();

                // We must "use" commands too.
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // Here we setup the command with the SQL we want to execute before we execute it.
                    cmd.CommandText = @"SELECT 
                                        Id, 
                                        ExerciseName,
                                        Language
                                        FROM Exercise
                                        WHERE [Language] LIKE 'JavaScript'";

                    // Execute the SQL in the database and get a "reader" that will give us access to the data.
                    SqlDataReader reader = cmd.ExecuteReader();

                    // A list to hold the cohorts we retrieve from the database.
                    List<Exercise> jsExercises = new List<Exercise>();

                    // Read() will return true if there's more data to read
                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        // We user the reader's GetXXX methods to get the value for a particular ordinal.
                        int idValue = reader.GetInt32(idColumnPosition);

                        int exerciseNameColumnPosition = reader.GetOrdinal("ExerciseName");
                        string exerciseNameValue = reader.GetString(exerciseNameColumnPosition);

                        int languageColumnPosition = reader.GetOrdinal("Language");
                        string LanguageValue = reader.GetString(languageColumnPosition);


                        // Create a collection of all JavaScript exercises
                        Exercise jsExercise = new Exercise
                        {
                            Id = idValue,
                            ExerciseName = exerciseNameValue,
                            Language = LanguageValue
                        };

                        //Add jsExercise
                        jsExercises.Add(jsExercise);
                    }

                    // Close SQL connection
                    reader.Close();

                    // Return the list of all exercises that use the language JavaScript
                    return jsExercises;
                }
            }
        }
        //Insert a new exercise into the database.
        public void AddExercise(Exercise exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO Exercise (ExerciseName, Language) Values (@ExerciseName, @Language)";
                    cmd.Parameters.Add(new SqlParameter("@ExerciseName", exercise.ExerciseName));
                    cmd.Parameters.Add(new SqlParameter("@Language", exercise.Language));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Find all instructors in the database. Include each instructor's cohort.
        public List<Instructor> GetAllInstructorsWithCohort()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT
                                        i.Id,
                                        i.FirstName,
                                        i.LastName,
                                        c.CohortName
                                        FROM Instructor i
                                        JOIN Cohort c ON c.Id = i.CohortId";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instructor> instructorsAndCohort = new List<Instructor>();

                    while (reader.Read())
                    {

                        // Create a collection of all JavaScript exercises
                        Instructor instructor = new Instructor
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName"))
                        };

                        Cohort cohort = new Cohort
                        {
                            CohortName = reader.GetString(reader.GetOrdinal("CohortName"))
                        };

                        instructor.Cohort = cohort;
                        instructorsAndCohort.Add(instructor);
                    }

                    // Close SQL connection
                    reader.Close();
                    return instructorsAndCohort;
                }

            }
        }

        //Insert a new instructor into the database. Assign the instructor to an existing cohort.
        public void AddInstructor(Instructor instructor)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Instructor (FirstName, LastName, SlackHandle, Speciality, CohortId)
                                        VALUES (@FirstName, @LastName, @SlackHandle, @Speciality, @CohortId)";
                    cmd.Parameters.Add(new SqlParameter("@FirstName", instructor.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", instructor.LastName));
                    cmd.Parameters.Add(new SqlParameter("@SlackHandle", instructor.SlackHandle));
                    cmd.Parameters.Add(new SqlParameter("@Speciality", instructor.Speciality));
                    cmd.Parameters.Add(new SqlParameter("@CohortId", instructor.CohortId));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Assign an existing exercise to an existing student.
        public void AssignExistingExerciseToExistingStudent(Student student, Exercise exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO StudentExercise (StudentId, ExerciseId)
                                        VALUES (@StudentId, @ExerciseId)";
                    cmd.Parameters.Add(new SqlParameter("@StudentId", student.Id));
                    cmd.Parameters.Add(new SqlParameter("@ExerciseId", exercise.Id));

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}