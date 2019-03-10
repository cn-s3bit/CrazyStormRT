using System;

namespace CrazyStorm_1._03 {
    public class BExecution {
        public int parentid;
        public int id;
        public int change;
        public int changetype;
        public int changevalue;
        public string region;
        public float value;
        public int time;
        public int ctime;
        public bool NeedDelete;

        public void Update(Barrage objects) {
            if(this.changetype==1) {
                switch(this.changevalue) {
                    case 0:
                        if(this.change==0) {
                            objects.life=(int)this.value;
                            break;
                        }
                        if(this.change==1) {
                            objects.life+=(int)this.value;
                            break;
                        }
                        if(this.change==2) {
                            objects.life-=(int)this.value;
                            break;
                        }
                        break;
                    case 1:
                        if(this.change==0) {
                            objects.type=(int)this.value;
                            break;
                        }
                        if(this.change==1) {
                            objects.type+=(int)this.value;
                            break;
                        }
                        if(this.change==2) {
                            objects.type-=(int)this.value;
                            break;
                        }
                        break;
                    case 2:
                        if(this.change==0) {
                            objects.wscale=this.value;
                            break;
                        }
                        if(this.change==1) {
                            objects.wscale+=this.value;
                            break;
                        }
                        if(this.change==2) {
                            objects.wscale-=this.value;
                            break;
                        }
                        break;
                    case 3:
                        if(this.change==0) {
                            objects.hscale=this.value;
                            break;
                        }
                        if(this.change==1) {
                            objects.hscale+=this.value;
                            break;
                        }
                        if(this.change==2) {
                            objects.hscale-=this.value;
                            break;
                        }
                        break;
                    case 4:
                        if(this.change==0) {
                            objects.R=this.value;
                            break;
                        }
                        if(this.change==1) {
                            objects.R+=this.value;
                            break;
                        }
                        if(this.change==2) {
                            objects.R-=this.value;
                            break;
                        }
                        break;
                    case 5:
                        if(this.change==0) {
                            objects.G=this.value;
                            break;
                        }
                        if(this.change==1) {
                            objects.G+=this.value;
                            break;
                        }
                        if(this.change==2) {
                            objects.G-=this.value;
                            break;
                        }
                        break;
                    case 6:
                        if(this.change==0) {
                            objects.B=this.value;
                            break;
                        }
                        if(this.change==1) {
                            objects.B+=this.value;
                            break;
                        }
                        if(this.change==2) {
                            objects.B-=this.value;
                            break;
                        }
                        break;
                    case 7:
                        if(this.change==0) {
                            objects.alpha=this.value;
                            break;
                        }
                        if(this.change==1) {
                            objects.alpha+=this.value;
                            break;
                        }
                        if(this.change==2) {
                            objects.alpha-=this.value;
                            break;
                        }
                        break;
                    case 8:
                        if(this.change==0) {
                            objects.head=this.value;
                            break;
                        }
                        if(this.change==1) {
                            objects.head+=this.value;
                            break;
                        }
                        if(this.change==2) {
                            objects.head-=this.value;
                            break;
                        }
                        break;
                    case 9:
                        if(this.change==0)
                            objects.speed=this.value;
                        else if(this.change==1)
                            objects.speed+=this.value;
                        else if(this.change==2)
                            objects.speed-=this.value;
                        objects.speedx=objects.xscale*objects.speed*(float)Math.Cos((double)MathHelper.ToRadians(objects.speedd));
                        objects.speedy=objects.yscale*objects.speed*(float)Math.Sin((double)MathHelper.ToRadians(objects.speedd));
                        break;
                    case 10:
                        if(this.change==0)
                            objects.speedd=this.value;
                        else if(this.change==1)
                            objects.speedd+=this.value;
                        else if(this.change==2)
                            objects.speedd-=this.value;
                        objects.speedx=objects.xscale*objects.speed*(float)Math.Cos((double)MathHelper.ToRadians(objects.speedd));
                        objects.speedy=objects.yscale*objects.speed*(float)Math.Sin((double)MathHelper.ToRadians(objects.speedd));
                        break;
                    case 11:
                        if(this.change==0)
                            objects.aspeed=this.value;
                        else if(this.change==1)
                            objects.aspeed+=this.value;
                        else if(this.change==2)
                            objects.aspeed-=this.value;
                        objects.aspeedx=objects.xscale*objects.aspeed*(float)Math.Cos((double)MathHelper.ToRadians(objects.aspeedd));
                        objects.aspeedy=objects.yscale*objects.aspeed*(float)Math.Sin((double)MathHelper.ToRadians(objects.aspeedd));
                        break;
                    case 12:
                        if(this.change==0)
                            objects.aspeedd=this.value;
                        else if(this.change==1)
                            objects.aspeedd+=this.value;
                        else if(this.change==2)
                            objects.aspeedd-=this.value;
                        objects.aspeedx=objects.xscale*objects.aspeed*(float)Math.Cos((double)MathHelper.ToRadians(objects.aspeedd));
                        objects.aspeedy=objects.yscale*objects.aspeed*(float)Math.Sin((double)MathHelper.ToRadians(objects.aspeedd));
                        break;
                    case 13:
                        if(this.change==0) {
                            objects.xscale=this.value;
                            break;
                        }
                        if(this.change==1) {
                            objects.xscale+=this.value;
                            break;
                        }
                        if(this.change==2) {
                            objects.xscale-=this.value;
                            break;
                        }
                        break;
                    case 14:
                        if(this.change==0) {
                            objects.yscale=this.value;
                            break;
                        }
                        if(this.change==1) {
                            objects.yscale+=this.value;
                            break;
                        }
                        if(this.change==2) {
                            objects.yscale-=this.value;
                            break;
                        }
                        break;
                    case 15:
                        if((double)this.value>0.0)
                            objects.Mist=true;
                        if((double)this.value<=0.0) {
                            objects.Mist=false;
                            break;
                        }
                        break;
                    case 16:
                        if((double)this.value>0.0)
                            objects.Dispel=true;
                        if((double)this.value<=0.0) {
                            objects.Dispel=false;
                            break;
                        }
                        break;
                    case 17:
                        if((double)this.value>0.0)
                            objects.Blend=true;
                        if((double)this.value<=0.0) {
                            objects.Blend=false;
                            break;
                        }
                        break;
                    case 18:
                        if((double)this.value>0.0)
                            objects.Afterimage=true;
                        if((double)this.value<=0.0) {
                            objects.Afterimage=false;
                            break;
                        }
                        break;
                    case 19:
                        if((double)this.value>0.0)
                            objects.Outdispel=true;
                        if((double)this.value<=0.0) {
                            objects.Outdispel=false;
                            break;
                        }
                        break;
                    case 20:
                        if((double)this.value>0.0)
                            objects.Invincible=true;
                        if((double)this.value<=0.0) {
                            objects.Invincible=false;
                            break;
                        }
                        break;
                }
            } else if(this.changetype==0) {
                switch(this.changevalue) {
                    case 0:
                        if(this.change==0) {
                            objects.life=(int)(((double)objects.life*((double)this.ctime-1.0)+(double)this.value)/(double)this.ctime);
                            break;
                        }
                        if(this.change==1) {
                            objects.life+=(int)((double)this.value/(double)this.time);
                            break;
                        }
                        if(this.change==2) {
                            objects.life-=(int)((double)this.value/(double)this.time);
                            break;
                        }
                        break;
                    case 1:
                        if(this.change==0) {
                            objects.type=(int)(((double)objects.type*((double)this.ctime-1.0)+(double)this.value)/(double)this.ctime);
                            break;
                        }
                        if(this.change==1) {
                            objects.type+=(int)((double)this.value/(double)this.time);
                            break;
                        }
                        if(this.change==2) {
                            objects.type-=(int)((double)this.value/(double)this.time);
                            break;
                        }
                        break;
                    case 2:
                        if(this.change==0) {
                            objects.wscale=(objects.wscale*((float)this.ctime-1f)+this.value)/(float)this.ctime;
                            break;
                        }
                        if(this.change==1) {
                            objects.wscale+=this.value/(float)this.time;
                            break;
                        }
                        if(this.change==2) {
                            objects.wscale-=this.value/(float)this.time;
                            break;
                        }
                        break;
                    case 3:
                        if(this.change==0) {
                            objects.hscale=(objects.hscale*((float)this.ctime-1f)+this.value)/(float)this.ctime;
                            break;
                        }
                        if(this.change==1) {
                            objects.hscale+=this.value/(float)this.time;
                            break;
                        }
                        if(this.change==2) {
                            objects.hscale-=this.value/(float)this.time;
                            break;
                        }
                        break;
                    case 4:
                        if(this.change==0) {
                            objects.R=(objects.R*((float)this.ctime-1f)+this.value)/(float)this.ctime;
                            break;
                        }
                        if(this.change==1) {
                            objects.R+=this.value/(float)this.time;
                            break;
                        }
                        if(this.change==2) {
                            objects.R-=this.value/(float)this.time;
                            break;
                        }
                        break;
                    case 5:
                        if(this.change==0) {
                            objects.G=(objects.G*((float)this.ctime-1f)+this.value)/(float)this.ctime;
                            break;
                        }
                        if(this.change==1) {
                            objects.G+=this.value/(float)this.time;
                            break;
                        }
                        if(this.change==2) {
                            objects.G-=this.value/(float)this.time;
                            break;
                        }
                        break;
                    case 6:
                        if(this.change==0) {
                            objects.B=(objects.B*((float)this.ctime-1f)+this.value)/(float)this.ctime;
                            break;
                        }
                        if(this.change==1) {
                            objects.B+=this.value/(float)this.time;
                            break;
                        }
                        if(this.change==2) {
                            objects.B-=this.value/(float)this.time;
                            break;
                        }
                        break;
                    case 7:
                        if(this.change==0) {
                            objects.alpha=(objects.alpha*((float)this.ctime-1f)+this.value)/(float)this.ctime;
                            break;
                        }
                        if(this.change==1) {
                            objects.alpha+=this.value/(float)this.time;
                            break;
                        }
                        if(this.change==2) {
                            objects.alpha-=this.value/(float)this.time;
                            break;
                        }
                        break;
                    case 8:
                        if(this.change==0) {
                            objects.head=(objects.head*((float)this.ctime-1f)+this.value)/(float)this.ctime;
                            break;
                        }
                        if(this.change==1) {
                            objects.head+=this.value/(float)this.time;
                            break;
                        }
                        if(this.change==2) {
                            objects.head-=this.value/(float)this.time;
                            break;
                        }
                        break;
                    case 9:
                        if(this.change==0)
                            objects.speed=(objects.speed*((float)this.ctime-1f)+this.value)/(float)this.ctime;
                        else if(this.change==1)
                            objects.speed+=this.value/(float)this.time;
                        else if(this.change==2)
                            objects.speed-=this.value/(float)this.time;
                        objects.speedx=objects.xscale*objects.speed*(float)Math.Cos((double)MathHelper.ToRadians(objects.speedd));
                        objects.speedy=objects.yscale*objects.speed*(float)Math.Sin((double)MathHelper.ToRadians(objects.speedd));
                        break;
                    case 10:
                        if(this.change==0)
                            objects.speedd=(objects.speedd*((float)this.ctime-1f)+this.value)/(float)this.ctime;
                        else if(this.change==1)
                            objects.speedd+=this.value/(float)this.time;
                        else if(this.change==2)
                            objects.speedd-=this.value/(float)this.time;
                        objects.speedx=objects.xscale*objects.speed*(float)Math.Cos((double)MathHelper.ToRadians(objects.speedd));
                        objects.speedy=objects.yscale*objects.speed*(float)Math.Sin((double)MathHelper.ToRadians(objects.speedd));
                        break;
                    case 11:
                        if(this.change==0)
                            objects.aspeed=(objects.aspeed*((float)this.ctime-1f)+this.value)/(float)this.ctime;
                        else if(this.change==1)
                            objects.aspeed+=this.value/(float)this.time;
                        else if(this.change==2)
                            objects.aspeed-=this.value/(float)this.time;
                        objects.aspeedx=objects.xscale*objects.aspeed*(float)Math.Cos((double)MathHelper.ToRadians(objects.aspeedd));
                        objects.aspeedy=objects.yscale*objects.aspeed*(float)Math.Sin((double)MathHelper.ToRadians(objects.aspeedd));
                        break;
                    case 12:
                        if(this.change==0)
                            objects.aspeedd=(objects.aspeedd*((float)this.ctime-1f)+this.value)/(float)this.ctime;
                        else if(this.change==1)
                            objects.aspeedd+=this.value/(float)this.time;
                        else if(this.change==2)
                            objects.aspeedd-=this.value/(float)this.time;
                        objects.aspeedx=objects.xscale*objects.aspeed*(float)Math.Cos((double)MathHelper.ToRadians(objects.aspeedd));
                        objects.aspeedy=objects.yscale*objects.aspeed*(float)Math.Sin((double)MathHelper.ToRadians(objects.aspeedd));
                        break;
                    case 13:
                        if(this.change==0) {
                            objects.xscale=(objects.xscale*((float)this.ctime-1f)+this.value)/(float)this.ctime;
                            break;
                        }
                        if(this.change==1) {
                            objects.xscale+=this.value/(float)this.time;
                            break;
                        }
                        if(this.change==2) {
                            objects.xscale-=this.value/(float)this.time;
                            break;
                        }
                        break;
                    case 14:
                        if(this.change==0) {
                            objects.yscale=(objects.yscale*((float)this.ctime-1f)+this.value)/(float)this.ctime;
                            break;
                        }
                        if(this.change==1) {
                            objects.yscale+=this.value/(float)this.time;
                            break;
                        }
                        if(this.change==2) {
                            objects.yscale-=this.value/(float)this.time;
                            break;
                        }
                        break;
                    case 15:
                        if((double)this.value>0.0)
                            objects.Mist=true;
                        if((double)this.value<=0.0) {
                            objects.Mist=false;
                            break;
                        }
                        break;
                    case 16:
                        if((double)this.value>0.0)
                            objects.Dispel=true;
                        if((double)this.value<=0.0) {
                            objects.Dispel=false;
                            break;
                        }
                        break;
                    case 17:
                        if((double)this.value>0.0)
                            objects.Blend=true;
                        if((double)this.value<=0.0) {
                            objects.Blend=false;
                            break;
                        }
                        break;
                    case 18:
                        if((double)this.value>0.0)
                            objects.Afterimage=true;
                        if((double)this.value<=0.0) {
                            objects.Afterimage=false;
                            break;
                        }
                        break;
                    case 19:
                        if((double)this.value>0.0)
                            objects.Outdispel=true;
                        if((double)this.value<=0.0) {
                            objects.Outdispel=false;
                            break;
                        }
                        break;
                    case 20:
                        if((double)this.value>0.0)
                            objects.Invincible=true;
                        if((double)this.value<=0.0) {
                            objects.Invincible=false;
                            break;
                        }
                        break;
                }
            } else if(this.changetype==2) {
                switch(this.changevalue) {
                    case 0:
                        if(this.change==0) {
                            objects.life=(int)((double)float.Parse(this.region)+((double)this.value-(double)float.Parse(this.region))*Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime)))));
                            break;
                        }
                        if(this.change==1) {
                            objects.life=(int)((double)float.Parse(this.region)+(double)this.value*Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime)))));
                            break;
                        }
                        if(this.change==2) {
                            objects.life=(int)((double)float.Parse(this.region)-(double)this.value*Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime)))));
                            break;
                        }
                        break;
                    case 1:
                        if(this.change==0) {
                            objects.type=(int)((double)float.Parse(this.region)+((double)this.value-(double)float.Parse(this.region))*Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime)))));
                            break;
                        }
                        if(this.change==1) {
                            objects.type=(int)((double)float.Parse(this.region)+(double)this.value*Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime)))));
                            break;
                        }
                        if(this.change==2) {
                            objects.type=(int)((double)float.Parse(this.region)-(double)this.value*Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime)))));
                            break;
                        }
                        break;
                    case 2:
                        if(this.change==0) {
                            objects.wscale=float.Parse(this.region)+(this.value-float.Parse(this.region))*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        if(this.change==1) {
                            objects.wscale=float.Parse(this.region)+this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        if(this.change==2) {
                            objects.wscale=float.Parse(this.region)-this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        break;
                    case 3:
                        if(this.change==0) {
                            objects.hscale=float.Parse(this.region)+(this.value-float.Parse(this.region))*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        if(this.change==1) {
                            objects.hscale=float.Parse(this.region)+this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        if(this.change==2) {
                            objects.hscale=float.Parse(this.region)-this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        break;
                    case 4:
                        if(this.change==0) {
                            objects.R=float.Parse(this.region)+(this.value-float.Parse(this.region))*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        if(this.change==1) {
                            objects.R=float.Parse(this.region)+this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        if(this.change==2) {
                            objects.R=float.Parse(this.region)-this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        break;
                    case 5:
                        if(this.change==0) {
                            objects.G=float.Parse(this.region)+(this.value-float.Parse(this.region))*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        if(this.change==1) {
                            objects.G=float.Parse(this.region)+this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        if(this.change==2) {
                            objects.G=float.Parse(this.region)-this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        break;
                    case 6:
                        if(this.change==0) {
                            objects.B=float.Parse(this.region)+(this.value-float.Parse(this.region))*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        if(this.change==1) {
                            objects.B=float.Parse(this.region)+this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        if(this.change==2) {
                            objects.B=float.Parse(this.region)-this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        break;
                    case 7:
                        if(this.change==0) {
                            objects.alpha=float.Parse(this.region)+(this.value-float.Parse(this.region))*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        if(this.change==1) {
                            objects.alpha=float.Parse(this.region)+this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        if(this.change==2) {
                            objects.alpha=float.Parse(this.region)-this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        break;
                    case 8:
                        if(this.change==0) {
                            objects.head=float.Parse(this.region)+(this.value-float.Parse(this.region))*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        if(this.change==1) {
                            objects.head=float.Parse(this.region)+this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        if(this.change==2) {
                            objects.head=float.Parse(this.region)-this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        break;
                    case 9:
                        if(this.change==0)
                            objects.speed=float.Parse(this.region)+(this.value-float.Parse(this.region))*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        else if(this.change==1)
                            objects.speed=float.Parse(this.region)+this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        else if(this.change==2)
                            objects.speed=float.Parse(this.region)-this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        objects.speedx=objects.xscale*objects.speed*(float)Math.Cos((double)MathHelper.ToRadians(objects.speedd));
                        objects.speedy=objects.yscale*objects.speed*(float)Math.Sin((double)MathHelper.ToRadians(objects.speedd));
                        break;
                    case 10:
                        if(this.change==0)
                            objects.speedd=float.Parse(this.region)+(this.value-float.Parse(this.region))*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        else if(this.change==1)
                            objects.speedd=float.Parse(this.region)+this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        else if(this.change==2)
                            objects.speedd=float.Parse(this.region)-this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        objects.speedx=objects.xscale*objects.speed*(float)Math.Cos((double)MathHelper.ToRadians(objects.speedd));
                        objects.speedy=objects.yscale*objects.speed*(float)Math.Sin((double)MathHelper.ToRadians(objects.speedd));
                        break;
                    case 11:
                        if(this.change==0)
                            objects.aspeed=float.Parse(this.region)+(this.value-float.Parse(this.region))*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        else if(this.change==1)
                            objects.aspeed=float.Parse(this.region)+this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        else if(this.change==2)
                            objects.aspeed=float.Parse(this.region)-this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        objects.aspeedx=objects.xscale*objects.aspeed*(float)Math.Cos((double)MathHelper.ToRadians(objects.aspeedd));
                        objects.aspeedy=objects.yscale*objects.aspeed*(float)Math.Sin((double)MathHelper.ToRadians(objects.aspeedd));
                        break;
                    case 12:
                        if(this.change==0)
                            objects.aspeedd=float.Parse(this.region)+(this.value-float.Parse(this.region))*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        else if(this.change==1)
                            objects.aspeedd=float.Parse(this.region)+this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        else if(this.change==2)
                            objects.aspeedd=float.Parse(this.region)-this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        objects.aspeedx=objects.xscale*objects.aspeed*(float)Math.Cos((double)MathHelper.ToRadians(objects.aspeedd));
                        objects.aspeedy=objects.yscale*objects.aspeed*(float)Math.Sin((double)MathHelper.ToRadians(objects.aspeedd));
                        break;
                    case 13:
                        if(this.change==0) {
                            objects.xscale=float.Parse(this.region)+(this.value-float.Parse(this.region))*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        if(this.change==1) {
                            objects.xscale=float.Parse(this.region)+this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        if(this.change==2) {
                            objects.xscale=float.Parse(this.region)-this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        break;
                    case 14:
                        if(this.change==0) {
                            objects.yscale=float.Parse(this.region)+(this.value-float.Parse(this.region))*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        if(this.change==1) {
                            objects.yscale=float.Parse(this.region)+this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        if(this.change==2) {
                            objects.yscale=float.Parse(this.region)-this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                            break;
                        }
                        break;
                    case 15:
                        if((double)this.value>0.0)
                            objects.Mist=true;
                        if((double)this.value<=0.0) {
                            objects.Mist=false;
                            break;
                        }
                        break;
                    case 16:
                        if((double)this.value>0.0)
                            objects.Dispel=true;
                        if((double)this.value<=0.0) {
                            objects.Dispel=false;
                            break;
                        }
                        break;
                    case 17:
                        if((double)this.value>0.0)
                            objects.Blend=true;
                        if((double)this.value<=0.0) {
                            objects.Blend=false;
                            break;
                        }
                        break;
                    case 18:
                        if((double)this.value>0.0)
                            objects.Afterimage=true;
                        if((double)this.value<=0.0) {
                            objects.Afterimage=false;
                            break;
                        }
                        break;
                    case 19:
                        if((double)this.value>0.0)
                            objects.Outdispel=true;
                        if((double)this.value<=0.0) {
                            objects.Outdispel=false;
                            break;
                        }
                        break;
                    case 20:
                        if((double)this.value>0.0)
                            objects.Invincible=true;
                        if((double)this.value<=0.0) {
                            objects.Invincible=false;
                            break;
                        }
                        break;
                }
            }
            --this.ctime;
            if(this.changetype==2&this.ctime==-1) {
                this.NeedDelete=true;
            } else {
                if(!(this.changetype!=2&this.ctime==0))
                    return;
                this.NeedDelete=true;
            }
        }
    }
}
