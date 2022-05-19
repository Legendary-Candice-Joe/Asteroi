using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace scripthelper
{
    public partial class Cool : Form
    {
        public bool insidefile = false;
        public string insidepath = "";
        string[] command;
        public Button[] buttones = new Button[10];
        public Label[] labes = new Label[10];
        string[] load = new string[20];
        long calc = DateTime.Now.Ticks / 1000;
        string hold = "";
        Timer bruh = new Timer();
        void saver(string hmmm, string hmm)
        {
            load[Convert.ToInt32(hmmm)] = hmm;
        }
        string callcrap(string hmmm)
        {
            return load[Convert.ToInt32(hmmm)];
        }
        int I = -1;
        public void ienit()
        {
            Console.ReadLine();
            if (insidefile == true)
            {
                command = System.IO.File.ReadAllText(insidepath).Split('\n');
                bruh.Enabled = true;
                bruh.Interval = 1;
                bruh.Tick += new EventHandler(ticking);
            }
        }
        string cheese;
        int thinge;
        void assma(object sender, EventArgs e)
        {
            switch (cheese.Split('_')[0].Trim())
            {
                case "changelabeltextEV":
                    labes[thinge].Text = cheese.Split('_')[1];
                    break;
                case "changebuttontextEV":
                    buttones[thinge].Text = cheese.Split('_')[1];
                    break;
                case "exitEV":
                    Application.Exit();
                    break;
                case "changebuttonposEV":
                    buttones[Convert.ToInt32(command[I].Split('_')[1])].Location = new System.Drawing.Point(Convert.ToInt32(command[I].Split('_')[2]), Convert.ToInt32(command[I].Split('_')[3]));
                    break;
                case "changelabelposEV":
                    labes[Convert.ToInt32(command[I].Split('_')[1])].Location = new System.Drawing.Point(Convert.ToInt32(command[I].Split('_')[2]), Convert.ToInt32(command[I].Split('_')[3]));
                    break;
            }
        }
        private void ticking(object sender, EventArgs e)
        {
            if (1 < 2)
            {
                I += 1;
                if (I >= command.Length)
                {
                    bruh.Stop();
                }
                else
                {
                    switch (command[I].Split('_')[0].Trim())
                    {
                        case "load":
                            load[Convert.ToInt32(command[I].Split('_')[2].Trim())] = command[I].Split('_')[1];
                            break;
                        case "wait":
                            System.Threading.Thread.Sleep(Convert.ToInt32(callcrap(command[I].Split('_')[1])));
                            break;
                        case "goto":
                            I = Convert.ToInt32(command[I].Split('_')[1]);
                            break;
                        case "if":
                            switch (command[I].Split('_')[1])
                            {
                                case "E":
                                    if (load[1].Trim() == load[2].Trim())
                                    {
                                        I = Convert.ToInt32(command[I].Split('_')[2]);
                                    }
                                    break;
                                case "N":
                                    if (load[1].Trim() != load[2].Trim())
                                    {
                                        I = Convert.ToInt32(command[I].Split('_')[2]);
                                    }
                                    break;
                                case "GR":
                                    if (Convert.ToInt32(load[1]) > Convert.ToInt32(load[2]))
                                    {
                                        I = Convert.ToInt32(command[I].Split('_')[2]);
                                    }
                                    break;
                                case "LS":
                                    if (Convert.ToInt32(load[1]) < Convert.ToInt32(load[2]))
                                    {
                                        I = Convert.ToInt32(command[I].Split('_')[2]);
                                    }
                                    break;
                                case "GE":
                                    if (Convert.ToInt32(load[1]) >= Convert.ToInt32(load[2]))
                                    {
                                        I = Convert.ToInt32(command[I].Split('_')[2]);
                                    }
                                    break;
                                case "LE":
                                    if (Convert.ToInt32(load[1]) <= Convert.ToInt32(load[2]))
                                    {
                                        I = Convert.ToInt32(command[I].Split('_')[2]);
                                    }
                                    break;
                            }
                            break;
                        case "getsystemvar":
                            switch (command[I].Split('_')[1].Trim())
                            {
                                case "time":
                                    saver(command[I].Split('_')[2], System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second);
                                    break;
                                case "disk":
                                    saver(command[I].Split('_')[2], System.IO.DriveInfo.GetDrives()[0].AvailableFreeSpace.ToString());
                                    break;
                                case "user":
                                    saver(command[I].Split('_')[2], Environment.UserName);
                                    break;
                            }
                            break;
                        case "math":
                            saver("1", new System.Data.DataTable().Compute(command[I].Split('_')[1], null).ToString());
                            break;
                        case "transfer":
                            saver(command[I].Split('_')[1], callcrap(command[I].Split('_')[2]));
                            break;
                        case "mul":
                            switch (command[I].Split('_')[1].Trim())
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
                            break;
                        case "changebuttontext":
                            buttones[Convert.ToInt32(command[I].Split('_')[1].Trim())].Text = command[I].Split('_')[2];
                            break;
                        case "showmessagebox":
                            MessageBox.Show(command[I].Split('_')[1]);
                            break;
                        case "changelabeltext":
                            labes[Convert.ToInt32(command[I].Split('_')[1].Trim())].Text = command[I].Split('_')[2];
                            break;
                        case "gettextfrombutton":
                            load[Convert.ToInt32(command[I].Split('_')[1].Trim())] = buttones[Convert.ToInt32(command[I].Split('_')[2].Trim())].Text;
                            break;
                        case "gettextfromlabel":
                            load[Convert.ToInt32(command[I].Split('_')[1].Trim())] = labes[Convert.ToInt32(command[I].Split('_')[2].Trim())].Text;
                            break;
                        case "makebuttonclickevent":
                            cheese = command[I + 1];
                            thinge = Convert.ToInt32(command[I].Split('_')[2]);
                            buttones[Convert.ToInt32(command[I].Split('_')[1])].Click += new System.EventHandler(assma);
                            break;
                        case "removebuttonclickevent":
                            buttones[Convert.ToInt32(command[I].Split('_')[1])].Click -= new System.EventHandler(assma);
                            break;
                        case "changebuttonpos":
                            buttones[Convert.ToInt32(command[I].Split('_')[1])].Location = new System.Drawing.Point(Convert.ToInt32(command[I].Split('_')[2]), Convert.ToInt32(command[I].Split('_')[3]));
                            break;
                        case "changelabelpos":
                            labes[Convert.ToInt32(command[I].Split('_')[1])].Location = new System.Drawing.Point(Convert.ToInt32(command[I].Split('_')[2]), Convert.ToInt32(command[I].Split('_')[3]));
                            break;
                    }
                }
            }
        }
    }
}
