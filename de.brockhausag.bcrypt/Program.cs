using CryptSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.brockhausag.bcrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BCrypt Beispiel");
            Console.WriteLine("================");

            //Eingabe lesen und in ein Byte-Array verwandeln
            var password = Input();
 
            //Beispiel mit 2a und 10 Runden
            var b0 = BlowfishCrypter.Blowfish.Crypt(password, BlowfishCrypter.Blowfish.GenerateSalt(10));
            Console.WriteLine("BCrypt (2a 10):\t{0}", b0);            
 
 
            //Beispiel mit 2y und 10 runden
            var b1 = BlowfishCrypter.Blowfish.Crypt(password, BlowfishCrypter.Blowfish.GenerateSalt(new CrypterOptions {{CrypterOption.Variant, BlowfishCrypterVariant.Corrected }, {CrypterOption.Rounds, 10}}));
            Console.WriteLine("BCrypt (2y 10):\t{0}", b1);
            
 
            //Beispiel mit Standardeinstellung (2a und 6 Runden)
            var b2 = BlowfishCrypter.Blowfish.Crypt(password);
            Console.WriteLine("BCrypt (2a  6):\t{0}", b2);       

            Console.WriteLine("Beliebige Taste drücken zum beenden");
            Console.ReadKey();
        }

        private static string Input()
        {
            Console.Write("Bitte ein Kennwort eingeben: ");
            var password = string.Empty;

            while (string.IsNullOrEmpty(password))
                password = Console.ReadLine();
            return password;
        }
    }
}
