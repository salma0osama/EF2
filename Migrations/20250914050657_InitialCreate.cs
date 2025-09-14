using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Examination_SystemEFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    MaximumDegree = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                    table.CheckConstraint("CK_Course_MaximumDegree_Positive", "MaximumDegree > 0");
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TotalMarks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ID);
                    table.CheckConstraint("CK_Exam_EndDateAfterStart", "EndDate > StartDate");
                    table.ForeignKey(
                        name: "FK_Exams_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exams_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorCourses",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorCourses", x => new { x.InstructorID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_InstructorCourses_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorCourses_Instructors_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamAttempts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalScore = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsSubmitted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsGraded = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    ExamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamAttempts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ExamAttempts_Exams_ExamID",
                        column: x => x.ExamID,
                        principalTable: "Exams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamAttempts_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Marks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuestionType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamID = table.Column<int>(type: "int", nullable: false),
                    MaxWordCount = table.Column<int>(type: "int", nullable: true),
                    GradingCriteria = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OptionA = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OptionB = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OptionC = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OptionD = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CorrectOption = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    CorrectAnswer = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.ID);
                    table.CheckConstraint("CK_Question_Marks_Positive", "Marks > 0");
                    table.ForeignKey(
                        name: "FK_Questions_Exams_ExamID",
                        column: x => x.ExamID,
                        principalTable: "Exams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAnswers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerText = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    SelectedOption = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    BooleanAnswer = table.Column<bool>(type: "bit", nullable: true),
                    MarksObtained = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamAttemptID = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAnswers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentAnswers_ExamAttempts_ExamAttemptID",
                        column: x => x.ExamAttemptID,
                        principalTable: "ExamAttempts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "CreatedDate", "Description", "IsActive", "MaximumDegree", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic programming concepts", true, 100m, "Introduction to Programming" },
                    { 2, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Algorithms and structures", true, 100m, "Data Structures" },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Relational databases and SQL", true, 100m, "Database Systems" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "ID", "Email", "HireDate", "IsActive", "Name", "Specialization" },
                values: new object[,]
                {
                    { 1, "omar.khaled@example.com", new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Prof. Omar Khaled", "Software Engineering" },
                    { 2, "laila.mansour@example.com", new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Dr. Laila Mansour", "Databases" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "Email", "EnrollmentDate", "IsActive", "Name", "StudentNumber" },
                values: new object[,]
                {
                    { 1, "Salma@gmail.com", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Salma Osama", "s1001" },
                    { 2, "Sara@gmail.com", new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sara Ahmed", "s1002" },
                    { 3, "Omar@gmail.com", new DateTime(2024, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Omar Ali", "s1003" },
                    { 4, "Menna@gmail.com", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Menna Khaled", "s1004" },
                    { 5, "Bilal@gmail.com", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Bilal Hassan", "s1005" }
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "ID", "CourseID", "Description", "Duration", "EndDate", "InstructorId", "IsActive", "StartDate", "Title", "TotalMarks" },
                values: new object[,]
                {
                    { 1, 1, "Midterm exam covering basics", new TimeSpan(0, 2, 0, 0, 0), new DateTime(2024, 3, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, true, new DateTime(2024, 3, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "Intro Programming Midterm", 50m },
                    { 2, 3, "Final exam for DB course", new TimeSpan(0, 3, 0, 0, 0), new DateTime(2024, 6, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, true, new DateTime(2024, 6, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "Database Systems Final", 100m }
                });

            migrationBuilder.InsertData(
                table: "InstructorCourses",
                columns: new[] { "CourseID", "InstructorID", "AssignedDate", "IsActive" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 3, 2, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseID", "StudentID", "EnrollmentDate", "Grade" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1, 2, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 3, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "ID", "CorrectOption", "CreatedDate", "ExamID", "Marks", "OptionA", "OptionB", "OptionC", "OptionD", "QuestionText", "QuestionType" },
                values: new object[] { 1, "A", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5m, "A place to store data", "A function", "A class", "An operator", "What is a variable?", 0 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "ID", "CorrectAnswer", "CreatedDate", "ExamID", "Marks", "QuestionText", "QuestionType" },
                values: new object[] { 2, true, new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5m, "SQL is used to manage relational databases.", 1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "ID", "CreatedDate", "ExamID", "GradingCriteria", "Marks", "MaxWordCount", "QuestionText", "QuestionType" },
                values: new object[] { 3, new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Clarity, completeness, examples", 10m, 500, "Explain normalization and its types.", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ExamAttempts_ExamID",
                table: "ExamAttempts",
                column: "ExamID");

            migrationBuilder.CreateIndex(
                name: "IX_ExamAttempts_StartTime",
                table: "ExamAttempts",
                column: "StartTime");

            migrationBuilder.CreateIndex(
                name: "IX_ExamAttempts_StudentID",
                table: "ExamAttempts",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CourseID",
                table: "Exams",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_InstructorId",
                table: "Exams",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_StartDate",
                table: "Exams",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorCourses_CourseID",
                table: "InstructorCourses",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Email",
                table: "Instructors",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExamID",
                table: "Questions",
                column: "ExamID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_ExamAttemptID",
                table: "StudentAnswers",
                column: "ExamAttemptID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_QuestionId",
                table: "StudentAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseID",
                table: "StudentCourses",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Email",
                table: "Students",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentNumber",
                table: "Students",
                column: "StudentNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructorCourses");

            migrationBuilder.DropTable(
                name: "StudentAnswers");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "ExamAttempts");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
