using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CrazyStorm_1._03 {
    [Serializable]
    public class Cover {
        private float[] conditions = new float[5];
        private float[] results = new float[11];
        private int clcount;
        private int clwait;
        public bool NeedDelete;
        public int Searched;
        public int id;
        public int childid;
        public int parentid;
        public int bindid;
        public bool Deepbind;
        public bool Deepbinded;
        public int parentcolor;
        public float x;
        public float y;
        public int time;
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
        public Vector2 speedds;
        public float aspeed;
        public float aspeedx;
        public float aspeedy;
        public float aspeedd;
        public Vector2 aspeedds;
        public Cover rand;
        public List<Event> Parentevents;
        public List<COExecution> Eventsexe;
        public List<Event> Sonevents;
        public Cover copys;

        public Cover() {
        }

        public Cover(float xs,float ys,int pc) {
            this.rand=new Cover();
            this.Parentevents=new List<Event>();
            this.Sonevents=new List<Event>();
            this.Eventsexe=new List<COExecution>();
            this.x=xs;
            this.y=ys;
            this.parentcolor=pc;
            this.begin=Layer.LayerArray[this.parentid].begin;
            this.life=Layer.LayerArray[this.parentid].end-Layer.LayerArray[this.parentid].begin+1;
            this.halfw=100;
            this.halfh=100;
            this.type=0;
            this.controlid=1;
            this.bindid=-1;
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
                this.childid=0;
                this.aspeedx=this.aspeed*(float)Math.Cos((double)MathHelper.ToRadians(this.aspeedd));
                this.aspeedy=this.aspeed*(float)Math.Sin((double)MathHelper.ToRadians(this.aspeedd));
                this.speedx=this.speed*(float)Math.Cos((double)MathHelper.ToRadians(this.speedd));
                this.speedy=this.speed*(float)Math.Sin((double)MathHelper.ToRadians(this.speedd));
                this.begin=(int)MathHelper.Clamp((float)this.begin,(float)Layer.LayerArray[this.parentid].begin,(float)(1+Layer.LayerArray[this.parentid].end-Layer.LayerArray[this.parentid].begin));
                this.life=(int)MathHelper.Clamp((float)this.life,1f,(float)(Layer.LayerArray[this.parentid].end-Layer.LayerArray[this.parentid].begin+2-this.begin));
            }
            if(this.bindid!=-1&&this.bindid>=Layer.LayerArray[this.parentid].BatchArray.Count) {
                this.bindid=-1;
                this.Deepbind=false;
            }
            if(!Time.Playing)
                return;
            if(this.Deepbinded)
                ++this.time;
            if(!(!this.Deepbinded&Time.now>=this.begin&Time.now<=this.begin+this.life-1)&&!(this.Deepbinded&this.time>=this.begin&this.time<=this.begin+this.life-1)&&!this.Deepbind)
                return;
            if(!this.Deepbind&!this.Deepbinded)
                this.time=Time.now-this.begin+1;
            if(!this.Deepbind) {
                this.speedx+=this.aspeedx;
                this.speedy+=this.aspeedy;
                this.x+=this.speedx;
                this.y+=this.speedy;
                this.conditions[0]=!this.Deepbinded ? (float)this.time : (float)(this.time-this.begin+1);
                this.conditions[1]=this.x+16f;
                this.conditions[2]=this.y+16f;
                this.conditions[3]=(float)this.halfw;
                this.conditions[4]=(float)this.halfh;
                this.results[0]=(float)this.halfw;
                this.results[1]=(float)this.halfh;
                this.results[2]=0.0f;
                this.results[3]=this.speed;
                this.results[4]=this.speedd;
                this.results[5]=this.aspeed;
                this.results[6]=this.aspeedd;
                this.results[7]=(float)this.type;
                this.results[8]=(float)this.controlid;
                this.results[9]=this.x-4f;
                this.results[10]=this.y+16f;
                foreach(Event parentevent in this.Parentevents) {
                    if(parentevent.t<=0)
                        parentevent.t=1;
                    if(this.time%parentevent.t==0)
                        ++parentevent.loop;
                    foreach(EventRead result in parentevent.results) {
                        if(result.special==4) {
                            if(result.changevalue==9)
                                result.res=Player.position.X;
                            if(result.changevalue==10)
                                result.res=Player.position.Y;
                            if(result.changevalue==4)
                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x-4f,this.y+16f));
                            if(result.changevalue==6)
                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x-4f,this.y+16f));
                        }
                        if(result.opreator==">") {
                            if(result.opreator2==">") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        COExecution coExecution = new COExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            coExecution.parentid=this.parentid;
                                            coExecution.id=this.id;
                                            coExecution.change=result.change;
                                            coExecution.changetype=result.changetype;
                                            coExecution.changevalue=result.changevalue;
                                            coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            coExecution.region=this.results[result.changename].ToString();
                                            coExecution.time=result.times;
                                            coExecution.ctime=coExecution.time;
                                            this.Eventsexe.Add(coExecution);
                                        } else
                                            continue;
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    COExecution coExecution = new COExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        coExecution.parentid=this.parentid;
                                        coExecution.id=this.id;
                                        coExecution.change=result.change;
                                        coExecution.changetype=result.changetype;
                                        coExecution.changevalue=result.changevalue;
                                        coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        coExecution.region=this.results[result.changename].ToString();
                                        coExecution.time=result.times;
                                        coExecution.ctime=coExecution.time;
                                        this.Eventsexe.Add(coExecution);
                                    } else
                                        continue;
                                }
                            } else if(result.opreator2=="=") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        COExecution coExecution = new COExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            coExecution.parentid=this.parentid;
                                            coExecution.id=this.id;
                                            coExecution.change=result.change;
                                            coExecution.changetype=result.changetype;
                                            coExecution.changevalue=result.changevalue;
                                            coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            coExecution.region=this.results[result.changename].ToString();
                                            coExecution.time=result.times;
                                            coExecution.ctime=coExecution.time;
                                            this.Eventsexe.Add(coExecution);
                                        } else
                                            continue;
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    COExecution coExecution = new COExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        coExecution.parentid=this.parentid;
                                        coExecution.id=this.id;
                                        coExecution.change=result.change;
                                        coExecution.changetype=result.changetype;
                                        coExecution.changevalue=result.changevalue;
                                        coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        coExecution.region=this.results[result.changename].ToString();
                                        coExecution.time=result.times;
                                        coExecution.ctime=coExecution.time;
                                        this.Eventsexe.Add(coExecution);
                                    } else
                                        continue;
                                }
                            } else if(result.opreator2=="<") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        COExecution coExecution = new COExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            coExecution.parentid=this.parentid;
                                            coExecution.id=this.id;
                                            coExecution.change=result.change;
                                            coExecution.changetype=result.changetype;
                                            coExecution.changevalue=result.changevalue;
                                            coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            coExecution.region=this.results[result.changename].ToString();
                                            coExecution.time=result.times;
                                            coExecution.ctime=coExecution.time;
                                            this.Eventsexe.Add(coExecution);
                                        } else
                                            continue;
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    COExecution coExecution = new COExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        coExecution.parentid=this.parentid;
                                        coExecution.id=this.id;
                                        coExecution.change=result.change;
                                        coExecution.changetype=result.changetype;
                                        coExecution.changevalue=result.changevalue;
                                        coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        coExecution.region=this.results[result.changename].ToString();
                                        coExecution.time=result.times;
                                        coExecution.ctime=coExecution.time;
                                        this.Eventsexe.Add(coExecution);
                                    } else
                                        continue;
                                }
                            } else if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)) {
                                COExecution coExecution = new COExecution();
                                if(!result.noloop) {
                                    if(result.time>0) {
                                        --result.time;
                                        if(result.time==0)
                                            result.noloop=true;
                                    }
                                    coExecution.parentid=this.parentid;
                                    coExecution.id=this.id;
                                    coExecution.change=result.change;
                                    coExecution.changetype=result.changetype;
                                    coExecution.changevalue=result.changevalue;
                                    coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                    coExecution.region=this.results[result.changename].ToString();
                                    coExecution.time=result.times;
                                    coExecution.ctime=coExecution.time;
                                    this.Eventsexe.Add(coExecution);
                                } else
                                    continue;
                            }
                        }
                        if(result.opreator=="=") {
                            if(result.opreator2==">") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        COExecution coExecution = new COExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            coExecution.parentid=this.parentid;
                                            coExecution.id=this.id;
                                            coExecution.change=result.change;
                                            coExecution.changetype=result.changetype;
                                            coExecution.changevalue=result.changevalue;
                                            coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            coExecution.region=this.results[result.changename].ToString();
                                            coExecution.time=result.times;
                                            coExecution.ctime=coExecution.time;
                                            this.Eventsexe.Add(coExecution);
                                        } else
                                            continue;
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    COExecution coExecution = new COExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        coExecution.parentid=this.parentid;
                                        coExecution.id=this.id;
                                        coExecution.change=result.change;
                                        coExecution.changetype=result.changetype;
                                        coExecution.changevalue=result.changevalue;
                                        coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        coExecution.region=this.results[result.changename].ToString();
                                        coExecution.time=result.times;
                                        coExecution.ctime=coExecution.time;
                                        this.Eventsexe.Add(coExecution);
                                    } else
                                        continue;
                                }
                            } else if(result.opreator2=="=") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        COExecution coExecution = new COExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            coExecution.parentid=this.parentid;
                                            coExecution.id=this.id;
                                            coExecution.change=result.change;
                                            coExecution.changetype=result.changetype;
                                            coExecution.changevalue=result.changevalue;
                                            coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            coExecution.region=this.results[result.changename].ToString();
                                            coExecution.time=result.times;
                                            coExecution.ctime=coExecution.time;
                                            this.Eventsexe.Add(coExecution);
                                        } else
                                            continue;
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    COExecution coExecution = new COExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        coExecution.parentid=this.parentid;
                                        coExecution.id=this.id;
                                        coExecution.change=result.change;
                                        coExecution.changetype=result.changetype;
                                        coExecution.changevalue=result.changevalue;
                                        coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        coExecution.region=this.results[result.changename].ToString();
                                        coExecution.time=result.times;
                                        coExecution.ctime=coExecution.time;
                                        this.Eventsexe.Add(coExecution);
                                    } else
                                        continue;
                                }
                            } else if(result.opreator2=="<") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        COExecution coExecution = new COExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            coExecution.parentid=this.parentid;
                                            coExecution.id=this.id;
                                            coExecution.change=result.change;
                                            coExecution.changetype=result.changetype;
                                            coExecution.changevalue=result.changevalue;
                                            coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            coExecution.region=this.results[result.changename].ToString();
                                            coExecution.time=result.times;
                                            coExecution.ctime=coExecution.time;
                                            this.Eventsexe.Add(coExecution);
                                        } else
                                            continue;
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    COExecution coExecution = new COExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        coExecution.parentid=this.parentid;
                                        coExecution.id=this.id;
                                        coExecution.change=result.change;
                                        coExecution.changetype=result.changetype;
                                        coExecution.changevalue=result.changevalue;
                                        coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        coExecution.region=this.results[result.changename].ToString();
                                        coExecution.time=result.times;
                                        coExecution.ctime=coExecution.time;
                                        this.Eventsexe.Add(coExecution);
                                    } else
                                        continue;
                                }
                            } else if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)) {
                                COExecution coExecution = new COExecution();
                                if(!result.noloop) {
                                    if(result.time>0) {
                                        --result.time;
                                        if(result.time==0)
                                            result.noloop=true;
                                    }
                                    coExecution.parentid=this.parentid;
                                    coExecution.id=this.id;
                                    coExecution.change=result.change;
                                    coExecution.changetype=result.changetype;
                                    coExecution.changevalue=result.changevalue;
                                    coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                    coExecution.region=this.results[result.changename].ToString();
                                    coExecution.time=result.times;
                                    coExecution.ctime=coExecution.time;
                                    this.Eventsexe.Add(coExecution);
                                } else
                                    continue;
                            }
                        }
                        if(result.opreator=="<") {
                            if(result.opreator2==">") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        COExecution coExecution = new COExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            coExecution.parentid=this.parentid;
                                            coExecution.id=this.id;
                                            coExecution.change=result.change;
                                            coExecution.changetype=result.changetype;
                                            coExecution.changevalue=result.changevalue;
                                            coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            coExecution.region=this.results[result.changename].ToString();
                                            coExecution.time=result.times;
                                            coExecution.ctime=coExecution.time;
                                            this.Eventsexe.Add(coExecution);
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    COExecution coExecution = new COExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        coExecution.parentid=this.parentid;
                                        coExecution.id=this.id;
                                        coExecution.change=result.change;
                                        coExecution.changetype=result.changetype;
                                        coExecution.changevalue=result.changevalue;
                                        coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        coExecution.region=this.results[result.changename].ToString();
                                        coExecution.time=result.times;
                                        coExecution.ctime=coExecution.time;
                                        this.Eventsexe.Add(coExecution);
                                    }
                                }
                            } else if(result.opreator2=="=") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        COExecution coExecution = new COExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            coExecution.parentid=this.parentid;
                                            coExecution.id=this.id;
                                            coExecution.change=result.change;
                                            coExecution.changetype=result.changetype;
                                            coExecution.changevalue=result.changevalue;
                                            coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            coExecution.region=this.results[result.changename].ToString();
                                            coExecution.time=result.times;
                                            coExecution.ctime=coExecution.time;
                                            this.Eventsexe.Add(coExecution);
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    COExecution coExecution = new COExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        coExecution.parentid=this.parentid;
                                        coExecution.id=this.id;
                                        coExecution.change=result.change;
                                        coExecution.changetype=result.changetype;
                                        coExecution.changevalue=result.changevalue;
                                        coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        coExecution.region=this.results[result.changename].ToString();
                                        coExecution.time=result.times;
                                        coExecution.ctime=coExecution.time;
                                        this.Eventsexe.Add(coExecution);
                                    }
                                }
                            } else if(result.opreator2=="<") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        COExecution coExecution = new COExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            coExecution.parentid=this.parentid;
                                            coExecution.id=this.id;
                                            coExecution.change=result.change;
                                            coExecution.changetype=result.changetype;
                                            coExecution.changevalue=result.changevalue;
                                            coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            coExecution.region=this.results[result.changename].ToString();
                                            coExecution.time=result.times;
                                            coExecution.ctime=coExecution.time;
                                            this.Eventsexe.Add(coExecution);
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    COExecution coExecution = new COExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        coExecution.parentid=this.parentid;
                                        coExecution.id=this.id;
                                        coExecution.change=result.change;
                                        coExecution.changetype=result.changetype;
                                        coExecution.changevalue=result.changevalue;
                                        coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        coExecution.region=this.results[result.changename].ToString();
                                        coExecution.time=result.times;
                                        coExecution.ctime=coExecution.time;
                                        this.Eventsexe.Add(coExecution);
                                    }
                                }
                            } else if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)) {
                                COExecution coExecution = new COExecution();
                                if(!result.noloop) {
                                    if(result.time>0) {
                                        --result.time;
                                        if(result.time==0)
                                            result.noloop=true;
                                    }
                                    coExecution.parentid=this.parentid;
                                    coExecution.id=this.id;
                                    coExecution.change=result.change;
                                    coExecution.changetype=result.changetype;
                                    coExecution.changevalue=result.changevalue;
                                    coExecution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                    coExecution.region=this.results[result.changename].ToString();
                                    coExecution.time=result.times;
                                    coExecution.ctime=coExecution.time;
                                    this.Eventsexe.Add(coExecution);
                                }
                            }
                        }
                    }
                }
                for(int index = 0;index<this.Eventsexe.Count;++index) {
                    if(!this.Eventsexe[index].NeedDelete) {
                        this.Eventsexe[index].Update(this);
                    } else {
                        this.Eventsexe.RemoveAt(index);
                        --index;
                    }
                }
            }
            if(this.bindid==-1) {
                foreach(Barrage barrage in Layer.LayerArray[this.parentid].Barrages) {
                    if(((barrage.Cover&!barrage.IsLase ? 1 : 0)&(barrage.time>15 ? 1 : (!barrage.Mist ? 1 : 0))&(!barrage.NeedDelete ? 1 : 0))!=0) {
                        if(this.Circle) {
                            if(this.type==0) {
                                if(Math.Sqrt(((double)this.x-4.0-(double)barrage.x)*((double)this.x-4.0-(double)barrage.x)+((double)this.y+16.0-(double)barrage.y)*((double)this.y+16.0-(double)barrage.y))<=(double)Math.Max(this.halfw,this.halfh)) {
                                    if(!barrage.Covered.Contains(this.id)) {
                                        for(int idx = 0;idx<this.Sonevents.Count;++idx) {
                                            barrage.Events.Add(new Event(idx) {
                                                t=this.Sonevents[idx].t,
                                                addtime=this.Sonevents[idx].addtime,
                                                events=this.Sonevents[idx].events,
                                                results=this.Sonevents[idx].results,
                                                index=this.Sonevents[idx].index,
                                                special=this.id
                                            });
                                            barrage.Covered.Add(this.id);
                                        }
                                    }
                                } else {
                                    if(barrage.Covered.Contains(this.id)) {
                                        for(int index = 0;index<barrage.Events.Count;++index) {
                                            if(barrage.Events[index].special==this.id) {
                                                barrage.Events.RemoveAt(index);
                                                --index;
                                            }
                                        }
                                    }
                                    barrage.Covered.Remove(this.id);
                                }
                            } else if(this.type==1) {
                                if(barrage.parentid==this.controlid-1&Math.Sqrt(((double)this.x-4.0-(double)barrage.x)*((double)this.x-4.0-(double)barrage.x)+((double)this.y+16.0-(double)barrage.y)*((double)this.y+16.0-(double)barrage.y))<=(double)Math.Max(this.halfw,this.halfh)) {
                                    if(!barrage.Covered.Contains(this.id)) {
                                        for(int idx = 0;idx<this.Sonevents.Count;++idx) {
                                            barrage.Events.Add(new Event(idx) {
                                                t=this.Sonevents[idx].t,
                                                addtime=this.Sonevents[idx].addtime,
                                                events=this.Sonevents[idx].events,
                                                results=this.Sonevents[idx].results,
                                                index=this.Sonevents[idx].index,
                                                special=this.id
                                            });
                                            barrage.Covered.Add(this.id);
                                        }
                                    }
                                } else {
                                    if(barrage.Covered.Contains(this.id)) {
                                        for(int index = 0;index<barrage.Events.Count;++index) {
                                            if(barrage.Events[index].special==this.id) {
                                                barrage.Events.RemoveAt(index);
                                                --index;
                                            }
                                        }
                                    }
                                    barrage.Covered.Remove(this.id);
                                }
                            }
                        } else if(this.type==0) {
                            if((double)Math.Abs(this.x-4f-barrage.x)<=(double)this.halfw&(double)Math.Abs(this.y+16f-barrage.y)<=(double)this.halfh) {
                                if(!barrage.Covered.Contains(this.id)) {
                                    for(int idx = 0;idx<this.Sonevents.Count;++idx) {
                                        barrage.Events.Add(new Event(idx) {
                                            t=this.Sonevents[idx].t,
                                            addtime=this.Sonevents[idx].addtime,
                                            events=this.Sonevents[idx].events,
                                            results=this.Sonevents[idx].results,
                                            index=this.Sonevents[idx].index,
                                            special=this.id
                                        });
                                        barrage.Covered.Add(this.id);
                                    }
                                }
                            } else {
                                if(barrage.Covered.Contains(this.id)) {
                                    for(int index = 0;index<barrage.Events.Count;++index) {
                                        if(barrage.Events[index].special==this.id) {
                                            barrage.Events.RemoveAt(index);
                                            --index;
                                        }
                                    }
                                }
                                barrage.Covered.Remove(this.id);
                            }
                        } else if(this.type==1) {
                            if(barrage.parentid==this.controlid-1&(double)Math.Abs(this.x-4f-barrage.x)<=(double)this.halfw&(double)Math.Abs(this.y+16f-barrage.y)<=(double)this.halfh) {
                                if(!barrage.Covered.Contains(this.id)) {
                                    for(int idx = 0;idx<this.Sonevents.Count;++idx) {
                                        barrage.Events.Add(new Event(idx) {
                                            t=this.Sonevents[idx].t,
                                            addtime=this.Sonevents[idx].addtime,
                                            events=this.Sonevents[idx].events,
                                            results=this.Sonevents[idx].results,
                                            index=this.Sonevents[idx].index,
                                            special=this.id
                                        });
                                        barrage.Covered.Add(this.id);
                                    }
                                }
                            } else {
                                if(barrage.Covered.Contains(this.id)) {
                                    for(int index = 0;index<barrage.Events.Count;++index) {
                                        if(barrage.Events[index].special==this.id) {
                                            barrage.Events.RemoveAt(index);
                                            --index;
                                        }
                                    }
                                }
                                barrage.Covered.Remove(this.id);
                            }
                        }
                    }
                }
            } else {
                int num1 = 1000;
                int num2 = 0;
                foreach(Barrage barrage1 in Layer.LayerArray[this.parentid].Barrages) {
                    if(!barrage1.IsLase&barrage1.parentid==this.bindid&!barrage1.NeedDelete) {
                        if(this.Deepbind) {
                            if(barrage1.cover!=null) {
                                barrage1.cover.x=barrage1.x;
                                barrage1.cover.y=barrage1.y;
                                barrage1.cover.Update();
                            } else {
                                barrage1.cover=this.BindClone();
                                barrage1.cover.id=this.childid;
                                barrage1.cover.Deepbind=false;
                                barrage1.cover.Deepbinded=true;
                                barrage1.cover.bindid=-1;
                            }
                        } else if(barrage1.time>=15||!barrage1.Mist) {
                            foreach(Barrage barrage2 in Layer.LayerArray[this.parentid].Barrages) {
                                if(((barrage2.id!=barrage1.id&barrage2.Cover&!barrage2.IsLase ? 1 : 0)&(barrage2.time>15 ? 1 : (!barrage2.Mist ? 1 : 0))&(!barrage2.NeedDelete ? 1 : 0))!=0) {
                                    if(this.Circle) {
                                        if(this.type==0) {
                                            if(Math.Sqrt(((double)barrage1.x-(double)barrage2.x)*((double)barrage1.x-(double)barrage2.x)+((double)barrage1.y-(double)barrage2.y)*((double)barrage1.y-(double)barrage2.y))<=(double)Math.Max(this.halfw,this.halfh)) {
                                                if(!barrage2.Covered.Contains(num1)) {
                                                    for(int idx = 0;idx<this.Sonevents.Count;++idx) {
                                                        barrage2.Events.Add(new Event(idx) {
                                                            t=this.Sonevents[idx].t,
                                                            addtime=this.Sonevents[idx].addtime,
                                                            events=this.Sonevents[idx].events,
                                                            results=this.Sonevents[idx].results,
                                                            index=this.Sonevents[idx].index,
                                                            special=barrage2.id
                                                        });
                                                        barrage2.Covered.Add(num1);
                                                        ++num2;
                                                    }
                                                }
                                            } else {
                                                if(barrage2.Covered.Contains(num1)) {
                                                    for(int index = 0;index<barrage2.Events.Count;++index) {
                                                        if(barrage2.Events[index].special==barrage2.id) {
                                                            barrage2.Events.RemoveAt(index);
                                                            --index;
                                                        }
                                                    }
                                                }
                                                barrage2.Covered.Remove(num1);
                                            }
                                        } else if(this.type==1) {
                                            if(barrage2.parentid==this.controlid-1&Math.Sqrt(((double)barrage1.x-(double)barrage2.x)*((double)barrage1.x-(double)barrage2.x)+((double)barrage1.y-(double)barrage2.y)*((double)barrage1.y-(double)barrage2.y))<=(double)Math.Max(this.halfw,this.halfh)) {
                                                if(!barrage2.Covered.Contains(num1)) {
                                                    for(int idx = 0;idx<this.Sonevents.Count;++idx) {
                                                        barrage2.Events.Add(new Event(idx) {
                                                            t=this.Sonevents[idx].t,
                                                            addtime=this.Sonevents[idx].addtime,
                                                            events=this.Sonevents[idx].events,
                                                            results=this.Sonevents[idx].results,
                                                            index=this.Sonevents[idx].index,
                                                            special=barrage2.id
                                                        });
                                                        barrage2.Covered.Add(num1);
                                                    }
                                                }
                                            } else {
                                                if(barrage2.Covered.Contains(num1)) {
                                                    for(int index = 0;index<barrage2.Events.Count;++index) {
                                                        if(barrage2.Events[index].special==barrage2.id) {
                                                            barrage2.Events.RemoveAt(index);
                                                            --index;
                                                        }
                                                    }
                                                }
                                                barrage2.Covered.Remove(num1);
                                            }
                                        }
                                    } else if(this.type==0) {
                                        if((double)Math.Abs(barrage1.x-barrage2.x)<=(double)this.halfw&(double)Math.Abs(barrage1.y-barrage2.y)<=(double)this.halfh) {
                                            if(!barrage2.Covered.Contains(num1)) {
                                                for(int idx = 0;idx<this.Sonevents.Count;++idx) {
                                                    barrage2.Events.Add(new Event(idx) {
                                                        t=this.Sonevents[idx].t,
                                                        addtime=this.Sonevents[idx].addtime,
                                                        events=this.Sonevents[idx].events,
                                                        results=this.Sonevents[idx].results,
                                                        index=this.Sonevents[idx].index,
                                                        special=barrage2.id
                                                    });
                                                    barrage2.Covered.Add(num1);
                                                }
                                            }
                                        } else {
                                            if(barrage2.Covered.Contains(num1)) {
                                                for(int index = 0;index<barrage2.Events.Count;++index) {
                                                    if(barrage2.Events[index].special==barrage2.id) {
                                                        barrage2.Events.RemoveAt(index);
                                                        --index;
                                                    }
                                                }
                                            }
                                            barrage2.Covered.Remove(num1);
                                        }
                                    } else if(this.type==1) {
                                        if(barrage2.parentid==this.controlid-1&(double)Math.Abs(barrage1.x-barrage2.x)<=(double)this.halfw&(double)Math.Abs(barrage1.y-barrage2.y)<=(double)this.halfh) {
                                            if(!barrage2.Covered.Contains(num1)) {
                                                for(int idx = 0;idx<this.Sonevents.Count;++idx) {
                                                    barrage2.Events.Add(new Event(idx) {
                                                        t=this.Sonevents[idx].t,
                                                        addtime=this.Sonevents[idx].addtime,
                                                        events=this.Sonevents[idx].events,
                                                        results=this.Sonevents[idx].results,
                                                        index=this.Sonevents[idx].index,
                                                        special=barrage2.id
                                                    });
                                                    barrage2.Covered.Add(num1);
                                                }
                                            }
                                        } else {
                                            if(barrage2.Covered.Contains(num1)) {
                                                for(int index = 0;index<barrage2.Events.Count;++index) {
                                                    if(barrage2.Events[index].special==barrage2.id) {
                                                        barrage2.Events.RemoveAt(index);
                                                        --index;
                                                    }
                                                }
                                            }
                                            barrage2.Covered.Remove(num1);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    ++num1;
                    ++this.childid;
                }
            }
        }

        public Cover BindClone() {
            Cover cover = this.Copy() as Cover;
            cover.Parentevents=new List<Event>();
            foreach(Event parentevent in this.Parentevents)
                cover.Parentevents.Add((Event)parentevent.Clone());
            cover.Eventsexe=new List<COExecution>();
            foreach(COExecution coExecution in this.Eventsexe)
                cover.Eventsexe.Add((COExecution)coExecution.Clone());
            cover.Sonevents=new List<Event>();
            foreach(Event sonevent in this.Sonevents)
                cover.Sonevents.Add((Event)sonevent.Clone());
            return cover;
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
