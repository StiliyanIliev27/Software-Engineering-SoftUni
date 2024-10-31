using Moq;

namespace TestDrivenDevelopmentAndMocking
{
    public class Program
    {
        static void Main(string[] args)
        {
            Mock<ICalculator> calcMock = new Mock<ICalculator>();

            calcMock.Setup(c => c.Add(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(1)
                .Callback<int, int>((a, b) =>
                {
                    Console.WriteLine(a + b);
                });

            Console.WriteLine(calcMock.Object.Add(1, 3));
        }
    }
}