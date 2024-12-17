namespace AutoChessGame
{
    public class Pawn : Piece
    {
        public Pawn(string color, (int x, int y) position)
            : base("Pawn", color, position)
        {
        }

        // Переопределение метода для проверки допустимости хода для пешки
        public override bool IsValidMove(int startX, int startY, int endX, int endY)
        {
            // Пешка может двигаться на одну клетку вперед, если на целевой клетке нет фигуры
            // Или может быть ход по диагонали на одну клетку, если это взятие
            if (startX == endX && startY + 1 == endY) // обычный ход вперед
            {
                return true;
            }
            return false; // В остальных случаях ход недопустим
        }
    }
}
