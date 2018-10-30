using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Criptare
{
    class Program
    {
        static void Main(string[] args)
        {
            // Construirea documentului xml
            XmlDocument xmlDoc = new XmlDocument();

            // Incarcarea continutului fisierului in documentul creat 
            try
            {
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load("mesajClar.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // CspParameters stocheaza parametri necesari criptarii
            // este necesar in momentul crearii cheii (vezi mai jos)
            CspParameters cspParams = new CspParameters();
            cspParams.KeyContainerName = "XML_ENC_RSA_KEY";

            // Se creeaza o noua cheie RSA si se salveaza in container. Aceasta cheie va cripta
            // o cheie SIMETRICA ce va fi introdusa in documentul XML
            RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);

            try
            {
                // Cripteaza elementul "password".
                Encrypt(xmlDoc, "password", "EncryptedElement1", rsaKey, "rsaKey");

                // Salveaza documentul xml
                xmlDoc.Save("mesajCriptat.xml");

                // Afiseaza continutul criptat la consola
                Console.WriteLine("Encrypted XML:");
                Console.WriteLine();
                Console.WriteLine(xmlDoc.OuterXml);
                Decrypt(xmlDoc, rsaKey, "rsaKey");
                xmlDoc.Save("mesajDecriptat.xml");

                // Afiseaza continutul decriptat la consola
                Console.WriteLine();
                Console.WriteLine("Decrypted XML:");
                Console.WriteLine();
                Console.WriteLine(xmlDoc.OuterXml);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // Eliberarea resurselor
                rsaKey.Clear();
            }


            Console.ReadLine();
        }

        /**
         * Doc = documentul xml
         * ElementToEncrypt = numele elementului de criptat
         * EncryptionElementID = id-ul elementului ce va fi criptat
         * RSA = algoritmul de criptare (algoritm asimetric)
         * KeyNane = numele cheii de criptare
         */
        public static void Encrypt(XmlDocument Doc, string ElementToEncrypt, string EncryptionElementID, RSA Alg, string KeyName)
        {
            // Verificarea argumentelor 
            if (Doc == null)
                throw new ArgumentNullException("Doc");
            if (ElementToEncrypt == null)
                throw new ArgumentNullException("ElementToEncrypt");
            if (EncryptionElementID == null)
                throw new ArgumentNullException("EncryptionElementID");
            if (Alg == null)
                throw new ArgumentNullException("Alg");
            if (KeyName == null)
                throw new ArgumentNullException("KeyName");

            //////////////////////////////////////////////// 
            // Identificarea elementului de criptat 
            ////////////////////////////////////////////////
            XmlElement elementToEncrypt = Doc.GetElementsByTagName(ElementToEncrypt)[0] as XmlElement;

            // Daca nu este gasit se arunca o exceptie
            if (elementToEncrypt == null)
            {
                throw new XmlException("The specified element was not found");

            }
            RijndaelManaged sessionKey = null;

            try
            {
                ////////////////////////////////////////////////// 
                // Se creeaza o noua instanta a clasei EncryptedXml 
                // si se foloseste pentru criptarea elementului xml 
                // cu o noua cheie simetrica generata random. 
                ////////////////////////////////////////////////// 

                // Se creaza o cheie de sesiune SIMETRICA Rijndael de 256 de biti
                sessionKey = new RijndaelManaged();
                sessionKey.KeySize = 256;

                EncryptedXml eXml = new EncryptedXml();

                byte[] encryptedElement = eXml.EncryptData(elementToEncrypt, sessionKey, false);
                //////////////////////////////////////////////// 
                // Se creeaza un obiect EncryptedData si se populeaza 
                // cu informatia criptata. 
                ////////////////////////////////////////////////

                EncryptedData edElement = new EncryptedData();
                edElement.Type = EncryptedXml.XmlEncElementUrl;
                edElement.Id = EncryptionElementID;

                // Se creeaza un element de tip EncryptionMethod astfel incat 
                // destinatarul sa stie ce algoritm va folosi pentru decriptare.
                edElement.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES256Url);

                // Cripteaza cheia de sesiune si se adauga intr-un element de tip EncryptedKey.
                EncryptedKey ek = new EncryptedKey();

                byte[] encryptedKey = EncryptedXml.EncryptKey(sessionKey.Key, Alg, false);

                ek.CipherData = new CipherData(encryptedKey);

                ek.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url);

                // Din cauza faptului ca un document xml poate avea
                // mai multe elemente EncrypredData criptate cu mai multe chei
                // este nevoie de specificarea unui element de tip DataReference
                // care sa indice elementul criptat cu aceasta cheie
                DataReference dRef = new DataReference();

                // Se specifica URI-ul
                dRef.Uri = "#" + EncryptionElementID;

                // Se adauga DataReference la EncryptedKey.
                ek.AddReference(dRef);

                // Se adauga cheia criptata la obiectul EncryptedData 
                // EncryptedData object.
                edElement.KeyInfo.AddClause(new KeyInfoEncryptedKey(ek));

                // Se seteaza numele cheii RSA
                KeyInfoName kin = new KeyInfoName();

                kin.Value = KeyName;

                // Adauga obiectul kin la cheia criptata
                ek.KeyInfo.AddClause(kin);

                // Se adauga elementul criptat
                edElement.CipherData.CipherValue = encryptedElement;

                //////////////////////////////////////////////////// 
                // Se inlocuieste elementul original cu elementul criptat
                ////////////////////////////////////////////////////
                EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);
            }
            catch (Exception e)
            {
                // re-throw the exception. 
                throw e;
            }
            finally
            {
                if (sessionKey != null)
                {
                    sessionKey.Clear();
                }

            }

        }

        public static void Decrypt(XmlDocument Doc, RSA Alg, string KeyName)
        {
            // Verificare argumente   
            if (Doc == null)
                throw new ArgumentNullException("Doc");
            if (Alg == null)
                throw new ArgumentNullException("Alg");
            if (KeyName == null)
                throw new ArgumentNullException("KeyName");

            // Se creeaza un nou obiect de tip EncryptedXml.
            EncryptedXml exml = new EncryptedXml(Doc);

            // Se adauga o mapare numeCheie - algoritm
            exml.AddKeyNameMapping(KeyName, Alg);

            // Se decripteaza
            exml.DecryptDocument();

        }
    }
}
