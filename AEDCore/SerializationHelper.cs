using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace AEDCore
{
    public static class SerializationHelper
    {
        public static void Serialize<Object>(Object dictionary, Stream stream)
        {
            try 
            {
                using (stream)
                {   
                    var formatter = new BinaryFormatter();
                    
                    formatter.Serialize(stream, dictionary);
                }
            }
            catch (IOException e)
            {
                Console.Write(e.Message);
            }
        }

        public static Object Deserialize<Object>(Stream stream) where Object : new()
        {
            var result = (Object)Activator.CreateInstance(typeof(Object));

            try
            {
                using (stream)
                {
                    var formatter = new BinaryFormatter();
                    
                    result = (Object)formatter.Deserialize(stream);
                }
            }
            catch (IOException e)
            {
                Console.Write(e.Message);
            }

            return result;
        }
    }
}
