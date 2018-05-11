using GradeBook.Enums;
using System;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Console.WriteLine("**MPC - StandardGradeBook Constructor");
            Type = GradeBookType.Standard;
        }
    }
}
