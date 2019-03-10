using System;

namespace CrazyStorm_1._03 {
    [Serializable]
    public class EventRead {
        public float rand;
        public int special;
        public int special2;
        public string condition;
        public string result;
        public string condition2;
        public int contype;
        public int contype2;
        public string opreator;
        public string opreator2;
        public string collector;
        public int change;
        public int changetype;
        public int changevalue;
        public int changename;
        public float res;
        public int times;
        public int time;
        public bool noloop;

        public object Copy() {
            return MemberwiseClone();
        }
    }
}
