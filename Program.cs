using System;
using System.Windows.Forms;

namespace scripthelper
{
    class Program
    {
        public void need()
        {
            
        }
        static void Main(string[] args)
        {
            Console.Title = "Asteroi - v1.7.1";
            string[] ascript;
            string[] load = new string[20];
            Cool Garold = new Cool();
            long calc = DateTime.Now.Ticks / 1000;
            string hold = "";
            void saver(string hmmm, string hmm)
            {
                load[Convert.ToInt32(hmmm)] = hmm;
            }
            string callcrap(string hmmm)
            {
                return load[Convert.ToInt32(hmmm)];
            }
            ascript = System.IO.File.ReadAllText(args[0]).Split('\n');
            for (var I = 0; I < ascript.Length; I++)
            {
                switch (ascript[I].Split('_')[0].Trim())
                {
                    case "load":
                        load[Convert.ToInt32(ascript[I].Split('_')[2].Trim())] = ascript[I].Split('_')[1];
                        continue;
                    case "printload":
                        if(ascript[I].Split('%').Length > 1)
                        {
                            hold += load[Convert.ToInt32(ascript[I].Split('%')[1].Trim())];
                        } else
                        {
                            Console.WriteLine(load[Convert.ToInt32(ascript[I].Split('_')[1])] + hold);
                            hold = "";
                        }
                        continue;
                    case "print":
                        if (ascript[I].Split('%').Length > 1)
                        {
                            hold += ascript[I].Split('%')[1];
                        }
                        else
                        {
                            /*byte[] bytes = System.Text.Encoding.Default.GetBytes(ascript[I].Split('_')[1]);
                            byte[] bytes2 = System.Text.Encoding.Default.GetBytes(hold);
                            byte[] bytes3 = System.Text.Encoding.Default.GetBytes($"{System.Text.Encoding.Default.GetString(bytes)}{System.Text.Encoding.Default.GetString(bytes2)}");
                            Console.WriteLine(System.Text.Encoding.UTF8.GetString(bytes3)); // I have literally never had so much trouble combining to strings. what the actual f**k!????
                            */
                            Console.WriteLine(ascript[I].Split('_')[1] + hold);
                            hold = "";
                        }
                        continue;
                    case "wait":
                        System.Threading.Thread.Sleep(Convert.ToInt32(callcrap(ascript[I].Split('_')[1])));
                        continue;
                    case "goto":
                        I = Convert.ToInt32(ascript[I].Split('_')[1]);
                        continue;
                    case "if":
                        switch (ascript[I].Split('_')[1])
                        {
                            case "E":
                                if (load[1].Trim() == load[2].Trim())
                                {
                                    I = Convert.ToInt32(ascript[I].Split('_')[2]);
                                }
                                break;
                            case "N":
                                if (load[1].Trim() != load[2].Trim())
                                {
                                    I = Convert.ToInt32(ascript[I].Split('_')[2]);
                                }
                                break;
                            case "GR":
                                if (Convert.ToInt32(load[1]) > Convert.ToInt32(load[2]))
                                {
                                    I = Convert.ToInt32(ascript[I].Split('_')[2]);
                                }
                                break;
                            case "LS":
                                if (Convert.ToInt32(load[1]) < Convert.ToInt32(load[2]))
                                {
                                    I = Convert.ToInt32(ascript[I].Split('_')[2]);
                                }
                                break;
                            case "GE":
                                if (Convert.ToInt32(load[1]) >= Convert.ToInt32(load[2]))
                                {
                                    I = Convert.ToInt32(ascript[I].Split('_')[2]);
                                }
                                break;
                            case "LE":
                                if (Convert.ToInt32(load[1]) <= Convert.ToInt32(load[2]))
                                {
                                    I = Convert.ToInt32(ascript[I].Split('_')[2]);
                                }
                                break;
                        }
                        continue;
                    case "input":
                        saver(ascript[I].Split('_')[1], Console.ReadLine());
                        continue;
                    case "getsystemvar":
                        switch (ascript[I].Split('_')[1].Trim())
                        {
                            case "time":
                                saver(ascript[I].Split('_')[2], System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second);
                                break;
                            case "disk":
                                saver(ascript[I].Split('_')[2], System.IO.DriveInfo.GetDrives()[0].AvailableFreeSpace.ToString());
                                break;
                            case "user":
                                saver(ascript[I].Split('_')[2], Environment.UserName);
                                break;
                        }
                        continue;
                    case "math":
                        saver("1", new System.Data.DataTable().Compute(ascript[I].Split('_')[1], null).ToString());
                        continue;
                    case "shutdown":
                        System.Diagnostics.Process.Start("shutdown", "/f /s /t 0");
                        continue;
                    case "transfer":
                        saver(ascript[I].Split('_')[1], callcrap(ascript[I].Split('_')[2]));
                        continue;
                    case "mul":
                        switch (ascript[I].Split('_')[1].Trim())
                        {
                            case "times":
                                load[1] = (Convert.ToInt32(load[1]) * Convert.ToInt32(load[2])).ToString();
                                break;
                            case "add":
                                load[1] = (Convert.ToInt32(load[1]) + Convert.ToInt32(load[2])).ToString();
                                break;
                            case "sub":
                                load[1] = (Convert.ToInt32(load[1]) - Convert.ToInt32(load[2])).ToString();
                                break;
                            case "divide":
                                load[1] = (Convert.ToInt32(load[1]) / Convert.ToInt32(load[2])).ToString();
                                break;
                        }
                        continue;
                    case "end":
                        System.Threading.Thread.Sleep(1);
                        Console.WriteLine(" ");
                        Console.WriteLine("Press any key to close...");
                        Console.ReadKey();
                        continue;
                    case "open":
                        System.Diagnostics.Process.Start(ascript[I].Split('^')[1], ascript[I].Split('^')[2]);
                        continue;
                    case "download":
                        new System.Net.WebClient().DownloadFile(ascript[I].Split('^')[1], ascript[I].Split('^')[2]);
                        //using ^ instead of _ because files/urls might contain underscores
                        continue;
                    case "delta":
                        long cacl2 = DateTime.Now.Ticks / 1000;
                        long delta = cacl2 - calc;
                        calc = DateTime.Now.Ticks / 1000;
                        saver(ascript[I].Split('_')[1], delta.ToString());
                        continue;
                    case "makestandardwindow":
                        Application.EnableVisualStyles();
                        Garold.Text = ascript[I].Split('_')[1];
                        Garold.ShowIcon = false;
                        Garold.ienit();
                        Application.Run(Garold);
                        continue;
                    case "makestandardbutton":
                        Garold.buttones[Convert.ToInt32(ascript[I].Split('_')[6])] = new System.Windows.Forms.Button();
                        Garold.buttones[Convert.ToInt32(ascript[I].Split('_')[6])].Location = new System.Drawing.Point(Convert.ToInt32(ascript[I].Split('_')[1]), Convert.ToInt32(ascript[I].Split('_')[2]));
                        Garold.buttones[Convert.ToInt32(ascript[I].Split('_')[6])].Name = "button1";
                        Garold.buttones[Convert.ToInt32(ascript[I].Split('_')[6])].Size = new System.Drawing.Size(Convert.ToInt32(ascript[I].Split('_')[4]), Convert.ToInt32(ascript[I].Split('_')[5]));
                        Garold.buttones[Convert.ToInt32(ascript[I].Split('_')[6])].TabIndex = 2;
                        Garold.buttones[Convert.ToInt32(ascript[I].Split('_')[6])].Text = ascript[I].Split('_')[3];
                        Garold.buttones[Convert.ToInt32(ascript[I].Split('_')[6])].UseVisualStyleBackColor = true;
                        Garold.buttones[Convert.ToInt32(ascript[I].Split('_')[6])].Parent = Garold;
                        continue;
                    case "makestandardtext":
                        Garold.labes[Convert.ToInt32(ascript[I].Split('_')[6])] = new System.Windows.Forms.Label();
                        Garold.labes[Convert.ToInt32(ascript[I].Split('_')[6])].Location = new System.Drawing.Point(Convert.ToInt32(ascript[I].Split('_')[1]), Convert.ToInt32(ascript[I].Split('_')[2]));
                        Garold.labes[Convert.ToInt32(ascript[I].Split('_')[6])].Name = "button1";
                        Garold.labes[Convert.ToInt32(ascript[I].Split('_')[6])].Size = new System.Drawing.Size(Convert.ToInt32(ascript[I].Split('_')[4]), Convert.ToInt32(ascript[I].Split('_')[5]));
                        Garold.labes[Convert.ToInt32(ascript[I].Split('_')[6])].TabIndex = 2;
                        Garold.labes[Convert.ToInt32(ascript[I].Split('_')[6])].Text = ascript[I].Split('_')[3];
                        Garold.labes[Convert.ToInt32(ascript[I].Split('_')[6])].Parent = Garold;
                        continue;
                    case "isf":
                        Garold.insidefile = true;
                        Garold.insidepath = ascript[I].Split('_')[1].Trim();
                        continue;
                    case "makebuttonclickevent":
                        var cheese = ascript[I + 1];
                        int thinge = Convert.ToInt32(ascript[I].Split('_')[2]);
                        void assma(object sender, EventArgs e)
                        {
                            switch (cheese.Split('_')[0].Trim())
                            {
                                case "changelabeltext":
                                    Garold.labes[thinge].Text = cheese.Split('_')[1];
                                    break;
                                case "changebuttontext":
                                    Garold.buttones[thinge].Text = cheese.Split('_')[1];
                                    break;
                                case "exit":
                                    Garold.Close();
                                    break;
                                case "changebuttonpos":
                                    Garold.buttones[Convert.ToInt32(ascript[I].Split('_')[1])].Location = new System.Drawing.Point(Convert.ToInt32(ascript[I].Split('_')[2]), Convert.ToInt32(ascript[I].Split('_')[3]));
                                    break;
                                case "changelabelpos":
                                    Garold.labes[Convert.ToInt32(ascript[I].Split('_')[1])].Location = new System.Drawing.Point(Convert.ToInt32(ascript[I].Split('_')[2]), Convert.ToInt32(ascript[I].Split('_')[3]));
                                    break;
                            }
                        }
                        Garold.buttones[Convert.ToInt32(ascript[I].Split('_')[1])].Click += new System.EventHandler(assma);
                        continue;
                }
            }
        }
    }
}
