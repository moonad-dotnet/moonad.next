namespace Moonad.Next.Tests
{
    public partial class NextExtensionsTests
    {
        [Fact]
        public void NextT2()
        {
            //Act
            var result = (8, 2).Next((x, y) => x * y).Next((i) => $"Sum result: {i}");
            
            //Assert
            Assert.Equal("Sum result: 16", result);
        }
    } 
}
