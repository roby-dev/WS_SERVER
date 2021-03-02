using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WS_Server_MVC.WS {
    /// <summary>
    /// Descripción breve de WebService
    /// </summary>    
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService {

        

        [WebMethod]
        public string HolaMundo() {
            return "Hola, bienvenido a la clase de Web II";
        }

        [WebMethod]
        public string Adios() {
            return "Gracias, nos vemos la próxima clase";
        }



        [WebMethod]
        public string Sumar(double numero, double numero2) => (numero + numero2).ToString();

        [WebMethod]
        public string Operaciones(int tipo,double numero1, double numero2) {           

            try {
                return (tipo == 0 ? numero1 + numero2 : tipo == 1 ? numero1 - numero2
             : tipo == 2 ? numero1 * numero2 : tipo == 3 ? numero1 / numero2 : 0).ToString();
            }
            catch(Exception e) {
                return "Ingrese valores válidos";
            }
         
        }

        [WebMethod]
        public string[] Tabla(int numero) {
            string[] tabla = new string[12];
            for (int i = 1; i <= 12; i++) {
                tabla[i-1] = numero + ";"+i+ ";"+ (i * numero).ToString();
            }
            return tabla;
        }

        [WebMethod]
        public string[] Bisiestos(string aniooInicio, string aniooFin) {
            int error = 0;
            try {
                
                int inicio = Convert.ToInt32(aniooInicio);
                int fin = Convert.ToInt32(aniooFin);
                
                if (fin <= inicio) {
                    error = 1;
                    throw new Exception();
                }
                if ((fin - inicio) == 1) {
                    error = 1;
                    throw new Exception();
                }
                if(inicio<=-10000) {
                    error = 3;
                    throw new Exception();
                }
                if(fin >= 10000) {
                    error = 3;
                    throw new Exception();
                }

                string[] anios = new string[fin - inicio + 1];
                int a = 0;
                for (int i=inicio;i<=fin;i++) {

                    if (i % 4 == 0 && i % 100 != 0 || i % 400 == 0) {
                        anios[a] = i +";BISIESTO";                        
                    } else {
                        anios[a] = i + ";NO BISIESTO";
                    }
                    a++;
                }
                return anios;

            }catch(Exception e) {
                string[] err = new string[1];
                if (error == 1) {
                    
                    err[0]="Error;Los años no deben de ser iguales o el año fin no debe ser menor al año de inicio";
                    return err;
                }
                if (error == 2) {
                 
                    err[0] = "Error;Los valores deben de ser positivos";
                    return err;                  
                }
                if (error == 3) {
                    
                    err[0] = "Error;Años válidos entre -9999 y 9999";
                    return err;                 
                }
              
                err[0] = "Error;Ingrese valores válidos";
                return err;                
            }
        }
    }
}
