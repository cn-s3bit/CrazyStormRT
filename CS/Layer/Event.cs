using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CrazyStorm_1._03 {
    [Serializable]
    public class Event {
        public string tag = "新事件组";
        public int t = 1;
        public List<string> events = new List<string>();
        public List<EventRead> results = new List<EventRead>();
        public int index;
        public int loop;
        public int addtime;
        public int special;

        public Event(int idx) {
            this.index=idx;
        }

        public object Clone() {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize((Stream)memoryStream,(object)this);
            memoryStream.Seek(0L,SeekOrigin.Begin);
            object obj = binaryFormatter.Deserialize((Stream)memoryStream);
            memoryStream.Close();
            return obj;
        }
    }
}
