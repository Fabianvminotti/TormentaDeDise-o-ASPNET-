using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCalculoBasica26Nov.Controllers
{
    public class IDFClass
    {
        public  double a { get; set; }
        public  double b { get; set; }
        public  double c { get; set; }
        public  double n { get; set; }
        public  double T { get; set; }
        public  double D { get; set; }
        public  int numIntervalos { get; set; }
        public  int deltaT { get; set; }

        

        public double[] Intensidad()
        {
            double[] intensidades = new double[numIntervalos];
            double[] acumulados = new double[numIntervalos];
            ArrTiempoClass ArrTiempo = new ArrTiempoClass();
            ArrTiempo.deltaT = deltaT;
            ArrTiempo.numIntervalos = numIntervalos;
            int[] tiempo = ArrTiempo.Generar();

            for (int i = 0; i < numIntervalos-1 ; i++)
            {
                intensidades[i] = (a * (Math.Pow(T,b)) / Math.Pow((tiempo[i] + c), n)); 

            }
            return intensidades;
        }

        public double[] Acumulados(double[] intensidades)
        {
            double[] acumulados = new double[numIntervalos];
            ArrTiempoClass ArrTiempo = new ArrTiempoClass();
            ArrTiempo.deltaT = deltaT;
            ArrTiempo.numIntervalos = numIntervalos;
            int[] tiempo = ArrTiempo.Generar();

            for (int i = 0; i < numIntervalos - 1; i++)
            {
                acumulados[i] =(( Convert.ToDouble(tiempo[i]))/60)*intensidades[i];
            }
            return acumulados;

        }

        public double[] Incrementales (double[] acumulados)
        {
            double[] incrementales = new double[numIntervalos];
            incrementales[0] = acumulados[0];
            for (int i = 1; i < numIntervalos - 1; i++)
            {
                incrementales[i] = acumulados[i]-acumulados[i-1];
            }
            return incrementales;
        }

        public double[] Reordenar(double[] incrementales)
        {
            double[] reordenado = new double[numIntervalos];
            double medioAux = numIntervalos / 2;
            int medio = Convert.ToInt32((Math.Truncate(medioAux)));
            int x=medio;
            int z;
            for (int i = 0; i < numIntervalos - 1; i++)
            {
                if ((i % 2) == 0)
                {
                    z = i;
                }
                else
                {
                    z = -i;
                }
                x = x + z;

                reordenado[x]=incrementales[i];
                
            }

            return reordenado;
        }
    }
}
