using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public class StudyClass {
                public String className { get; set; }
                public List<Student> Students { get; set; }
        }

        public class Student {
                public String studentName { get; set; }
        }

        private static StudyClass GetClassData()
        {
            StudyClass Sc = new StudyClass();
            return Sc;
            
        }

        static void Main(string[] args)
        {

            var classObject = GetClassData();

            var StudyClass = new StudyClass()
            {
                className = classObject.Students
            };
            foreach (var student in classObject.students)
            {
                    StudyClass.
            }
         }

        
    }
}
