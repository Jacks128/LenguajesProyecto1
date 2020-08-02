using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Jacks
{
    class Manejador
    {
        List<Token> salidaToken;
        List<Error> salidaError;
        List<Pais> paises;
        private static Manejador llamado;

        public static Manejador Obtenerllamado()
        {
            if (llamado == null)
            {
                llamado = new Manejador();
            }
            return llamado;
        }
        public Manejador()
        {
            salidaToken = new List<Token>();

            salidaError = new List<Error>();
            paises = new List<Pais>();
        }

        public List<Token> getsalidaToken()
        {
            return salidaToken;
        }


        public List<Error> getsalidaError()
        {
            return salidaError;
        }

        public List<Pais> GetPais() {
            return paises;
        }

        public void agregarPais(string nameGraphic , string continente, int satCont, string pais, int poblacion, int saturacion, string bandera)
        {
            Pais newpais = new Pais(nameGraphic, continente,  satCont,pais, poblacion, saturacion, bandera);
            paises.Add(newpais);
        }
    }
}
