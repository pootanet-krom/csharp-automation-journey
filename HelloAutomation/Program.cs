using System.Diagnostics;

namespace HelloAutomation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string machineName = "Conveyor-01";
            int targetOutput = 1200;
            double shiftHours = 8.0;

            Console.WriteLine("=== Production Calculator ===");
            Console.WriteLine("Machine: " + machineName);

            Console.Write("Actual output (pcs): ");
            int actualOutput = int.Parse(Console.ReadLine());

            Console.Write("NG (pcs): ");
            int ngCount = int.Parse(Console.ReadLine());

            double achievement = (double)actualOutput / targetOutput * 100;
            double taktTime = shiftHours * 3600 / targetOutput;

            double yieldPercent = (double)(actualOutput - ngCount) / actualOutput * 100;


            Console.WriteLine($"Achievement : {achievement:F1} %");
            Console.WriteLine($"Takt time   : {taktTime:F2} sec/pcs");
            Console.WriteLine($"Yield  : {yieldPercent:F1} %");

            Console.WriteLine();
            Console.Write("Line status :");
            if (achievement >= 100)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TARGET MET");
            }
            else if (achievement >= 90)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("BEHIND TARGET");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CRITICAL - Notify shift leader");
            }
            Console.ResetColor();
            if (yieldPercent >= 98)
            {
                Console.WriteLine("Quality : OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Quality : NG - Check process");
            }
            Console.ResetColor();

            if(achievement >= 100 && yieldPercent >= 98)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("★ PERFECT SHIFT ★");
            }
            Console.ResetColor();
        }
    }
}