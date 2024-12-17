using System;
using Xunit;
using AutoChessGame;

namespace TestProject1
{
    public class PieceTests
    {
        [Fact]
        public void TestIsValidMove_Pawn_ValidMove()
        {
            // Пример создания объекта фигуры (например, пешка)
            var pawn = new Pawn("White", (0, 1)); // Пешка на позиции (0, 1)

            // Проверяем правильность хода для пешки
            // Пешка может двигаться только на одну клетку вперед, например, на (0, 2)
            bool isValid = pawn.IsValidMove(0, 1, 0, 2);

            // Ожидаем, что ход будет допустимым
            Assert.True(isValid);
        }

        [Fact]
        public void TestIsValidMove_Pawn_InvalidMove()
        {
            var pawn = new Pawn("White", (0, 1)); // Пешка на позиции (0, 1)

            // Пример недопустимого хода для пешки
            // Пешка не может двигаться на (1, 2), так как она не может двигаться по диагонали
            bool isValid = pawn.IsValidMove(0, 1, 1, 2);

            // Ожидаем, что ход будет недопустимым
            Assert.False(isValid);
        }
    }
}
