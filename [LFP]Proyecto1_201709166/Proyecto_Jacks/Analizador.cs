using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Jacks
{
    class Analizador
    {
        private int estado;
        private int inicial;
        private static int id;
        private static int columna = 0;
        private static int fila = 1;
        private String auxlex;
        private String error;
        Form1 colorres = new Form1();
        RichTextBox caja;
        
        public void Scanear(String Entrada) {
            caja = colorres.rtbTexto;
            Entrada = Entrada + '#';
            estado = 0;
            id = 0;
            inicial = 100;
            auxlex = "";
            error = "";
            char c; 
            for (int i = 0; i <= Entrada.Length - 1; i++)
            {
                c = Entrada.ElementAt(i);
                columna++;
                switch (estado)
                {
                    case 0:/*Estado Inicial y simbolos*/
                        if (c == 'G')/* palabra reservada Grafica*/
                        {
                            estado = 1;
                            auxlex += c;
                        }
                        else if (c == 'C')/*Palabra reservada Continente*/
                        {
                            estado = 7;
                            auxlex += c;
                        }
                        else if (c == 'N')/*Palabra reservada Nombre*/
                        {
                            estado = 16;
                            auxlex += c;
                        }
                        else if (c == 'P')/*Palabra reservada Poblacion*/
                        {
                            estado = 21;
                            auxlex += c;
                        }
                        else if (c == 'S')/*Palabra reservada Saturacion*/
                        {
                            estado = 29;
                            auxlex += c;
                        }
                        else if (c == 'B')/*Palabra reservada Bandera*/
                        {
                            estado = 38;
                            auxlex += c;
                        }
                        else if (char.IsDigit(c))/*Es una numero*/
                        {
                            estado = 44;
                            auxlex += c;
                        }
                        else if (c == '\r' || c == '\t' || c == '\b' || Char.IsWhiteSpace(c) || c == '\f')
                        {

                            estado = 0;
                            fila++;
                            //columna = 0;
                        }
                        else if (c == '\n')
                        {
                            columna = 0;
                        }

                        else if (c == '{')
                        {
                            auxlex += c;
                            id = 14;
                            agregarToken(Token.Tipo.LLAVE_IZQ);
                        }
                        else if (c == '}')
                        {
                            auxlex += c;
                            id = 14;
                            agregarToken(Token.Tipo.LLAVE_DER);
                        }
                        else if (c.CompareTo(';') == 0)
                        {
                            auxlex += c;
                            id = 13;
                            agregarToken(Token.Tipo.PUNTO_Y_COMA);
                        }
                        else if (c.CompareTo(':') == 0)
                        {
                            auxlex += c;
                            id = 12;
                            agregarToken(Token.Tipo.OTROS);
                        }
                        else if (c.CompareTo('%')==0)
                        {
                            auxlex += c;
                            id = 12;
                            agregarToken(Token.Tipo.OTROS);
                        }
                        else if (c == '"')/*Es una cadena*/
                        {
                            estado = 46;
                            auxlex += c;
                        }
                       
                        else if (c.CompareTo('@') == 0)
                        {
                            auxlex += c;
                            error += c;
                            agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                        }
                        else if (c.CompareTo('!') == 0)
                        {
                            auxlex += c;
                            error += c;
                            agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                        }
                        else if (c.CompareTo('?') == 0)
                        {
                            auxlex += c;
                            error += c;
                            agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);


                            }
                        }
                                         
                        break;

                case 1:/*Palabra reservada Grafica*/
                        if (c == 'r')
                        {
                            auxlex += c;
                            estado = 2;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                               // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 2:
                        if (c == 'a')
                        {
                            auxlex += c;
                            estado = 3;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 3:
                        if (c == 'f')
                        {
                            auxlex += c;
                            estado = 4;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 4:
                        if (c == 'i')
                        {
                            auxlex += c;
                            estado = 5;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 5:
                        if (c == 'c')
                        {
                            auxlex += c;
                            estado = 6;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);

                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 6:
                        if (c == 'a')
                        {
                            auxlex += c;
                            id = 1;
                            agregarToken(Token.Tipo.PALABRA_RES_GRA);
                            
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;

                    case 7:/*PAALABRA RESERVADA CONTINTENTE*/
                        if (c == 'o')
                        {
                            auxlex += c;
                            estado = 8;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 8:
                        if (c == 'n')
                        {
                            auxlex += c;
                            estado = 9;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 9:
                        if (c == 't')
                        {
                            auxlex += c;
                            estado = 10;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 10:
                        if (c == 'i')
                        {
                            auxlex += c;
                            estado = 11;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 11:
                        if (c == 'n')
                        {
                            auxlex += c;
                            estado = 12;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 12:
                        if (c == 'e')
                        {
                            auxlex += c;
                            estado = 13;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 13:
                        if (c == 'n')
                        {
                            auxlex += c;
                            estado = 14;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 14:
                        if (c == 't')
                        {
                            auxlex += c;
                            estado = 15;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 15:
                        if (c == 'e')
                        {
                            auxlex += c;
                            id = 2;
                            agregarToken(Token.Tipo.PALABRA_RES_CONT);
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;

                    case 16:/*PALABRA RESERVADA NOMBRE*/
                        if (c == 'o')
                        {
                            auxlex += c;
                            estado = 17;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 17:
                        if (c == 'm')
                        {
                            auxlex += c;
                            estado = 18;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 18:
                        if (c == 'b')
                        {
                            auxlex += c;
                            estado = 19;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 19:
                        if (c == 'r')
                        {
                            auxlex += c;
                            estado = 20;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 20:
                        if (c == 'e')
                        {
                            auxlex += c;
                            id = 3;
                            agregarToken(Token.Tipo.PALABRA_RES_NOM);
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 21:/*PALABRA RESERVADA POBLCAION*/
                        if (c == 'o')
                        {
                            auxlex += c;
                            estado = 22;
                        }
                        else if (c== 'a')
                        {
                            auxlex += c;
                            estado = 47;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 22:
                        if (c == 'b')
                        {
                            auxlex += c;
                            estado = 23;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 23:
                        if (c == 'l')
                        {
                            auxlex += c;
                            estado = 24;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 24:
                        if (c == 'a')
                        {
                            auxlex += c;
                            estado = 25;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                              
                                
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;

                    case 25:
                        if (c == 'c')
                        {
                            auxlex += c;
                            estado = 26;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 26:
                        if (c == 'i')
                        {
                            auxlex += c;
                            estado = 27;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 27:
                        if (c == 'o')
                        {
                            auxlex += c;
                            estado = 28;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 28:
                        if (c == 'n')
                        {
                            auxlex += c;
                            id = 4;
                            agregarToken(Token.Tipo.PALABRA_RES_POB);
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;

                    case 29:/*PALABRA RESERVADA SATURACION*/
                        if (c == 'a')
                        {
                            auxlex += c;
                            estado = 30;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 30:
                        if (c == 't')
                        {
                            auxlex += c;
                            estado = 31;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 31:
                        if (c == 'u')
                        {
                            auxlex += c;
                            estado = 32;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 32:
                        if (c == 'r')
                        {
                            auxlex += c;
                            estado = 33;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 33:
                        if (c == 'a')
                        {
                            auxlex += c;
                            estado = 34;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 34:
                        if (c == 'c')
                        {
                            auxlex += c;
                            estado = 35;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 35:
                        if (c == 'i')
                        {
                            auxlex += c;
                            estado = 36;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 36:
                        if (c == 'o')
                        {
                            auxlex += c;
                            estado = 37;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 37:
                        if (c == 'n')
                        {
                            auxlex += c;
                            id = 6;
                            agregarToken(Token.Tipo.PALABRA_RES_SAT);
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;

                    case 38:/*PALABRA RESERVADA BANDERA*/
                        if (c == 'a')
                        {
                            auxlex += c;
                            estado = 39;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 39:
                        if (c == 'n')
                        {
                            auxlex += c;
                            estado = 40;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 40:
                        if (c == 'd')
                        {
                            auxlex += c;
                            estado = 41;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 41:
                        if (c == 'e')
                        {
                            auxlex += c;
                            estado = 42;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 42:
                        if (c == 'r')
                        {
                            auxlex += c;
                            estado = 43;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    case 43:
                        if (c == 'a')
                        {
                            auxlex += c;
                            id = 7;
                            agregarToken(Token.Tipo.PALABRA_RES_BAND);
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;

                    case 44:
                        if (char.IsDigit(c))
                        {
                            auxlex += c;
                            estado = 44;

                        }
                        else if (c == '%')
                        {
                            auxlex += c;
                            estado = 45;
                        } else {
                            id = 8;
                            agregarToken(Token.Tipo.NUMERO);
                            //Console.WriteLine(caja.Text);
                           // MessageBox.Show(caja.Text);
                            //colorc(caja, auxlex, Color.Green, 0);
                            i -= 1;
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                            else
                            {
                                // Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                            }
                        }
                        break;
                    case 45:
                        id = 9;
                        agregarToken(Token.Tipo.SATURACION);
                        break;
                    case 46:
                        if (char.IsLetter(c))
                        {
                            auxlex += c;
                            estado = 46;
                        }
                        else if (char.IsDigit(c))
                        {
                            auxlex += c;
                            estado = 46;
                        }
                        else if (c == '@')
                        {
                            auxlex += c;
                            estado = 46;
                        }
                        else if (c == '/')
                        {
                            auxlex += c;
                            estado = 46;
                        }

                        else if (c == '\\')
                        {
                            auxlex += c;
                            estado = 46;
                        }
                        else if (c == '$')
                        {
                            auxlex += c;
                            estado = 46;
                        }
                        else if (c == '%')
                        {
                            auxlex += c;
                            estado = 46;
                        }
                        else if (c == '&')
                        {
                            auxlex += c;
                            estado = 46;
                        }
                        else if (c == '(')
                        {
                            auxlex += c;
                            estado = 46;
                        }
                        else if (c == ')')
                        {
                            auxlex += c;
                            estado = 46;
                        }

                        else if (c == ':')
                        {
                            auxlex += c;
                            estado = 46;
                        }

                        else if (c == '.')
                        {
                            auxlex += c;
                            estado = 46;
                        }

                        else if (c == '?')
                        {
                            auxlex += c;
                            estado = 46;
                        }

                        else if (c == '¿')
                        {
                            auxlex += c;
                            estado = 46;
                        }
                        else if (c == '<')
                        {
                            auxlex += c;
                            estado = 46;
                        }
                        else if (c == '>')
                        {
                            auxlex += c;
                            estado = 46;
                        }
                        else if (c == '#')
                        {
                            auxlex += c;
                            estado = 46;
                        }

                        else if (Char.IsWhiteSpace(c))
                        {
                            auxlex += c;
                            estado = 46;
                        }
                        else if (c == '\r' || c == '\t' || c == '\b' || Char.IsWhiteSpace(c) || c == '\f')
                        {
                            auxlex += c;
                            estado = 46;
                        }
                        else if (c == '"')
                        {
                            auxlex += c;
                            id = 10;
                            agregarToken(Token.Tipo.CADENA);
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                        }
                        break;
                    case 47:
                        if (c == 'i')
                        {
                            auxlex += c;
                            estado = 48;
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                    
                    case 48:
                        if (c == 's')
                        {
                            auxlex += c;
                            id = 11;
                            agregarToken(Token.Tipo.PALABRA_RES_PA);
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length - 1)
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                            }
                            else
                            {
                                Console.WriteLine("Error lexico en " + c);
                                estado = 0;
                                error += c;
                                agregarError(Error.Descripcion.CARACTER_DESCONOCIDO);
                                // Console.WriteLine("Hemos concluido el analisis con exito");
                            }
                        }
                        break;
                }
            }

            }
            public void agregarToken(Token.Tipo tipo)
            {
                Manejador.Obtenerllamado().getsalidaToken().Add(new Token(auxlex, tipo, fila, columna, id));
                auxlex = "";
                estado = 0;
            }

            public void agregarError(Error.Descripcion desc)
            {
                Manejador.Obtenerllamado().getsalidaError().Add(new Error(error, desc, fila, columna));
                error = "";
                estado = 0;
            }



            public void ImprimirTokens(List<Token> tokens)
            {
                foreach (Token item in tokens)
                {
                    Console.WriteLine("Tipo:" + item.GetTipo() + " | Lexema:" + item.getAuxlex() + " | Fila:" + item.GetFila() + " | Columna" + item.GetColumna() + " | Id " + item.GetId());

                }
            }

            public void ImprimirError(LinkedList<Error> errores)
            {
                foreach (Error item in errores)
                {
                    Console.WriteLine("Tipo:" + item.Getdescripcion() + " | Lexema:" + item.getError() + " | Fila:" + item.Getfila() + " | Columna" + item.Getcolumna()  );


                }
            }

        public void TokenHTML()
        {
            
            
            // MessageBox.Show();
            String pagina;
            pagina = "<html>" +
            "<body bgcolor= #F5D0A9>" +
            "<h1 align='center'><U>TABLA DE TOKENS</U></h1></br>" +
            "<table cellpadding='20' border = '1' align='center'>" +
            "<tr>" +
            "<td bgcolor= #FF8000><strong>No." + "</strong></td>" +
            "<td bgcolor= #FF8000><strong>Tipo" + "</strong></td>" +
            "<td bgcolor= #FF8000><strong>Lexema" + "</strong></td>" +
            "<td bgcolor= #FF8000><strong>Columna" + "</strong></td>" +
            "<td bgcolor= #FF8000><strong>Fila" + "</strong></td>" +
            "<td bgcolor= #FF8000><strong>ID" + "</strong></td>" +
            "</tr>";
            String cadena = "";
            String t;

            for (int i = 0; i < Manejador.Obtenerllamado().getsalidaToken().Count; i++)
            {
                Token lista = Manejador.Obtenerllamado().getsalidaToken().ElementAt(i);
                t = "";
                t = "<tr>" +
                "<td><strong>" + (i + 1).ToString() +
                "</strong></td>" +
                "<td>" + lista.GetTipo() +
                "</td>" +
                "<td>" + lista.getAuxlex() +
                "</td>" +
                "<td>" + lista.GetColumna() +
                "</td>" +
                "<td>" + lista.GetFila() +
                "</td>" +
                 "<td>" + lista.GetId() +
                "</td>" +
                "</tr>";
                cadena = cadena + t;
            }
            pagina = pagina + cadena +
            "</table>" +
            "</body>" +
            "</html>";
            File.WriteAllText("Tokens.html", pagina);
            System.Diagnostics.Process.Start("Tokens.html");
        }
        
        public void Mostrar()
        {
            caja.Clear();

            /*for (int i = 0; i < Tokens.Count(); i++)
            {
                int id = Tokens.ElementAt(i).idToken;
                if (id == 8)
                {
                    Colorear(text1, Tokens.ElementAt(i).lexema, Color.ForestGreen);
                }
                else if (id == 9)
                {
                    Colorear(text1, Tokens.ElementAt(i).lexema, Color.LightBlue);
                }
                else if (id == 10)
                {
                    Colorear(text1, "\t" + Tokens.ElementAt(i).lexema, Color.LightBlue);
                }
                else if (id == 12)
                {
                    Colorear(text1, "\t\t" + Tokens.ElementAt(i).lexema, Color.LightBlue);
                }
                else if (id == 11 || id == 13)
                {
                    Colorear(text1, "\t\t\t" + Tokens.ElementAt(i).lexema, Color.LightBlue);
                }
                else if (id == 2)
                {
                    Colorear(text1, Tokens.ElementAt(i).lexema + "\n", Color.Purple);

                }
                else if (id == 3)
                {
                    Colorear(text1, Tokens.ElementAt(i).lexema + "\n", Color.Purple);

                }
                else if (id == 1)
                {
                    Colorear(text1, Tokens.ElementAt(i).lexema, Color.Yellow);
                }
                else if (id == 6)
                {
                    Colorear(text1, Tokens.ElementAt(i).lexema + "\n", Color.Red);
                }
                else if (id == 4)
                {
                    Colorear(text1, Tokens.ElementAt(i).lexema, Color.Pink);
                }
                else if (id == 7)
                {
                    Colorear(text1, Tokens.ElementAt(i).lexema, Color.Blue);
                }
                else if (id == 5 || id == 14 || id == 0)
                {
                    Colorear(text1, Tokens.ElementAt(i).lexema, Color.Black);
                }*/
            //}
        }
        public void ErrorHTML()
        {
            String pagina1;
            pagina1 = "<html>" +
            "<body bgcolor=#F5D0A9>" +
            "<h1 align='center'><U>TABLA DE ERRORES</U></h1></br>" +
            "<table cellpadding='20' border = '1' align='center'>" +
            "<tr>" +
            "<td bgcolor= #FF0040><strong>No." + "</strong></td>" +
            "<td bgcolor= #FF0040><strong>Tipo" + "</strong></td>" +
            "<td bgcolor= #FF0040><strong>Lexema" + "</strong></td>" +
            "<td bgcolor= #FF0040><strong>Columna" + "</strong></td>" +
            "<td bgcolor= #FF0040><strong>Fila" + "</strong></td>" +
            "</tr>";
            String cadena1 = "";
            String t;

            for (int i = 0; i < Manejador.Obtenerllamado().getsalidaError().Count; i++)
            {
                Error lista = Manejador.Obtenerllamado().getsalidaError().ElementAt(i);
                t = "";
                t = "<tr>" +
                "<td><strong>" + (i + 1).ToString() +
                "</strong></td>" +
                "<td>" + lista.Getdescripcion() +
                "</td>" +
                "<td>" + lista.getError() +
                "</td>" +
                "<td>" + lista.Getcolumna() +
                "</td>" +
                "<td>" + lista.Getfila() +
                "</td>" +
                "</tr>";
                cadena1 = cadena1 + t;
            }
            pagina1 = pagina1 + cadena1 +
            "</table>" +
            "</body>" +
            "</html>";
            File.WriteAllText("Errores.html", pagina1);
            System.Diagnostics.Process.Start("Errores.html");
        }

    
} 
    }
