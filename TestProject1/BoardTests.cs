using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChessGame;

namespace AutoChessGameTests
{
    public class BoardTests
    {
        [Fact]
        public void Initialize_ShouldPlaceAllPiecesOnBoard()
        {
            // Arrange
            var board = new Board();
            board.Initialize();

            // Act
            var rookAtA1 = board.GetPieceAt((0, 0));
            var knightAtB1 = board.GetPieceAt((1, 0));

            // Assert
            Assert.NotNull(rookAtA1);
            Assert.Equal("Rook", rookAtA1.Type);
            Assert.NotNull(knightAtB1);
            Assert.Equal("Knight", knightAtB1.Type);
        }

        [Fact]
        public void IsEmpty_ShouldReturnTrueIfCellIsEmpty()
        {
            // Arrange
            var board = new Board();
            board.Initialize();

            // Act
            var isEmpty = board.IsEmpty((4, 4)); // Пустая клетка

            // Assert
            Assert.True(isEmpty);
        }

        [Fact]
        public void IsEmpty_ShouldReturnFalseIfCellIsOccupied()
        {
            // Arrange
            var board = new Board();
            board.Initialize();

            // Act
            var isEmpty = board.IsEmpty((0, 0)); // Занята ладьей

            // Assert
            Assert.False(isEmpty);
        }
    }
}
