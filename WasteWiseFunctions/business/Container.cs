using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WasteWiseFunctions.business
{
    public class Container
    {
        List<Sensor> sensors;

        public void addSensor(Sensor s)
        {
            sensors.Add(s);
        }
    }
}