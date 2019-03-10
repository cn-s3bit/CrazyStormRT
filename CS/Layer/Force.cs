using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CrazyStorm_1._03 {
    [Serializable]
    public class Force:ICloneable {
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
        public int halfw;
        public int halfh;
        public bool Circle;
        public int type;
        public int controlid;
        public float speed;
        public float speedd;
        public float speedx;
        public float speedy;
        public float aspeed;
        public float aspeedx;
        public float aspeedy;
        public float aspeedd;
        public float addaspeed;
        public float addaspeedd;
        public bool Suction;
        public bool Repulsion;
        public float addspeed;
        public Force rand;
        public List<Event> Parentevents;
        public Force copys;

        public Force() {
        }

        public Force(float xs,float ys,int pc) {
            this.rand=new Force();
            this.Parentevents=new List<Event>();
            this.x=xs;
            this.y=ys;
            this.parentcolor=pc;
            this.begin=Layer.LayerArray[this.parentid].begin;
            this.life=Layer.LayerArray[this.parentid].end-Layer.LayerArray[this.parentid].begin+1;
            this.halfw=100;
            this.halfh=100;
            this.type=0;
            this.controlid=1;
            this.speed=0.0f;
            this.speedd=0.0f;
            this.aspeed=0.0f;
            this.aspeedd=0.0f;
            this.Circle=false;
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
            if(this.Circle) {
                if(Math.Sqrt(((double)this.x-4.0-(double)Player.position.X)*((double)this.x-4.0-(double)Player.position.X)+((double)this.y+16.0-(double)Player.position.Y)*((double)this.y+16.0-(double)Player.position.Y))<=(double)Math.Max(this.halfw,this.halfh)) {
                    if(this.Suction) {
                        float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,Player.position.X,Player.position.Y));
                        Player.position.X+=this.addspeed*(float)Math.Cos((double)MathHelper.ToRadians(degrees));
                        Player.position.Y+=this.addspeed*(float)Math.Sin((double)MathHelper.ToRadians(degrees));
                    } else if(this.Repulsion) {
                        float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,Player.position.X,Player.position.Y));
                        Player.position.X+=this.addspeed*(float)Math.Cos((double)MathHelper.ToRadians(180f+degrees));
                        Player.position.Y+=this.addspeed*(float)Math.Sin((double)MathHelper.ToRadians(180f+degrees));
                    } else {
                        Player.position.X+=this.addspeed*(float)Math.Cos((double)MathHelper.ToRadians(this.addaspeedd));
                        Player.position.Y+=this.addspeed*(float)Math.Sin((double)MathHelper.ToRadians(this.addaspeedd));
                    }
                    if(Player.position.X<=4.5f)
                        Player.position.X=4.5f;
                    if(Player.position.X>=625.5f)
                        Player.position.X=625.5f;
                    if(Player.position.Y<=4.5f)
                        Player.position.Y=4.5f;
                    if(Player.position.Y>=475.5f)
                        Player.position.Y=475.5f;
                }
            } else if((double)Math.Abs(this.x-4f-Player.position.X)<=(double)this.halfw&(double)Math.Abs(this.y+16f-Player.position.Y)<=(double)this.halfh) {
                if(this.Suction) {
                    float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,Player.position.X,Player.position.Y));
                    Player.position.X+=this.addspeed*(float)Math.Cos((double)MathHelper.ToRadians(degrees));
                    Player.position.Y+=this.addspeed*(float)Math.Sin((double)MathHelper.ToRadians(degrees));
                } else if(this.Repulsion) {
                    float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,Player.position.X,Player.position.Y));
                    Player.position.X+=this.addspeed*(float)Math.Cos((double)MathHelper.ToRadians(180f+degrees));
                    Player.position.Y+=this.addspeed*(float)Math.Sin((double)MathHelper.ToRadians(180f+degrees));
                } else {
                    Player.position.X+=this.addspeed*(float)Math.Cos((double)MathHelper.ToRadians(this.addaspeedd));
                    Player.position.Y+=this.addspeed*(float)Math.Sin((double)MathHelper.ToRadians(this.addaspeedd));
                }
                if(Player.position.X<=4.5f)
                    Player.position.X=4.5f;
                if(Player.position.X>=625.5f)
                    Player.position.X=625.5f;
                if(Player.position.Y<=4.5f)
                    Player.position.Y=4.5f;
                if(Player.position.Y>=475.5f)
                    Player.position.Y=475.5f;
            }
            foreach(Barrage barrage in Layer.LayerArray[this.parentid].Barrages) {
                if(barrage.Force) {
                    if(this.Circle) {
                        if(this.type==0) {
                            if(Math.Sqrt(((double)this.x-4.0-(double)barrage.x)*((double)this.x-4.0-(double)barrage.x)+((double)this.y+16.0-(double)barrage.y)*((double)this.y+16.0-(double)barrage.y))<=(double)Math.Max(this.halfw,this.halfh)) {
                                if(this.Suction) {
                                    float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,barrage.x,barrage.y));
                                    barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(degrees));
                                    barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(degrees));
                                } else if(this.Repulsion) {
                                    float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,barrage.x,barrage.y));
                                    barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(180f+degrees));
                                    barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(180f+degrees));
                                } else {
                                    barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(this.addaspeedd));
                                    barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(this.addaspeedd));
                                }
                            }
                        } else if(this.type==1&&barrage.parentid==this.controlid-1&Math.Sqrt(((double)this.x-4.0-(double)barrage.x)*((double)this.x-4.0-(double)barrage.x)+((double)this.y+16.0-(double)barrage.y)*((double)this.y+16.0-(double)barrage.y))<=(double)Math.Max(this.halfw,this.halfh)) {
                            if(this.Suction) {
                                float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,barrage.x,barrage.y));
                                barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(degrees));
                                barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(degrees));
                            } else if(this.Repulsion) {
                                float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,barrage.x,barrage.y));
                                barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(180f+degrees));
                                barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(180f+degrees));
                            } else {
                                barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(this.addaspeedd));
                                barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(this.addaspeedd));
                            }
                        }
                    } else if(this.type==0) {
                        if((double)Math.Abs(this.x-4f-barrage.x)<=(double)this.halfw&(double)Math.Abs(this.y+16f-barrage.y)<=(double)this.halfh) {
                            if(this.Suction) {
                                float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,barrage.x,barrage.y));
                                barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(degrees));
                                barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(degrees));
                            } else if(this.Repulsion) {
                                float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,barrage.x,barrage.y));
                                barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(180f+degrees));
                                barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(180f+degrees));
                            } else {
                                barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(this.addaspeedd));
                                barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(this.addaspeedd));
                            }
                        }
                    } else if(this.type==1&&barrage.parentid==this.controlid-1&(double)Math.Abs(this.x-4f-barrage.x)<=(double)this.halfw&(double)Math.Abs(this.y+16f-barrage.y)<=(double)this.halfh) {
                        if(this.Suction) {
                            float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,barrage.x,barrage.y));
                            barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(degrees));
                            barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(degrees));
                        } else if(this.Repulsion) {
                            float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,barrage.x,barrage.y));
                            barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(180f+degrees));
                            barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(180f+degrees));
                        } else {
                            barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(this.addaspeedd));
                            barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(this.addaspeedd));
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
