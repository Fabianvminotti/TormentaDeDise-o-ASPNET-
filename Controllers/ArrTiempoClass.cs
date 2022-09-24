using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCalculoBasica26Nov.Controllers
{
    public class ArrTiempoClass
    {
        public int numIntervalos { get; set; }
        public int deltaT { get; set; }

        public int[] Generar()
        {
            int[] arraTemp = new int[numIntervalos];
            int i;
            for (i = 0; i <= (numIntervalos - 1); i++)
            {
                arraTemp[i] = deltaT * (i + 1);
            }
            return arraTemp;
        }
    }
}
