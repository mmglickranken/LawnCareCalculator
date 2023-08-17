using System;

namespace HOT2_GPA2LetterGradeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AttemptToCalculate();
        }

        private static void AttemptToCalculate()
        {
            bool    result      = false;
            string  promt       = "Enter GPA: ";
            decimal gpa         = 0m;
            string  letterGrade = "";

            Console.WriteLine(promt);

            result = Decimal.TryParse((Console.ReadLine()), out gpa);

            // Validate that GPA is numeric.
            if (!result)
            {
                do
                {
                    Console.WriteLine("Numeric grade must be a positive numeric, that is within range! (0 - 4)");
                    Console.WriteLine("\n" + promt);

                    result = Decimal.TryParse(Console.ReadLine(), out gpa);
                }
                while (!result);
            }

            // Validate that GPA is within range.
            if ((gpa < 0) || (gpa > 4))
            {
                do
                {
                    Console.WriteLine("GPA OUT OF RANGE (< 0 or > 4)");
                    Console.WriteLine("\n" + promt);

                    result = Decimal.TryParse(Console.ReadLine(), out gpa);
                }
                while ((gpa < 0) || (gpa > 4));
            }

            // letterGrade = "F".
            if (gpa < 1)
            {
                result = true;
                letterGrade = "F";
            }

            // letterGrade = "D".
            else if (gpa > 0.0m && gpa <= 1.5m)
            {
                letterGrade = "D";
            }

            // letterGrade = "C".
            else if (gpa > 1.5m && gpa <= 2.5m)
            {
                letterGrade = "C";
            }

            // letterGrade = "B".
            else if (gpa > 2.5m && gpa <= 3.2m)
            {
                letterGrade = "B";
            }

            // letterGrade = "A".
            else
            {
                letterGrade = "A";
            }

            Console.WriteLine("\nYour letter grade is: " + letterGrade + ".");
            Console.ReadLine();
            AttemptToCalculate();
        }
    }
}
