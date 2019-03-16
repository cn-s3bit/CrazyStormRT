using System;
using System.Collections.Generic;
using System.IO;

namespace CrazyStorm_1._03 {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main () {
            new Main ().Initialize ("set.xna");
            while (true) {
                string command = Console.ReadLine ();
                switch (command[0]) {
                    case 'q':
                        return;
                    case 'o':
                        Th902Interface.OpenMbg (command.Substring (1));
                        break;
                    case 'p':
                        string[] s = command.Substring (1).Split (',');
                        Th902Interface.SetPlayerPosition (float.Parse (s[0]) / 1.5f, float.Parse (s[1]) / 1.5f);
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
                                    bw.Write (b.x * 1.5f);
                                    bw.Write (b.y * 1.5f);
                                    bw.Write (b.type);
                                    bw.Write (b.wscale);
                                    bw.Write (b.hscale);
                                    bw.Write (b.Blend);
                                    bw.Write (b.R / 255.0f);
                                    bw.Write (b.G / 255.0f);
                                    bw.Write (b.B / 255.0f);
                                    bw.Write (b.alpha / 100.0f);
                                    bw.Write (b.head + 90.0f);
                                }
                                Console.Write (ms.Length.ToString ("0000000000"));
                                Console.Out.Flush ();
                                using (Stream stdout = Console.OpenStandardOutput()) {
                                    stdout.Flush ();
                                    ms.Seek (0, SeekOrigin.Begin);
                                    ms.CopyTo (stdout, Math.Max (32768, (int)ms.Length));
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
