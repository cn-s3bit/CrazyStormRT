using System;
using System.Windows.Forms;

namespace CrazyStorm_1._03 {
    public partial class dataReader:Form {
        int flag = 0;

        public dataReader() {
            InitializeComponent();
            Main d = new Main();
            d.Initialize(); 
        }
        private int lastFrame = 0;
        private void timer1_Tick(object sender,EventArgs e) {
            bulletCount.Text="bullet:"+Th902Interface.GetBulletCount();
            string s = "";
            foreach(Barrage b in Th902Interface.bullets) {
                s+="x:"+b.x;
                s+=",";
                s+="y:"+b.y;
                s+=" ";
                if(flag%8==0) {
                    s+="\n";
                }
                ++flag;
            }
            label2.Text=s;
        }

        private void timer2_Tick(object sender,EventArgs e) {
            Th902Interface.Update();
        }

        private void timer3_Tick(object sender,EventArgs e) {
            label1.Text="FPS:"+(Main.frame-lastFrame);
            lastFrame=Main.frame;
        }
         
        private void start_Click(object sender,EventArgs e) {
            Th902Interface.OpenMbg(@"D:\th902\th902-main\src\resources\Danmaku\里冬.mbg");
        }
    }
}
