using System;
using System.Windows.Forms;

namespace CrazyStorm_1._03 { 
        static class Program {
            /// <summary>
            /// 应用程序的主入口点。
            /// </summary>
            [STAThread]
            static void Main() {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new dataReader());
            }
        }
    }
