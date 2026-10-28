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
            bool running = true;
            int shiftCount = 0;
            while (running)
            {

                Console.WriteLine("=== Production Calculator ===");
                Console.WriteLine("Machine: " + machineName);
                shiftCount++;

                Console.Write("Actual output (pcs): ");
                int actualOutput = int.Parse(Console.ReadLine());

                Console.Write("NG (pcs): ");
                int ngCount = int.Parse(Console.ReadLine());

                double achievement = (double)actualOutput / targetOutput * 100;
                double taktTime = shiftHours * 3600 / targetOutput;

                double yieldPercent = (double)(actualOutput - ngCount) / actualOutput * 100;


                Console.WriteLine($"Achievement : {achievement:F1} %");
                Console.WriteLine($"Takt time   : {taktTime:F2} sec/pcs");
                Console.WriteLine($"Yield       : {yieldPercent:F1} %");

                Console.WriteLine();
                Console.Write("Line status : ");
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

                if (achievement >= 100 && yieldPercent >= 98)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("★ PERFECT SHIFT ★");
                }
                Console.ResetColor();

                Console.Write("Alarm code (Enter = none):");
                String alarmCode = Console.ReadLine().ToUpper();

                switch (alarmCode)
                {
                    case "E01":
                        Console.WriteLine("→ Motor overload: check motor current & thermal relay");
                        break;
                    case "E02":
                        Console.WriteLine("→ Emergency stop pressed: check E-stop circuit");
                        break;
                    case "E03":
                    case "E04":
                        Console.WriteLine("→ Sensor fault: check sensor wiring & alignment");
                        break;
                    case "E05":
                        Console.WriteLine("→ Air pressure low: check regulator & air supply");
                        break;
                    case "":
                        Console.WriteLine("→ No alarm this shift");
                        break;
                    default:
                        Console.WriteLine("→ Unknown alarm code");
                        break;

                }
                Console.WriteLine();
                Console.Write("Calculate another shift? (y/n) : ");
                string answer = Console.ReadLine();
                if (answer != "y")
                {
                    running = false;
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Total shifts calculated: {shiftCount}");
            Console.WriteLine("Program ended.");
        }
    }
}