namespace Moonad.Next.Tests
{
    public partial class NextExtensionsTests
    {
        [Fact]
        public void NextT3()
        {
            //Act
            var result = (1, 3, 5).Next((x, y, z) => (x + y, z))
                                  .Next((x, y) => x * y)
                                  .Next(x => Math.Pow(x, 2));

            //Assert
            Assert.Equal(400, result);
        }
    }
}

