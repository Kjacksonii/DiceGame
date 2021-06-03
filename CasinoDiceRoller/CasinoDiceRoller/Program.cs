using System;
using System.Collections.Generic;

namespace CasinoDiceRoller
{
    class Program
    {
        static void Main(string[] args)
        {
            RollDice dice = new RollDice();
            dice.Run();
            Console.ReadKey();
        }
    }

    public class RollDice
    {
        private const int maxDice = 2;
        private const int minDice = 1;
        private const int maxSides = 10;
        private const int minSides = 6;

        private Dice[] _dices;

        private List<string> _menuItems = new List<string>
    {
        "Exit",
        "Setup Dice",
        "Roll"
    };

        public void Run()
        {
            Console.Write("Welcome to GC Craps Table!");
            while (true)
            {
                ShowMenu(_menuItems);
                switch (ConsoleHelper.ReadInteger("Enter your selection: ", 0, _menuItems.Count - 1))
                {
                    case 1:
                        Setup();
                        break;
                    case 2:
                        Roll();
                        break;
                    case 0:
                        Console.WriteLine("Bye.");
                        return;
                    default:
                        //Console.WriteLine("Error: Unexpected menu input!");
                        break;
                }
            }
        }

        private void Roll()
        {
            if (_dices == null)
            {
                Console.WriteLine("Please setup the Roll Dice first.");
                return;
            }

            Console.WriteLine("Rolling...");
            for (int i = 0; i < _dices.Length; i++)
            {
                _dices[i].Roll();

            }
            Console.WriteLine($"You rolled: {string.Join(", ", (object[])_dices)}");
                
            

            int total = 0;
            for (int i = 0; i < _dices.Length; i++)
            {
                if (_dices[i].Value == 1 && _dices[i].Value == 1)
                {
                    Console.WriteLine("Snake Eyes!");
                }
                else if (_dices[i].Value == 1 && _dices[i].Value == 2)
                {
                    Console.WriteLine("Ace Deuce");
                }
                else if (_dices[i].Value == 6 && _dices[i].Value == 6)
                {
                    Console.WriteLine("Box Car");
                }
                    total += _dices[i].Value;
            }
            Console.WriteLine($"Total rolled is {total}");
            if (total == 2)
            {
                Console.WriteLine("Craps!");
            }
            else if (total == 3)
            {
                Console.WriteLine("Craps!");
            }
            else if (total == 12)
            {
                Console.WriteLine("Craps!");
            }
            else if (total == 7 || total == 11)
            {
                Console.WriteLine("YOU WIN!!!");
            }
        }

        private void Setup()
        {
            int diceCount = ConsoleHelper.ReadInteger("How many dice do you want to throw? ", minDice, maxDice);
            int sides = ConsoleHelper.ReadInteger("How many sides does each dice have? ", minSides, maxSides);
            _menuItems[1] = $"Change Roll Dice setup. (currently {diceCount} dice of {sides} sides).";
            _dices = CreateDice(diceCount, sides);
        }

        private Dice[] CreateDice(int diceCount, int sides)
        {
            Dice[] dices = new Dice[diceCount];
            for (int i = 0; i < diceCount; i++)
            {
                dices[i] = new Dice(sides);
            }
            return dices;
        }

        private void ShowMenu(List<string> items)
        {
            Console.WriteLine();
            for (int i = 1; i < items.Count; i++)
                Console.WriteLine($"[{i}] {items[i]}");
            Console.WriteLine($"[0] {items[0]}");
        }
    }

    public class Dice
    {
        private static Random rndGen = new Random();

        private int _sides;

        public int Value { get; private set; }

        public Dice(int sides)
        {
            _sides = sides;
        }

        public void Roll()
        {
            Value = rndGen.Next(0, _sides) + 1;
        }

        public override string ToString()
        {
            return $"[{Value}]";
        }
    }

    public static class ConsoleHelper
    {
        public static int ReadInteger(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int option) && option >= min && option <= max)
                    return option;
                Console.WriteLine($"You need to enter a valid number from {min} to {max}!");
            }
        }
    }
}





