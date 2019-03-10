using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CrazyStorm_1._03 {
    [Serializable]
    public class Batch {
        public int bindid = -1;
        private float[] conditions = new float[13];
        private float[] results = new float[33];
        private int clcount;
        private int clwait;
        public int Searched;
        public bool NeedDelete;
        public int id;
        public int parentid;
        public int parentcolor;
        public bool Binding;
        public bool Bindwithspeedd;
        public bool Deepbind;
        public bool Deepbinded;
        public float x;
        public float y;
        public int time;
        public int begin;
        public int life;
        public float fx;
        public float fy;
        public float r;
        public float rdirection;
        public Vector2 rdirections;
        public int tiao;
        public int t;
        public float fdirection;
        public float bfdirection;
        public Vector2 fdirections;
        public int range;
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
        public int sonlife;
        public float type;
        public float wscale;
        public float hscale;
        public float colorR;
        public float colorG;
        public float colorB;
        public float alpha;
        public float head;
        public Vector2 heads;
        public bool Withspeedd;
        public float sonspeed;
        public float sonspeedd;
        public Vector2 sonspeedds;
        public float sonaspeed;
        public float sonaspeedd;
        public float bsonaspeedd;
        public Vector2 sonaspeedds;
        public float xscale;
        public float yscale;
        public bool Mist;
        public bool Dispel;
        public bool Blend;
        public bool Afterimage;
        public bool Outdispel;
        public bool Invincible;
        public bool Cover;
        public bool Rebound;
        public bool Force;
        public Batch rand;
        public List<Event> Parentevents;
        public List<Execution> Eventsexe;
        public List<Event> Sonevents;
        public Batch copys;

        public Batch() {
        }

        public Batch(float xs,float ys,int pc) {
            rand=new Batch();
            rdirections=new Vector2();
            fdirections=new Vector2();
            speedds=new Vector2();
            aspeedds=new Vector2();
            heads=new Vector2();
            sonspeedds=new Vector2();
            sonaspeedds=new Vector2();
            Parentevents=new List<Event>();
            Sonevents=new List<Event>();
            Eventsexe=new List<Execution>();
            x=xs;
            y=ys;
            parentcolor=pc;
            begin=Layer.LayerArray[parentid].begin;
            life=Layer.LayerArray[parentid].end-Layer.LayerArray[parentid].begin+1;
            fx=-99998f;
            fy=-99998f;
            r=0.0f;
            rdirection=0.0f;
            tiao=1;
            t=5;
            fdirection=0.0f;
            range=360;
            speed=0.0f;
            speedd=0.0f;
            aspeed=0.0f;
            aspeedd=0.0f;
            sonlife=200;
            type=1f;
            wscale=1f;
            hscale=1f;
            colorR=byte.MaxValue;
            colorG=byte.MaxValue;
            colorB=byte.MaxValue;
            alpha=100f;
            head=0.0f;
            Withspeedd=true;
            sonspeed=5f;
            sonspeedd=0.0f;
            sonaspeed=0.0f;
            sonaspeedd=0.0f;
            xscale=1f;
            yscale=1f;
            Mist=true;
            Dispel=true;
            Blend=false;
            Afterimage=false;
            Outdispel=true;
            Invincible=false;
            Cover=true;
            Rebound=true;
            Force=true;
        }

        public void Update() {
            if(clcount==1) {
                ++clwait;
                if(clwait>15) {
                    clwait=0;
                    clcount=0;
                }
            }
            if(!Time.Playing) {
                aspeedx=aspeed*(float)Math.Cos(MathHelper.ToRadians(aspeedd));
                aspeedy=aspeed*(float)Math.Sin(MathHelper.ToRadians(aspeedd));
                speedx=speed*(float)Math.Cos(MathHelper.ToRadians(speedd));
                speedy=speed*(float)Math.Sin(MathHelper.ToRadians(speedd));
                begin=(int)MathHelper.Clamp(begin,Layer.LayerArray[parentid].begin,1+Layer.LayerArray[parentid].end-Layer.LayerArray[parentid].begin);
                life=(int)MathHelper.Clamp(life,1f,Layer.LayerArray[parentid].end-Layer.LayerArray[parentid].begin+2-begin);
            }
            if(bindid==id) {
                bindid=-1;
                Deepbind=false;
                Bindwithspeedd=false;
            }
            if(bindid!=-1&&bindid>=Layer.LayerArray[parentid].BatchArray.Count) {
                bindid=-1;
                Deepbind=false;
                Bindwithspeedd=false;
            }
            if(!Time.Playing)
                return;
            if(Deepbinded)
                ++time;
            if(!(!Deepbinded&Time.now>=begin&Time.now<=begin+life-1)&&!(Deepbinded&time>=begin&time<=begin+life-1)&&!Deepbind) {
                return;
            }

            if(!Deepbind&!Deepbinded)
                time=Time.now-begin+1;
            if(!Deepbind) {
                speedx+=aspeedx;
                speedy+=aspeedy;
                x+=speedx;
                y+=speedy;
                this.fx+=this.speedx;
                this.fy+=this.speedy;
                this.conditions[0]=!this.Deepbinded ? (float)this.time : (float)(this.time-this.begin+1);
                this.conditions[1]=this.fx;
                this.conditions[2]=this.fy;
                this.conditions[3]=this.r;
                this.conditions[4]=this.rdirection;
                this.conditions[5]=(float)this.tiao;
                this.conditions[6]=(float)this.t;
                this.conditions[7]=this.fdirection;
                this.conditions[8]=(float)this.range;
                this.conditions[9]=this.wscale;
                this.conditions[10]=this.hscale;
                this.conditions[11]=this.alpha;
                this.conditions[12]=this.head;
                this.results[0]=this.fx;
                this.results[1]=this.fy;
                this.results[2]=this.r;
                this.results[3]=this.rdirection;
                this.results[4]=(float)this.tiao;
                this.results[5]=(float)this.t;
                this.results[6]=this.fdirection;
                this.results[7]=(float)this.range;
                this.results[8]=this.speed;
                this.results[9]=this.speedd;
                this.results[10]=this.aspeed;
                this.results[11]=this.aspeedd;
                this.results[12]=(float)this.life;
                this.results[13]=this.type;
                this.results[14]=this.wscale;
                this.results[15]=this.hscale;
                this.results[16]=this.colorR;
                this.results[17]=this.colorG;
                this.results[18]=this.colorB;
                this.results[19]=this.alpha;
                this.results[20]=this.head;
                this.results[21]=this.sonspeed;
                this.results[22]=this.sonspeedd;
                this.results[23]=this.sonaspeed;
                this.results[24]=this.sonaspeedd;
                this.results[25]=this.xscale;
                this.results[26]=this.yscale;
                this.results[27]=0.0f;
                this.results[28]=0.0f;
                this.results[29]=0.0f;
                this.results[30]=0.0f;
                this.results[31]=0.0f;
                this.results[32]=0.0f;
                foreach(Event parentevent in this.Parentevents) {
                    if(parentevent.t<=0)
                        parentevent.t=1;
                    if(this.time%parentevent.t==0)
                        ++parentevent.loop;
                    foreach(EventRead result in parentevent.results) {
                        if(result.special==3) {
                            if(result.changevalue==0)
                                result.res=this.x-4f;
                            if(result.changevalue==1)
                                result.res=this.y+16f;
                            if(result.changevalue==6)
                                result.res=MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,this.fx,this.fy));
                            if(result.changevalue==24)
                                result.res=MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,this.fx,this.fy));
                        }
                        if(result.special==4) {
                            if(result.changevalue==0)
                                result.res=Player.position.X;
                            if(result.changevalue==1)
                                result.res=Player.position.Y;
                            if(result.changevalue==3)
                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.fx,this.fy));
                            if(result.changevalue==6)
                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.fx,this.fy));
                            if(result.changevalue==9)
                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.fx,this.fy));
                            if(result.changevalue==11)
                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.fx,this.fy));
                            if(result.changevalue==24)
                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.fx,this.fy));
                        }
                        if(result.opreator==">") {
                            if(result.opreator2==">") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        if(result.special==1)
                                            this.Recover();
                                        else if(result.special==2) {
                                            this.Shoot();
                                        } else {
                                            Execution execution = new Execution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                execution.parentid=this.parentid;
                                                execution.id=this.id;
                                                execution.change=result.change;
                                                execution.changetype=result.changetype;
                                                execution.changevalue=result.changevalue;
                                                execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                execution.region=this.results[result.changename].ToString();
                                                execution.time=result.times;
                                                execution.ctime=execution.time;
                                                this.Eventsexe.Add(execution);
                                            } else
                                                continue;
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    if(result.special==1)
                                        this.Recover();
                                    else if(result.special==2) {
                                        this.Shoot();
                                    } else {
                                        Execution execution = new Execution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            execution.parentid=this.parentid;
                                            execution.id=this.id;
                                            execution.change=result.change;
                                            execution.changetype=result.changetype;
                                            execution.changevalue=result.changevalue;
                                            execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            execution.region=this.results[result.changename].ToString();
                                            execution.time=result.times;
                                            execution.ctime=execution.time;
                                            this.Eventsexe.Add(execution);
                                        } else
                                            continue;
                                    }
                                }
                            } else if(result.opreator2=="=") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        if(result.special==1)
                                            this.Recover();
                                        else if(result.special==2) {
                                            this.Shoot();
                                        } else {
                                            Execution execution = new Execution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                execution.parentid=this.parentid;
                                                execution.id=this.id;
                                                execution.change=result.change;
                                                execution.changetype=result.changetype;
                                                execution.changevalue=result.changevalue;
                                                execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                execution.region=this.results[result.changename].ToString();
                                                execution.time=result.times;
                                                execution.ctime=execution.time;
                                                this.Eventsexe.Add(execution);
                                            } else
                                                continue;
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    if(result.special==1)
                                        this.Recover();
                                    else if(result.special==2) {
                                        this.Shoot();
                                    } else {
                                        Execution execution = new Execution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            execution.parentid=this.parentid;
                                            execution.id=this.id;
                                            execution.change=result.change;
                                            execution.changetype=result.changetype;
                                            execution.changevalue=result.changevalue;
                                            execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            execution.region=this.results[result.changename].ToString();
                                            execution.time=result.times;
                                            execution.ctime=execution.time;
                                            this.Eventsexe.Add(execution);
                                        } else
                                            continue;
                                    }
                                }
                            } else if(result.opreator2=="<") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        if(result.special==1)
                                            this.Recover();
                                        else if(result.special==2) {
                                            this.Shoot();
                                        } else {
                                            Execution execution = new Execution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                execution.parentid=this.parentid;
                                                execution.id=this.id;
                                                execution.change=result.change;
                                                execution.changetype=result.changetype;
                                                execution.changevalue=result.changevalue;
                                                execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                execution.region=this.results[result.changename].ToString();
                                                execution.time=result.times;
                                                execution.ctime=execution.time;
                                                this.Eventsexe.Add(execution);
                                            } else
                                                continue;
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    if(result.special==1)
                                        this.Recover();
                                    else if(result.special==2) {
                                        this.Shoot();
                                    } else {
                                        Execution execution = new Execution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            execution.parentid=this.parentid;
                                            execution.id=this.id;
                                            execution.change=result.change;
                                            execution.changetype=result.changetype;
                                            execution.changevalue=result.changevalue;
                                            execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            execution.region=this.results[result.changename].ToString();
                                            execution.time=result.times;
                                            execution.ctime=execution.time;
                                            this.Eventsexe.Add(execution);
                                        } else
                                            continue;
                                    }
                                }
                            } else if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)) {
                                if(result.special==1)
                                    this.Recover();
                                else if(result.special==2) {
                                    this.Shoot();
                                } else {
                                    Execution execution = new Execution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        execution.parentid=this.parentid;
                                        execution.id=this.id;
                                        execution.change=result.change;
                                        execution.changetype=result.changetype;
                                        execution.changevalue=result.changevalue;
                                        execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        execution.region=this.results[result.changename].ToString();
                                        execution.time=result.times;
                                        execution.ctime=execution.time;
                                        this.Eventsexe.Add(execution);
                                    } else
                                        continue;
                                }
                            }
                        }
                        if(result.opreator=="=") {
                            if(result.opreator2==">") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        if(result.special==1)
                                            this.Recover();
                                        else if(result.special==2) {
                                            this.Shoot();
                                        } else {
                                            Execution execution = new Execution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                execution.parentid=this.parentid;
                                                execution.id=this.id;
                                                execution.change=result.change;
                                                execution.changetype=result.changetype;
                                                execution.changevalue=result.changevalue;
                                                execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                execution.region=this.results[result.changename].ToString();
                                                execution.time=result.times;
                                                execution.ctime=execution.time;
                                                this.Eventsexe.Add(execution);
                                            } else
                                                continue;
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    if(result.special==1)
                                        this.Recover();
                                    else if(result.special==2) {
                                        this.Shoot();
                                    } else {
                                        Execution execution = new Execution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            execution.parentid=this.parentid;
                                            execution.id=this.id;
                                            execution.change=result.change;
                                            execution.changetype=result.changetype;
                                            execution.changevalue=result.changevalue;
                                            execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            execution.region=this.results[result.changename].ToString();
                                            execution.time=result.times;
                                            execution.ctime=execution.time;
                                            this.Eventsexe.Add(execution);
                                        } else
                                            continue;
                                    }
                                }
                            } else if(result.opreator2=="=") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        if(result.special==1)
                                            this.Recover();
                                        else if(result.special==2) {
                                            this.Shoot();
                                        } else {
                                            Execution execution = new Execution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                execution.parentid=this.parentid;
                                                execution.id=this.id;
                                                execution.change=result.change;
                                                execution.changetype=result.changetype;
                                                execution.changevalue=result.changevalue;
                                                execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                execution.region=this.results[result.changename].ToString();
                                                execution.time=result.times;
                                                execution.ctime=execution.time;
                                                this.Eventsexe.Add(execution);
                                            } else
                                                continue;
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    if(result.special==1)
                                        this.Recover();
                                    else if(result.special==2) {
                                        this.Shoot();
                                    } else {
                                        Execution execution = new Execution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            execution.parentid=this.parentid;
                                            execution.id=this.id;
                                            execution.change=result.change;
                                            execution.changetype=result.changetype;
                                            execution.changevalue=result.changevalue;
                                            execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            execution.region=this.results[result.changename].ToString();
                                            execution.time=result.times;
                                            execution.ctime=execution.time;
                                            this.Eventsexe.Add(execution);
                                        } else
                                            continue;
                                    }
                                }
                            } else if(result.opreator2=="<") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        if(result.special==1)
                                            this.Recover();
                                        else if(result.special==2) {
                                            this.Shoot();
                                        } else {
                                            Execution execution = new Execution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                execution.parentid=this.parentid;
                                                execution.id=this.id;
                                                execution.change=result.change;
                                                execution.changetype=result.changetype;
                                                execution.changevalue=result.changevalue;
                                                execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                execution.region=this.results[result.changename].ToString();
                                                execution.time=result.times;
                                                execution.ctime=execution.time;
                                                this.Eventsexe.Add(execution);
                                            } else
                                                continue;
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    if(result.special==1)
                                        this.Recover();
                                    else if(result.special==2) {
                                        this.Shoot();
                                    } else {
                                        Execution execution = new Execution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            execution.parentid=this.parentid;
                                            execution.id=this.id;
                                            execution.change=result.change;
                                            execution.changetype=result.changetype;
                                            execution.changevalue=result.changevalue;
                                            execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            execution.region=this.results[result.changename].ToString();
                                            execution.time=result.times;
                                            execution.ctime=execution.time;
                                            this.Eventsexe.Add(execution);
                                        } else
                                            continue;
                                    }
                                }
                            } else if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)) {
                                if(result.special==1)
                                    this.Recover();
                                else if(result.special==2) {
                                    this.Shoot();
                                } else {
                                    Execution execution = new Execution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        execution.parentid=this.parentid;
                                        execution.id=this.id;
                                        execution.change=result.change;
                                        execution.changetype=result.changetype;
                                        execution.changevalue=result.changevalue;
                                        execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        execution.region=this.results[result.changename].ToString();
                                        execution.time=result.times;
                                        execution.ctime=execution.time;
                                        this.Eventsexe.Add(execution);
                                    } else
                                        continue;
                                }
                            }
                        }
                        if(result.opreator=="<") {
                            if(result.opreator2==">") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        if(result.special==1)
                                            this.Recover();
                                        else if(result.special==2) {
                                            this.Shoot();
                                        } else {
                                            Execution execution = new Execution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                execution.parentid=this.parentid;
                                                execution.id=this.id;
                                                execution.change=result.change;
                                                execution.changetype=result.changetype;
                                                execution.changevalue=result.changevalue;
                                                execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                execution.region=this.results[result.changename].ToString();
                                                execution.time=result.times;
                                                execution.ctime=execution.time;
                                                this.Eventsexe.Add(execution);
                                            }
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    if(result.special==1)
                                        this.Recover();
                                    else if(result.special==2) {
                                        this.Shoot();
                                    } else {
                                        Execution execution = new Execution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            execution.parentid=this.parentid;
                                            execution.id=this.id;
                                            execution.change=result.change;
                                            execution.changetype=result.changetype;
                                            execution.changevalue=result.changevalue;
                                            execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            execution.region=this.results[result.changename].ToString();
                                            execution.time=result.times;
                                            execution.ctime=execution.time;
                                            this.Eventsexe.Add(execution);
                                        }
                                    }
                                }
                            } else if(result.opreator2=="=") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        if(result.special==1)
                                            this.Recover();
                                        else if(result.special==2) {
                                            this.Shoot();
                                        } else {
                                            Execution execution = new Execution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                execution.parentid=this.parentid;
                                                execution.id=this.id;
                                                execution.change=result.change;
                                                execution.changetype=result.changetype;
                                                execution.changevalue=result.changevalue;
                                                execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                execution.region=this.results[result.changename].ToString();
                                                execution.time=result.times;
                                                execution.ctime=execution.time;
                                                this.Eventsexe.Add(execution);
                                            }
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    if(result.special==1)
                                        this.Recover();
                                    else if(result.special==2) {
                                        this.Shoot();
                                    } else {
                                        Execution execution = new Execution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            execution.parentid=this.parentid;
                                            execution.id=this.id;
                                            execution.change=result.change;
                                            execution.changetype=result.changetype;
                                            execution.changevalue=result.changevalue;
                                            execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            execution.region=this.results[result.changename].ToString();
                                            execution.time=result.times;
                                            execution.ctime=execution.time;
                                            this.Eventsexe.Add(execution);
                                        }
                                    }
                                }
                            } else if(result.opreator2=="<") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        if(result.special==1)
                                            this.Recover();
                                        else if(result.special==2) {
                                            this.Shoot();
                                        } else {
                                            Execution execution = new Execution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                execution.parentid=this.parentid;
                                                execution.id=this.id;
                                                execution.change=result.change;
                                                execution.changetype=result.changetype;
                                                execution.changevalue=result.changevalue;
                                                execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                execution.region=this.results[result.changename].ToString();
                                                execution.time=result.times;
                                                execution.ctime=execution.time;
                                                this.Eventsexe.Add(execution);
                                            }
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    if(result.special==1)
                                        this.Recover();
                                    else if(result.special==2) {
                                        this.Shoot();
                                    } else {
                                        Execution execution = new Execution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            execution.parentid=this.parentid;
                                            execution.id=this.id;
                                            execution.change=result.change;
                                            execution.changetype=result.changetype;
                                            execution.changevalue=result.changevalue;
                                            execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            execution.region=this.results[result.changename].ToString();
                                            execution.time=result.times;
                                            execution.ctime=execution.time;
                                            this.Eventsexe.Add(execution);
                                        }
                                    }
                                }
                            } else if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)) {
                                if(result.special==1)
                                    this.Recover();
                                else if(result.special==2) {
                                    this.Shoot();
                                } else {
                                    Execution execution = new Execution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        execution.parentid=this.parentid;
                                        execution.id=this.id;
                                        execution.change=result.change;
                                        execution.changetype=result.changetype;
                                        execution.changevalue=result.changevalue;
                                        execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        execution.region=this.results[result.changename].ToString();
                                        execution.time=result.times;
                                        execution.ctime=execution.time;
                                        this.Eventsexe.Add(execution);
                                    }
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
            if(this.t<=0)
                return;
            if(this.Deepbind) {
                this.Shoot();
            } else {
                if(this.time%this.t+(int)MathHelper.Lerp((float)-this.rand.t,(float)this.rand.t,(float)Main.rand.NextDouble())!=0)
                    return;
                this.Shoot();
            }
        }

        private void Shoot() {
            int num1 = this.tiao+(int)MathHelper.Lerp((float)-this.rand.tiao,(float)this.rand.tiao,(float)Main.rand.NextDouble());
            float num2 = (float)(int)MathHelper.Lerp(-this.rand.fx,this.rand.fx,(float)Main.rand.NextDouble());
            float num3 = (float)(int)MathHelper.Lerp(-this.rand.fy,this.rand.fy,(float)Main.rand.NextDouble());
            int num4 = (int)MathHelper.Lerp(-this.rand.r,this.rand.r,(float)Main.rand.NextDouble());
            float num5 = MathHelper.Lerp(-this.rand.rdirection,this.rand.rdirection,(float)Main.rand.NextDouble());
            float num6 = (float)(int)MathHelper.Lerp(-this.rand.head,this.rand.head,(float)Main.rand.NextDouble());
            int num7 = (int)MathHelper.Lerp((float)-this.rand.range,(float)this.rand.range,(float)Main.rand.NextDouble());
            float num8 = MathHelper.Lerp(-this.rand.sonspeed,this.rand.sonspeed,(float)Main.rand.NextDouble());
            float num9 = MathHelper.Lerp(-this.rand.fdirection,this.rand.fdirection,(float)Main.rand.NextDouble());
            float num10 = MathHelper.Lerp(-this.rand.sonaspeed,this.rand.sonaspeed,(float)Main.rand.NextDouble());
            float num11 = MathHelper.Lerp(-this.rand.sonaspeedd,this.rand.sonaspeedd,(float)Main.rand.NextDouble());
            float val1 = MathHelper.Lerp(-this.rand.wscale,this.rand.wscale,(float)Main.rand.NextDouble());
            float val2 = MathHelper.Lerp(-this.rand.hscale,this.rand.hscale,(float)Main.rand.NextDouble());
            if(this.bindid==-1) {
                for(int index1 = 0;index1<num1;++index1) {
                    if(Layer.LayerArray[parentid].BatchArray[id].rdirection==-99999.0) {
                        rdirection=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,fx,fy));
                    }

                    float degrees = rdirection+(index1-(float)((num1-1.0)/2.0))*(range+num7)/num1+num5;
                    Barrage barrage = new Barrage {
                        x=fx+(float)((r+(double)num4)*Math.Cos(MathHelper.ToRadians(degrees)))+num2+Center.ox-Center.x,
                        y=fy+(float)((r+(double)num4)*Math.Sin(MathHelper.ToRadians(degrees)))+num3+Center.oy-Center.y,
                        life=sonlife,
                        type=(int)type-1,
                        wscale=wscale+Math.Max(val1,val2),
                        hscale=hscale+Math.Max(val1,val2),
                        head=head+num6,
                        alpha=alpha,
                        R=colorR,
                        G=colorG,
                        B=colorB,
                        speed=sonspeed+num8,
                        aspeed=this.sonaspeed+num10,
                        fx=this.x-4f,
                        fy=this.y+16f,
                        fdirection=(double)this.bfdirection<-99997.0 ? this.bfdirection : this.fdirection,
                        fdirections=this.fdirections,
                        randfdirection=num9,
                        g=index1,
                        tiaos=num1,
                        range=this.range,
                        randrange=num7,
                        sonaspeedd=(double)this.bsonaspeedd<-99997.0 ? this.bsonaspeedd : this.sonaspeedd,
                        sonaspeedds=this.sonaspeedds,
                        randsonaspeedd=num11,
                        Withspeedd=this.Withspeedd,
                        xscale=this.xscale,
                        yscale=this.yscale,
                        Mist=this.Mist,
                        Dispel=this.Dispel,
                        Blend=this.Blend,
                        Outdispel=this.Outdispel,
                        Afterimage=this.Afterimage,
                        Invincible=this.Invincible,
                        Cover=this.Cover,
                        Rebound=this.Rebound,
                        Force=this.Force
                    };
                    for(int idx = 0;idx<this.Sonevents.Count;++idx) {
                        Event @event = new Event(idx);
                        @event.t=this.Sonevents[idx].t;
                        @event.addtime=this.Sonevents[idx].addtime;
                        @event.events=this.Sonevents[idx].events;
                        for(int index2 = 0;index2<this.Sonevents[idx].results.Count;++index2)
                            @event.results.Add((EventRead)this.Sonevents[idx].results[index2].Copy());
                        @event.index=this.Sonevents[idx].index;
                        barrage.Events.Add(@event);
                    }
                    barrage.parentid=this.id;
                    Layer.LayerArray[this.parentid].Barrages.Add(barrage);
                }
            } else {
                for(int index1 = 0;index1<Layer.LayerArray[this.parentid].Barrages.Count;++index1) {
                    if(((!Layer.LayerArray[this.parentid].Barrages[index1].IsLase&Layer.LayerArray[this.parentid].Barrages[index1].parentid==this.bindid ? 1 : 0)&(Layer.LayerArray[this.parentid].Barrages[index1].time>15 ? 1 : (!Layer.LayerArray[this.parentid].Barrages[index1].Mist ? 1 : 0))&(!Layer.LayerArray[this.parentid].Barrages[index1].NeedDelete ? 1 : 0))!=0) {
                        if(this.Deepbind) {
                            if(Layer.LayerArray[this.parentid].Barrages[index1].batch!=null) {
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.x=Layer.LayerArray[this.parentid].Barrages[index1].x;
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.y=Layer.LayerArray[this.parentid].Barrages[index1].y;
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.fx=Layer.LayerArray[this.parentid].Barrages[index1].x;
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.fy=Layer.LayerArray[this.parentid].Barrages[index1].y;
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.Update();
                            } else {
                                Layer.LayerArray[this.parentid].Barrages[index1].batch=this.BindClone();
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.Deepbind=false;
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.Deepbinded=true;
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.bindid=-1;
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.time=0;
                                if(this.Bindwithspeedd)
                                    Layer.LayerArray[this.parentid].Barrages[index1].batch.fdirection+=Layer.LayerArray[this.parentid].Barrages[index1].fdirection;
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.Bindwithspeedd=false;
                            }
                        } else {
                            for(int index2 = 0;index2<num1;++index2) {
                                Barrage barrage = new Barrage();
                                if((double)Layer.LayerArray[this.parentid].BatchArray[this.id].rdirection==-99999.0)
                                    this.rdirection=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,Layer.LayerArray[this.parentid].Barrages[index1].x,Layer.LayerArray[this.parentid].Barrages[index1].y));
                                float degrees = this.rdirection+((float)index2-(float)(((double)num1-1.0)/2.0))*(float)(this.range+num7)/(float)num1+num5;
                                barrage.x=Layer.LayerArray[this.parentid].Barrages[index1].x+(float)(((double)this.r+(double)num4)*Math.Cos((double)MathHelper.ToRadians(degrees)))+num2;
                                barrage.y=Layer.LayerArray[this.parentid].Barrages[index1].y+(float)(((double)this.r+(double)num4)*Math.Sin((double)MathHelper.ToRadians(degrees)))+num3;
                                barrage.life=this.sonlife;
                                barrage.type=(int)this.type-1;
                                barrage.wscale=this.wscale+Math.Max(val1,val2);
                                barrage.hscale=this.hscale+Math.Max(val1,val2);
                                if((double)Layer.LayerArray[this.parentid].BatchArray[this.id].head==-100000.0)
                                    this.head=MathHelper.ToDegrees(Main.Twopointangle(this.heads.X,this.heads.Y,barrage.x,barrage.y));
                                barrage.head=this.head+num6;
                                barrage.alpha=this.alpha;
                                barrage.R=this.colorR;
                                barrage.G=this.colorG;
                                barrage.B=this.colorB;
                                barrage.speed=this.sonspeed+num8;
                                barrage.aspeed=this.sonaspeed+num10;
                                barrage.fx=this.x-4f;
                                barrage.fy=this.y+16f;
                                barrage.fdirection=(double)this.bfdirection<-99997.0 ? this.bfdirection : this.fdirection;
                                barrage.bindspeedd=Layer.LayerArray[this.parentid].Barrages[index1].speedd;
                                barrage.Bindwithspeedd=this.Bindwithspeedd;
                                barrage.fdirections=this.fdirections;
                                barrage.randfdirection=num9;
                                barrage.g=index2;
                                barrage.tiaos=num1;
                                barrage.range=this.range;
                                barrage.randrange=num7;
                                barrage.sonaspeedd=(double)this.bsonaspeedd<-99997.0 ? this.bsonaspeedd : this.sonaspeedd;
                                barrage.sonaspeedds=this.sonaspeedds;
                                barrage.randsonaspeedd=num11;
                                barrage.Withspeedd=this.Withspeedd;
                                barrage.xscale=this.xscale;
                                barrage.yscale=this.yscale;
                                barrage.Mist=this.Mist;
                                barrage.Dispel=this.Dispel;
                                barrage.Blend=this.Blend;
                                barrage.Outdispel=this.Outdispel;
                                barrage.Afterimage=this.Afterimage;
                                barrage.Invincible=this.Invincible;
                                barrage.Cover=this.Cover;
                                barrage.Rebound=this.Rebound;
                                barrage.Force=this.Force;
                                for(int idx = 0;idx<this.Sonevents.Count;++idx) {
                                    Event @event = new Event(idx);
                                    @event.t=this.Sonevents[idx].t;
                                    @event.addtime=this.Sonevents[idx].addtime;
                                    @event.events=this.Sonevents[idx].events;
                                    for(int index3 = 0;index3<this.Sonevents[idx].results.Count;++index3)
                                        @event.results.Add((EventRead)this.Sonevents[idx].results[index3].Copy());
                                    @event.index=this.Sonevents[idx].index;
                                    barrage.Events.Add(@event);
                                }
                                barrage.parentid=this.id;
                                Layer.LayerArray[this.parentid].Barrages.Add(barrage);
                            }
                        }
                    }
                }
            }
        }
        public Batch BindClone() {
            Batch batch = this.Copy() as Batch;
            batch.Parentevents=new List<Event>();
            foreach(Event parentevent in this.Parentevents)
                batch.Parentevents.Add((Event)parentevent.Clone());
            batch.Eventsexe=new List<Execution>();
            foreach(Execution execution in this.Eventsexe)
                batch.Eventsexe.Add((Execution)execution.Clone());
            batch.Sonevents=new List<Event>();
            foreach(Event sonevent in this.Sonevents)
                batch.Sonevents.Add((Event)sonevent.Clone());
            return batch;
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

        public void Recover() {
            this.x=Layer.LayerArray[this.parentid].BatchArray[this.id].x;
            this.y=Layer.LayerArray[this.parentid].BatchArray[this.id].y;
            this.parentcolor=Layer.LayerArray[this.parentid].BatchArray[this.id].parentcolor;
            this.begin=Layer.LayerArray[this.parentid].BatchArray[this.id].begin;
            this.life=Layer.LayerArray[this.parentid].BatchArray[this.id].life;
            this.fx=Layer.LayerArray[this.parentid].BatchArray[this.id].fx;
            this.fy=Layer.LayerArray[this.parentid].BatchArray[this.id].fy;
            this.r=Layer.LayerArray[this.parentid].BatchArray[this.id].r;
            this.rdirection=Layer.LayerArray[this.parentid].BatchArray[this.id].rdirection;
            this.tiao=Layer.LayerArray[this.parentid].BatchArray[this.id].tiao;
            this.t=Layer.LayerArray[this.parentid].BatchArray[this.id].t;
            this.fdirection=Layer.LayerArray[this.parentid].BatchArray[this.id].fdirection;
            this.range=Layer.LayerArray[this.parentid].BatchArray[this.id].range;
            this.speed=Layer.LayerArray[this.parentid].BatchArray[this.id].speed;
            this.speedd=Layer.LayerArray[this.parentid].BatchArray[this.id].speedd;
            this.aspeed=Layer.LayerArray[this.parentid].BatchArray[this.id].aspeed;
            this.aspeedd=Layer.LayerArray[this.parentid].BatchArray[this.id].aspeedd;
            this.sonlife=Layer.LayerArray[this.parentid].BatchArray[this.id].sonlife;
            this.type=Layer.LayerArray[this.parentid].BatchArray[this.id].type;
            this.wscale=Layer.LayerArray[this.parentid].BatchArray[this.id].wscale;
            this.hscale=Layer.LayerArray[this.parentid].BatchArray[this.id].hscale;
            this.colorR=Layer.LayerArray[this.parentid].BatchArray[this.id].colorR;
            this.colorG=Layer.LayerArray[this.parentid].BatchArray[this.id].colorG;
            this.colorB=Layer.LayerArray[this.parentid].BatchArray[this.id].colorB;
            this.alpha=Layer.LayerArray[this.parentid].BatchArray[this.id].alpha;
            this.head=Layer.LayerArray[this.parentid].BatchArray[this.id].head;
            this.Withspeedd=Layer.LayerArray[this.parentid].BatchArray[this.id].Withspeedd;
            this.sonspeed=Layer.LayerArray[this.parentid].BatchArray[this.id].sonspeed;
            this.sonspeedd=Layer.LayerArray[this.parentid].BatchArray[this.id].sonspeedd;
            this.sonaspeed=Layer.LayerArray[this.parentid].BatchArray[this.id].sonaspeed;
            this.sonaspeedd=Layer.LayerArray[this.parentid].BatchArray[this.id].sonaspeedd;
            this.xscale=Layer.LayerArray[this.parentid].BatchArray[this.id].xscale;
            this.yscale=Layer.LayerArray[this.parentid].BatchArray[this.id].yscale;
            this.Mist=Layer.LayerArray[this.parentid].BatchArray[this.id].Mist;
            this.Dispel=Layer.LayerArray[this.parentid].BatchArray[this.id].Dispel;
            this.Blend=Layer.LayerArray[this.parentid].BatchArray[this.id].Blend;
            this.Afterimage=Layer.LayerArray[this.parentid].BatchArray[this.id].Afterimage;
            this.Outdispel=Layer.LayerArray[this.parentid].BatchArray[this.id].Outdispel;
            this.Invincible=Layer.LayerArray[this.parentid].BatchArray[this.id].Invincible;
        }

        public void PreviewUpdate() {
            if(!(Time.now>=this.begin&Time.now<=this.begin+this.life-1))
                return;
            int now = Time.now;
            this.speedx+=this.aspeedx;
            this.speedy+=this.aspeedy;
            this.x+=this.speedx;
            this.y+=this.speedy;
            this.fx+=this.speedx;
            this.fy+=this.speedy;
        }
    }
}
