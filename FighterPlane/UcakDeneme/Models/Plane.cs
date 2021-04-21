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
    class Plane : Object,IMove,IDisappear
    {
        public Plane()
        {  // size of the plane (x,y)
            unit(50, 50);
        }
        public int speed { get; set; }

        public void MoveDown()
        {
            Location = new Point(Location.X, Location.Y + speed);
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
            throw new NotImplementedException();
        }

        public override void unit(int x, int y)
        {
            base.unit(x, y);
            Picture.ImageLocation = "Resources/plane.PNG";
            speed = 4;//5
        }
    }
}
