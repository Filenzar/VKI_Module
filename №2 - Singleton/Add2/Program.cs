using System;
using System.Collections.Generic;
using System.Linq;

public sealed class Servers
{
    private static readonly Servers _instance = new Servers();
    private readonly HashSet<string> _servers = new HashSet<string>();
    private readonly object _lock = new object(); 

    private Servers() { }

    public static Servers Instance => _instance;

    public bool AddServer(string url)
    {
        if (url.StartsWith("http://") || url.StartsWith("https://"))
        {
            lock (_lock)
            {
                return _servers.Add(url);
            }
        }
        return false;
    }

    public IEnumerable<string> GetHttpServers()
    {
        lock (_lock) 
        {
            return _servers.Where(url => url.StartsWith("http://")).ToList();
        }
    }

    public IEnumerable<string> GetHttpsServers()
    {
        lock (_lock) 
        {
            return _servers.Where(url => url.StartsWith("https://")).ToList();
        }
    }
}


public class Program
{
    public static void Main()
    {
        Servers servers = Servers.Instance;

        Console.WriteLine(servers.AddServer("http://example.com"));  // True
        Console.WriteLine(servers.AddServer("https://secure.com"));  // True
        Console.WriteLine(servers.AddServer("https://zoo.com"));  // True
        Console.WriteLine(servers.AddServer("http://aboba.com"));  // True
        Console.WriteLine(servers.AddServer("ftp://file.com"));      // False 
        Console.WriteLine(servers.AddServer("http://example.com"));  // False 

        Console.WriteLine("HTTP Servers:");
        foreach (var server in servers.GetHttpServers())
        {
            Console.WriteLine(server);
        }

        Console.WriteLine("HTTPS Servers:");
        foreach (var server in servers.GetHttpsServers())
        {
            Console.WriteLine(server);
        }
        Console.ReadLine();
    }
}
