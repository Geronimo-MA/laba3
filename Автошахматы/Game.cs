using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace AutoChessGame
{
    public class Game
    {
        public Board GameBoard { get; set; }
        public string CurrentPlayer { get; set; }

        public Game()
        {
            GameBoard = new Board();
            GameBoard.Initialize();
            CurrentPlayer = "White";
        }

        public bool MovePiece(string command)
        {
            var parts = command.Split(' ');
            if (parts.Length != 2)
                return false;

            var fromPosition = ParsePosition(parts[0]);
            var toPosition = ParsePosition(parts[1]);

            if (fromPosition == null || toPosition == null)
                return false;

            var piece = GameBoard.GetPieceAt((fromPosition.Value.Item1, fromPosition.Value.Item2));
            if (piece == null || piece.Color != CurrentPlayer)
                return false;

            if (GameBoard.IsPathClear((fromPosition.Value.Item1, fromPosition.Value.Item2), (toPosition.Value.Item1, toPosition.Value.Item2)) &&
                IsMoveValid(piece, (fromPosition.Value.Item1, fromPosition.Value.Item2), (toPosition.Value.Item1, toPosition.Value.Item2)))
            {
                piece.Position = (toPosition.Value.Item1, toPosition.Value.Item2);
                CurrentPlayer = CurrentPlayer == "White" ? "Black" : "White";
                return true;
            }

            return false;
        }

        private (int, int)? ParsePosition(string pos)
        {
            if (pos.Length != 2)
                return null;

            char file = pos[0];
            char rank = pos[1];

            if (file < 'a' || file > 'h' || rank < '1' || rank > '8')
                return null;

            return (file - 'a', rank - '1');
        }

        private bool IsMoveValid(Piece piece, (int, int) from, (int, int) to)
        {
            return true;
        }

        // Сохранение игры в XML
        public void SaveGame(string fileName = "savegame.xml")
        {
            string saveDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Saves");
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }

            string filePath = Path.Combine(saveDirectory, fileName);

            // Сериализация в XML
            var serializer = new XmlSerializer(typeof(Game));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, this);
            }

            Console.WriteLine($"Игра сохранена в {filePath}");
        }

        // Загрузка игры из XML
        public static Game LoadGame(string fileName = "savegame.xml")
        {
            string saveDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Saves");
            string filePath = Path.Combine(saveDirectory, fileName);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл сохранения не найден: {filePath}");
            }

            // Десериализация из XML
            var serializer = new XmlSerializer(typeof(Game));
            using (var reader = new StreamReader(filePath))
            {
                return (Game)serializer.Deserialize(reader);
            }
        }
    }
}
