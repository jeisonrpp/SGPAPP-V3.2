using System;

namespace SGPPDFController
{
    public class clsRandomNum
    {
        public Random rdn = new Random();
        public string caracteres = "1234567890";
        public int longitud;
        public char letra;
        public int Longitud = 4;
        public String RandomNo;

        public void GetNo()
        {
            RandomNo = "";
            longitud = caracteres.Length;
            for (int i = 0; i < Longitud; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                RandomNo += letra.ToString();
            }
        }
    }
}
