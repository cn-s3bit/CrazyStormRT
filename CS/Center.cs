using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CrazyStorm_1._03 {
    public class Center {
        public static float ox = 315f;
        public static float oy = 240f;
        public static float ospeed = 0.0f;
        public static float ospeedd = 0.0f;
        public static float oaspeed = 0.0f;
        public static float oaspeedd = 0.0f;
        public static float speedx = 0.0f;
        public static float speedy = 0.0f;
        public static float aspeedx = 0.0f;
        public static float aspeedy = 0.0f;
        public static float x = 315f;
        public static float y = 240f;
        public static float speed = 0.0f;
        public static float speedd = 0.0f;
        public static float aspeed = 0.0f;
        public static float aspeedd = 0.0f;
        public static List<string> events = new List<string>();
        public static bool Available = true;
        public static bool Aim = false;
        public static List<Event> Events = new List<Event>();
        public static List<CExecution> Eventsexe = new List<CExecution>();

        public static void Clear() {
            x=315f;
            y=240f;
            speed=0.0f;
            speedd=0.0f;
            aspeed=0.0f;
            aspeedd=0.0f;
            ox=x;
            oy=y;
            ospeed=speed;
            ospeedd=speedd;
            oaspeed=aspeed;
            oaspeedd=aspeedd;
            speedx=0.0f;
            speedy=0.0f;
            aspeedx=0.0f;
            aspeedy=0.0f;
            events=new List<string>();
            Available=true;
        }

        public static void Update() {
            speedx+=aspeedx;
            speedy+=aspeedy;
            ox+=speedx;
            oy+=speedy;
            Hashtable hashtable1 = new Hashtable();
            Hashtable hashtable2 = new Hashtable();
            hashtable1.Add("当前帧",Time.now);
            hashtable2.Add("速度",ospeed);
            hashtable2.Add("速度方向",ospeedd);
            hashtable2.Add("加速度",oaspeed);
            hashtable2.Add("加速度方向",oaspeedd);
            foreach(string str1 in events) {
                if(!str1.Contains("PlayMusic")&&!str1.Contains("UseKira")&&!str1.Contains("BanSound")) {
                    string s = str1.Split('：')[0];
                    string str2 = "";
                    string str3 = "";
                    string str4 = str1.Split('：')[1];
                    int num1 = 0;
                    string str5 = "";
                    int num2 = 0;
                    string str6 = "";
                    float num3 = 0.0f;
                    int num4 = 0;
                    if(s.Contains("=")) {
                        str2=s.Split('=')[0];
                        str3="=";
                        s=s.Split('=')[1];
                    }
                    if(str3=="="&&(double)float.Parse(hashtable1[str2].ToString())==float.Parse(s)) {
                        if(str1.Contains("变化到")) {
                            num1=0;
                            string[] strArray = str4.Split("变化到".ToCharArray())[3].Split("，".ToCharArray());
                            num2=(int)Main.results3[str4.Split("变化到".ToCharArray())[0]];
                            str6=str4.Split("变化到".ToCharArray())[0];
                            if(strArray[0].Contains('+')) {
                                num3=(float)(float.Parse(strArray[0].Split('+')[0])+(double)MathHelper.Lerp(-float.Parse(strArray[0].Split('+')[1]),float.Parse(strArray[0].Split('+')[1]),(float)Main.rand.NextDouble()));
                            } else {
                                num3=num2==1||num2==3 ? (!strArray[0].Contains("自机") ? float.Parse(strArray[0]) : MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,ox,oy))) : float.Parse(strArray[0]);
                            }
                            str5=strArray[1];
                            num4=int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                        } else if(str1.Contains("增加")) {
                            num1=1;
                            string[] strArray = str4.Split("增".ToCharArray())[1].Split("，".ToCharArray());
                            strArray[0]=strArray[0].Replace("加","");
                            num2=(int)Main.results3[str4.Split("增".ToCharArray())[0]];
                            str6=str4.Split("增".ToCharArray())[0];
                            if(strArray[0].Contains('+')) {
                                num3=(float)(float.Parse(strArray[0].Split('+')[0])+(double)MathHelper.Lerp(-float.Parse(strArray[0].Split('+')[1]),float.Parse(strArray[0].Split('+')[1]),(float)Main.rand.NextDouble()));
                            } else {
                                num3=num2==1||num2==3 ? (!strArray[0].Contains("自机") ? float.Parse(strArray[0]) : MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,ox,oy))) : float.Parse(strArray[0]);
                            }
                            str5=strArray[1];
                            num4=int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                        } else if(str1.Contains("减少")) {
                            num1=2;
                            string[] strArray = str4.Split("减少".ToCharArray())[2].Split("，".ToCharArray());
                            num2=(int)Main.results3[str4.Split("减少".ToCharArray())[0]];
                            str6=str4.Split("减少".ToCharArray())[0];
                            if(strArray[0].Contains('+')) {
                                num3=(float)(float.Parse(strArray[0].Split('+')[0])+(double)MathHelper.Lerp(-float.Parse(strArray[0].Split('+')[1]),float.Parse(strArray[0].Split('+')[1]),(float)Main.rand.NextDouble()));
                            } else {
                                num3=num2==1||num2==3 ? (!strArray[0].Contains("自机") ? float.Parse(strArray[0]) : MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,ox,oy))) : float.Parse(strArray[0]);
                            }
                            str5=strArray[1];
                            num4=int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                        }
                        if(str1.Contains("跟随自机")) {
                            Eventsexe.Add(new CExecution() {
                                changetype=3,
                                ctime=60
                            });
                        } else if(str1.Contains("范围移动")) {
                            Eventsexe.Add(new CExecution() {
                                changetype=4,
                                ctime=60,
                                value=MathHelper.Lerp(float.Parse(str1.Split('，')[1]),float.Parse(str1.Split('，')[2]),(float)Main.rand.NextDouble()),
                                value2=MathHelper.Lerp(float.Parse(str1.Split('，')[3]),float.Parse(str1.Split('，')[4]),(float)Main.rand.NextDouble())
                            });
                        } else {
                            CExecution cexecution = new CExecution() {
                                change=num1,
                                changetype=(int)Main.type[str5],
                                changevalue=num2,
                                value=num3,
                                region=hashtable2[str6].ToString(),
                                time=num4
                            };
                            cexecution.ctime=cexecution.time;
                            Eventsexe.Add(cexecution);
                        }
                    }
                }
            }
            for(int index = 0;index<Eventsexe.Count;++index) {
                if(!Eventsexe[index].NeedDelete) {
                    Eventsexe[index].Update();
                } else {
                    Eventsexe.RemoveAt(index);
                    --index;
                }
            }
        }
    }
}
