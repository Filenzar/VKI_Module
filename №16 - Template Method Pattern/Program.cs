using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    using System;

    // Абстрактный класс для генерации отчетов
    public abstract class ReportGenerator
    {
        // Шаблонный метод для генерации отчета
        public void GenerateReport()
        {
            CollectData();
            ProcessData();
            FormatReport();
            ExportReport();
        }

        // Абстрактные методы, которые должны быть реализованы в наследниках
        protected abstract void CollectData();
        protected abstract void ProcessData();
        protected abstract void FormatReport();

        // Конкретный метод
        private void ExportReport()
        {
            Console.WriteLine("Отчет экспортирован в файл.");
        }
    }

    // Конкретный класс для генерации отчета по студентам
    public class StudentReportGenerator : ReportGenerator
    {
        protected override void CollectData()
        {
            Console.WriteLine("Собраны данные о студентах.");
        }

        protected override void ProcessData()
        {
            Console.WriteLine("Данные о студентах обработаны.");
        }

        protected override void FormatReport()
        {
            Console.WriteLine("Отчет о студентах отформатирован.");
        }
    }

    // Конкретный класс для генерации отчета по курсам
    public class CourseReportGenerator : ReportGenerator
    {
        protected override void CollectData()
        {
            Console.WriteLine("Собраны данные о курсах.");
        }

        protected override void ProcessData()
        {
            Console.WriteLine("Данные о курсах обработаны.");
        }

        protected override void FormatReport()
        {
            Console.WriteLine("Отчет о курсах отформатирован.");
        }
    }

    // Пример использования
    public class Program
    {
        public static void Main(string[] args)
        {
            ReportGenerator studentReport = new StudentReportGenerator();
            studentReport.GenerateReport();

            Console.WriteLine();

            ReportGenerator courseReport = new CourseReportGenerator();
            courseReport.GenerateReport();
            Console.ReadLine();
        }
    }

}
