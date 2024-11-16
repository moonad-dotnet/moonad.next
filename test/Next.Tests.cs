namespace Moonad.Next.Tests
{
    public partial class NextExtensionsTests
    {
        [Fact]
        public void Next()
        {
            //Act
            var result = 10.Next(i => $"O número selecionado foi {i}.");

            //Assert
            Assert.Equal("O número selecionado foi 10.", result);
        }

        [Fact]
        public void NextWithAction()
        {
            //Arrange
            bool on = true;
            void TurnOff() => on = false;

            //Act
            on.Next(i => TurnOff());

            //Assert
            Assert.False(on);
        }

        [Fact]
        public static async Task NextAsyncTest()
        {
            //Arrange
            var task = 10.Next(i => Task.FromResult(i + 2.5m));

            //Act
            var result = await task;

            //Assert
            Assert.True(task.IsCompleted);
            Assert.Equal(12.5m, result);
        }

        [Fact]
        public void NextAsyncCancellation()
        {
            //Arrange
            var cancellationToken = new CancellationToken(true);

            async Task<int> cancel(int value, CancellationToken cancellationToken) =>
                await Task.Run(() => value, cancellationToken);

            //Assert
            Assert.ThrowsAsync<TaskCanceledException>(async () => await 0.Next(cancel, cancellationToken));
        }

        [Fact]
        public async void NextAsyncTask()
        {
            //Arrange
            static int timesTen(int value)
                => value * 10;

            //Act
            var result = await Task.Run(() => 10)
                                   .Next(timesTen);

            //Assert
            Assert.Equal(100, result);
        }

        [Fact]
        public async void NextAsyncFromTask()
        {
            //Arrange
            async Task<int> timesTen(int value)
                => await Task.Run(() => value * 10);

            //Act
            var result = await Task.Run(() => 10)
                                   .Next(timesTen);

            //Assert
            Assert.Equal(100, result);
        }

        [Fact]
        public async Task NextAsyncTaskCancellation()
        {
            //Arrange
            var cancellationToken = new CancellationToken(true);

            async Task<int> timesTen(int value, CancellationToken cancellationToken)
                => await Task.Run(() => value * 10, cancellationToken);

            //Assert
            var result = await Assert.ThrowsAsync<TaskCanceledException>(async () => await Task.Run(() => 1).Next(timesTen, cancellationToken));
        }
    }
}
