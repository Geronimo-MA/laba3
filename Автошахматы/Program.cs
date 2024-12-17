using System;

namespace AutoChessGame
{
    class Program
    {
        static void Main()
        {
            Game game;

            Console.WriteLine("Новая игра или загрузить? (new/load)");
            string command = Console.ReadLine()?.ToLower();

            if (command == "load")
            {
                try
                {
                    game = Game.LoadGame();
                    Console.WriteLine("Игра успешно загружена!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка загрузки: " + ex.Message);
                    Console.WriteLine("Начата новая игра.");
                    game = new Game();
                }
            }
            else
            {
                game = new Game();
            }

            while (true)
            {
                game.GameBoard.Display();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Текущий игрок: {game.CurrentPlayer}");
                Console.ResetColor();
                Console.WriteLine("Введите ход (например, 'e2 e4') или 'exit' или 'save':");

                command = Console.ReadLine();
                if (command.ToLower() == "exit")
                {
                    Console.WriteLine("Игра завершена. Спасибо за игру!");
                    break;
                }
                else if (command.ToLower() == "save")
                {
                    game.SaveGame();
                    Console.WriteLine("Игра успешно сохранена!");
                }
                else if (!game.MovePiece(command))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка. Попробуйте снова.");
                    Console.ResetColor();
                }
            }
        }
    }
}
