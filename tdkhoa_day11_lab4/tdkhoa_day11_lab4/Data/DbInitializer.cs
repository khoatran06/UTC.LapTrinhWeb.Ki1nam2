using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using tdkhoa_day11_lab4.Models;

namespace tdkhoa_day11_lab4.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SchoolContext>>()))
            {
                // Tạo database nếu chưa tồn tại
                context.Database.EnsureCreated();

                // Nếu đã có dữ liệu chuyên ngành thì không thêm lại
                if (context.Majors.Any())
                {
                    return;
                }

                // Thêm chuyên ngành
                var majors = new Major[]
                {
                    new Major { MajorName = "IT" },
                    new Major { MajorName = "Economics" },
                    new Major { MajorName = "Mathematics" }
                };

                foreach (var major in majors)
                {
                    context.Majors.Add(major);
                }

                context.SaveChanges();

                // Thêm sinh viên
                var learners = new Learner[]
                {
                    new Learner
                    {
                        FirstMidName = "Carson",
                        LastName = "Alexander",
                        EnrollmentDate = DateTime.Parse("2005-09-01"),
                        MajorID = 1
                    },
                    new Learner
                    {
                        FirstMidName = "Meredith",
                        LastName = "Alonso",
                        EnrollmentDate = DateTime.Parse("2002-09-01"),
                        MajorID = 2
                    }
                };

                foreach (var learner in learners)
                {
                    context.Learners.Add(learner);
                }

                context.SaveChanges();

                // Thêm môn học
                var courses = new Course[]
                {
                    new Course
                    {
                        CourseID = 1050,
                        Title = "Chemistry",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 4022,
                        Title = "Microeconomics",
                        Credits = 3
                    },
                    new Course
                    {
                        CourseID = 4041,
                        Title = "Macroeconomics",
                        Credits = 3
                    }
                };

                foreach (var course in courses)
                {
                    context.Courses.Add(course);
                }

                context.SaveChanges();

                // Thêm dữ liệu đăng ký môn học
                var enrollments = new Enrollment[]
                {
                    new Enrollment
                    {
                        LearnerID = 1,
                        CourseID = 1050,
                        Grade = 5.5f
                    },
                    new Enrollment
                    {
                        LearnerID = 1,
                        CourseID = 4022,
                        Grade = 7.5f
                    },
                    new Enrollment
                    {
                        LearnerID = 2,
                        CourseID = 1050,
                        Grade = 3.5f
                    },
                    new Enrollment
                    {
                        LearnerID = 2,
                        CourseID = 4041,
                        Grade = 7.0f
                    }
                };

                foreach (var enrollment in enrollments)
                {
                    context.Enrollments.Add(enrollment);
                }

                context.SaveChanges();
            }
        }
    }
}