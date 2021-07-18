using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    public class EggCare: Bee
    {

        public const float CARE_PROGRESS_PER_SHIFT = 0.15f;
        public override float CostPerShift { get; set; } = 1.35f;

        private Queen queenRef;

        public EggCare(Queen queenRef) : base("Egg Care") 
        {
            this.queenRef = queenRef;
        }

        protected override void DoJob()
        {
            queenRef.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }
    }
}
