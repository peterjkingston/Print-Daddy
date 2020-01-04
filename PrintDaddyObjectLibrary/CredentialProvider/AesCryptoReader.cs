using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PrintDaddyObjectLibrary
{
    public class AesCryptoReader : ICryptoReader
    {

        /// <summary>
        /// Returns T object from the stream, decrypted. T must implement ISerializable or an error is thown.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cryptoStream"></param>
        /// <returns></returns>
        public T StreamRead<T>(Stream cryptoStream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            byte[] cryptoItem = (byte[])formatter.Deserialize(cryptoStream);
            T item = Decrypt<T>(cryptoItem);
            return item;
        }

        private T Decrypt<T>(byte[] cryptoItem)
        {
            ICryptoTransform decryptor = GetAesManaged().CreateDecryptor();
            using (MemoryStream mStream = new MemoryStream(cryptoItem))
            {
                using (CryptoStream cStream = new CryptoStream(mStream, decryptor, CryptoStreamMode.Read))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return (T)formatter.Deserialize(cStream);
                }
            }
        }

        private AesManaged GetAesManaged()
        {
            if (!(File.Exists(@"aesKey.dat") && File.Exists(@"aesVector.dat")))
            {
                WriteNewAes();
            }
            return ReadAes();
        }

        private AesManaged ReadAes()
        {
            AesManaged aes = new AesManaged();
            aes.Key = (byte[])new BinaryFormatter().Deserialize(new FileStream(@"aesKey.dat", FileMode.Open, FileAccess.Read));
            aes.IV = (byte[])new BinaryFormatter().Deserialize(new FileStream(@"aesVector.dat", FileMode.Open, FileAccess.Read));
            return aes;
        }

        private void WriteNewAes()
        {
            AesManaged aes = new AesManaged();
            BinaryFormatter formatter = new BinaryFormatter();
            aes.GenerateKey();
            FileStream fs = new FileStream(@"aesKey.dat", FileMode.Create);
            formatter.Serialize(fs, aes.Key);

            fs = new FileStream(@"aesVector.dat", FileMode.Create);
            aes.GenerateIV();
            formatter.Serialize(fs, aes.IV);
        }
    }
}
