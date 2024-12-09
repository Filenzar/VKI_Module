using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Strategy
{
    public interface IWeapon
    {
        void UseWeapon();  // Метод для использования оружия
    }
    public class Sword : IWeapon
    {
        public void UseWeapon()
        {
            Console.WriteLine("You swing the sword!");
        }
    }
    public class Bow : IWeapon
    {
        public void UseWeapon()
        {
            Console.WriteLine("You shoot an arrow from the bow!");
        }
    }
    public class Axe : IWeapon
    {
        public void UseWeapon()
        {
            Console.WriteLine("You swing the axe!");
        }
    }
    public class Player
    {
        private IWeapon weapon;  // Оружие игрока

        // Конструктор для установки оружия
        public Player(IWeapon initialWeapon)
        {
            weapon = initialWeapon;
        }

        // Метод для смены оружия
        public void SetWeapon(IWeapon newWeapon)
        {
            weapon = newWeapon;
        }

        // Метод атаки, который использует текущее оружие
        public void Attack()
        {
            weapon.UseWeapon();
        }
    }
    public class Game
    {
        private Player player;

        public Game()
        {
            // Инициализация игрока с начальным оружием (например, меч)
            player = new Player(new Sword());
        }

        // Метод для начала игры
        public void Start()
        {
            bool gameRunning = true;

            while (gameRunning)
            {
                Console.WriteLine("\nChoose your action:");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Change Weapon");
                Console.WriteLine("3. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        player.Attack();  // Выполняем атаку
                        break;

                    case "2":
                        ChangeWeapon();  // Смена оружия
                        break;

                    case "3":
                        gameRunning = false;  // Выход из игры
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }

        // Метод для изменения оружия
        private void ChangeWeapon()
        {
            Console.WriteLine("\nChoose a new weapon:");
            Console.WriteLine("1. Sword");
            Console.WriteLine("2. Bow");
            Console.WriteLine("3. Axe");
            string weaponChoice = Console.ReadLine();

            switch (weaponChoice)
            {
                case "1":
                    player.SetWeapon(new Sword());  // Устанавливаем меч
                    Console.WriteLine("You equipped a sword!");
                    break;

                case "2":
                    player.SetWeapon(new Bow());  // Устанавливаем лук
                    Console.WriteLine("You equipped a bow!");
                    break;

                case "3":
                    player.SetWeapon(new Axe());  // Устанавливаем топор
                    Console.WriteLine("You equipped an axe!");
                    break;

                default:
                    Console.WriteLine("Invalid choice! Weapon not changed.");
                    break;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем игру
            Game game = new Game();
            game.Start();  // Запускаем игру
        }
    }

}
