using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterPlane.Interfaces
{
    interface IMove
    {
        void MoveLeft();
        void MoveRight();
        void MoveDown();
        void MoveUp();
    }
}
