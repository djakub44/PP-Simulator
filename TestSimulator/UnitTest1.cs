using Simulator;
using Simulator.Maps;
using Xunit.Sdk;
namespace TestSimulator
{
    public class ValidateTests
    {
        [Theory]
        [InlineData(3,5)]
        [InlineData(15,10)]
        [InlineData(-1,5)]
        [InlineData(7,7)]
        public void Limit_IntShouldReturnCorrectValue(int n, int expected)
        {
            int min = 5;
            int max = 10;
            Assert.Equal(expected, Validate.Limit(n,min,max));
        }

        [Theory]
        [InlineData("qwertyqwerty", "Qwert")]
        [InlineData("qwerty   ", "Qwert")]
        [InlineData("qw       ertyqwerty", "Qw#")]
        [InlineData("     qwertyuop", "Qwert")]
        public void Limit_StringShouldReturnCorrectValue(string s, string expected)
        {
            int min = 3;
            int max = 5;
            Assert.Equal(expected, Validate.Limit(s, min, max));
        }

        [Theory]
        [InlineData(3, 4)]
        [InlineData(-8, -7)]
        [InlineData(10, 0)]
        [InlineData(9, 10)]
        public void Counter_ShouldReturnCorrectValue(int n, int expected)
        {
            int max = 10;
            Assert.Equal(expected,Validate.Counter(n,max));
        }

        [Theory]
        [InlineData(3,false)]
        [InlineData(-8, false)]
        [InlineData(10, true)]
        [InlineData(5, true)]
        [InlineData(7, true)]
        [InlineData(15, false)]
        public void LimitSize_ShouldReturnCorrectValue(int size, bool expected)
        {
            int min = 5;
            int max = 10;
            Assert.Equal(expected, Validate.LimitSize(size, min, max));
        }

        [Theory]
        [InlineData(1,1,1,2,true)]
        [InlineData(1, 2, 5, 2, true)]
        [InlineData(1, 2, 3, 4, false)]
        [InlineData(1, 1, 1, 1, true)]
        public void Collinear_ShouldReturnCorrectValue(int x1, int y1, int x2, int y2,bool expected)
        {
            Point p1 = new(x1, y1);
            Point p2 = new(x2, y2);

            Assert.Equal(expected, Validate.Collinear(p1, p2));
        }
    }
    public class RectangleTests
    {
        [Fact]
        public void Constructor_ValidIntegers()
        {
            var (x1, y1, x2, y2) = (1, 2, 3, 4);
            Rectangle r = new(x1,y1,x2,y2);
            Assert.Equal(r.ToString(), $"({x1}, {y1}):({x2}, {y2})");
        }

        [Fact]
        public void Constructor_ValidIntegersSwappedCorners()
        {
            var (x1, y1, x2, y2) = (3, 4, 1, 2);
            Rectangle r = new(x1, y1, x2, y2);
            Assert.Equal(r.ToString(), $"({x2}, {y2}):({x1}, {y1})");
        }

        [Fact]
        public void Constructor_ValidPoints()
        {
            Point p1 = new(1, 2);
            Point p2 = new(3, 4);
            Rectangle r = new(p1, p2);
            Assert.Equal(r.ToString(), $"({p1.X}, {p1.Y}):({p2.X}, {p2.Y})");
        }

        [Fact]
        public void Constructor_ValidPointsSwappedCorners()
        {
            Point p1 = new(1, 2);
            Point p2 = new(3, 4);
            Rectangle r = new(p2, p1);
            Assert.Equal(r.ToString(), $"({p1.X}, {p1.Y}):({p2.X}, {p2.Y})");
        }

        [Fact]
        public void Constructor_InvalidPointsCollinear()
        {
            Assert.Throws<ArgumentException>(() => new Rectangle(1, 2, 1, 4));
        }
        [Theory]
        [InlineData(2,2,true)]
        [InlineData(5, 5, false)]
        [InlineData(4, 4, true)]
        public void Contains_IntegersShouldReturnCorrectValue(int x,int y,bool expected)
        {
            Rectangle r = new(1,1,4,4);
            Assert.Equal(expected,r.Contains(x,y));
        }

        [Theory]
        [InlineData(2, 2, true)]
        [InlineData(5, 5, false)]
        [InlineData(4, 4, true)]
        public void Contains_PointsShouldReturnCorrectValue(int x, int y, bool expected)
        {
            Point p = new(x, y);
            Rectangle r = new(1, 1, 4, 4);
            Assert.Equal(expected, r.Contains(p));
        }
    }

    public class PointTests
    {
        [Fact]
        public void Constructor_Valid()
        {
            Point point = new(1,2);
            Assert.Equal((1, 2), (point.X, point.Y));
        }

        [Fact]
        public void Constructor_Valid_Default()
        {
            Point point = new();
            Assert.Equal((0, 0), (point.X, point.Y));
        }


        [Theory]
        [InlineData(2, 2, Direction.Left, 1, 2)]
        [InlineData(2, 2, Direction.Right, 3, 2)]
        [InlineData(2, 2, Direction.Up, 2, 3)]
        [InlineData(2, 2, Direction.Down, 2, 1)]
        [InlineData(-2, -2, Direction.Down, -2, -3)]
        public void Next_SholdReturnCorrectValue(int x, int y, Direction direction, int expectedX, int expectedY)
        {
            Assert.Equal(new Point(expectedX, expectedY), new Point(x, y).Next(direction));
        }

