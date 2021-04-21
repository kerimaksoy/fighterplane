using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FighterPlane.Interfaces;
namespace FighterPlane.Models
{
    class Bullet: Object,IMove,IDisappear
    {
        public Bullet()
        {// size of the bullet (x,y)
            unit(12, 25);
            
        }
        public int Speed { get; set; }
        
        public void MoveDown()
        {
            throw new NotImplementedException();
        }

        public void MoveRight()
        {
            throw new NotImplementedException();
        }

        public void MoveLeft()
        {
            throw new NotImplementedException();
        }

        public void Disappear()
        {
            Picture.Dispose();
        }

        public void MoveUp()
        {
            Location = new Point(Location.X, Location.Y - Speed);
        }
        public override void unit(int x, int y)
        {
            base.unit(x, y);
            Picture.ImageLocation = "Resources/bullet.PNG";
            Speed = 13;//10
        }
    }
}
