using System;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace BuildingSystem.Tests
{
    public class Calculator
    {
        [Fact] // metodun test metodu olduðunu saðlayan attiribute
        public void Be_Able_To_Add_Two_Numbers()
        {

            // Arrange  : Hazýrla
            int number1 = 10;
            int number2 = 20;
            var sut = new CalculatorMethod();

            //Act : iþle

            int result =sut.Addition(number1, number2);

            // Assert : göster

            Assert.Equal(30, result);


            

            
        }
    }
}
