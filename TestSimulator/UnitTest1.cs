using Simulator;
using Simulator.Maps;
namespace TestSimulator
{

    public class SmallTorusMapTests
    {
        [Fact]
        public void Constructor_ValidSize_ShouldSetSize()
        {
            // Arrange
            int size = 10;
            // Act
            var map = new SmallTorusMap(size);
            // Assert
            Assert.Equal(size, map.Size);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(21)]
        public void
            Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException
            (int size)
        {
            // Act & Assert
            // The way to check if method throws anticipated exception:
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                 new SmallTorusMap(size));
        }

        [Theory]
        [InlineData(3, 4, 5, true)]
        [InlineData(6, 1, 5, false)]
        [InlineData(19, 19, 20, true)]
        [InlineData(20, 20, 20, false)]
        public void Exist_ShouldReturnCorrectValue(int x, int y,
            int size, bool expected)
        {
            // Arrange
            var map = new SmallTorusMap(size);
            var point = new Point(x, y);
            // Act
            var result = map.Exist(point);
            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5, 10, Direction.Up, 5, 11)]
        [InlineData(0, 0, Direction.Down, 0, 19)]
        [InlineData(0, 8, Direction.Left, 19, 8)]
        [InlineData(19, 10, Direction.Right, 0, 10)]
        public void Next_ShouldReturnCorrectNextPoint(int x, int y,
            Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var map = new SmallTorusMap(20);
            var point = new Point(x, y);
            // Act
            var nextPoint = map.Next(point, direction);
            // Assert
            Assert.Equal(new Point(expectedX, expectedY), nextPoint);
        }

        [Theory]
        [InlineData(5, 10, Direction.Up, 6, 11)]
        [InlineData(0, 0, Direction.Down, 19, 19)]
        [InlineData(0, 8, Direction.Left, 19, 9)]
        [InlineData(19, 10, Direction.Right, 0, 9)]
        public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y,
            Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var map = new SmallTorusMap(20);
            var point = new Point(x, y);
            // Act
            var nextPoint = map.NextDiagonal(point, direction);
            // Assert
            Assert.Equal(new Point(expectedX, expectedY), nextPoint);
        }
    }
    //public class DirectionParserTests
    //{
    //    [Fact]
    //    public void Parse_ShouldParseDirectionsCorrectly()
    //    {
    //        // Arrange
    //        string input = "URDL";
    //        // Act
    //        var result = DirectionParser.Parse(input);
    //        // Assert
    //        Assert.Equal([Direction.Up, Direction.Right,
    //        Direction.Down, Direction.Left],
    //            result
    //        );
    //    }

    //    [Fact]
    //    public void Parse_ShouldHandleLowercaseLetters()
    //    {
    //        // Arrange
    //        string input = "urdl";
    //        // Act
    //        var result = DirectionParser.Parse(input);
    //        // Assert
    //        Assert.Equal([Direction.Up, Direction.Right,
    //        Direction.Down, Direction.Left],
    //            result
    //        );
    //    }

    //    [Fact]
    //    public void Parse_ShouldReturnEmptyArrayForEmptyString()
    //    {
    //        // Arrange
    //        string input = "";
    //        // Act
    //        var result = DirectionParser.Parse(input);
    //        // Assert
    //        Assert.Empty(result);
    //    }

    //    [Theory]
    //    [InlineData("urdlx", new[] { Direction.Up, Direction.Right,
    //    Direction.Down, Direction.Left })]
    //    [InlineData("xxxdR lyyLTyu", new[] { Direction.Down,
    //     Direction.Right, Direction.Left, Direction.Left,
    //     Direction.Up })]

    //    public void Parse_ShouldIgnoreInvalidCharacters(string s,
    //        Direction[] expected)
    //    {
    //        // Arrange 
    //        // use [Theory] [InlineData] to check multiple sets of data
    //        // Act
    //        var result = DirectionParser.Parse(s);
    //        // Assert
    //        Assert.Equal(expected, result);
    //    }
    //}
}