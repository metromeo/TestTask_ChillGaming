using System.IO;
using UnityEngine;

namespace CGTest
{
    public class JsonDataProvider : IDataProvider
    {
        public Data Data { get; private set; }
        public JsonDataProvider(DataSettings dataSettings)
        {
            using (StreamReader stream = new StreamReader(dataSettings.PathToFile))
            {
                string json = stream.ReadToEnd();
                Data = JsonUtility.FromJson<Data>(json);
            }
        }
    }
}
