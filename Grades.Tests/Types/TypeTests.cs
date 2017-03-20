using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.Types
{
    [TestClass]
   public class TypeTests
    {
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];
            AddGrades(grades);
            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void UpperCaseAString()
        {
            string name = "Frank";
           name= name.ToUpper();
            Assert.AreEqual("FRANK", name);
        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
           date= date.AddDays(1);
            Assert.AreEqual(2, date.Day);
        }
        [TestMethod]
        public void ValueTypesParseByValue()
        {
            int x = 46;
            IncreamentNumber(x);
            Assert.AreEqual(46, x);
        }
        private void IncreamentNumber(int number)
        {
            number += 1;
        }
        //[TestMethod]
        //public void ReferenceTypesParseByValue()
        //{
        //    GradeBook book1 = new GradeBook();
        //    GradeBook book2 = book1;
        //    GiveBookAName(book2);
        //    Assert.AreEqual("A grade book", book1.Name);
        //}
        private void GiveBookAName(GradeBook book)
        {
            book.Name = "A grade book";
        }
        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Frank";
            string name2 = "frank";
            bool result = string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IntVariablesHoldsAvalue()
        {
            int x1 = 100;
            int x2 = x1;
            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }
        //[TestMethod]
        //public void GradeBookvariablesHoldReference()
        //{
        //    GradeBook g1 = new GradeBook();
        //    GradeBook g2 = g1;
        //    g1.Name = "Frank's Gradebook";
        //    Assert.AreEqual(g1.Name, g2.Name);
        //}
    }
}
