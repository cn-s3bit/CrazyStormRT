using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CrazyStorm_1._03 {
    [Serializable]
    public class Rebound:ICloneable {
        private int clcount;
        private int clwait;
        public bool NeedDelete;
        public int Searched;
        public int id;
        public int parentid;
        public int parentcolor;
        public float x;
        public float y;
        public int begin;
        public int life;
        public int longs;
        public int time;
        public float angle;
        public float speed;
        public float speedd;
        public float speedx;
        public float speedy;
        public Vector2 speedds;
        public float aspeed;
        public float aspeedx;
        public float aspeedy;
        public float aspeedd;
        public Vector2 aspeedds;
        public Rebound rand;
        public List<Event> Parentevents;
        public Rebound copys;

        public Rebound() {
        }

        public Rebound(float xs,float ys,int pc) {
            this.rand=new Rebound();
            this.Parentevents=new List<Event>();
            this.x=xs;
            this.y=ys;
            this.parentcolor=pc;
            this.begin=Layer.LayerArray[this.parentid].begin;
            this.life=Layer.LayerArray[this.parentid].end-Layer.LayerArray[this.parentid].begin+1;
            this.longs=100;
            this.time=1;
            this.angle=0.0f;
        }

        public void Update() {
            if(this.clcount==1) {
                ++this.clwait;
                if(this.clwait>15) {
                    this.clwait=0;
                    this.clcount=0;
                }
            }
            if(!Time.Playing) {
                this.aspeedx=this.aspeed*(float)Math.Cos((double)MathHelper.ToRadians(this.aspeedd));
                this.aspeedy=this.aspeed*(float)Math.Sin((double)MathHelper.ToRadians(this.aspeedd));
                this.speedx=this.speed*(float)Math.Cos((double)MathHelper.ToRadians(this.speedd));
                this.speedy=this.speed*(float)Math.Sin((double)MathHelper.ToRadians(this.speedd));
                this.begin=(int)MathHelper.Clamp((float)this.begin,(float)Layer.LayerArray[this.parentid].begin,(float)(1+Layer.LayerArray[this.parentid].end-Layer.LayerArray[this.parentid].begin));
                this.life=(int)MathHelper.Clamp((float)this.life,1f,(float)(Layer.LayerArray[this.parentid].end-Layer.LayerArray[this.parentid].begin+2-this.begin));
            }
            if(!Time.Playing||!(Time.now>=this.begin&Time.now<=this.begin+this.life-1))
                return;
            int now = Time.now;
            this.speedx+=this.aspeedx;
            this.speedy+=this.aspeedy;
            this.x+=this.speedx;
            this.y+=this.speedy;
            float x2 = this.x-4f;
            float y2 = this.y+16f;
            float x3 = (float)((double)this.x-4.0+(double)this.longs*Math.Cos((double)MathHelper.ToRadians(this.angle)));
            float y3 = (float)((double)this.y+16.0+(double)this.longs*Math.Sin((double)MathHelper.ToRadians(this.angle)));
            Line line1 = new Line(new Vector2(x2,y2),new Vector2(x3,y3));
            foreach(Barrage barrage in Layer.LayerArray[this.parentid].Barrages) {
                if(barrage.Rebound&&(barrage.time>15||!barrage.Mist)&&!barrage.Dis) {
                    float speedx = barrage.speedx;
                    float speedy = barrage.speedy;
                    float num1 = speedx+barrage.aspeedx;
                    float num2 = speedy+barrage.aspeedy;
                    float x4 = barrage.x;
                    float y4 = barrage.y;
                    float num3 = x4+(num1-this.speedx);
                    float num4 = y4+(num2-this.speedy);
                    float x5 = num3;
                    float y5 = num4;
                    float x6 = barrage.x;
                    float y6 = barrage.y;
                    Line line2 = new Line(new Vector2(x5,y5),new Vector2(x6,y6));
                    if(((Main.CheckTwoLineCrose(line1,line2) ? 1 : 0)&(barrage.reboundtime<this.time ? 1 : (this.time==0 ? 1 : 0)))!=0) {
                        float num5 = (float)(((double)y3-(double)y2)*((double)x6-(double)x5)-((double)y6-(double)y5)*((double)x3-(double)x2));
                        float num6 = (float)(((double)x3-(double)x2)*((double)x6-(double)x5)*((double)y5-(double)y2)+((double)y3-(double)y2)*((double)x6-(double)x5)*(double)x2-((double)y6-(double)y5)*((double)x3-(double)x2)*(double)x5)/num5;
                        float num7 = (float)((((double)y3-(double)y2)*((double)y6-(double)y5)*((double)x5-(double)x2)+((double)x3-(double)x2)*((double)y6-(double)y5)*(double)y2-((double)x6-(double)x5)*((double)y3-(double)y2)*(double)y5)/-(double)num5);
                        barrage.speedd=2f*this.angle-barrage.speedd;
                        float num8 = (float)(((double)num6-(double)x5)*((double)num6-(double)x5)+((double)num7-(double)y5)*((double)num7-(double)y5));
                        barrage.x=num6+barrage.xscale*(float)(Math.Sqrt((double)num8)*Math.Cos((double)MathHelper.ToRadians(barrage.speedd)));
                        barrage.y=num7+barrage.yscale*(float)(Math.Sqrt((double)num8)*Math.Sin((double)MathHelper.ToRadians(barrage.speedd)));
                        barrage.speedx=barrage.xscale*barrage.speed*(float)Math.Cos((double)MathHelper.ToRadians(barrage.speedd));
                        barrage.speedy=barrage.yscale*barrage.speed*(float)Math.Sin((double)MathHelper.ToRadians(barrage.speedd));
                        ++barrage.reboundtime;
                        foreach(Event parentevent in this.Parentevents) {
                            string str = "";
                            string s = "";
                            int num9 = 0;
                            string tag = parentevent.tag;
                            if(parentevent.tag.Contains("变化到")) {
                                str=tag.Split("变化到".ToCharArray())[0];
                                s=tag.Split("变化到".ToCharArray())[3].Split('+')[0];
                                num9=1;
                            }
                            if(parentevent.tag.Contains("增加")) {
                                str=tag.Split("增".ToCharArray())[0];
                                s=tag.Split("增".ToCharArray())[1].Replace("加","").Split('+')[0];
                                num9=2;
                            }
                            if(parentevent.tag.Contains("减少")) {
                                str=tag.Split("减少".ToCharArray())[0];
                                s=tag.Split("减少".ToCharArray())[2].Split('+')[0];
                                num9=3;
                            }
                            if(parentevent.tag.Contains("+")) {
                                float num10 = float.Parse(parentevent.tag.Split('+')[1]);
                                s=(float.Parse(s)+MathHelper.Lerp(-num10,num10,(float)Main.rand.NextDouble())).ToString();
                            }
                            if(str=="生命") {
                                switch(num9) {
                                    case 1:
                                        barrage.life=(int)float.Parse(s);
                                        break;
                                    case 2:
                                        barrage.life+=(int)float.Parse(s);
                                        break;
                                    case 3:
                                        barrage.life-=(int)float.Parse(s);
                                        break;
                                }
                            }
                            if(str=="类型") {
                                switch(num9) {
                                    case 1:
                                        barrage.type=(int)float.Parse(s);
                                        break;
                                    case 2:
                                        barrage.type+=(int)float.Parse(s);
                                        break;
                                    case 3:
                                        barrage.type-=(int)float.Parse(s);
                                        break;
                                }
                            }
                            if(str=="宽比") {
                                switch(num9) {
                                    case 1:
                                        barrage.wscale=float.Parse(s);
                                        break;
                                    case 2:
                                        barrage.wscale+=float.Parse(s);
                                        break;
                                    case 3:
                                        barrage.wscale-=float.Parse(s);
                                        break;
                                }
                            }
                            if(str=="高比") {
                                switch(num9) {
                                    case 1:
                                        barrage.hscale=float.Parse(s);
                                        break;
                                    case 2:
                                        barrage.hscale+=float.Parse(s);
                                        break;
                                    case 3:
                                        barrage.hscale-=float.Parse(s);
                                        break;
                                }
                            }
                            if(str=="R") {
                                switch(num9) {
                                    case 1:
                                        barrage.R=float.Parse(s);
                                        break;
                                    case 2:
                                        barrage.R+=float.Parse(s);
                                        break;
                                    case 3:
                                        barrage.R-=float.Parse(s);
                                        break;
                                }
                            }
                            if(str=="G") {
                                switch(num9) {
                                    case 1:
                                        barrage.G=float.Parse(s);
                                        break;
                                    case 2:
                                        barrage.G+=float.Parse(s);
                                        break;
                                    case 3:
                                        barrage.G-=float.Parse(s);
                                        break;
                                }
                            }
                            if(str=="B") {
                                switch(num9) {
                                    case 1:
                                        barrage.B=float.Parse(s);
                                        break;
                                    case 2:
                                        barrage.B+=float.Parse(s);
                                        break;
                                    case 3:
                                        barrage.B-=float.Parse(s);
                                        break;
                                }
                            }
                            if(str=="不透明度") {
                                switch(num9) {
                                    case 1:
                                        barrage.alpha=float.Parse(s);
                                        break;
                                    case 2:
                                        barrage.alpha+=float.Parse(s);
                                        break;
                                    case 3:
                                        barrage.alpha-=float.Parse(s);
                                        break;
                                }
                            }
                            if(str=="朝向") {
                                switch(num9) {
                                    case 1:
                                        barrage.head=float.Parse(s);
                                        break;
                                    case 2:
                                        barrage.head+=float.Parse(s);
                                        break;
                                    case 3:
                                        barrage.head-=float.Parse(s);
                                        break;
                                }
                            }
                            if(str=="子弹速度") {
                                switch(num9) {
                                    case 1:
                                        barrage.speed=float.Parse(s);
                                        break;
                                    case 2:
                                        barrage.speed+=float.Parse(s);
                                        break;
                                    case 3:
                                        barrage.speed-=float.Parse(s);
                                        break;
                                }
                                barrage.speedx=barrage.xscale*barrage.speed*(float)Math.Cos((double)MathHelper.ToRadians(barrage.speedd));
                                barrage.speedy=barrage.yscale*barrage.speed*(float)Math.Sin((double)MathHelper.ToRadians(barrage.speedd));
                            }
                            if(str=="子弹速度方向") {
                                if(s.Contains("自机")) {
                                    barrage.speedd=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,barrage.x,barrage.y));
                                } else {
                                    switch(num9) {
                                        case 1:
                                            barrage.speedd=float.Parse(s);
                                            break;
                                        case 2:
                                            barrage.speedd+=float.Parse(s);
                                            break;
                                        case 3:
                                            barrage.speedd-=float.Parse(s);
                                            break;
                                    }
                                }
                                barrage.speedx=barrage.xscale*barrage.speed*(float)Math.Cos((double)MathHelper.ToRadians(barrage.speedd));
                                barrage.speedy=barrage.yscale*barrage.speed*(float)Math.Sin((double)MathHelper.ToRadians(barrage.speedd));
                            }
                            if(str=="子弹加速度") {
                                switch(num9) {
                                    case 1:
                                        barrage.aspeed=float.Parse(s);
                                        break;
                                    case 2:
                                        barrage.aspeed+=float.Parse(s);
                                        break;
                                    case 3:
                                        barrage.aspeed-=float.Parse(s);
                                        break;
                                }
                                barrage.aspeedx=barrage.xscale*barrage.aspeed*(float)Math.Cos((double)MathHelper.ToRadians(barrage.aspeedd));
                                barrage.aspeedy=barrage.yscale*barrage.aspeed*(float)Math.Sin((double)MathHelper.ToRadians(barrage.aspeedd));
                            }
                            if(str=="子弹加速度方向") {
                                if(s.Contains("自机")) {
                                    barrage.aspeedd=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,barrage.x,barrage.y));
                                } else {
                                    switch(num9) {
                                        case 1:
                                            barrage.aspeedd=float.Parse(s);
                                            break;
                                        case 2:
                                            barrage.aspeedd+=float.Parse(s);
                                            break;
                                        case 3:
                                            barrage.aspeedd-=float.Parse(s);
                                            break;
                                    }
                                }
                                barrage.aspeedx=barrage.xscale*barrage.aspeed*(float)Math.Cos((double)MathHelper.ToRadians(barrage.aspeedd));
                                barrage.aspeedy=barrage.yscale*barrage.aspeed*(float)Math.Sin((double)MathHelper.ToRadians(barrage.aspeedd));
                            }
                            if(str=="横比") {
                                switch(num9) {
                                    case 1:
                                        barrage.xscale=float.Parse(s);
                                        break;
                                    case 2:
                                        barrage.xscale+=float.Parse(s);
                                        break;
                                    case 3:
                                        barrage.xscale-=float.Parse(s);
                                        break;
                                }
                            }
                            if(str=="纵比") {
                                switch(num9) {
                                    case 1:
                                        barrage.yscale=float.Parse(s);
                                        break;
                                    case 2:
                                        barrage.yscale+=float.Parse(s);
                                        break;
                                    case 3:
                                        barrage.yscale-=float.Parse(s);
                                        break;
                                }
                            }
                            if(str=="雾化效果")
                                barrage.Mist=(int)float.Parse(s)>0;
                            if(str=="消除效果")
                                barrage.Dispel=(int)float.Parse(s)>0;
                            if(str=="高光效果")
                                barrage.Blend=(int)float.Parse(s)>0;
                            if(str=="拖影效果")
                                barrage.Afterimage=(int)float.Parse(s)>0;
                            if(str=="出屏即消")
                                barrage.Outdispel=(int)float.Parse(s)>0;
                            if(str=="无敌状态")
                                barrage.Invincible=(int)float.Parse(s)>0;
                        }
                    }
                }
            }
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

        public object Copy() {
            return this.MemberwiseClone();
        }

        public void PreviewUpdate() {
            if(!(Time.now>=this.begin&Time.now<=this.begin+this.life-1))
                return;
            int now = Time.now;
            this.speedx+=this.aspeedx;
            this.speedy+=this.aspeedy;
            this.x+=this.speedx;
            this.y+=this.speedy;
        }
    }
}
