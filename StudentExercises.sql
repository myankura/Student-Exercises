
CREATE DATABASE StudentExercises

CREATE TABLE Student (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    FirstName VARCHAR(55) NOT NULL,
    LastName VARCHAR(55) NOT NULL,
    SlackHandle VARCHAR(55) NOT NULL,
    CohortId INTEGER NOT NULL,
    CONSTRAINT FK_Student_Cohort FOREIGN KEY(CohortId) REFERENCES Cohort(Id)
);

CREATE TABLE Cohort (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    CohortName VARCHAR(55) NOT NULL
);

CREATE TABLE Exercise (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    ExerciseName VARCHAR(55) NOT NULL,
    LanguageUsed VARCHAR(55) NOT NULL
);

CREATE TABLE Instructor (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    FirstName VARCHAR(55) NOT NULL,
    LastName VARCHAR(55) NOT NULL,
    SlackHandle VARCHAR(55) NOT NULL,
    Speciality VARCHAR (55) NOT NULL,
    CohortId INTEGER NOT NULL,
    CONSTRAINT FK_Instructor_Cohort FOREIGN KEY(CohortId) REFERENCES Cohort(Id)
);

CREATE TABLE StudentExercise (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    StudentId INTEGER NOT NULL,
    ExerciseId INTEGER NOT NULL,
    CONSTRAINT FK_StudentExercise_Student FOREIGN KEY(StudentId) REFERENCES Student(Id),
    CONSTRAINT FK_StudentExercise_Exercise FOREIGN KEY(ExerciseId) REFERENCES Exercise(Id)
);

SELECT * FROM StudentExercise;
SELECT * FROM Cohort;
SELECT * FROM Student;
SELECT * FROM Instructor;
SELECT * FROM Exercise;

INSERT INTO Cohort (CohortName)
VALUES ('C31');

INSERT INTO Cohort (CohortName)
VALUES ('C32');

INSERT INTO Cohort (CohortName)
VALUES ('C33');

INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId)
VALUES ('Juan', 'Solo', 'juan.solo', 1);

INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId)
VALUES ('Ken', 'M', 'ken.m', 2);

INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId)
VALUES ('Mike', 'Jones', 'mike.jones', 3);

INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId)
VALUES ('Billy', 'Mays', 'billy.mays', 1);

INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId)
VALUES ('Tom', 'Foolery', 'tom', 1);

INSERT INTO Exercise (ExerciseName, LanguageUsed)
VALUES ('Lists', 'C#');

INSERT INTO Exercise (ExerciseName, LanguageUsed)
VALUES ('Classes', 'C#');

INSERT INTO Exercise (ExerciseName, LanguageUsed)
VALUES ('Dictionaries', 'C#');

INSERT INTO Exercise (ExerciseName, LanguageUsed)
VALUES ('Daily Journal', 'JavaScript');

INSERT INTO Exercise (ExerciseName, LanguageUsed)
VALUES ('Chicken Monkey', 'JavaScript');

INSERT INTO Instructor (FirstName, LastName, SlackHandle, Speciality, CohortId)
VALUES ('Andy', 'Collins', 'andy.collins', 'Jokes', 1);

INSERT INTO Instructor (FirstName, LastName, SlackHandle, Speciality, CohortId)
VALUES ('Jisie', 'David', 'jisie', 'Sneaking up on people in a boot', 3);

INSERT INTO Instructor (FirstName, LastName, SlackHandle, Speciality, CohortId)
VALUES ('Joe', 'Shepherd', 'joe.shep', 'Dad Jokes', 2);

INSERT INTO Instructor (FirstName, LastName, SlackHandle, Speciality, CohortId)
VALUES ('Steve', 'Brownlee', 'coach', 'Dad Jokes', 1);

INSERT INTO StudentExercise (StudentId, ExerciseId)
VALUES (1, 1);

INSERT INTO StudentExercise (StudentId, ExerciseId)
VALUES (1, 2);

INSERT INTO StudentExercise (StudentId, ExerciseId)
VALUES (2, 3);

INSERT INTO StudentExercise (StudentId, ExerciseId)
VALUES (2, 4);

INSERT INTO StudentExercise (StudentId, ExerciseId)
VALUES (3, 1);

INSERT INTO StudentExercise (StudentId, ExerciseId)
VALUES (3, 5);

INSERT INTO StudentExercise (StudentId, ExerciseId)
VALUES (4, 5);

INSERT INTO StudentExercise (StudentId, ExerciseId)
VALUES (4, 1);

INSERT INTO StudentExercise (StudentId, ExerciseId)
VALUES (5, 4);

INSERT INTO StudentExercise (StudentId, ExerciseId)
VALUES (5, 5);