        [Theory]
        [InlineData(2, 2, Direction.Left, 1, 3)]
        [InlineData(2, 2, Direction.Right, 3, 1)]
        [InlineData(2, 2, Direction.Up, 3, 3)]
        [InlineData(2, 2, Direction.Down, 1, 1)]
        [InlineData(-2, -2, Direction.Down, -3, -3)]
        public void NextDiagonal_SholdReturnCorrectValue(int x, int y, Direction direction, int expectedX, int expectedY)
        {
            Assert.Equal(new Point(expectedX, expectedY), new Point(x, y).NextDiagonal(direction));
        }

    }
    public class SmallSquareMapTests
    {
        [Fact]
        public void Constructor_Valid_ShouldSetSizeX()
        {
            int size = 10;
            var m = new SmallSquareMap(size);
            Assert.Equal(size, m.SizeX);
        }

        [Fact]
        public void Constructor_Valid_ShouldSetSizeY()
        {
            int size = 10;
            var m = new SmallSquareMap(size);
            Assert.Equal(size, m.SizeY);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(2)]
        [InlineData(100)]
        public void Constructor_ShouldThrowOutOfRange(int size)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
        }

        [Theory]
        [InlineData(1,2,true)]
        [InlineData(0, 0, true)]
        [InlineData(-1, 2, false)]
        [InlineData(11, 2, false)]
        [InlineData(9, 9, true)]
        [InlineData(1, 11, false)]
        public void Exist_ShouldReturnCorrectValue(int x, int y, bool expected)
        {
            int size = 10;
            var m = new SmallSquareMap(size);
            Assert.Equal(expected, m.Exist(new Point(x, y)));
        }

        [Theory]
        [InlineData(2, 2, Direction.Left, 1, 2)]
        [InlineData(2, 2, Direction.Right, 3, 2)]
        [InlineData(2, 2, Direction.Up, 2, 3)]
        [InlineData(2, 2, Direction.Down, 2, 1)]
        [InlineData(0, 2, Direction.Left, 0, 2)]
        [InlineData(9, 2, Direction.Right, 9, 2)]
        [InlineData(2, 9, Direction.Up, 2, 9)]
        [InlineData(2, 0, Direction.Down, 2, 0)]
        [InlineData(15, 15, Direction.Left, 15, 15)]
        public void Next_SholdReturnCorrectValue(int x, int y,Direction direction, int expectedX,int expectedY)
        {
            int size = 10;
            var m = new SmallSquareMap(size);
            Assert.Equal(new Point(expectedX,expectedY), m.Next(new Point(x, y), direction));
        }

        [Theory]
        [InlineData(2, 2, Direction.Left, 1, 3)]
        [InlineData(2, 2, Direction.Right, 3, 1)]
        [InlineData(2, 2, Direction.Up, 3, 3)]
        [InlineData(2, 2, Direction.Down, 1, 1)]
        [InlineData(0, 2, Direction.Left, 0, 2)]
        [InlineData(9, 2, Direction.Right, 9, 2)]
        [InlineData(2, 9, Direction.Up, 2, 9)]
        [InlineData(2, 0, Direction.Down, 2, 0)]
        [InlineData(15, 15, Direction.Left, 15, 15)]
        public void NextDiagonal_SholdReturnCorrectValue(int x, int y, Direction direction, int expectedX, int expectedY)
        {
            int size = 10;
            var m = new SmallSquareMap(size);
            Assert.Equal(new Point(expectedX, expectedY), m.NextDiagonal(new Point(x, y), direction));
        }

    }
    public class SmallTorusMapTests
    {
        [Fact]
        public void Constructor_ValidSize_ShouldSetSizeX()
        {
            // Arrange
            int sizeX = 10;
            int sizeY = 10;
            // Act
            var map = new SmallTorusMap(sizeX,sizeY);
            // Assert
            Assert.Equal(sizeX, map.SizeX);
        }

        [Fact]
        public void Constructor_ValidSize_ShouldSetSizeY()
        {
            // Arrange
            int sizeX = 10;
            int sizeY = 8;
            // Act
            var map = new SmallTorusMap(sizeX, sizeY);
            // Assert
            Assert.Equal(sizeY, map.SizeY);
        }

        [Theory]
        [InlineData(4,10)]
        [InlineData(21,7)]
        public void
            Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException
            (int sizeX, int sizeY)
        {
            // Act & Assert
            // The way to check if method throws anticipated exception:
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                 new SmallTorusMap(sizeX, sizeY));
        }

        [Theory]
        [InlineData(3, 4, 5, 5, true)]
        [InlineData(6, 1, 5, 5,  false)]
        [InlineData(19, 19, 20, 20, true)]
        [InlineData(20, 20, 20, 20, false)]
        public void Exist_ShouldReturnCorrectValue(int x, int y,
            int sizeX, int sizeY, bool expected)
        {
            // Arrange
            var map = new SmallTorusMap(sizeX, sizeY);
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
            var map = new SmallTorusMap(20,20);
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
            var map = new SmallTorusMap(20, 20);
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