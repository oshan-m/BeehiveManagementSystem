using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    public class Queen : Bee
    {
        private const float EGGS_PER_SHIFT = 0.45f;
        private const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;
        
        private Bee[] workers = new Bee[0];
        private float eggs = 0;
        private float unassignedWorkers = 3;
        public string StatusReport { get; private set; }
        public override float CostPerShift { get { return 2.15f; } }


        public Queen() : base("Queen") 
        {
            AssignBee("Nectar Collector");
            AssignBee("Honey Manufacturer");
            AssignBee("Egg Care");
        }
        private void AddWorker(Bee worker)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
            UpdateStatusReport();
        }
        private void UpdateStatusReport()
        {
            string report = HoneyVault.StatusReport;

            report += $"Egg count: {eggs}\n";
            report += $"Unassigned workers: {unassignedWorkers}";

            report += $"TOTAL WORKERS: {workers.Length}";
            //report += $"{NectarCollector.}"
            StatusReport = report;
        }
        public void CareForEggs(float eggsToConvert)
        {
            if (eggs> eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
        }

        public void AssignBee(string jobName)
        {
            switch (jobName)
            {
                case "Nectar Collector":
                    AddWorker(new NectarCollector());
                    break;
                case "Honey Manufacturer":
                    break;
                case "Egg Care":
                    break;
                default:
                    break;
            }
        }
        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            foreach (Bee worker in workers)
            {
                worker.WorkTheNextShift();
                HoneyVault.ConsumeHoney(HONEY_PER_UNASSIGNED_WORKER * workers.Length);
            }
            UpdateStatusReport();
        }


    }
}
