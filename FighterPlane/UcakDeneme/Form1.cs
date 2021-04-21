using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FighterPlane.Models;
namespace FighterPlane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int score = 0;
        List<Plane> planes = new List<Plane>();
        List<Bullet> bullets = new List<Bullet>();
        Models.FighterPlane fighterplane;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        { // location of the fighterplane according to mouse location
            fighterplane.Location = new Point(e.X-31, this.ClientSize.Height - (fighterplane.Size.Height+5));
        }
         
        private void Form1_Load(object sender, EventArgs e)
        {
            fighterplane = new Models.FighterPlane();
            this.Controls.Add(fighterplane.Picture);
            //Start location of the plane (x,y)
            fighterplane.Location = new Point( 300, this.ClientSize.Height - fighterplane.Size.Height);
            this.Text = "SCORE: ";

            timer1.Enabled = true;
            timer1.Interval = 30;
            timer2.Enabled = true;
            timer2.Interval = 700;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Plane item in planes)
            {
                item.MoveDown();
                
                if (TouchBottom(item))
                {
                    timer1.Stop();
                    timer2.Stop();
                    MessageBox.Show(" YOUR SCORE: " + score.ToString(), "GAME OVER !");

                    GameOver();
                }
            }

            foreach (Bullet item in bullets)
            {
                item.MoveUp();
            }

            try
            {
                foreach (var plane in planes)
                {
                    foreach (var bullet in bullets)
                    {
                        if (Collision(plane, bullet))
                        {
                            score++;
                            plane.Disappear();
                            bullet.Disappear();
                            bullets.Remove(bullet);
                            planes.Remove(plane);
                            this.Text = "SCORE: " + score.ToString();
                            timer1.Interval -= 11;
                            
                            timer2.Interval -= 70;
                            if (timer1.Interval <= 10)
                            {
                                timer1.Interval += 5;
                            }
                            if (timer2.Interval <= 100)
                            {
                                timer2.Interval += 100;
                            }
                            
                        }
                    }
                }
            }
            catch (Exception)
            {

                
            }

            
            
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            Plane plane = new Plane();
            planes.Add(plane);
            this.Controls.Add(plane.Picture);
            //Creats random locations (x,y) for the planes
            plane.Location = new Point(new Random().Next(0, this.ClientSize.Height));
            

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Bullet bullet = new Bullet();
            bullets.Add(bullet);
            this.Controls.Add(bullet.Picture);
            // Location of the bullets (x,y)
            var bulletLocation = new Point(fighterplane.Location.X + 24,fighterplane.Location.Y);
            bullet.Location = bulletLocation;
            
        }

        bool TouchBottom(Plane u)
        {
            if (u.Location.Y+u.Size.Height >= this.ClientSize.Height)
            {
                return true;
            }
            else
                return false;
        }
        
         bool Collision(Plane u, Bullet m)
        {
            if ((m.Location.X + m.Size.Width > u.Location.X && u.Location.X + u.Size.Width > m.Location.X) && (u.Location.Y + u.Size.Height >= m.Location.Y))
            {
                return true;
            }
            else
                return false;
        }


        void GameOver()
        {
            
            Application.Exit();
        }

       
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                timer1.Stop();
                timer2.Stop();
                DialogResult dialogResult = MessageBox.Show("Do you want to CONTINUE ?", "GAME PAUSED !", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    timer1.Start();
                    timer2.Start();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }

            

        }
        
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e, MouseEventArgs ee)
        {
            Form1_MouseClick(sender, ee);
        }
        

    }
}
