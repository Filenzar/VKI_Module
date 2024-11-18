using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;



public interface ISubject
{
    void Request(string request);
}

public class RealSubject : ISubject
{
    public void Request(string request)
    {
        // Здесь выполняется реальная логика запроса
        Console.WriteLine($"RealSubject: Processing request: {request}");
    }
}

public class Proxy : ISubject
{
    private RealSubject _realSubject;
    private Dictionary<string, string> _cache = new Dictionary<string, string>();
    private DateTime _lastCacheClearTime;

    public Proxy()
    {
        _realSubject = new RealSubject();
        _lastCacheClearTime = DateTime.Now;
    }

    public void Request(string request)
    {
        // Проверка кэширования (сбросить кэш, если прошло больше 10 секунд)
        if ((DateTime.Now - _lastCacheClearTime).TotalSeconds > 10)
        {
            Console.WriteLine("Cache expired. Clearing cache...");
            _cache.Clear();
            _lastCacheClearTime = DateTime.Now;
        }

        // Проверка прав доступа (например, допустим, доступ разрешен только для запросов, начинающихся с "admin")
        if (!HasAccess(request))
        {
            Console.WriteLine("Proxy: Access denied for request.");
            return;
        }

        // Проверка наличия данных в кэше
        if (_cache.ContainsKey(request))
        {
            Console.WriteLine($"Proxy: Returning cached result for request: {request}");
            Console.WriteLine($"Cached Response: {_cache[request]}");
        }
        else
        {
            Console.WriteLine($"Proxy: No cache for request. Forwarding to RealSubject.");
            _realSubject.Request(request);
            // Сохраняем результат в кэш (для примера просто сохраняем сам запрос как результат)
            _cache[request] = $"Processed {request} at {DateTime.Now}";
        }
    }

    private bool HasAccess(string request)
    {
        // Пример проверки доступа: разрешаем доступ только для запросов, начинающихся с "admin"
        return request.StartsWith("admin", StringComparison.OrdinalIgnoreCase);
    }
}

public class Program
{
    public static void Main()
    {
        // Создаем прокси
        ISubject proxy = new Proxy();

        // Пример запросов
        proxy.Request("admin:login");      // Должен быть обработан
        proxy.Request("user:login");       // Доступ будет запрещен

        // Пример повторного запроса (должен использовать кэш)
        proxy.Request("admin:login");

        // Задержка для сброса кэша
        Console.WriteLine("Waiting for cache expiration...");
        Thread.Sleep(11000);  // Ждем более 10 секунд

        // Повторный запрос после истечения времени кэширования
        proxy.Request("admin:login");

        Console.ReadLine();
    }
}

