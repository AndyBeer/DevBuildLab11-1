using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace PigLatinTest
{
    public class TestProgram
    {//added the xunit unit test suite
        //commented main method out of Program.cs
        //made the test class public
        [Fact]
        public void TestToPigLatin()
        {

            //Arrange
            PigLatin p = new PigLatin();
            string expected = "appleway";
            //Act
            string actual = p.ToPigLatin("apple");
            //Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("apple", "appleway")]
        [InlineData("heck", "eckhhay")]
        [InlineData("strong", "ongstray")]
        [InlineData("tommy@email.com", "tommy@email.com")]
        [InlineData("aardvark", "aardvarkway")]
        [InlineData("Tommy", "ommytay")]
        [InlineData("gym", "gym")]
        [InlineData("apple joy gym tommy@email.com strong", "appleway oyjay gym tommy@email.com ongstray")]
        //First run of these shows that ONLY "gym" and email formatting working as expected


        public void TestPigLatinTheory(string word, string expected)
        {
            PigLatin p = new PigLatin();
            string actual = p.ToPigLatin(word);
            Assert.Equal(expected, actual);
        }
        //The string with spaces breaks our Theory unit test
    }
    
}
