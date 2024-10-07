using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    
    public class ComputerGame
    {
        private string name;
        private PegiAgeRating pegiAgeRating;
        private double budgetInMillionsOfDollars;
        private int minimumGpuMemoryInMegabytes;
        private int diskSpaceNeededInGB;
        private int ramNeededInGb;
        private int coresNeeded;
        private double coreSpeedInGhz;

        public ComputerGame(string name,
                            PegiAgeRating pegiAgeRating,
                            double budgetInMillionsOfDollars,
                            int minimumGpuMemoryInMegabytes,
                            int diskSpaceNeededInGB,
                            int ramNeededInGb,
                            int coresNeeded,
                            double coreSpeedInGhz)
        {
            this.name = name;
            this.pegiAgeRating = pegiAgeRating;
            this.budgetInMillionsOfDollars = budgetInMillionsOfDollars;
            this.minimumGpuMemoryInMegabytes = minimumGpuMemoryInMegabytes;
            this.diskSpaceNeededInGB = diskSpaceNeededInGB;
            this.ramNeededInGb = ramNeededInGb;
            this.coresNeeded = coresNeeded;
            this.coreSpeedInGhz = coreSpeedInGhz;
        }

        public string getName()
        {
            return name;
        }

        public PegiAgeRating getPegiAgeRating()
        {
            return pegiAgeRating;
        }

        public double getBudgetInMillionsOfDollars()
        {
            return budgetInMillionsOfDollars;
        }

        public int getMinimumGpuMemoryInMegabytes()
        {
            return minimumGpuMemoryInMegabytes;
        }

        public int getDiskSpaceNeededInGB()
        {
            return diskSpaceNeededInGB;
        }

        public int getRamNeededInGb()
        {
            return ramNeededInGb;
        }

        public int getCoresNeeded()
        {
            return coresNeeded;
        }

        public double getCoreSpeedInGhz()
        {
            return coreSpeedInGhz;
        }
    }

    public enum PegiAgeRating
    {
        P3, P7, P12, P16, P18
    }

    public class Requirements
    {
        private int gpuGb;
        private int HDDGb;
        private int RAMGb;
        private double cpuGhz;
        private int coresNum;

        public Requirements(int gpuGb,
                            int HDDGb,
                            int RAMGb,
                            double cpuGhz,
                            int coresNum)
        {
            this.gpuGb = gpuGb;
            this.HDDGb = HDDGb;
            this.RAMGb = RAMGb;
            this.cpuGhz = cpuGhz;
            this.coresNum = coresNum;
        }

        public int getGpuGb()
        {
            return gpuGb;
        }

        public int getHDDGb()
        {
            return HDDGb;
        }

        public int getRAMGb()
        {
            return RAMGb;
        }

        public double getCpuGhz()
        {
            return cpuGhz;
        }

        public int getCoresNum()
        {
            return coresNum;
        }
    }

    public interface PCGame
    {
        string getTitle();
        int getPegiAllowedAge();
        bool isTripleAGame();
        Requirements getRequirements();
    }

    //Adapter
    public class ComputerGameAdapter : PCGame
    {
        private readonly ComputerGame _computerGame;

        public ComputerGameAdapter(ComputerGame computerGame)
        {
            _computerGame = computerGame;
        }

        public string getTitle()
        {
            return _computerGame.getName();
        }

        public int getPegiAllowedAge()
        {
            switch (_computerGame.getPegiAgeRating())
            {
                case PegiAgeRating.P3:
                    return 3;
                case PegiAgeRating.P7:
                    return 7;
                case PegiAgeRating.P12:
                    return 12;
                case PegiAgeRating.P16:
                    return 16;
                case PegiAgeRating.P18:
                    return 18;
                default:
                    return 0; // Нет рейтинга
            }
        }

        public bool isTripleAGame()
        {
            return _computerGame.getBudgetInMillionsOfDollars() > 50;
        }

        public Requirements getRequirements()
        {
            return new Requirements(
                _computerGame.getMinimumGpuMemoryInMegabytes() / 1024 * 8, // Преобразуем в Гб
                _computerGame.getDiskSpaceNeededInGB(),
                _computerGame.getRamNeededInGb() * 8,                      // Преобразуем в Гб
                _computerGame.getCoreSpeedInGhz(),
                _computerGame.getCoresNeeded()
            );
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // ComputerGame
            ComputerGame computerGame = new ComputerGame(
                "Silent Hill 2 Remake",
                PegiAgeRating.P18,
                5, // Бюджет в миллионах
                8192, // Минимальная видеопамять в мегабайтах
                50,   // Необходимое место на диске в ГБ
                16,    // Необходимая оперативная память в ГБ
                8,    // Необходимое количество ядер
                4.2   // Скорость ядра в ГГц
            );

            // ComputerGameAdapter
            PCGame pcGame = new ComputerGameAdapter(computerGame);

            
            Console.WriteLine("Название: " + pcGame.getTitle());
            Console.WriteLine("Возрастной рейтинг PEGI: " + pcGame.getPegiAllowedAge() + "+");
            Console.WriteLine("Статус TripleA: " + (pcGame.isTripleAGame() ? "Да" : "Нет"));

            // Requirements
            Requirements requirements = pcGame.getRequirements();
            Console.WriteLine("Системные требования:");
            Console.WriteLine($"  GPU: {requirements.getGpuGb()} Gb");
            Console.WriteLine($"  HDD: {requirements.getHDDGb()} GB");
            Console.WriteLine($"  RAM: {requirements.getRAMGb()} Gb");
            Console.WriteLine($"  Cores: {requirements.getCoresNum()}");
            Console.WriteLine($"  CPU Speed: {requirements.getCpuGhz()} GHz");
            Console.ReadLine();
        }
    }
}
