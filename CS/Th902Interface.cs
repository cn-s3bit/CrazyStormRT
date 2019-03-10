using System.Collections.Generic;
using System.Linq;

namespace CrazyStorm_1._03 {
    class Th902Interface {
        public static List<Barrage> bullets = new List<Barrage>();

        public static List<Barrage> GetBulletList() {
            return bullets;
        }

        public static int GetBulletCount() {
            return bullets.Count();
        }

        public static void OpenMbg(string mbgPath) {
            Main.OpenMbgFile(mbgPath);
        }

        public static void Update() {
            Main.updateAll();
        }

        public static Vector2 GetPalyerPosition() {
            return Player.position;
        }

        public static void SetPlayerX(float x) {
            Player.position.X=x;
        }

        public static void SetPlayerY(float y) {
            Player.position.Y=y;
        }

        public static void SetPlayerPosition(float x,float y) {
            Player.position.X=x;
            Player.position.Y=y;
        }

        public static void SetRandomSeed(int seed) {
            Main.rand=new System.Random(seed);
        }
    }
}
