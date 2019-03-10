using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CrazyStorm_1._03 {
    public class Main {
        public static int frame = 0;
        public static Hashtable conditions = new Hashtable();
        public static Hashtable results = new Hashtable();
        public static Hashtable type = new Hashtable();
        public static Hashtable conditions2 = new Hashtable();
        public static Hashtable results2 = new Hashtable();
        public static Hashtable results3 = new Hashtable();
        public static Hashtable cconditions = new Hashtable();
        public static Hashtable cresults = new Hashtable();
        public static Hashtable lconditions = new Hashtable();
        public static Hashtable lresults = new Hashtable();
        public static Hashtable lresults2 = new Hashtable();
        public static List<BarrageType> bgset = new List<BarrageType>();
        public static Random rand; 
        public static bool Available;

        public Main() {
        }

        public void Initialize() {
            Available=false;
            rand=new Random(); 
            type.Add("正比",0);
            type.Add("固定",1);
            type.Add("正弦",2);
            conditions.Add("",0);
            conditions.Add("当前帧",0);
            conditions.Add("X坐标",1);
            conditions.Add("Y坐标",2);
            conditions.Add("半径",3);
            conditions.Add("半径方向",4);
            conditions.Add("条数",5);
            conditions.Add("周期",6);
            conditions.Add("角度",7);
            conditions.Add("范围",8);
            conditions.Add("宽比",9);
            conditions.Add("高比",10);
            conditions.Add("不透明度",11);
            conditions.Add("朝向",12);
            results.Add("X坐标",0);
            results.Add("Y坐标",1);
            results.Add("半径",2);
            results.Add("半径方向",3);
            results.Add("条数",4);
            results.Add("周期",5);
            results.Add("角度",6);
            results.Add("范围",7);
            results.Add("速度",8);
            results.Add("速度方向",9);
            results.Add("加速度",10);
            results.Add("加速度方向",11);
            results.Add("生命",12);
            results.Add("类型",13);
            results.Add("宽比",14);
            results.Add("高比",15);
            results.Add("R",16);
            results.Add("G",17);
            results.Add("B",18);
            results.Add("不透明度",19);
            results.Add("朝向",20);
            results.Add("子弹速度",21);
            results.Add("子弹速度方向",22);
            results.Add("子弹加速度",23);
            results.Add("子弹加速度方向",24);
            results.Add("横比",25);
            results.Add("纵比",26);
            results.Add("雾化效果",27);
            results.Add("消除效果",28);
            results.Add("高光效果",29);
            results.Add("拖影效果",30);
            results.Add("出屏即消",31);
            results.Add("无敌状态",32);
            conditions2.Add("",0);
            conditions2.Add("当前帧",0);
            conditions2.Add("X坐标",1);
            conditions2.Add("Y坐标",2);
            results2.Add("生命",0);
            results2.Add("类型",1);
            results2.Add("宽比",2);
            results2.Add("高比",3);
            results2.Add("R",4);
            results2.Add("G",5);
            results2.Add("B",6);
            results2.Add("不透明度",7);
            results2.Add("朝向",8);
            results2.Add("子弹速度",9);
            results2.Add("子弹速度方向",10);
            results2.Add("子弹加速度",11);
            results2.Add("子弹加速度方向",12);
            results2.Add("横比",13);
            results2.Add("纵比",14);
            results2.Add("雾化效果",15);
            results2.Add("消除效果",16);
            results2.Add("高光效果",17);
            results2.Add("拖影效果",18);
            results2.Add("出屏即消",19);
            results2.Add("无敌状态",20);
            results3.Add("速度",0);
            results3.Add("速度方向",1);
            results3.Add("加速度",2);
            results3.Add("加速度方向",3);
            cconditions.Add("",0);
            cconditions.Add("当前帧",0);
            cconditions.Add("X坐标",1);
            cconditions.Add("Y坐标",2);
            cconditions.Add("半宽",3);
            cconditions.Add("半高",4);
            cresults.Add("半宽",0);
            cresults.Add("半高",1);
            cresults.Add("启用圆形",2);
            cresults.Add("速度",3);
            cresults.Add("速度方向",4);
            cresults.Add("加速度",5);
            cresults.Add("加速度方向",6);
            cresults.Add("类型",7);
            cresults.Add("ID",8);
            cresults.Add("X坐标",9);
            cresults.Add("Y坐标",10);
            lconditions.Add("",0);
            lconditions.Add("当前帧",0);
            lconditions.Add("半径",1);
            lconditions.Add("半径方向",2);
            lconditions.Add("条数",3);
            lconditions.Add("周期",4);
            lconditions.Add("角度",5);
            lconditions.Add("范围",6);
            lconditions.Add("宽比",7);
            lconditions.Add("长度",8);
            lconditions.Add("不透明度",9);
            lresults.Add("半径",0);
            lresults.Add("半径方向",1);
            lresults.Add("条数",2);
            lresults.Add("周期",3);
            lresults.Add("角度",4);
            lresults.Add("范围",5);
            lresults.Add("速度",6);
            lresults.Add("速度方向",7);
            lresults.Add("加速度",8);
            lresults.Add("加速度方向",9);
            lresults.Add("生命",10);
            lresults.Add("类型",11);
            lresults.Add("宽比",12);
            lresults.Add("长度",13);
            lresults.Add("不透明度",14);
            lresults.Add("子弹速度",15);
            lresults.Add("子弹速度方向",16);
            lresults.Add("子弹加速度",17);
            lresults.Add("子弹加速度方向",18);
            lresults.Add("横比",19);
            lresults.Add("纵比",20);
            lresults.Add("高光效果",21);
            lresults.Add("出屏即消",22);
            lresults.Add("无敌状态",23);
            lresults2.Add("生命",0);
            lresults2.Add("类型",1);
            lresults2.Add("宽比",2);
            lresults2.Add("长度",3);
            lresults2.Add("不透明度",4);
            lresults2.Add("子弹速度",5);
            lresults2.Add("子弹速度方向",6);
            lresults2.Add("子弹加速度",7);
            lresults2.Add("子弹加速度方向",8);
            lresults2.Add("横比",9);
            lresults2.Add("纵比",10);
            lresults2.Add("高光效果",11);
            lresults2.Add("出屏即消",12);
            lresults2.Add("无敌状态",13);
        }

        public static void updateAll() {
            frame++;
            Time.Update();
            Th902Interface.bullets.Clear();
            for(int index1 = 0;index1<Layer.LayerArray.Count;++index1) {
                Th902Interface.bullets.AddRange(Layer.LayerArray[index1].Barrages);
            }

            for(int index = 0;index<Layer.LayerArray.Count;++index) {
                Layer.LayerArray[index].sort=index;
                Layer.LayerArray[index].Update();
            }

            for(int index1 = 0;index1<Layer.LayerArray.Count;++index1) {
                if(Layer.LayerArray[index1].Visible&!Time.Playing) {
                    for(int index2 = 0;index2<Layer.LayerArray[index1].ForceArray.Count;++index2) {
                        if(Layer.LayerArray[index1].ForceArray[index2].NeedDelete) {
                            Layer.LayerArray[index1].ForceArray.RemoveAt(index2);
                        }
                    }
                    for(int index2 = 0;index2<Layer.LayerArray[index1].ReboundArray.Count;++index2) {
                        if(Layer.LayerArray[index1].ReboundArray[index2].NeedDelete) {
                            Layer.LayerArray[index1].ReboundArray.RemoveAt(index2);
                        }
                    }
                    for(int index2 = 0;index2<Layer.LayerArray[index1].CoverArray.Count;++index2) {
                        if(Layer.LayerArray[index1].CoverArray[index2].NeedDelete) {
                            Layer.LayerArray[index1].CoverArray.RemoveAt(index2);
                        }
                    }
                    for(int index2 = 0;index2<Layer.LayerArray[index1].LaseArray.Count;++index2) {
                        if(Layer.LayerArray[index1].LaseArray[index2].NeedDelete) {
                            Layer.LayerArray[index1].LaseArray.RemoveAt(index2);
                        }
                    }
                    for(int index2 = 0;index2<Layer.LayerArray[index1].BatchArray.Count;++index2) {
                        if(Layer.LayerArray[index1].BatchArray[index2].NeedDelete) {
                            Layer.LayerArray[index1].BatchArray.RemoveAt(index2);
                        }
                    }
                }
                for(int index2 = 0;index2<Layer.LayerArray[index1].Barrages.Count;++index2) {
                    if(Layer.LayerArray[index1].Barrages[index2].Blend) {
                        if(!Layer.LayerArray[index1].Barrages[index2].NeedDelete) {
                        } else {
                            Layer.LayerArray[index1].Barrages.RemoveAt(index2);
                            --index2;
                        }
                    }
                }
                for(int index2 = 0;index2<Layer.LayerArray[index1].Barrages.Count;++index2) {
                    if(!Layer.LayerArray[index1].Barrages[index2].Blend) {
                        if(!Layer.LayerArray[index1].Barrages[index2].NeedDelete) {
                        } else {
                            Layer.LayerArray[index1].Barrages.RemoveAt(index2);
                            --index2;
                        }
                    }
                }
            }

            for(int index = 0;index<Layer.LayerArray.Count;++index) {
                if(Layer.LayerArray[index].NeedDelete) {
                    Layer.LayerArray.RemoveAt(index);
                }
            }
            Center.Update();
        }

        public static string Cuts(string word,string num,int array) {
            char[] charArray = num.ToCharArray();
            return word.Split(charArray)[array-1];
        }

        public static float Twopointangle(float x2,float y2,float x1,float y1) {
            float num = x2-(double)x1==0.0 ? (float)Math.Atan((y2-(double)y1)/(x2-(double)x1+0.100000001490116)) : (float)Math.Atan((y2-(double)y1)/(x2-(double)x1));
            if(x2-(double)x1<0.0) {
                num+=3.141593f;
            }
            return num;
        }

        private static float CrossMul(Vector2 pt1,Vector2 pt2) {
            return (float)((double)pt1.X*pt2.Y-pt1.Y*(double)pt2.X);
        }

        private static bool CheckCrose(Line line1,Line line2) {
            Vector2 pt1_1 = new Vector2();
            Vector2 pt1_2 = new Vector2();
            Vector2 pt2 = new Vector2();
            pt1_1.X=line2.Start.X-line1.End.X;
            pt1_1.Y=line2.Start.Y-line1.End.Y;
            pt1_2.X=line2.End.X-line1.End.X;
            pt1_2.Y=line2.End.Y-line1.End.Y;
            pt2.X=line1.Start.X-line1.End.X;
            pt2.Y=line1.Start.Y-line1.End.Y;
            return (double)CrossMul(pt1_1,pt2)*CrossMul(pt1_2,pt2)<=0.0;
        }

        public static bool CheckTwoLineCrose(Line line1,Line line2) {
            if(CheckCrose(line1,line2)) {
                return CheckCrose(line2,line1);
            }
            return false;
        }
        public static void OpenMbgFile(string path) {
            StreamReader streamReader = new StreamReader(path);
            if(streamReader.ReadLine()=="Crazy Storm Data 1.01") {
                Available=true;
                Layer.Clear();
                Center.Clear();
                Time.Clear();
                GC.Collect();
                string source = streamReader.ReadLine();
                if(source.Contains("GlobalEvents")) {
                    int num1 = int.Parse(source.Split(' ')[0]);
                    for(int index = 0;index<num1;++index) {
                        string str = streamReader.ReadLine();
                        Time.GEcount.Add(int.Parse(str.Split('_')[0])-1);
                        GlobalEvent globalEvent = new GlobalEvent {
                            gotocondition=int.Parse(str.Split('_')[1]),
                            gotoopreator=str.Split('_')[2],
                            gotocvalue=int.Parse(str.Split('_')[3]),
                            isgoto=(bool.Parse(str.Split('_')[4]) ? 1 : 0)!=0,
                            gototime=int.Parse(str.Split('_')[5]),
                            gotowhere=int.Parse(str.Split('_')[6]),
                            quakecondition=int.Parse(str.Split('_')[7]),
                            quakeopreator=str.Split('_')[8],
                            quakecvalue=int.Parse(str.Split('_')[9]),
                            isquake=(bool.Parse(str.Split('_')[10]) ? 1 : 0)!=0,
                            quaketime=int.Parse(str.Split('_')[11]),
                            quakelevel=int.Parse(str.Split('_')[12]),
                            stopcondition=int.Parse(str.Split('_')[13]),
                            stopopreator=str.Split('_')[14],
                            stopcvalue=int.Parse(str.Split('_')[15]),
                            isstop=(bool.Parse(str.Split('_')[16]) ? 1 : 0)!=0,
                            stoptime=int.Parse(str.Split('_')[17]),
                            stoplevel=int.Parse(str.Split('_')[18])
                        };
                        if(Time.GE.Count<int.Parse(str.Split('_')[0])) {
                            int num2 = 0;
                            while(true) {
                                if(num2<int.Parse(str.Split('_')[0])) {
                                    Time.GE.Add(new GlobalEvent() {
                                        gotocondition=-1,
                                        quakecondition=-1,
                                        stopcondition=-1,
                                        stoplevel=-1
                                    });
                                    ++num2;
                                } else {
                                    break;
                                }
                            }
                        }
                        Time.GE[int.Parse(str.Split('_')[0])-1]=globalEvent;
                    }
                    source=streamReader.ReadLine();
                }
                if(source.Contains("Sounds")) {
                    int num = int.Parse(source.Split(' ')[0]);
                    for(int index = 0;index<num;++index) {
                        streamReader.ReadLine();
                    }
                    source=streamReader.ReadLine();
                }
                if(source.Contains(",")) {
                    Center.Available=true;
                    Center.x=float.Parse(source.Split(':')[1].Split(',')[0]);
                    Center.y=float.Parse(source.Split(':')[1].Split(',')[1]);
                    if(source.Split(':')[1].Split(',').Length>=7) {
                        Center.speed=float.Parse(source.Split(':')[1].Split(',')[2]);
                        Center.speedd=float.Parse(source.Split(':')[1].Split(',')[3]);
                        Center.aspeed=float.Parse(source.Split(':')[1].Split(',')[4]);
                        Center.aspeedd=float.Parse(source.Split(':')[1].Split(',')[5]);
                        int index = 0;
                        while(true) {
                            if(index<source.Split(':')[1].Split(',')[6].Split(';').Length-1) {
                                Center.events.Add(source.Split(':')[1].Split(',')[6].Split(';')[index]);
                                ++index;
                            } else
                                break;
                        }
                    }
                } else {
                    Center.Available=false;
                }
                Time.total=int.Parse(streamReader.ReadLine().Split(':')[1]);
                for(int index1 = 0;index1<4;++index1) {
                    string str1 = streamReader.ReadLine();
                    if(str1.Split(':')[1].Split(',')[0]!="empty") {
                        Layer layer = new Layer(str1.Split(':')[1].Split(',')[0],int.Parse(str1.Split(':')[1].Split(',')[1]),int.Parse(str1.Split(':')[1].Split(',')[2]));
                        int num1 = int.Parse(str1.Split(':')[1].Split(',')[3]);
                        for(int index2 = 0;index2<num1;++index2) {
                            string str2 = streamReader.ReadLine();
                            Batch batch = new Batch(float.Parse(str2.Split(',')[6]),float.Parse(str2.Split(',')[7]),Layer.LayerArray[Layer.LayerArray.Count-Layer.selection-1].color) {
                                id=int.Parse(str2.Split(',')[0]),
                                parentid=int.Parse(str2.Split(',')[1]),
                                Binding=(bool.Parse(str2.Split(',')[2]) ? 1 : 0)!=0,
                                bindid=int.Parse(str2.Split(',')[3]),
                                Bindwithspeedd=(bool.Parse(str2.Split(',')[4]) ? 1 : 0)!=0,
                                begin=int.Parse(str2.Split(',')[8]),
                                life=int.Parse(str2.Split(',')[9]),
                                fx=float.Parse(str2.Split(',')[10]),
                                fy=float.Parse(str2.Split(',')[11]),
                                r=int.Parse(str2.Split(',')[12]),
                                rdirection=float.Parse(str2.Split(',')[13])
                            };
                            string str3 = str2.Split(',')[14].Replace("{","").Replace("}","");
                            batch.rdirections.X=float.Parse(str3.Split(' ')[0].Split(':')[1]);
                            batch.rdirections.Y=float.Parse(str3.Split(' ')[1].Split(':')[1]);
                            batch.tiao=int.Parse(str2.Split(',')[15]);
                            batch.t=int.Parse(str2.Split(',')[16]);
                            batch.fdirection=float.Parse(str2.Split(',')[17]);
                            string str4 = str2.Split(',')[18].Replace("{","").Replace("}","");
                            batch.fdirections.X=float.Parse(str4.Split(' ')[0].Split(':')[1]);
                            batch.fdirections.Y=float.Parse(str4.Split(' ')[1].Split(':')[1]);
                            batch.range=int.Parse(str2.Split(',')[19]);
                            batch.speed=float.Parse(str2.Split(',')[20]);
                            batch.speedd=float.Parse(str2.Split(',')[21]);
                            string str5 = str2.Split(',')[22].Replace("{","").Replace("}","");
                            batch.speedds.X=float.Parse(str5.Split(' ')[0].Split(':')[1]);
                            batch.speedds.Y=float.Parse(str5.Split(' ')[1].Split(':')[1]);
                            batch.aspeed=float.Parse(str2.Split(',')[23]);
                            batch.aspeedd=float.Parse(str2.Split(',')[24]);
                            string str6 = str2.Split(',')[25].Replace("{","").Replace("}","");
                            batch.aspeedds.X=float.Parse(str6.Split(' ')[0].Split(':')[1]);
                            batch.aspeedds.Y=float.Parse(str6.Split(' ')[1].Split(':')[1]);
                            batch.sonlife=int.Parse(str2.Split(',')[26]);
                            batch.type=(float)int.Parse(str2.Split(',')[27]);
                            batch.wscale=float.Parse(str2.Split(',')[28]);
                            batch.hscale=float.Parse(str2.Split(',')[29]);
                            batch.colorR=(float)int.Parse(str2.Split(',')[30]);
                            batch.colorG=(float)int.Parse(str2.Split(',')[31]);
                            batch.colorB=(float)int.Parse(str2.Split(',')[32]);
                            batch.alpha=(float)int.Parse(str2.Split(',')[33]);
                            batch.head=float.Parse(str2.Split(',')[34]);
                            string str7 = str2.Split(',')[35].Replace("{","").Replace("}","");
                            batch.heads.X=float.Parse(str7.Split(' ')[0].Split(':')[1]);
                            batch.heads.Y=float.Parse(str7.Split(' ')[1].Split(':')[1]);
                            batch.Withspeedd=(bool.Parse(str2.Split(',')[36]) ? 1 : 0)!=0;
                            batch.sonspeed=float.Parse(str2.Split(',')[37]);
                            batch.sonspeedd=float.Parse(str2.Split(',')[38]);
                            string str8 = str2.Split(',')[39].Replace("{","").Replace("}","");
                            batch.sonspeedds.X=float.Parse(str8.Split(' ')[0].Split(':')[1]);
                            batch.sonspeedds.Y=float.Parse(str8.Split(' ')[1].Split(':')[1]);
                            batch.sonaspeed=float.Parse(str2.Split(',')[40]);
                            batch.sonaspeedd=float.Parse(str2.Split(',')[41]);
                            string str9 = str2.Split(',')[42].Replace("{","").Replace("}","");
                            batch.sonaspeedds.X=float.Parse(str9.Split(' ')[0].Split(':')[1]);
                            batch.sonaspeedds.Y=float.Parse(str9.Split(' ')[1].Split(':')[1]);
                            batch.xscale=float.Parse(str2.Split(',')[43]);
                            batch.yscale=float.Parse(str2.Split(',')[44]);
                            batch.Mist=(bool.Parse(str2.Split(',')[45]) ? 1 : 0)!=0;
                            batch.Dispel=(bool.Parse(str2.Split(',')[46]) ? 1 : 0)!=0;
                            batch.Blend=(bool.Parse(str2.Split(',')[47]) ? 1 : 0)!=0;
                            batch.Afterimage=(bool.Parse(str2.Split(',')[48]) ? 1 : 0)!=0;
                            batch.Outdispel=(bool.Parse(str2.Split(',')[49]) ? 1 : 0)!=0;
                            batch.Invincible=(bool.Parse(str2.Split(',')[50]) ? 1 : 0)!=0;
                            string str10 = str2.Split(',')[51];
                            int idx1 = 0;
                            while(true) {
                                if(idx1<str10.Split('&').Length-1) {
                                    string str11 = str10.Split('&')[idx1];
                                    Event @event = new Event(idx1) {
                                        tag=str11.Split('|')[0],
                                        t=int.Parse(str11.Split('|')[1]),
                                        addtime=int.Parse(str11.Split('|')[2])
                                    };
                                    int index3 = 0;
                                    while(true) {
                                        if(index3<str11.Split('|')[3].Split(';').Length-1) {
                                            @event.events.Add(str11.Split('|')[3].Split(';')[index3]);
                                            ++index3;
                                        } else
                                            break;
                                    }
                                    batch.Parentevents.Add(@event);
                                    ++idx1;
                                } else
                                    break;
                            }
                            string str12 = str2.Split(',')[52];
                            int idx2 = 0;
                            while(true) {
                                if(idx2<str12.Split('&').Length-1) {
                                    string str11 = str12.Split('&')[idx2];
                                    Event @event = new Event(idx2) {
                                        tag=str11.Split('|')[0],
                                        t=int.Parse(str11.Split('|')[1]),
                                        addtime=int.Parse(str11.Split('|')[2])
                                    };
                                    int index3 = 0;
                                    while(true) {
                                        if(index3<str11.Split('|')[3].Split(';').Length-1) {
                                            @event.events.Add(str11.Split('|')[3].Split(';')[index3]);
                                            ++index3;
                                        } else {
                                            break;
                                        }
                                    }
                                    batch.Sonevents.Add(@event);
                                    ++idx2;
                                } else {
                                    break;
                                }
                            }
                            batch.rand.fx=float.Parse(str2.Split(',')[53]);
                            batch.rand.fy=float.Parse(str2.Split(',')[54]);
                            batch.rand.r=(float)int.Parse(str2.Split(',')[55]);
                            batch.rand.rdirection=float.Parse(str2.Split(',')[56]);
                            batch.rand.tiao=int.Parse(str2.Split(',')[57]);
                            batch.rand.t=int.Parse(str2.Split(',')[58]);
                            batch.rand.fdirection=float.Parse(str2.Split(',')[59]);
                            batch.rand.range=int.Parse(str2.Split(',')[60]);
                            batch.rand.speed=float.Parse(str2.Split(',')[61]);
                            batch.rand.speedd=float.Parse(str2.Split(',')[62]);
                            batch.rand.aspeed=float.Parse(str2.Split(',')[63]);
                            batch.rand.aspeedd=float.Parse(str2.Split(',')[64]);
                            batch.rand.head=float.Parse(str2.Split(',')[65]);
                            batch.rand.sonspeed=float.Parse(str2.Split(',')[66]);
                            batch.rand.sonspeedd=float.Parse(str2.Split(',')[67]);
                            batch.rand.sonaspeed=float.Parse(str2.Split(',')[68]);
                            batch.rand.sonaspeedd=float.Parse(str2.Split(',')[69]);
                            if(str2.Split(',').Length>=72) {
                                batch.Cover=(bool.Parse(str2.Split(',')[70]) ? 1 : 0)!=0;
                                batch.Rebound=(bool.Parse(str2.Split(',')[71]) ? 1 : 0)!=0;
                                batch.Force=(bool.Parse(str2.Split(',')[72]) ? 1 : 0)!=0;
                            }
                            if(str2.Split(',').Length>=74)
                                batch.Deepbind=(bool.Parse(str2.Split(',')[73]) ? 1 : 0)!=0;
                            Layer.LayerArray[index1].BatchArray.Add(batch);
                        }
                        if(str1.Split(':')[1].Split(',').Length>=7) {
                            int num2 = int.Parse(str1.Split(':')[1].Split(',')[4]);
                            for(int index2 = 0;index2<num2;++index2) {
                                string str2 = streamReader.ReadLine();
                                Lase lase = new Lase(float.Parse(str2.Split(',')[6]),float.Parse(str2.Split(',')[7]),Layer.LayerArray[Layer.LayerArray.Count-Layer.selection-1].color) {
                                    id=int.Parse(str2.Split(',')[0]),
                                    parentid=int.Parse(str2.Split(',')[1]),
                                    Binding=(bool.Parse(str2.Split(',')[2]) ? 1 : 0)!=0,
                                    bindid=int.Parse(str2.Split(',')[3]),
                                    Bindwithspeedd=(bool.Parse(str2.Split(',')[4]) ? 1 : 0)!=0,
                                    begin=int.Parse(str2.Split(',')[8]),
                                    life=int.Parse(str2.Split(',')[9]),
                                    r=(float)int.Parse(str2.Split(',')[10]),
                                    rdirection=float.Parse(str2.Split(',')[11])
                                };
                                string str3 = str2.Split(',')[12].Replace("{","").Replace("}","");
                                lase.rdirections.X=float.Parse(str3.Split(' ')[0].Split(':')[1]);
                                lase.rdirections.Y=float.Parse(str3.Split(' ')[1].Split(':')[1]);
                                lase.tiao=int.Parse(str2.Split(',')[13]);
                                lase.t=int.Parse(str2.Split(',')[14]);
                                lase.fdirection=float.Parse(str2.Split(',')[15]);
                                string str4 = str2.Split(',')[16].Replace("{","").Replace("}","");
                                lase.fdirections.X=float.Parse(str4.Split(' ')[0].Split(':')[1]);
                                lase.fdirections.Y=float.Parse(str4.Split(' ')[1].Split(':')[1]);
                                lase.range=int.Parse(str2.Split(',')[17]);
                                lase.speed=float.Parse(str2.Split(',')[18]);
                                lase.speedd=float.Parse(str2.Split(',')[19]);
                                string str5 = str2.Split(',')[20].Replace("{","").Replace("}","");
                                lase.speedds.X=float.Parse(str5.Split(' ')[0].Split(':')[1]);
                                lase.speedds.Y=float.Parse(str5.Split(' ')[1].Split(':')[1]);
                                lase.aspeed=float.Parse(str2.Split(',')[21]);
                                lase.aspeedd=float.Parse(str2.Split(',')[22]);
                                string str6 = str2.Split(',')[23].Replace("{","").Replace("}","");
                                lase.aspeedds.X=float.Parse(str6.Split(' ')[0].Split(':')[1]);
                                lase.aspeedds.Y=float.Parse(str6.Split(' ')[1].Split(':')[1]);
                                lase.sonlife=int.Parse(str2.Split(',')[24]);
                                lase.type=(float)int.Parse(str2.Split(',')[25]);
                                lase.wscale=float.Parse(str2.Split(',')[26]);
                                lase.longs=float.Parse(str2.Split(',')[27]);
                                lase.alpha=(float)int.Parse(str2.Split(',')[28]);
                                lase.Ray=(bool.Parse(str2.Split(',')[29]) ? 1 : 0)!=0;
                                lase.sonspeed=float.Parse(str2.Split(',')[30]);
                                lase.sonspeedd=float.Parse(str2.Split(',')[31]);
                                string str7 = str2.Split(',')[32].Replace("{","").Replace("}","");
                                lase.sonspeedds.X=float.Parse(str7.Split(' ')[0].Split(':')[1]);
                                lase.sonspeedds.Y=float.Parse(str7.Split(' ')[1].Split(':')[1]);
                                lase.sonaspeed=float.Parse(str2.Split(',')[33]);
                                lase.sonaspeedd=float.Parse(str2.Split(',')[34]);
                                string str8 = str2.Split(',')[35].Replace("{","").Replace("}","");
                                lase.sonaspeedds.X=float.Parse(str8.Split(' ')[0].Split(':')[1]);
                                lase.sonaspeedds.Y=float.Parse(str8.Split(' ')[1].Split(':')[1]);
                                lase.xscale=float.Parse(str2.Split(',')[36]);
                                lase.yscale=float.Parse(str2.Split(',')[37]);
                                lase.Blend=(bool.Parse(str2.Split(',')[38]) ? 1 : 0)!=0;
                                lase.Outdispel=(bool.Parse(str2.Split(',')[39]) ? 1 : 0)!=0;
                                lase.Invincible=(bool.Parse(str2.Split(',')[40]) ? 1 : 0)!=0;
                                string str9 = str2.Split(',')[42];
                                int idx1 = 0;
                                while(true) {
                                    if(idx1<str9.Split('&').Length-1) {
                                        string str10 = str9.Split('&')[idx1];
                                        Event @event = new Event(idx1) {
                                            tag=str10.Split('|')[0],
                                            t=int.Parse(str10.Split('|')[1]),
                                            addtime=int.Parse(str10.Split('|')[2])
                                        };
                                        int index3 = 0;
                                        while(true) {
                                            if(index3<str10.Split('|')[3].Split(';').Length-1) {
                                                @event.events.Add(str10.Split('|')[3].Split(';')[index3]);
                                                ++index3;
                                            } else
                                                break;
                                        }
                                        lase.Parentevents.Add(@event);
                                        ++idx1;
                                    } else
                                        break;
                                }
                                string str11 = str2.Split(',')[43];
                                int idx2 = 0;
                                while(true) {
                                    if(idx2<str11.Split('&').Length-1) {
                                        string str10 = str11.Split('&')[idx2];
                                        Event @event = new Event(idx2) {
                                            tag=str10.Split('|')[0],
                                            t=int.Parse(str10.Split('|')[1]),
                                            addtime=int.Parse(str10.Split('|')[2])
                                        };
                                        int index3 = 0;
                                        while(true) {
                                            if(index3<str10.Split('|')[3].Split(';').Length-1) {
                                                @event.events.Add(str10.Split('|')[3].Split(';')[index3]);
                                                ++index3;
                                            } else
                                                break;
                                        }
                                        lase.Sonevents.Add(@event);
                                        ++idx2;
                                    } else
                                        break;
                                }
                                lase.rand.r=(float)int.Parse(str2.Split(',')[44]);
                                lase.rand.rdirection=float.Parse(str2.Split(',')[45]);
                                lase.rand.tiao=int.Parse(str2.Split(',')[46]);
                                lase.rand.t=int.Parse(str2.Split(',')[47]);
                                lase.rand.fdirection=float.Parse(str2.Split(',')[48]);
                                lase.rand.range=int.Parse(str2.Split(',')[49]);
                                lase.rand.speed=float.Parse(str2.Split(',')[50]);
                                lase.rand.speedd=float.Parse(str2.Split(',')[51]);
                                lase.rand.aspeed=float.Parse(str2.Split(',')[52]);
                                lase.rand.aspeedd=float.Parse(str2.Split(',')[53]);
                                lase.rand.sonspeed=float.Parse(str2.Split(',')[54]);
                                lase.rand.sonspeedd=float.Parse(str2.Split(',')[55]);
                                lase.rand.sonaspeed=float.Parse(str2.Split(',')[56]);
                                lase.rand.sonaspeedd=float.Parse(str2.Split(',')[57]);
                                if(str2.Split(',').Length>=59)
                                    lase.Deepbind=(bool.Parse(str2.Split(',')[58]) ? 1 : 0)!=0;
                                Layer.LayerArray[index1].LaseArray.Add(lase);
                            }
                            int num3 = int.Parse(str1.Split(':')[1].Split(',')[5]);
                            for(int index2 = 0;index2<num3;++index2) {
                                string str2 = streamReader.ReadLine();
                                Cover cover = new Cover(float.Parse(str2.Split(',')[2]),float.Parse(str2.Split(',')[3]),Layer.LayerArray[Layer.LayerArray.Count-Layer.selection-1].color) {
                                    id=int.Parse(str2.Split(',')[0]),
                                    parentid=int.Parse(str2.Split(',')[1]),
                                    begin=int.Parse(str2.Split(',')[4]),
                                    life=int.Parse(str2.Split(',')[5]),
                                    halfw=int.Parse(str2.Split(',')[6]),
                                    halfh=int.Parse(str2.Split(',')[7]),
                                    Circle=(bool.Parse(str2.Split(',')[8]) ? 1 : 0)!=0,
                                    type=int.Parse(str2.Split(',')[9]),
                                    controlid=int.Parse(str2.Split(',')[10]),
                                    speed=float.Parse(str2.Split(',')[11]),
                                    speedd=float.Parse(str2.Split(',')[12])
                                };
                                string str3 = str2.Split(',')[13].Replace("{","").Replace("}","");
                                cover.speedds.X=float.Parse(str3.Split(' ')[0].Split(':')[1]);
                                cover.speedds.Y=float.Parse(str3.Split(' ')[1].Split(':')[1]);
                                cover.aspeed=float.Parse(str2.Split(',')[14]);
                                cover.aspeedd=float.Parse(str2.Split(',')[15]);
                                string str4 = str2.Split(',')[16].Replace("{","").Replace("}","");
                                cover.aspeedds.X=float.Parse(str4.Split(' ')[0].Split(':')[1]);
                                cover.aspeedds.Y=float.Parse(str4.Split(' ')[1].Split(':')[1]);
                                string str5 = str2.Split(',')[17];
                                int idx1 = 0;
                                while(true) {
                                    if(idx1<str5.Split('&').Length-1) {
                                        string str6 = str5.Split('&')[idx1];
                                        Event @event = new Event(idx1) {
                                            tag=str6.Split('|')[0],
                                            t=int.Parse(str6.Split('|')[1]),
                                            addtime=int.Parse(str6.Split('|')[2])
                                        };
                                        int index3 = 0;
                                        while(true) {
                                            if(index3<str6.Split('|')[3].Split(';').Length-1) {
                                                @event.events.Add(str6.Split('|')[3].Split(';')[index3]);
                                                ++index3;
                                            } else
                                                break;
                                        }
                                        cover.Parentevents.Add(@event);
                                        ++idx1;
                                    } else
                                        break;
                                }
                                string str7 = str2.Split(',')[18];
                                int idx2 = 0;
                                while(true) {
                                    if(idx2<str7.Split('&').Length-1) {
                                        string str6 = str7.Split('&')[idx2];
                                        Event @event = new Event(idx2) {
                                            tag=str6.Split('|')[0],
                                            t=int.Parse(str6.Split('|')[1]),
                                            addtime=int.Parse(str6.Split('|')[2])
                                        };
                                        int index3 = 0;
                                        while(true) {
                                            if(index3<str6.Split('|')[3].Split(';').Length-1) {
                                                @event.events.Add(str6.Split('|')[3].Split(';')[index3]);
                                                ++index3;
                                            } else
                                                break;
                                        }
                                        cover.Sonevents.Add(@event);
                                        ++idx2;
                                    } else
                                        break;
                                }
                                cover.rand.speed=float.Parse(str2.Split(',')[19]);
                                cover.rand.speedd=float.Parse(str2.Split(',')[20]);
                                cover.rand.aspeed=float.Parse(str2.Split(',')[21]);
                                cover.rand.aspeedd=float.Parse(str2.Split(',')[22]);
                                if(str2.Split(',').Length>=24)
                                    cover.bindid=int.Parse(str2.Split(',')[23]);
                                if(str2.Split(',').Length>=25) {
                                    if(str2.Split(',')[24]!="")
                                        cover.Deepbind=(bool.Parse(str2.Split(',')[24]) ? 1 : 0)!=0;
                                }
                                Layer.LayerArray[index1].CoverArray.Add(cover);
                            }
                            int num4 = int.Parse(str1.Split(':')[1].Split(',')[6]);
                            for(int index2 = 0;index2<num4;++index2) {
                                string str2 = streamReader.ReadLine();
                                Rebound rebound = new Rebound(float.Parse(str2.Split(',')[2]),float.Parse(str2.Split(',')[3]),Layer.LayerArray[Layer.LayerArray.Count-Layer.selection-1].color) {
                                    id=int.Parse(str2.Split(',')[0]),
                                    parentid=int.Parse(str2.Split(',')[1]),
                                    begin=int.Parse(str2.Split(',')[4]),
                                    life=int.Parse(str2.Split(',')[5]),
                                    longs=int.Parse(str2.Split(',')[6]),
                                    angle=(float)int.Parse(str2.Split(',')[7]),
                                    time=int.Parse(str2.Split(',')[8]),
                                    speed=float.Parse(str2.Split(',')[9]),
                                    speedd=float.Parse(str2.Split(',')[10]),
                                    aspeed=float.Parse(str2.Split(',')[11]),
                                    aspeedd=float.Parse(str2.Split(',')[12])
                                };
                                string str3 = str2.Split(',')[13];
                                int idx = 0;
                                while(true) {
                                    if(idx<str3.Split('&').Length-1) {
                                        string str4 = str3.Split('&')[idx];
                                        rebound.Parentevents.Add(new Event(idx) {
                                            tag=str4
                                        });
                                        ++idx;
                                    } else
                                        break;
                                }
                                rebound.rand.speed=float.Parse(str2.Split(',')[14]);
                                rebound.rand.speedd=float.Parse(str2.Split(',')[15]);
                                rebound.rand.aspeed=float.Parse(str2.Split(',')[16]);
                                rebound.rand.aspeedd=float.Parse(str2.Split(',')[17]);
                                Layer.LayerArray[index1].ReboundArray.Add(rebound);
                            }
                            int num5 = int.Parse(str1.Split(':')[1].Split(',')[7]);
                            for(int index2 = 0;index2<num5;++index2) {
                                string str2 = streamReader.ReadLine();
                                Layer.LayerArray[index1].ForceArray.Add(new Force(float.Parse(str2.Split(',')[2]),float.Parse(str2.Split(',')[3]),Layer.LayerArray[Layer.LayerArray.Count-Layer.selection-1].color) {
                                    id=int.Parse(str2.Split(',')[0]),
                                    parentid=int.Parse(str2.Split(',')[1]),
                                    begin=int.Parse(str2.Split(',')[4]),
                                    life=int.Parse(str2.Split(',')[5]),
                                    halfw=int.Parse(str2.Split(',')[6]),
                                    halfh=int.Parse(str2.Split(',')[7]),
                                    Circle=(bool.Parse(str2.Split(',')[8]) ? 1 : 0)!=0,
                                    type=int.Parse(str2.Split(',')[9]),
                                    controlid=int.Parse(str2.Split(',')[10]),
                                    speed=float.Parse(str2.Split(',')[11]),
                                    speedd=float.Parse(str2.Split(',')[12]),
                                    aspeed=float.Parse(str2.Split(',')[13]),
                                    aspeedd=float.Parse(str2.Split(',')[14]),
                                    addaspeed=float.Parse(str2.Split(',')[15]),
                                    addaspeedd=float.Parse(str2.Split(',')[16]),
                                    Suction=(bool.Parse(str2.Split(',')[17]) ? 1 : 0)!=0,
                                    Repulsion=(bool.Parse(str2.Split(',')[18]) ? 1 : 0)!=0,
                                    addspeed=float.Parse(str2.Split(',')[19]),
                                    rand= {
                    speed = float.Parse(str2.Split(',')[20]),
                    speedd = float.Parse(str2.Split(',')[21]),
                    aspeed = float.Parse(str2.Split(',')[22]),
                    aspeedd = float.Parse(str2.Split(',')[23])
                  }
                                });
                            }
                        }
                    }
                }
            } else {
            }
            streamReader.Close();
        }



    }
}
