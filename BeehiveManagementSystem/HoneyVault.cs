using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    public static class HoneyVault
    {
        public const float NECTAR_CONVERSION_RATIO = .19f;
        public const float LOW_LEVEL_WARNING = 10f;
        private static float honey = 25f;
        private static float nectar = 100f;

        //static string StatusReport;
        static public string StatusReport
        {
            get
            {
                string report = $"{honey} units of honey\n {nectar} untis of nectar\n";
                if (honey < LOW_LEVEL_WARNING)
                {
                    report += "LOW HONEY - ADD A HONEY MANUFACTURER\n";
                }
                else if(nectar < LOW_LEVEL_WARNING)
                {
                    report += "LOW NECTAR - ADD A NECTAR COLLECTOR\n";

                }
                return report;
            }
        }



        public static void CollectNectar(float amount)
        {
            if (amount > 0f)
            {
                honey += amount;
            }
        }

        public static void ConvertNectarToHoney(float amount)
        {
            if (nectar > amount)
            {
                nectar -= amount;
                honey += amount * NECTAR_CONVERSION_RATIO;
            }
            else
            {
                honey += nectar * NECTAR_CONVERSION_RATIO;
            }
        }

        public static bool ConsumeHoney(float amount)
        {
            if (honey >= amount)
            {
                honey -= amount;
                return true;
            }
            return false;
        }
    }
}
