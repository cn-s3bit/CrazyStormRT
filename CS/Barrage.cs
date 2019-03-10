using System;
using System.Collections.Generic;

namespace CrazyStorm_1._03 {
    public class Barrage {
        public int id = -1;
        public int parentid = -2;
        public Shadows[] savesha = new Shadows[50];
        public List<int> Covered = new List<int>();
        public float dscale = 0.9f;
        private float[] conditions = new float[3];
        private float[] results = new float[21];
        public bool IsLase;
        public bool IsRay;
        public int shatime;
        public bool NeedDelete;
        public bool Dis;
        public int life;
        public int time;
        public int type;
        public float x;
        public float y;
        public float wscale;
        public float rwscale;
        public float hscale;
        public float longs;
        public float rlongs;
        public float randf;
        public float R;
        public float G;
        public float B;
        public float alpha;
        public float head;
        public float speed;
        public float speedx;
        public float speedy;
        public float bspeedx;
        public float bspeedy;
        public float speedd;
        public float vf;
        public float aspeed;
        public float aspeedx;
        public float aspeedy;
        public float aspeedd;
        public bool Withspeedd;
        public float fdirection;
        public float sonaspeedd;
        public float fx;
        public float fy;
        public Vector2 fdirections;
        public Vector2 sonaspeedds;
        public float randfdirection;
        public float randsonaspeedd;
        public int g;
        public int tiaos;
        public int range;
        public int randrange;
        public float bindspeedd;
        public bool Bindwithspeedd;
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
        public bool Alreadylong;
        public int reboundtime;
        public int fadeout;
        public Batch batch;
        public Lase lase;
        public Cover cover;
        public List<Event> Events;
        public List<BExecution> Eventsexe;
        public List<BLExecution> LEventsexe;

        public Barrage() {
            NeedDelete=false;
            for(int index = 0;index<50;++index) {
                savesha[index]=new Shadows {
                    x=x,
                    y=y,
                    alpha=0.0f
                };
            }
            Events=new List<Event>();
            Eventsexe=new List<BExecution>();
            LEventsexe=new List<BLExecution>();
        }

