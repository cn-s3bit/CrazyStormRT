using System;

namespace CrazyStorm_1._03 {
    public static class MathHelper { 

        public static float ToRadians(float degrees) {
            return (float)(degrees*(Math.PI/180f));
        }

        public static float ToDegrees(float radians) {
            return radians*57.29578f;
        }

        public static float Clamp(float value,float min,float max) {
            value=value>max ? max : value;
            value=value<min ? min : value;
            return value;
        }

        public static float Lerp(float value1,float value2,float amount) {
            return value1+(value2-value1)*amount;
        }
    }
}
