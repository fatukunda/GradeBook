﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = new ThrowAwayGradeBook();
            book.NameChanged += onNameChanged;
            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }
            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Higest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a grade book name");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine(description + " : " + result);
        }
        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + " : " + result);
        }
        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description} : {result} ");//string interporlation
        }
        static void onNameChanged(object sender, NameChangedEventArgs  args)
        {
            Console.WriteLine($"Grade book changed from {args.ExistingName} to {args.NewName}");
        }
    }
    
}
