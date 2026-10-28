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
            int NG = int.Parse(Console.ReadLine());

            double achievement = (double)actualOutput / targetOutput * 100;
            double taktTime = shiftHours * 3600 / targetOutput;

            double yieldPercent = (double)(actualOutput - NG) / actualOutput * 100;


            Console.WriteLine($"Achievement : {achievement:F1} %");
            Console.WriteLine($"Takt time   : {taktTime:F2} sec/pcs");
            Console.WriteLine($"Yield  : {yieldPercent:F1} %");
        }
    }
}