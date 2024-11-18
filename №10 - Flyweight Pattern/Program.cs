using System;
using System.Collections.Generic;

// Класс, представляющий персонажа
public class Character
{
    // Легковесные данные
    public string Name { get; private set; }
    public string Type { get; private set; }
    public string Image { get; private set; }

    // Тяжелые данные
    public int Level { get; set; }
    public int Experience { get; set; }

    public Character(string name, string type, string image)
    {
        Name = name;
        Type = type;
        Image = image;
    }

    public void Display()
    {
        Console.WriteLine($"Персонаж: {Name}, Тип: {Type}, Изображение: {Image}, Уровень: {Level}, Опыт: {Experience}");
    }
}

public class CharacterFactory
{
    // Словарь для хранения созданных объектов
    private Dictionary<string, Character> _characters = new Dictionary<string, Character>();

    public Character GetCharacter(string name, string type, string image)
    {
        // Ключ для персонажа
        string key = $"{name}_{type}_{image}";

        // Если персонаж с таким ключом уже существует, возвращаем его
        if (_characters.ContainsKey(key))
        {
            Console.WriteLine("Возвращение существующего персонажа.");
            return _characters[key];
        }
        else
        {
            Console.WriteLine("Создание нового персонажа.");
            var character = new Character(name, type, image);
            _characters[key] = character;
            return character;
        }
    }
}

class Program
{
    static void Main()
    {
        // Создаем фабрику персонажей
        var characterFactory = new CharacterFactory();

        // Запрашиваем персонажей
        var character1 = characterFactory.GetCharacter("Джон", "Воин", "warrior_image.png");
        var character2 = characterFactory.GetCharacter("Марк", "Маг", "mage_image.png");
        var character3 = characterFactory.GetCharacter("Джон", "Воин", "warrior_image.png"); // Возвращает character1

        // Изменяем тяжелые данные
        character1.Level = 5;
        character1.Experience = 100;

        character2.Level = 3;
        character2.Experience = 50;

        // Отображаем информацию о персонажах
        character1.Display();
        character2.Display();
        character3.Display(); // Выводит character1

        Console.ReadLine();
    }
}
