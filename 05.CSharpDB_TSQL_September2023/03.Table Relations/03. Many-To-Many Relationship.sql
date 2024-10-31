CREATE TABLE Students(
	StudentID INT PRIMARY KEY, 
	[Name] NVARCHAR(50),
)

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY IDENTITY(101, 1), 
	[Name] NVARCHAR(50),
)

CREATE TABLE StudentsExams(
    StudentID INT,
	ExamID INT,
	PRIMARY KEY(StudentID, ExamID),
    FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
	FOREIGN KEY(ExamID) REFERENCES Exams(ExamID)
)

INSERT INTO Students(StudentID, [Name])
	VALUES
	                (1, 'Mila')
				   ,(2, 'Toni')
				   ,(3, 'Ron')

INSERT INTO Exams([Name])
	VALUES
                 ('SpringMVC')
				,('Neo4j')
				,('Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID)
	VALUES
	                     (1, 101)
						,(1, 102)
						,(2, 101)