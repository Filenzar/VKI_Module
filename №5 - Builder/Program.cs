using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    
    public class CPU
    {
        public string Model { get; set; }
        public int Cores { get; set; }

        public override string ToString() => $"{Model} ({Cores} cores)";
    }

    public class Motherboard
    {
        public string Model { get; set; }

        public override string ToString() => Model;
    }

    public class RAM
    {
        public string Size { get; set; }

        public override string ToString() => Size;
    }

    public class Storage
    {
        public string Type { get; set; }
        public string Size { get; set; }

        public override string ToString() => $"{Size} {Type}";
    }

    public class GPU
    {
        public string Model { get; set; }

        public override string ToString() => Model;
    }
    public class Computer
    {
        public CPU CPU { get; set; }
        public Motherboard Motherboard { get; set; }
        public RAM RAM { get; set; }
        public Storage Storage { get; set; }
        public GPU GPU { get; set; }

        public override string ToString()
        {
            return $"Computer Configuration:\n" +
                   $"- CPU: {CPU}\n" +
                   $"- Motherboard: {Motherboard}\n" +
                   $"- RAM: {RAM}\n" +
                   $"- Storage: {Storage}\n" +
                   $"- GPU: {GPU}";
        }
    }
    public class ComputerBuilder
    {
        private Computer _computer = new Computer();

        public ComputerBuilder SetCPU(CPU cpu)
        {
            _computer.CPU = cpu;
            return this;
        }

        public ComputerBuilder SetMotherboard(Motherboard motherboard)
        {
            _computer.Motherboard = motherboard;
            return this;
        }

        public ComputerBuilder SetRAM(RAM ram)
        {
            _computer.RAM = ram;
            return this;
        }

        public ComputerBuilder SetStorage(Storage storage)
        {
            _computer.Storage = storage;
            return this;
        }

        public ComputerBuilder SetGPU(GPU gpu)
        {
            _computer.GPU = gpu;
            return this;
        }

        public Computer Build()
        {
            return _computer;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ComputerBuilder();

            var computer = builder
                .SetCPU(new CPU { Model = "Intel Core i7", Cores = 8 })
                .SetMotherboard(new Motherboard { Model = "ASUS ROG Strix" })
                .SetRAM(new RAM { Size = "16GB" })
                .SetStorage(new Storage { Type = "SSD", Size = "1TB" })
                .SetGPU(new GPU { Model = "NVIDIA GeForce RTX 3070" })
                .Build();

            Console.WriteLine(computer);
            Console.ReadLine();
        }
    }

}
