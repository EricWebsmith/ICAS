using Icas.Common;
using Icas.DataPreprocessing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Icas.DataPreprocessing
{
    public static class Serializer
    {
        public static void Serialize(string fileName, object graph)
        {
            using (FileStream fs = new FileStream(Config.WorkingFolder + fileName, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, graph);
            }
        }

        public static T Deserialize<T>(string fileName)
        {
            using (FileStream fs = new FileStream(Config.WorkingFolder + fileName, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                object o = bf.Deserialize(fs);
                return (T)o;
            }
        }
    }
}
