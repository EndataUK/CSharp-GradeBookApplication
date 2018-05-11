using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Console.WriteLine("**MPC - RankedGradeBook Constructor");
            Type = GradeBookType.Ranked;
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
            return;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
            return;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work.");
            }
            else
            {
                int graderank = (int)Math.Ceiling(Students.Count / 5.0);
                var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

                if (averageGrade >= grades[graderank - 1])
                {
                    return 'A';
                }
                else if (averageGrade >= grades[graderank * 2 - 1])
                {
                    return 'B';
                }
                else if (averageGrade >= grades[graderank * 3 - 1])
                {
                    return 'C';
                }
                else if (averageGrade >= grades[graderank * 4 - 1])
                {
                    return 'D';
                }
                else
                {
                    return 'F';
                }
            }
        }
    }
}
