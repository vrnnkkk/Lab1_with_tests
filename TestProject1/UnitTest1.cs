using System;
using Xunit;
using System.Collections.Generic;
using Lab1;
using Lab1_2;
using System.Collections;
using System.Linq;


namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void OrderRowsByNumberOfSameValues_ShouldNotThrowException()
        {
            // Arrange
            int[,] matrix = {
        { 1, 2, 3, 4 },
        { 2, 3, 4, 5 },
        { 1, 2, 3, 4 },
        { 5, 6, 7, 8 },
        { 1, 2, 3, 4 }
    };

            // Act
            var exception = Record.Exception(() => Lab1_2.Program.OrderRowsByNumberOfSameValues(matrix));

            // Assert
            Assert.Null(exception);
        }


        [Fact]
        public void SearchFirstNumberOfColWithNegValue_ShouldReturnCorrectColumnNumber()
        {
            // Arrange
            int[,] matrix1 = {
                { 1, 2, 3, 4 },
                { -2, 3, 4, 5 },
                { 1, -2, 3, 4 },
                { 5, 6, 7, 8 },
                { 1, 2, 3, 4 }
            };

            // Arrange Console Output
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            Lab1_2.Program.SearchFirstNumberOfColWithNegValue(matrix1);
            string result1 = consoleOutput.ToString().Trim();

            consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);


            // Assert
            Assert.Equal("Номер первого столбца, где нет отрицательных элементов 3", result1);

        }
        private bool IsMatrixOrdered(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                if (matrix[i, 0] > matrix[i + 1, 0])
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Lab1ProgramTests
    {
        [Fact]
        public void NegCount_ShouldReturnCorrectCount()
        {
            // Arrange
            float[] array = { -1.5f, 2.3f, 0.8f, -4.2f, 5.6f };

            // Act
            int result = Lab1.Program.NegCount(array);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void SumAfterMinAbs_ShouldReturnCorrectSum()
        {
            // Arrange
            float[] array = { -1.5f, 2.3f, 0.8f, -4.2f, 5.6f };

            // Act
            float result = Lab1.Program.SumAfterMinAbs(array);

            // Assert
            Assert.Equal(expected: 9.8f, actual: result, precision: 2);
        }

        [Fact]
        public void IndexOfMinAbs_ShouldReturnCorrectIndex()
        {
            // Arrange
            float[] array = { -1.5f, 2.3f, 0.8f, -4.2f, 5.6f };

            // Act
            int result = Lab1.Program.IndexOfMinAbs(array);

            // Assert
            Assert.Equal(2, result);
        }
    }
}