        public void Update() {
            if(!IsLase&type!=-2) {
                float x1 = x;
                float y1 = y;
                float x2 = Player.position.X;
                float y2 = Player.position.Y;
                int num1 = 0;
                if(Mist) {
                    num1=15;
                }
                ++time;
                if(type<=-1) {
                    type=-1;
                }
                if(type>=Main.bgset.Count) {
                    type=Main.bgset.Count-1;
                }
                if(time>15||!Mist) {
                    if(Mist&time==16||!Mist&time==1) {
                        if(fdirection==-99998.0) {
                            fdirection=MathHelper.ToDegrees(Main.Twopointangle(fx,fy,x,y));
                        } else if(fdirection==-99999.0) {
                            fdirection=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                        } else if(this.fdirection==-100000.0) {
                            fdirection=MathHelper.ToDegrees(Main.Twopointangle(fdirections.X,fdirections.Y,x,y));
                        }
                        speedd=!Bindwithspeedd ? (float)(fdirection+(double)randfdirection+(g-(float)((tiaos-1.0)/2.0))*(double)(range+randrange)/tiaos) : (float)(fdirection+(double)randfdirection+(g-(float)((tiaos-1.0)/2.0))*(double)(range+randrange)/tiaos)+bindspeedd;
                        if(sonaspeedd==-99998.0) {
                            sonaspeedd=MathHelper.ToDegrees(Main.Twopointangle(fx,fy,x,y));
                        } else if(sonaspeedd==-99999.0) {
                            sonaspeedd=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                        } else if(sonaspeedd==-100000.0) {
                            sonaspeedd=MathHelper.ToDegrees(Main.Twopointangle(sonaspeedds.X,sonaspeedds.Y,x,y));
                        }
                        aspeedd=sonaspeedd+randsonaspeedd;
                        speedx=xscale*speed*(float)Math.Cos(MathHelper.ToRadians(speedd));
                        speedy=yscale*speed*(float)Math.Sin(MathHelper.ToRadians(speedd));
                        aspeedx=xscale*aspeed*(float)Math.Cos(MathHelper.ToRadians(aspeedd));
                        aspeedy=yscale*aspeed*(float)Math.Sin(MathHelper.ToRadians(aspeedd));
                        if(Withspeedd) {
                            head=speedd+90f;
                        }
                    }
                    if(!Dis) {
                        speedx+=aspeedx*Time.stop;
                        speedy+=aspeedy*Time.stop;
                        x+=speedx*Time.stop;
                        y+=speedy*Time.stop;
                    }
                    if(speed!=0.0) {
                        if(speedy!=0.0) {
                            vf=1.570796f-(float)Math.Atan(speedx/(double)xscale/(speedy/(double)yscale));
                            if(speedy<0.0) {
                                vf+=3.141593f;
                            }
                        } else {
                            if(speedx>=0.0) {
                                vf=0.0f;
                            }
                            if(speedx<0.0) {
                                vf=3.141593f;
                            }
                        }
                        if(speed>0.0) {
                            speedd=MathHelper.ToDegrees(vf);
                            if(Withspeedd) {
                                head=speedd;
                            }
                        } else if(Withspeedd) {
                            head=MathHelper.ToDegrees(vf);
                        }
                    }
                    if(Afterimage&time<=num1+life) {
                        savesha[shatime].alpha=(float)(0.400000005960464*(alpha/100.0));
                        savesha[shatime].x=x;
                        savesha[shatime].y=y;
                        savesha[shatime].d=head;
                        ++shatime;
                        if(shatime>=49) {
                            shatime=0;
                        }
                    } else {
                        shatime=0;
                    }
                    conditions[0]=time-num1;
                    conditions[1]=x;
                    conditions[2]=y;
                    results[0]=life;
                    results[1]=type;
                    results[2]=wscale;
                    results[3]=hscale;
                    results[4]=R;
                    results[5]=G;
                    results[6]=B;
                    results[7]=alpha;
                    results[8]=head;
                    results[9]=speed;
                    results[10]=speedd;
                    results[11]=aspeed;
                    results[12]=aspeedd;
                    results[13]=xscale;
                    results[14]=yscale;
                    results[15]=0.0f;
                    results[16]=0.0f;
                    results[17]=0.0f;
                    results[18]=0.0f;
                    results[19]=0.0f;
                    results[20]=0.0f;
                    foreach(Event @event in Events) {
                        if(@event.t<=0) {
                            @event.t=1;
                        }
                        if((time-num1)%@event.t==0) {
                            ++@event.loop;
                        }
                        foreach(EventRead result in @event.results) {
                            if(result.special2==1) {
                                conditions[0]=Time.now;
                            }
                            if(result.opreator==">") {
                                if(result.opreator2==">") {
                                    if(result.collector=="且") {
                                        if(conditions[result.contype]>float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&conditions[result.contype2]>float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==10) {
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                }
                                                if(result.changevalue==12) {
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                }
                                            }
                                            BExecution bexecution = new BExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                bexecution.change=result.change;
                                                bexecution.changetype=result.changetype;
                                                bexecution.changevalue=result.changevalue;
                                                bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                bexecution.region=results[result.changename].ToString();
                                                bexecution.time=result.times;
                                                bexecution.ctime=bexecution.time;
                                                Eventsexe.Add(bexecution);
                                            } else {
                                                continue;
                                            }
                                        }
                                    } else if(result.collector=="或"&&(conditions[result.contype]>float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||conditions[result.contype2]>float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==10) {
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                            if(result.changevalue==12) {
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                        }
                                        BExecution bexecution = new BExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            bexecution.change=result.change;
                                            bexecution.changetype=result.changetype;
                                            bexecution.changevalue=result.changevalue;
                                            bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            bexecution.region=results[result.changename].ToString();
                                            bexecution.time=result.times;
                                            bexecution.ctime=bexecution.time;
                                            Eventsexe.Add(bexecution);
                                        } else {
                                            continue;
                                        }
                                    }
                                } else if(result.opreator2=="=") {
                                    if(result.collector=="且") {
                                        if(conditions[result.contype]>(double)float.Parse(result.condition)+@event.loop*@event.addtime&conditions[result.contype2]==(double)float.Parse(result.condition2)+@event.loop*@event.addtime) {
                                            if(result.special==4) {
                                                if(result.changevalue==10) {
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                }
                                                if(result.changevalue==12) {
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                }
                                            }
                                            BExecution bexecution = new BExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                bexecution.change=result.change;
                                                bexecution.changetype=result.changetype;
                                                bexecution.changevalue=result.changevalue;
                                                bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                bexecution.region=results[result.changename].ToString();
                                                bexecution.time=result.times;
                                                bexecution.ctime=bexecution.time;
                                                Eventsexe.Add(bexecution);
                                            } else {
                                                continue;
                                            }
                                        }
                                    } else if(result.collector=="或"&&(conditions[result.contype]>(double)float.Parse(result.condition)+@event.loop*@event.addtime||conditions[result.contype2]==(double)float.Parse(result.condition2)+@event.loop*@event.addtime)) {
                                        if(result.special==4) {
                                            if(result.changevalue==10) {
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                            if(result.changevalue==12) {
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                        }
                                        BExecution bexecution = new BExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            bexecution.change=result.change;
                                            bexecution.changetype=result.changetype;
                                            bexecution.changevalue=result.changevalue;
                                            bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            bexecution.region=results[result.changename].ToString();
                                            bexecution.time=result.times;
                                            bexecution.ctime=bexecution.time;
                                            Eventsexe.Add(bexecution);
                                        } else {
                                            continue;
                                        }
                                    }
                                } else if(result.opreator2=="<") {
                                    if(result.collector=="且") {
                                        if(conditions[result.contype]>float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&conditions[result.contype2]<float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==10) {
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                }
                                                if(result.changevalue==12) {
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                }
                                            }
                                            BExecution bexecution = new BExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                bexecution.change=result.change;
                                                bexecution.changetype=result.changetype;
                                                bexecution.changevalue=result.changevalue;
                                                bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                bexecution.region=results[result.changename].ToString();
                                                bexecution.time=result.times;
                                                bexecution.ctime=bexecution.time;
                                                Eventsexe.Add(bexecution);
                                            } else {
                                                continue;
                                            }
                                        }
                                    } else if(result.collector=="或"&&(conditions[result.contype]>float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||conditions[result.contype2]<float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==10) {
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                            if(result.changevalue==12) {
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                        }
                                        BExecution bexecution = new BExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            bexecution.change=result.change;
                                            bexecution.changetype=result.changetype;
                                            bexecution.changevalue=result.changevalue;
                                            bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            bexecution.region=results[result.changename].ToString();
                                            bexecution.time=result.times;
                                            bexecution.ctime=bexecution.time;
                                            Eventsexe.Add(bexecution);
                                        } else {
                                            continue;
                                        }
                                    }
                                } else if(conditions[result.contype]>float.Parse(result.condition)+(double)(@event.loop*@event.addtime)) {
                                    if(result.special==4) {
                                        if(result.changevalue==10) {
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                        }
                                        if(result.changevalue==12) {
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                        }
                                    }
                                    BExecution bexecution = new BExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        bexecution.change=result.change;
                                        bexecution.changetype=result.changetype;
                                        bexecution.changevalue=result.changevalue;
                                        bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        bexecution.region=results[result.changename].ToString();
                                        bexecution.time=result.times;
                                        bexecution.ctime=bexecution.time;
                                        Eventsexe.Add(bexecution);
                                    } else {
                                        continue;
                                    }
                                }
                            }
                            if(result.opreator=="=") {
                                if(result.opreator2==">") {
                                    if(result.collector=="且") {
                                        if(conditions[result.contype]==float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&conditions[result.contype2]>float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==10) {
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                }
                                                if(result.changevalue==12) {
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                }
                                            }
                                            BExecution bexecution = new BExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                bexecution.change=result.change;
                                                bexecution.changetype=result.changetype;
                                                bexecution.changevalue=result.changevalue;
                                                bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                bexecution.region=results[result.changename].ToString();
                                                bexecution.time=result.times;
                                                bexecution.ctime=bexecution.time;
                                                Eventsexe.Add(bexecution);
                                            } else {
                                                continue;
                                            }
                                        }
                                    } else if(result.collector=="或"&&(conditions[result.contype]==float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||conditions[result.contype2]>float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==10) {
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                            if(result.changevalue==12) {
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                        }
                                        BExecution bexecution = new BExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            bexecution.change=result.change;
                                            bexecution.changetype=result.changetype;
                                            bexecution.changevalue=result.changevalue;
                                            bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            bexecution.region=results[result.changename].ToString();
                                            bexecution.time=result.times;
                                            bexecution.ctime=bexecution.time;
                                            Eventsexe.Add(bexecution);
                                        } else {
                                            continue;
                                        }
                                    }
                                } else if(result.opreator2=="=") {
                                    if(result.collector=="且") {
                                        if(conditions[result.contype]==float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&conditions[result.contype2]==float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==10) {
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                }
                                                if(result.changevalue==12) {
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                }
                                            }
                                            BExecution bexecution = new BExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                bexecution.change=result.change;
                                                bexecution.changetype=result.changetype;
                                                bexecution.changevalue=result.changevalue;
                                                bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                bexecution.region=results[result.changename].ToString();
                                                bexecution.time=result.times;
                                                bexecution.ctime=bexecution.time;
                                                Eventsexe.Add(bexecution);
                                            } else {
                                                continue;
                                            }
                                        }
                                    } else if(result.collector=="或"&&(conditions[result.contype]==float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||conditions[result.contype2]==float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==10) {
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                            if(result.changevalue==12) {
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                        }
                                        BExecution bexecution = new BExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            bexecution.change=result.change;
                                            bexecution.changetype=result.changetype;
                                            bexecution.changevalue=result.changevalue;
                                            bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            bexecution.region=results[result.changename].ToString();
                                            bexecution.time=result.times;
                                            bexecution.ctime=bexecution.time;
                                            Eventsexe.Add(bexecution);
                                        } else {
                                            continue;
                                        }
                                    }
                                } else if(result.opreator2=="<") {
                                    if(result.collector=="且") {
                                        if(conditions[result.contype]==float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&conditions[result.contype2]<float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==10) {
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                }
                                                if(result.changevalue==12) {
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                }
                                            }
                                            BExecution bexecution = new BExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                bexecution.change=result.change;
                                                bexecution.changetype=result.changetype;
                                                bexecution.changevalue=result.changevalue;
                                                bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                bexecution.region=results[result.changename].ToString();
                                                bexecution.time=result.times;
                                                bexecution.ctime=bexecution.time;
                                                Eventsexe.Add(bexecution);
                                            } else {
                                                continue;
                                            }
                                        }
                                    } else if(result.collector=="或"&&(conditions[result.contype]==float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||conditions[result.contype2]<float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==10) {
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                            if(result.changevalue==12) {
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                        }
                                        BExecution bexecution = new BExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            bexecution.change=result.change;
                                            bexecution.changetype=result.changetype;
                                            bexecution.changevalue=result.changevalue;
                                            bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            bexecution.region=results[result.changename].ToString();
                                            bexecution.time=result.times;
                                            bexecution.ctime=bexecution.time;
                                            Eventsexe.Add(bexecution);
                                        } else {
                                            continue;
                                        }
                                    }
                                } else if(conditions[result.contype]==float.Parse(result.condition)+(double)(@event.loop*@event.addtime)) {
                                    if(result.special==4) {
                                        if(result.changevalue==10) {
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                        }
                                        if(result.changevalue==12) {
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                        }
                                    }
                                    BExecution bexecution = new BExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        bexecution.change=result.change;
                                        bexecution.changetype=result.changetype;
                                        bexecution.changevalue=result.changevalue;
                                        bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        bexecution.region=results[result.changename].ToString();
                                        bexecution.time=result.times;
                                        bexecution.ctime=bexecution.time;
                                        Eventsexe.Add(bexecution);
                                    } else {
                                        continue;
                                    }
                                }
                            }
                            if(result.opreator=="<") {
                                if(result.opreator2==">") {
                                    if(result.collector=="且") {
                                        if(conditions[result.contype]<float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&conditions[result.contype2]>float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==10) {
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                }
                                                if(result.changevalue==12) {
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                }
                                            }
                                            BExecution bexecution = new BExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                bexecution.change=result.change;
                                                bexecution.changetype=result.changetype;
                                                bexecution.changevalue=result.changevalue;
                                                bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                bexecution.region=results[result.changename].ToString();
                                                bexecution.time=result.times;
                                                bexecution.ctime=bexecution.time;
                                                Eventsexe.Add(bexecution);
                                            } else {
                                                continue;
                                            }
                                        }
                                    } else if(result.collector=="或"&&(conditions[result.contype]<float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||conditions[result.contype2]>float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==10) {
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                            if(result.changevalue==12) {
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                        }
                                        BExecution bexecution = new BExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            bexecution.change=result.change;
                                            bexecution.changetype=result.changetype;
                                            bexecution.changevalue=result.changevalue;
                                            bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            bexecution.region=results[result.changename].ToString();
                                            bexecution.time=result.times;
                                            bexecution.ctime=bexecution.time;
                                            Eventsexe.Add(bexecution);
                                        } else {
                                            continue;
                                        }
                                    }
                                } else if(result.opreator2=="=") {
                                    if(result.collector=="且") {
                                        if(conditions[result.contype]<(double)float.Parse(result.condition)+@event.loop*@event.addtime&conditions[result.contype2]==float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==10) {
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                }
                                                if(result.changevalue==12) {
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                }
                                            }
                                            BExecution bexecution = new BExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                bexecution.change=result.change;
                                                bexecution.changetype=result.changetype;
                                                bexecution.changevalue=result.changevalue;
                                                bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                bexecution.region=results[result.changename].ToString();
                                                bexecution.time=result.times;
                                                bexecution.ctime=bexecution.time;
                                                Eventsexe.Add(bexecution);
                                            } else {
                                                continue;
                                            }
                                        }
                                    } else if(result.collector=="或"&&(conditions[result.contype]<float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||conditions[result.contype2]==float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==10) {
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                            if(result.changevalue==12) {
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                        }
                                        BExecution bexecution = new BExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            bexecution.change=result.change;
                                            bexecution.changetype=result.changetype;
                                            bexecution.changevalue=result.changevalue;
                                            bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            bexecution.region=results[result.changename].ToString();
                                            bexecution.time=result.times;
                                            bexecution.ctime=bexecution.time;
                                            Eventsexe.Add(bexecution);
                                        } else {
                                            continue;
                                        }
                                    }
                                } else if(result.opreator2=="<") {
                                    if(result.collector=="且") {
                                        if(conditions[result.contype]<float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&conditions[result.contype2]<float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==10) {
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                }
                                                if(result.changevalue==12) {
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                }
                                            }
                                            BExecution bexecution = new BExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                bexecution.change=result.change;
                                                bexecution.changetype=result.changetype;
                                                bexecution.changevalue=result.changevalue;
                                                bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                bexecution.region=results[result.changename].ToString();
                                                bexecution.time=result.times;
                                                bexecution.ctime=bexecution.time;
                                                Eventsexe.Add(bexecution);
                                            } else {
                                                continue;
                                            }
                                        }
                                    } else if(result.collector=="或"&&(conditions[result.contype]<float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||conditions[result.contype2]<float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==10) {
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                            if(result.changevalue==12) {
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                        }
                                        BExecution bexecution = new BExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            bexecution.change=result.change;
                                            bexecution.changetype=result.changetype;
                                            bexecution.changevalue=result.changevalue;
                                            bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            bexecution.region=results[result.changename].ToString();
                                            bexecution.time=result.times;
                                            bexecution.ctime=bexecution.time;
                                            Eventsexe.Add(bexecution);
                                        } else {
                                            continue;
                                        }
                                    }
                                } else if(conditions[result.contype]<float.Parse(result.condition)+(double)(@event.loop*@event.addtime)) {
                                    if(result.special==4) {
                                        if(result.changevalue==10) {
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                        }
                                        if(result.changevalue==12) {
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                        }
                                    }
                                    BExecution bexecution = new BExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        bexecution.change=result.change;
                                        bexecution.changetype=result.changetype;
                                        bexecution.changevalue=result.changevalue;
                                        bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        bexecution.region=results[result.changename].ToString();
                                        bexecution.time=result.times;
                                        bexecution.ctime=bexecution.time;
                                        Eventsexe.Add(bexecution);
                                    } else {
                                        continue;
                                    }
                                }
                            }
                            if(result.special==5) {
                                x=Center.ox;
                                y=Center.oy;
                            }
                            if(result.special2==1) {
                                conditions[0]=Time.now;
                            }
                        }
                    }
                    for(int index = 0;index<Eventsexe.Count;++index) {
                        if(!Eventsexe[index].NeedDelete) {
                            Eventsexe[index].Update(this);
                        } else {
                            Eventsexe.RemoveAt(index);
                            --index;
                        }
                    }
                     if(time>num1+life) {
                        if(Dispel&type>=0) { 
                        } else {
                            NeedDelete=true;
                        }
                    }
                } else if(!Invincible&&Math.Sqrt((x-(double)Player.position.X)*(x-(double)Player.position.X)+(y-(double)Player.position.Y)*(y-(double)Player.position.Y))<=10.0) {
                    NeedDelete=true;
                }
                int num2 = 0;
                foreach(Shadows shadows in savesha) {
                    if(shadows.alpha<=0.0)
                        ++num2;
                }
                if(Outdispel) {
                    if(num2==savesha.Length) {
                        if(x<0||x>630||(y<0||y>480)) {
                            NeedDelete=true;
                        }
                    }
                } else if(num2==savesha.Length) {
                    if(x<-110.0||x>740.0||(y<-250.0||y>730.0)) {
                        NeedDelete=true;
                    }
                }
            }
            if(!(!IsLase&type==-2)) {
                return;
            }
            NeedDelete=true;
        } 

        public void LUpdate() {
            if(IsLase&type!=-1) {
                float x1 = x;
                float y1 = y;
                float x2 = Player.position.X;
                float y2 = Player.position.Y;
                ++time;
                if(time<=life) {
                    conditions[0]=time;
                    results[0]=life;
                    results[1]=type;
                    results[2]=wscale;
                    results[3]=longs;
                    results[4]=alpha;
                    results[5]=speed;
                    results[6]=speedd;
                    results[7]=aspeed;
                    results[8]=aspeedd;
                    results[9]=xscale;
                    results[10]=yscale;
                    results[11]=0.0f;
                    results[12]=0.0f;
                    results[13]=0.0f;
                    foreach(Event @event in Events) {
                        if(@event.t<=0)
                            @event.t=1;
                        if(time%@event.t==0)
                            ++@event.loop;
                        foreach(EventRead result in @event.results) {
                            if(result.opreator==">") {
                                if(result.opreator2==">") {
                                    if(result.collector=="且") {
                                        if(conditions[result.contype]>float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&conditions[result.contype2]>float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==6)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                if(result.changevalue==8)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                            BLExecution blExecution = new BLExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                blExecution.change=result.change;
                                                blExecution.changetype=result.changetype;
                                                blExecution.changevalue=result.changevalue;
                                                blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                blExecution.region=results[result.changename].ToString();
                                                blExecution.time=result.times;
                                                blExecution.ctime=blExecution.time;
                                                LEventsexe.Add(blExecution);
                                            } else {
                                                continue;
                                            }
                                        }
                                    } else if(result.collector=="或"&&(conditions[result.contype]>float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||conditions[result.contype2]>float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==6)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            if(result.changevalue==8)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                        }
                                        BLExecution blExecution = new BLExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            blExecution.change=result.change;
                                            blExecution.changetype=result.changetype;
                                            blExecution.changevalue=result.changevalue;
                                            blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            blExecution.region=results[result.changename].ToString();
                                            blExecution.time=result.times;
                                            blExecution.ctime=blExecution.time;
                                            LEventsexe.Add(blExecution);
                                        } else {
                                            continue;
                                        }
                                    }
                                } else if(result.opreator2=="=") {
                                    if(result.collector=="且") {
                                        if(conditions[result.contype]>float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&conditions[result.contype2]==float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==6)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                if(result.changevalue==8)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                            BLExecution blExecution = new BLExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                blExecution.change=result.change;
                                                blExecution.changetype=result.changetype;
                                                blExecution.changevalue=result.changevalue;
                                                blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                blExecution.region=results[result.changename].ToString();
                                                blExecution.time=result.times;
                                                blExecution.ctime=blExecution.time;
                                                LEventsexe.Add(blExecution);
                                            } else {
                                                continue;
                                            }
                                        }
                                    } else if(result.collector=="或"&&(conditions[result.contype]>float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||conditions[result.contype2]==float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==6)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            if(result.changevalue==8)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                        }
                                        BLExecution blExecution = new BLExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            blExecution.change=result.change;
                                            blExecution.changetype=result.changetype;
                                            blExecution.changevalue=result.changevalue;
                                            blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            blExecution.region=results[result.changename].ToString();
                                            blExecution.time=result.times;
                                            blExecution.ctime=blExecution.time;
                                            LEventsexe.Add(blExecution);
                                        } else {
                                            continue;
                                        }
                                    }
                                } else if(result.opreator2=="<") {
                                    if(result.collector=="且") {
                                        if(conditions[result.contype]>float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&conditions[result.contype2]<float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==6)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                if(result.changevalue==8)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                            BLExecution blExecution = new BLExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                blExecution.change=result.change;
                                                blExecution.changetype=result.changetype;
                                                blExecution.changevalue=result.changevalue;
                                                blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                blExecution.region=results[result.changename].ToString();
                                                blExecution.time=result.times;
                                                blExecution.ctime=blExecution.time;
                                                LEventsexe.Add(blExecution);
                                            } else {
                                                continue;
                                            }
                                        }
                                    } else if(result.collector=="或"&&(conditions[result.contype]>float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||conditions[result.contype2]<float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==6)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            if(result.changevalue==8)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                        }
                                        BLExecution blExecution = new BLExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            blExecution.change=result.change;
                                            blExecution.changetype=result.changetype;
                                            blExecution.changevalue=result.changevalue;
                                            blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            blExecution.region=results[result.changename].ToString();
                                            blExecution.time=result.times;
                                            blExecution.ctime=blExecution.time;
                                            LEventsexe.Add(blExecution);
                                        } else {
                                            continue;
                                        }
                                    }
                                } else if(conditions[result.contype]>float.Parse(result.condition)+(double)(@event.loop*@event.addtime)) {
                                    if(result.special==4) {
                                        if(result.changevalue==6)
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                        if(result.changevalue==8)
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                    }
                                    BLExecution blExecution = new BLExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        blExecution.change=result.change;
                                        blExecution.changetype=result.changetype;
                                        blExecution.changevalue=result.changevalue;
                                        blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        blExecution.region=results[result.changename].ToString();
                                        blExecution.time=result.times;
                                        blExecution.ctime=blExecution.time;
                                        LEventsexe.Add(blExecution);
                                    } else {
                                        continue;
                                    }
                                }
                            }
                            if(result.opreator=="=") {
                                if(result.opreator2==">") {
                                    if(result.collector=="且") {
                                        if(conditions[result.contype]==float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&conditions[result.contype2]>float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==6)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                if(result.changevalue==8)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                            BLExecution blExecution = new BLExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                blExecution.change=result.change;
                                                blExecution.changetype=result.changetype;
                                                blExecution.changevalue=result.changevalue;
                                                blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                blExecution.region=results[result.changename].ToString();
                                                blExecution.time=result.times;
                                                blExecution.ctime=blExecution.time;
                                                LEventsexe.Add(blExecution);
                                            } else {
                                                continue;
                                            }
                                        }
                                    } else if(result.collector=="或"&&(conditions[result.contype]==float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||conditions[result.contype2]>float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==6)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            if(result.changevalue==8)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                        }
                                        BLExecution blExecution = new BLExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            blExecution.change=result.change;
                                            blExecution.changetype=result.changetype;
                                            blExecution.changevalue=result.changevalue;
                                            blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            blExecution.region=results[result.changename].ToString();
                                            blExecution.time=result.times;
                                            blExecution.ctime=blExecution.time;
                                            LEventsexe.Add(blExecution);
                                        } else {
                                            continue;
                                        }
                                    }
                                } else if(result.opreator2=="=") {
                                    if(result.collector=="且") {
                                        if(conditions[result.contype]==float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&conditions[result.contype2]==float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==6)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                if(result.changevalue==8)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                            BLExecution blExecution = new BLExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                blExecution.change=result.change;
                                                blExecution.changetype=result.changetype;
                                                blExecution.changevalue=result.changevalue;
                                                blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                blExecution.region=results[result.changename].ToString();
                                                blExecution.time=result.times;
                                                blExecution.ctime=blExecution.time;
                                                LEventsexe.Add(blExecution);
                                            } else {
                                                continue;
                                            }
                                        }
                                    } else if(result.collector=="或"&&(conditions[result.contype]==float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||conditions[result.contype2]==float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==6)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            if(result.changevalue==8)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                        }
                                        BLExecution blExecution = new BLExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            blExecution.change=result.change;
                                            blExecution.changetype=result.changetype;
                                            blExecution.changevalue=result.changevalue;
                                            blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            blExecution.region=results[result.changename].ToString();
                                            blExecution.time=result.times;
                                            blExecution.ctime=blExecution.time;
                                            LEventsexe.Add(blExecution);
                                        } else {
                                            continue;
                                        }
                                    }
                                } else if(result.opreator2=="<") {
                                    if(result.collector=="且") {
                                        if(conditions[result.contype]==float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&conditions[result.contype2]<float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==6)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                if(result.changevalue==8)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                            BLExecution blExecution = new BLExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                blExecution.change=result.change;
                                                blExecution.changetype=result.changetype;
                                                blExecution.changevalue=result.changevalue;
                                                blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                blExecution.region=results[result.changename].ToString();
                                                blExecution.time=result.times;
                                                blExecution.ctime=blExecution.time;
                                                LEventsexe.Add(blExecution);
                                            } else {
                                                continue;
                                            }
                                        }
                                    } else if(result.collector=="或"&&(conditions[result.contype]==float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||conditions[result.contype2]<float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==6)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            if(result.changevalue==8)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                        }
                                        BLExecution blExecution = new BLExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            blExecution.change=result.change;
                                            blExecution.changetype=result.changetype;
                                            blExecution.changevalue=result.changevalue;
                                            blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            blExecution.region=results[result.changename].ToString();
                                            blExecution.time=result.times;
                                            blExecution.ctime=blExecution.time;
                                            LEventsexe.Add(blExecution);
                                        } else {
                                            continue;
                                        }
                                    }
                                } else if(conditions[result.contype]==float.Parse(result.condition)+(double)(@event.loop*@event.addtime)) {
                                    if(result.special==4) {
                                        if(result.changevalue==6)
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                        if(result.changevalue==8)
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                    }
                                    BLExecution blExecution = new BLExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        blExecution.change=result.change;
                                        blExecution.changetype=result.changetype;
                                        blExecution.changevalue=result.changevalue;
                                        blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        blExecution.region=results[result.changename].ToString();
                                        blExecution.time=result.times;
                                        blExecution.ctime=blExecution.time;
                                        LEventsexe.Add(blExecution);
                                    } else {
                                        continue;
                                    }
                                }
                            }
                            if(result.opreator=="<") {
                                if(result.opreator2==">") {
                                    if(result.collector=="且") {
                                        if(conditions[result.contype]<(double)float.Parse(result.condition)+@event.loop*@event.addtime&conditions[result.contype2]>float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==6)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                if(result.changevalue==8)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                            BLExecution blExecution = new BLExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                blExecution.change=result.change;
                                                blExecution.changetype=result.changetype;
                                                blExecution.changevalue=result.changevalue;
                                                blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                blExecution.region=results[result.changename].ToString();
                                                blExecution.time=result.times;
                                                blExecution.ctime=blExecution.time;
                                                LEventsexe.Add(blExecution);
                                            } else {
                                                continue;
                                            }
                                        }
                                    } else if(result.collector=="或"&&(conditions[result.contype]<float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||conditions[result.contype2]>float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==6)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            if(result.changevalue==8)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                        }
                                        BLExecution blExecution = new BLExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            blExecution.change=result.change;
                                            blExecution.changetype=result.changetype;
                                            blExecution.changevalue=result.changevalue;
                                            blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            blExecution.region=results[result.changename].ToString();
                                            blExecution.time=result.times;
                                            blExecution.ctime=blExecution.time;
                                            LEventsexe.Add(blExecution);
                                        } else {
                                            continue;
                                        }
                                    }
                                } else if(result.opreator2=="=") {
                                    if(result.collector=="且") {
                                        if(conditions[result.contype]<float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&conditions[result.contype2]==float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==6)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                if(result.changevalue==8)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                            BLExecution blExecution = new BLExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                blExecution.change=result.change;
                                                blExecution.changetype=result.changetype;
                                                blExecution.changevalue=result.changevalue;
                                                blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                blExecution.region=results[result.changename].ToString();
                                                blExecution.time=result.times;
                                                blExecution.ctime=blExecution.time;
                                                LEventsexe.Add(blExecution);
                                            } else {
                                                continue;
                                            }
                                        }
                                    } else if(result.collector=="或"&&(conditions[result.contype]<float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||conditions[result.contype2]==float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==6)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            if(result.changevalue==8)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                        }
                                        BLExecution blExecution = new BLExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            blExecution.change=result.change;
                                            blExecution.changetype=result.changetype;
                                            blExecution.changevalue=result.changevalue;
                                            blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            blExecution.region=results[result.changename].ToString();
                                            blExecution.time=result.times;
                                            blExecution.ctime=blExecution.time;
                                            LEventsexe.Add(blExecution);
                                        } else {
                                            continue;
                                        }
                                    }
                                } else if(result.opreator2=="<") {
                                    if(result.collector=="且") {
                                        if(conditions[result.contype]<float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&conditions[result.contype2]<float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==6)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                                if(result.changevalue==8)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            }
                                            BLExecution blExecution = new BLExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                blExecution.change=result.change;
                                                blExecution.changetype=result.changetype;
                                                blExecution.changevalue=result.changevalue;
                                                blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                blExecution.region=results[result.changename].ToString();
                                                blExecution.time=result.times;
                                                blExecution.ctime=blExecution.time;
                                                LEventsexe.Add(blExecution);
                                            } else {
                                                continue;
                                            }
                                        }
                                    } else if(result.collector=="或"&&(conditions[result.contype]<float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||conditions[result.contype2]<float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==6)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                            if(result.changevalue==8)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                        }
                                        BLExecution blExecution = new BLExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            blExecution.change=result.change;
                                            blExecution.changetype=result.changetype;
                                            blExecution.changevalue=result.changevalue;
                                            blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            blExecution.region=results[result.changename].ToString();
                                            blExecution.time=result.times;
                                            blExecution.ctime=blExecution.time;
                                            LEventsexe.Add(blExecution);
                                        } else {
                                            continue;
                                        }
                                    }
                                } else if(conditions[result.contype]<float.Parse(result.condition)+(double)(@event.loop*@event.addtime)) {
                                    if(result.special==4) {
                                        if(result.changevalue==6)
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                        if(result.changevalue==8)
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,x,y));
                                    }
                                    BLExecution blExecution = new BLExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        blExecution.change=result.change;
                                        blExecution.changetype=result.changetype;
                                        blExecution.changevalue=result.changevalue;
                                        blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        blExecution.region=results[result.changename].ToString();
                                        blExecution.time=result.times;
                                        blExecution.ctime=blExecution.time;
                                        LEventsexe.Add(blExecution);
                                    } else {
                                        continue;
                                    }
                                }
                            }
                            if(result.special==5) {
                                x=Center.ox;
                                y=Center.oy;
                            }
                        }
                    }
                    for(int index = 0;index<LEventsexe.Count;++index) {
                        if(!LEventsexe[index].NeedDelete) {
                            LEventsexe[index].Update(this);
                        } else {
                            LEventsexe.RemoveAt(index);
                            --index;
                        }
                    }
                    rwscale=wscale;
                    if(!IsRay) {
                        if(speedy!=0.0) {
                            vf=1.570796f-(float)Math.Atan(speedx/(double)speedy);
                            if(speedy<0.0) {
                                vf+=3.141593f;
                            }
                        } else {
                            if(speedx>=0.0) {
                                vf=0.0f;
                            }
                            if(speedx<0.0) {
                                vf=3.141593f;
                            }
                        }
                        head=MathHelper.ToDegrees(vf);
                        if(rlongs<(double)longs&!Alreadylong) {
                            rlongs+=speed;
                        }
                        if(rlongs>=(double)longs) {
                            Alreadylong=true;
                        }
                        if(rlongs>=(double)longs||Alreadylong) {
                            rlongs=longs;
                            speedx+=aspeedx*Time.stop;
                            speedy+=aspeedy*Time.stop;
                            x+=speedx*Time.stop;
                            y+=speedy*Time.stop;
                            if(Outdispel) {
                                if(x<0||x>630||(y<0||y>480)) {
                                    NeedDelete=true;
                                }
                            } else if(x<-110.0||x>740.0||(y<-250.0||y>730.0)) {
                                NeedDelete=true;
                            }
                        }
                       } else {
                        rlongs=792f;
                        head=speedd;
                        speedx+=aspeedx*Time.stop;
                        speedy+=aspeedy*Time.stop;
                        x+=speedx*Time.stop;
                        y+=speedy*Time.stop;
                        }
                } else {
                    if(!IsRay) {
                        speedx+=aspeedx;
                        speedy+=aspeedy;
                        x+=speedx;
                        y+=speedy;
                        rlongs-=speed;
                        wscale-=0.1f*rwscale;
                        if(wscale<0.0) {
                            wscale=0.0f;
                        }
                        if(rlongs<0.0) {
                            rlongs=0.0f;
                        }
                        if(rlongs==0.0) {
                            NeedDelete=true;
                        }
                    } else {
                        head=speedd;
                        wscale-=0.1f*rwscale;
                        if(wscale<0.0) {
                            wscale=0.0f;
                        }
                        if(wscale==0.0) {
                            NeedDelete=true;
                        }
                    }
                    for(int index = 0;index<LEventsexe.Count;++index) {
                        if(!LEventsexe[index].NeedDelete) {
                            LEventsexe[index].Update(this);
                        } else {
                            LEventsexe.RemoveAt(index);
                            --index;
                        }
                    }
                }
            }
            if(!(IsLase&type==-1)) {
                return;
            }
            NeedDelete=true;
        } 
    }
}
