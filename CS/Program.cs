using System;
using System.Collections.Generic;
using System.IO;

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
                        using (MemoryStream ms = new MemoryStream()) {
                            using (BinaryWriter bw = new BinaryWriter(ms)) {
                                for (int i = 0; i < filtered.Count; i++) {
                                    Barrage b = filtered[i];
                                    bw.Write (b.x);
                                    bw.Write (b.y);
                                    bw.Write (150);
                                    bw.Write (b.wscale);
                                    bw.Write (b.hscale);
                                    bw.Write (b.Blend);
                                }
                                Console.Write (ms.Length.ToString ("0000000000"));
                                Console.Out.Flush ();
                                using (Stream stdout = Console.OpenStandardOutput()) {
                                    ms.Seek (0, SeekOrigin.Begin);
                                    ms.CopyTo (stdout);
                                    stdout.Flush ();
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            };
        }
    }
}