using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using EllipticCurve;

namespace Cryptography1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Generate new Keys
            PrivateKey privateKey = new PrivateKey();
            //PrivateKey privateKey = PrivateKey.fromString(, "secp256k1");
            PublicKey publicKey = privateKey.publicKey();

            string message = "EKA|v0.1|John Doe|Z4385097|M|02-01-1988|119334006|Nasopharyngeal Swab|2021-05-25T16:45:32.729+08:00|94531-1|SARS-COV2-2019 RT-PCR|260385009|Negative|L01|C01";

            // Generate Signature
            Signature signature = Ecdsa.sign(message, privateKey);

            string messageSigned = message + "|" + signature.toBase64();
            Console.WriteLine("Message : ");
            Console.WriteLine(message);
            Console.WriteLine("");
            Console.WriteLine("PrivateKey PEM : ");
            Console.WriteLine(privateKey.toPem());
            Console.WriteLine("");
            Console.WriteLine("PrivateKey Byte : " );
            Console.WriteLine(Convert.ToBase64String(privateKey.toString()));
            Console.WriteLine("");
            Console.WriteLine("PublicKey PEM : " );
            Console.WriteLine(publicKey.toPem());
            Console.WriteLine("");
            Console.WriteLine("PublicKey Byte : ");
            Console.WriteLine(Convert.ToBase64String(publicKey.toString()));
            Console.WriteLine("");
            Console.WriteLine("Message Signed : ");
            Console.WriteLine(messageSigned);
            Console.WriteLine("");
            // Verify if signature is valid
            string verified = "";

            if(Ecdsa.verify(message, signature, publicKey) == true)
            {
                verified = "Verified Signature";
            }
            else
            {
                verified = "Not Verified Signature";
            }
            Console.WriteLine(verified);
        }


    }
}
