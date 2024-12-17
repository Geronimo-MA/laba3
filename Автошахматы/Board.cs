using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AutoChessGame
{
    public class Board
    {
        [XmlArray("Pieces")]
        [XmlArrayItem("Piece")]
        public List<Piece> Pieces { get; set; } = new List<Piece>();

        public void Initialize()
        {
            // Белые фигуры
            Pieces.Add(new Piece("Rook", "White", (0, 0)));
            Pieces.Add(new Piece("Knight", "White", (1, 0)));
            Pieces.Add(new Piece("Bishop", "White", (2, 0)));
            Pieces.Add(new Piece("Queen", "White", (3, 0)));
            Pieces.Add(new Piece("King", "White", (4, 0)));
            Pieces.Add(new Piece("Bishop", "White", (5, 0)));
            Pieces.Add(new Piece("Knight", "White", (6, 0)));
            Pieces.Add(new Piece("Rook", "White", (7, 0)));
            for (int i = 0; i < 8; i++)
                Pieces.Add(new Piece("Pawn", "White", (i, 1)));

            // Черные фигуры
            Pieces.Add(new Piece("Rook", "Black", (0, 7)));
            Pieces.Add(new Piece("Knight", "Black", (1, 7)));
            Pieces.Add(new Piece("Bishop", "Black", (2, 7)));
            Pieces.Add(new Piece("Queen", "Black", (3, 7)));
            Pieces.Add(new Piece("King", "Black", (4, 7)));
            Pieces.Add(new Piece("Bishop", "Black", (5, 7)));
            Pieces.Add(new Piece("Knight", "Black", (6, 7)));
            Pieces.Add(new Piece("Rook", "Black", (7, 7)));
            for (int i = 0; i < 8; i++)
                Pieces.Add(new Piece("Pawn", "Black", (i, 6)));
        }

        public Piece GetPieceAt((int x, int y) position) =>
            Pieces.Find(p => p.Position == position);

        public bool IsEmpty((int x, int y) position) =>
            GetPieceAt(position) == null;

        public bool IsPathClear((int x, int y) from, (int x, int y) to)
        {
            int dx = Math.Sign(to.Item1 - from.Item1);
            int dy = Math.Sign(to.Item2 - from.Item2);
            var current = (from.Item1 + dx, from.Item2 + dy);

            while (current != to)
            {
                if (!IsEmpty(current))
                    return false;
                current = (current.Item1 + dx, current.Item2 + dy);
            }

            return true;
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("\n   a b c d e f g h ");
            Console.WriteLine("  -----------------");
            for (int y = 7; y >= 0; y--)
            {
                Console.Write($"{y + 1}| ");
                for (int x = 0; x < 8; x++)
                {
                    var piece = GetPieceAt((x, y));
                    if (piece != null)
                    {
                        Console.ForegroundColor = piece.Color == "White" ? ConsoleColor.White : ConsoleColor.DarkYellow;
                        Console.Write($"{GetSymbol(piece.Type)} ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }
                Console.WriteLine($"|{y + 1}");
            }
            Console.WriteLine("  -----------------");
            Console.WriteLine("   a b c d e f g h \n");
        }

        private char GetSymbol(string type) => type switch
        {
            "Rook" => 'R',
            "Knight" => 'N',
            "Bishop" => 'B',
            "Queen" => 'Q',
            "King" => 'K',
            "Pawn" => 'P',
            _ => '?'
        };
    }
}
