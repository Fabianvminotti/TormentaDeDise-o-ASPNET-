using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCalculoBasica26Nov.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicoController : ControllerBase
    {
        // GET: api/<ValuesController>
        //[HttpGet]
        //public string get()
        //{
        //    string resultado = "Api para la creacion de tormentas de diseño";
        //    return resultado;
        //}


        //// GET api/<ValuesController>/5
        ////[HttpGet("{a}/{b}/{c}/{T}/{tc}/{deltat}")]
        //[HttpGet("{a}/{b}/{c}/{T}/{tc}/{deltat}")]

        //public int[] Get(float a,
        //                    float b,
        //                    float c,
        //                    int T,
        //                    double tc,
        //                    double deltat)
        //{
        //    //double cantIntervalos;
        //    //cantIntervalos = tc / deltat;
        //    //int intervalo =(int)Math.Round(tc / deltat);
        //    //int intervalo = 10;
        //    //double[] arrTiempo = new double[intervalo];
        //    //arrTiempo = intTiempo(tc, deltat, 10);
        //    //return arrTiempo;
        //    ArrTiempoClass ejeTiempo = new ArrTiempoClass();
        //    ejeTiempo.numIntervalos = 5;
        //    ejeTiempo.deltaT = 10;
        //    int[] ejeX = ejeTiempo.Generar();
        //    return ejeX;
        //}

        [HttpGet]
        public string Get()
        {
            return "programa en funcionamiento";
        }


        //[HttpGet("{a}/{b}/{c}/{T}/{tc}/{deltat}")]
        [HttpGet("{I}/{T}")]

        public int[] Get(int I,int T)
        {
            
            ArrTiempoClass ejeTiempo = new ArrTiempoClass();
            ejeTiempo.numIntervalos = I;
            ejeTiempo.deltaT = T;
            int[] ejeX = ejeTiempo.Generar();
            return ejeX;
        }



        //public double[] intTiempo(double tc, double deltat, int intervalo) {
        //    double[] arraTemp = new double[intervalo];

        //    if (deltat == 0)
        //    {
        //        deltat=1;
        //    };          
        //    int i = 0;
        //    for (i = 0; i <= (intervalo-1); i++)
        //    {
        //        arraTemp[i] = deltat * (i + 1);
        //    }




        //    return arraTemp;            
        //}





        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //ESTO FUNCIONA
        //public int get()
        //{
        //    int resultado = 9 + 2;
        //    return resultado;
        //}


    }

    [Route("api/2")]
    public class BasicoController2 : ControllerBase
    {
        



        //[HttpGet("{a}/{b}/{c}/{T}/{tc}/{deltat}")]
        [HttpGet("{a}/{b}/{c}/{n}/{T}/{D}/{numIntervalos}")]

        public object Get(double a,double b,double c, double n, double T, double D, int numIntervalos)
        {
            int deltaT = Convert.ToInt32(Math.Truncate(D))/numIntervalos;

            //definicion de las clases a usar

            ArrTiempoClass ArrTiempo = new ArrTiempoClass();
            IDFClass IDF = new IDFClass();
            TorDisenoClass TorDiseno = new TorDisenoClass();

            //definicion eje tiempo

            ArrTiempo.deltaT = deltaT;
            ArrTiempo.numIntervalos = numIntervalos;
            int[] EjeXaux = ArrTiempo.Generar();
            double[] EjeX = new double[numIntervalos];
            for (int i = 0; i < EjeXaux.Length; i++)
            {
                EjeX[i]= Convert.ToDouble(EjeXaux[i]);
            }

            //definicion eje de precipitaciones

            IDF.a = a;
            IDF.b = b;
            IDF.c = c;
            IDF.n = n;
            IDF.T = T;
            IDF.D = D;
            IDF.numIntervalos = numIntervalos;
            IDF.deltaT = deltaT;

            double[] intensidad = IDF.Intensidad();
            double[] acumulados = IDF.Acumulados(intensidad);
            double[] incrementales = IDF.Incrementales(acumulados);
            double[] reordenado = IDF.Reordenar(incrementales);

            //definicion de la clase tormenta

            TorDiseno.EjeX = EjeX;
            TorDiseno.EjeY = reordenado;

            //double[] Resultado = new double[2];
            //Resultado[0] = TorDiseno.EjeX;


            return TorDiseno;

        }


    }

}
