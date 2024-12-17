using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChessGame;

namespace AutoChessGameTests
{
    public class GameTests
    {
        [Fact]
        public void NewGame_ShouldInitializeWithWhitePlayer()
        {
            // Arrange
            var game = new Game();

            // Act
            var currentPlayer = game.CurrentPlayer;

            // Assert
            Assert.Equal("White", currentPlayer);
        }

        [Fact]
        public void MovePiece_ShouldReturnFalseForInvalidMove()
        {
            // Arrange
            var game = new Game();
            string invalidMove = "e2 e5"; // Пешка не может двигаться на две клетки вперед в первый ход.

            // Act
            var result = game.MovePiece(invalidMove);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void MovePiece_ShouldReturnTrueForValidMove()
        {
            // Arrange
            var game = new Game();
            string validMove = "e2 e3"; // Пешка двигается на одну клетку вперед.

            // Act
            var result = game.MovePiece(validMove);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void LoadGame_ShouldLoadSavedGameCorrectly()
        {
            // Arrange
            string fileName = "test_game.json";
            var game = new Game();
            game.MovePiece("e2 e4");
            game.SaveGame(fileName);

            // Act
            var loadedGame = Game.LoadGame(fileName);

            // Assert
            Assert.NotNull(loadedGame);
            Assert.Equal("White", loadedGame.CurrentPlayer);
            var piece = loadedGame.GameBoard.GetPieceAt((4, 3)); // Проверка, что пешка на правильной позиции.
            Assert.NotNull(piece);
            Assert.Equal("Pawn", piece.Type);
        }
    }
}
