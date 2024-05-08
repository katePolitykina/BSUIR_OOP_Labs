
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace Signature
{
    public class Signature
    {
        public static bool Sign(byte[] data, string path)
        {
            SHA256 hashMaker = SHA256.Create();

            byte[] hash = hashMaker.ComputeHash(data);
            RSAParameters sharedParameters;
            byte[] signedHash;

            using (RSA rsa = RSA.Create())
            {
                sharedParameters = rsa.ExportParameters(false);

                RSAPKCS1SignatureFormatter rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);
                rsaFormatter.SetHashAlgorithm(nameof(SHA256));

                signedHash = rsaFormatter.CreateSignature(hash);
                Console.WriteLine(signedHash.Length);
            }
            string signedHashPath = path + Path.DirectorySeparatorChar + "signature.bin";
            string sharedParametersPath = path + Path.DirectorySeparatorChar + "Parameters.txt";
            try
            {
                using (FileStream fs = new FileStream(signedHashPath, FileMode.Create))
                {
                    using (BinaryWriter writer = new BinaryWriter(fs))
                    {
                        writer.Write(signedHash);
                    }
                }
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Modulus: " + Convert.ToBase64String(sharedParameters.Modulus));
                sb.AppendLine("Exponent: " + Convert.ToBase64String(sharedParameters.Exponent));

                File.WriteAllText(sharedParametersPath, sb.ToString());
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public static bool Verify( byte[] dllToVerify, string path)
        {
            string signedHashPath = path + Path.DirectorySeparatorChar + "signature.bin";
            string sharedParametersPath = path + Path.DirectorySeparatorChar + "Parameters.txt";
            byte[] signedHash;
            try
            {
                if (File.Exists(signedHashPath))
                {
                    signedHash = File.ReadAllBytes(signedHashPath);
                    Console.WriteLine(signedHash.Length);
                }
                else
                {
                    return false;
                }
                if (File.Exists(sharedParametersPath))
                {
                    string[] lines = File.ReadAllLines(sharedParametersPath);
                    byte[] modulus = Convert.FromBase64String(lines[0].Substring("Modulus: ".Length));
                    byte[] exponent = Convert.FromBase64String(lines[1].Substring("Exponent: ".Length));
                    RSAParameters sharedParameters = new RSAParameters
                    {
                        Modulus = modulus,
                        Exponent = exponent
                    };
                    SHA256 alg = SHA256.Create();
                    byte[] hash = alg.ComputeHash(dllToVerify);
                    using (RSA rsa = RSA.Create())
                    {
                        rsa.ImportParameters(sharedParameters);

                        RSAPKCS1SignatureDeformatter rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
                        rsaDeformatter.SetHashAlgorithm(nameof(SHA256));


                        return rsaDeformatter.VerifySignature(hash, signedHash);

                    }
                }
            }
            catch (Exception ex )
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return false;
        }
        
    }
}
