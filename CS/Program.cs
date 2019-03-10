using System;
using System.Collections.Generic;

namespace CrazyStorm_1._03 {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main () {
            new Main ().Initialize ();
            while(true) {
                string command = Console.ReadLine ();
                switch (command[0]) {
                    case 'q':
                        return;
                    case 'o':
                        Th902Interface.OpenMbg (command.Substring (1));
                        break;
                    case 'p':
                        string[] s = command.Substring (1).Split (',');
                        Th902Interface.SetPlayerPosition (float.Parse (s[0]), float.Parse (s[1]));
                        break;
                    case 'r':
                        Th902Interface.SetRandomSeed (int.Parse (command.Substring (1)));
                        break;
                    case 'u':
                        Th902Interface.Update ();
                        break;
                    case 'g':
                        var list = Th902Interface.GetBulletList ();
                        var filtered = new List<Barrage> ();
                        foreach (var item in list) {
                            if (item.IsLase || item.IsRay)
                                continue;
                            filtered.Add (item);
                        }
                        Console.Write (filtered.Count);
                        Console.Write (' ');
                        for (int i = 0; i < filtered.Count; i++) {
                            Barrage b = filtered[i];
                            Console.Write (b.x);
                            Console.Write (' ');
                            Console.Write (b.y);
                            Console.Write (' ');
                            Console.Write (b.type);
                            Console.Write (' ');
                            Console.Write (b.wscale);
                            Console.Write (' ');
                            Console.Write (b.hscale);
                            Console.Write (' ');
                            Console.Write (b.Blend);
                            Console.Write (' ');
                        }
                        break;
                    default:
                        break;
                }
            };
        }
    }
}