using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace buttonchase
{
    public partial class Form1 : Form
    {
        #region variables
        private struct btnprfl // button profile
        {
            public string sound; // sound of that button
            public Button btn; // button control
        }
        private btnprfl[] btninfo = new btnprfl[20]; // button information

        private string[] sound = new string[] // sound of that button
        {
            "cat",
            "dog",
            "bird",
            "tiger",
            "chiken",
            "cow",
            "pig",
            "sheep"
        };
        private string snd = ""; // sound for instruction

        private SoundPlayer player = new SoundPlayer(); // to play sound file (.wav)

        private string[] tgnm = new string[] // list of tags/name
        {
            "cat",
            "dog",
            "bird",
            "tiger",
            "chiken",
            "cow",
            "pig",
            "sheep"
        };

        private Color[] clr = new Color[] // list of color
        {
            // light 
            Color.Yellow,
            Color.Cyan,
            Color.Lime,
            Color.White,
            // dark
            Color.Red,
            Color.Blue,
            Color.Green,
            Color.Black
        };

        private bool[] ans = new bool[] // list of randomed list of true or false
        {
            true,
            false,
            false,
            true,
            false,
            true,
            true,
            false
        };

        private string[] slctn = new string[] // list of what type the user will pick
        {
            "Sound", "Backcolor", "Forecolor", "Tag"
        };

        private Random rndm = new Random(); // create random
        private int rand = 0, rand2 = 0; // first random for forecolor and second rand for slctn
        private Timer[] tmr = new Timer[3]; // timer
        private Label lbl; // create question label
        private Label cntr; // create timer label
        private Label wncnt; // create win count label
        private Panel pnl; // create panel
        private int counter = 120, wincount = 0; // counter for timer 3, counter for correct click of the button
        #endregion

        #region methods
        public Form1()
        {
            InitializeComponent();
            crtcntrl();
        }

        private void crtcntrl()
        {
            #region create button
            for (int i = 0; i < btninfo.Length; i++)
            {
                rand = 0; // set rand back to 0
                btninfo[i].btn = new Button();
                btninfo[i].btn.AutoSize = false;
                btninfo[i].btn.Size = new Size(75, 25); // set the button size
                btninfo[i].btn.SendToBack();
                partcrtcntrl(i); // part method for creating button
                switch (i) // create button click events
                {
                    case 0: btninfo[i].btn.Click += new EventHandler(btn0_Click);
                        break;
                    case 1: btninfo[i].btn.Click += new EventHandler(btn1_Click);
                        break;
                    case 2: btninfo[i].btn.Click += new EventHandler(btn2_Click);
                        break;
                    case 3: btninfo[i].btn.Click += new EventHandler(btn3_Click);
                        break;
                    case 4: btninfo[i].btn.Click += new EventHandler(btn4_Click);
                        break;
                    case 5: btninfo[i].btn.Click += new EventHandler(btn5_Click);
                        break;
                    case 6: btninfo[i].btn.Click += new EventHandler(btn6_Click);
                        break;
                    case 7: btninfo[i].btn.Click += new EventHandler(btn7_Click);
                        break;
                    case 8: btninfo[i].btn.Click += new EventHandler(btn8_Click);
                        break;
                    case 9: btninfo[i].btn.Click += new EventHandler(btn9_Click);
                        break;
                    case 10: btninfo[i].btn.Click += new EventHandler(btn10_Click);
                        break;
                    case 11: btninfo[i].btn.Click += new EventHandler(btn11_Click);
                        break;
                    case 12: btninfo[i].btn.Click += new EventHandler(btn12_Click);
                        break;
                    case 13: btninfo[i].btn.Click += new EventHandler(btn13_Click);
                        break;
                    case 14: btninfo[i].btn.Click += new EventHandler(btn14_Click);
                        break;
                    case 15: btninfo[i].btn.Click += new EventHandler(btn15_Click);
                        break;
                    case 16: btninfo[i].btn.Click += new EventHandler(btn16_Click);
                        break;
                    case 17: btninfo[i].btn.Click += new EventHandler(btn17_Click);
                        break;
                    case 18: btninfo[i].btn.Click += new EventHandler(btn18_Click);
                        break;
                    case 19: btninfo[i].btn.Click += new EventHandler(btn19_Click);
                        break;
                }
                this.Controls.Add(btninfo[i].btn); // adds the control to the form
            }
            #endregion 

            #region create timer
            for (int i = 0; i < tmr.Length; i++)
            {
                tmr[i] = new Timer();
                tmr[i].Enabled = true;
                tmr[i].Start();
                if (i == 0) // timer for relocation of button
                {
                    tmr[i].Interval = 2000;
                    tmr[i].Tick += new EventHandler(tmr0_Tick);
                }
                else if (i == 1) // timer for regeneration of instruction
                {
                    tmr[i].Interval = 10000;
                    tmr[i].Tick += new EventHandler(tmr1_Tick);
                }
                else // timer count
                {
                    tmr[i].Interval = 1500;
                    tmr[i].Tick += new EventHandler(tmr2_Tick);
                }
            }
            #endregion

            #region create panel and label
            // panel
            pnl = new Panel();
            pnl.BackColor = Color.Black;
            pnl.Size = new Size(593, 30);
            pnl.Location = new Point(0, 0);
            pnl.BringToFront();
            this.Controls.Add(pnl);

            // question label
            lbl = new Label();
            lbl.ForeColor = Color.White;
            lbl.Location = new Point(0, 0);
            lbl.Size = new Size(493, 30);
            lbl.Font = new Font("Arial", 14F, FontStyle.Regular);
            partcrtcntrl();
            lbl.BringToFront();
            lbl.Click += new EventHandler(lbl_Click);
            pnl.Controls.Add(lbl);

            // timer label
            cntr = new Label();
            cntr.BackColor = Color.Blue;
            cntr.ForeColor = Color.Yellow;
            cntr.Location = new Point(543, 0);
            cntr.Size = new Size(50, 30);
            cntr.Font = new Font("Arial", 14F, FontStyle.Regular);
            cntr.Text = counter.ToString();
            cntr.BringToFront();
            pnl.Controls.Add(cntr);

            // win count label
            wncnt = new Label();
            wncnt.BackColor = Color.Green;
            wncnt.ForeColor = Color.White;
            wncnt.Location = new Point(493, 0);
            wncnt.Size = new Size(50, 30);
            wncnt.Font = new Font("Arial", 14F, FontStyle.Regular);
            wncnt.Text = wincount.ToString();
            wncnt.BringToFront();
            pnl.Controls.Add(wncnt);
            #endregion 
        }

        private void partcrtcntrl(int i) // for button
        {
            btninfo[i].btn.Location = new Point(random(30, 518), random(30, 250)); // location for the button
            btninfo[i].btn.Visible = ans[random(0, ans.Length)]; // which of the 20 buttons will be visible
            btninfo[i].btn.BackColor = clr[random(0, clr.Length)]; // random generate of color
            if (rand >= 0 && rand <= 3) // to make the text clear
            { btninfo[i].btn.ForeColor = clr[random(4, 8)]; } // random generate of color
            else
            { btninfo[i].btn.ForeColor = clr[random(0, 3)]; } // random generate of color
            btninfo[i].btn.Text = tgnm[random(0, tgnm.Length)]; // random generate f text
            btninfo[i].sound = btninfo[i].btn.Text; // pass the animal name to sound
        }

        private void partcrtcntrl() // for lbl instruction
        {
            rand2 = random2(0, 4);
            switch (rand2)
            {
                case 0: // Sound
                    lbl.Text = "Click Buttons by: " + slctn[rand2];
                    snd = sound[random(0, sound.Length)];
                    switch (snd)
                    {
                        case "cat": player.Stream = Properties.Resources.cat;
                            break;
                        case "dog": player.Stream = Properties.Resources.dog;
                            break;
                        case "bird": player.Stream = Properties.Resources.bird;
                            break;
                        case "tiger": player.Stream = Properties.Resources.tiger;
                            break;
                        case "chiken": player.Stream = Properties.Resources.chiken;
                            break;
                        case "cow": player.Stream = Properties.Resources.cow;
                            break;
                        case "pig": player.Stream = Properties.Resources.pig;
                            break;
                        case "sheep": player.Stream = Properties.Resources.sheep;
                            break;
                    }
                    player.Play();
                    break;
                case 1: // Backcolor
                    lbl.Text = "Click Buttons by: " + slctn[rand2] + " having " + clr[random(0, clr.Length)].ToString();
                    break;
                case 2: // Forecolor
                    lbl.Text = "Click Buttons by: " + slctn[rand2] + " having " + clr[random(0, clr.Length)].ToString();
                    break;
                case 3: // Tag
                    lbl.Text = "Click Buttons by: " + slctn[rand2] + " having [" + tgnm[random(0, tgnm.Length)] + "]";
                    break;
            }
        }

        private int random(int min, int max)
        {
            return rand = rndm.Next(min, max);
        }

        private int random2(int min, int max)
        {
            return rndm.Next(min, max);
        }
        
        private void chkbtn(int i) // check the clicked button
        {
            switch (rand2)
            {
                case 0: // Sound
                    if(snd == btninfo[i].sound)
                    { wincount += 5; }
                    else
                    { wincount -= 2; }
                    break;
                case 1: // Backcolor
                    if (btninfo[i].btn.BackColor.ToString() == lbl.Text.Substring(35, lbl.Text.Length - 35))
                    { wincount += 5; }
                    else
                    { wincount -= 2; }
                    break;
                case 2: // Forecolor
                    if (btninfo[i].btn.ForeColor.ToString() == lbl.Text.Substring(35, lbl.Text.Length - 35))
                    { wincount += 5; }
                    else
                    { wincount -= 2; }
                    break;
                case 3: // Tag
                    if (btninfo[i].btn.Text == lbl.Text.Substring(30, lbl.Text.Length - 31))
                    { wincount += 5; }
                    else
                    { wincount -= 2; }
                    break;
            }
            wncnt.Text = wincount.ToString();
            btninfo[i].btn.Visible = false;
        }
        #endregion 

        #region events
        private void lbl_Click(object sender, EventArgs e)
        {
            player.Play();
        }

        private void tmr0_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < btninfo.Length; i++)
            {
                rand = 0;
                partcrtcntrl(i);
            }
        }

        private void tmr1_Tick(object sender, EventArgs e)
        {
            partcrtcntrl(); // part method to regenerate instruction
        }

        private void tmr2_Tick(object sender, EventArgs e)
        {
            if (counter > 0)
            {
                counter -= 1;
                cntr.Text = counter.ToString();
            }
            else
            {
                for (int i = 0; i < tmr.Length; i++)
                { tmr[i].Stop();}
                if (MessageBox.Show("Your score is: " + wncnt.Text, "Play again?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    counter = 120;
                    wincount = 0;
                    for (int i = 0; i < tmr.Length; i++)
                    { tmr[i].Start(); }
                }
                else
                {
                    Form1.ActiveForm.Close();
                }
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            chkbtn(0);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            chkbtn(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            chkbtn(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            chkbtn(3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            chkbtn(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            chkbtn(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            chkbtn(6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            chkbtn(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            chkbtn(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            chkbtn(9);
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            chkbtn(10);
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            chkbtn(11);
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            chkbtn(12);
        }

        private void btn13_Click(object sender, EventArgs e)
        {
            chkbtn(13);
        }

        private void btn14_Click(object sender, EventArgs e)
        {
            chkbtn(14);
        }

        private void btn15_Click(object sender, EventArgs e)
        {
            chkbtn(15);
        }

        private void btn16_Click(object sender, EventArgs e)
        {
            chkbtn(16);
        }

        private void btn17_Click(object sender, EventArgs e)
        {
            chkbtn(17);
        }

        private void btn18_Click(object sender, EventArgs e)
        {
            chkbtn(18);
        }

        private void btn19_Click(object sender, EventArgs e)
        {
            chkbtn(19);
        }
        #endregion
    }
}