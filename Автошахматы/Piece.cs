using System;
using System.Xml.Serialization;

namespace AutoChessGame
{
    public class Piece
    {
        [XmlElement("Type")]
        public string Type { get; set; }
        [XmlElement("Color")]
        public string Color { get; set; }
        [XmlElement("Position")]
        public (int x, int y) Position { get; set; }

        public Piece() { } // Пустой конструктор для сериализации

        public Piece(string type, string color, (int x, int y) position)
        {
            Type = type;
            Color = color;
            Position = position;
        }

        // Виртуальный метод для проверки допустимости хода
        public virtual bool IsValidMove(int startX, int startY, int endX, int endY)
        {
            return false; // Базовая фигура не может двигаться (или используется как шаблон)
        }

        public override string ToString() => $"{Color} {Type} at ({Position.x}, {Position.y})";
    }
}
