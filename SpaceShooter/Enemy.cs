using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter {
    class Enemy : GameObject {
        protected int speedVertical = 30;
        protected int speedHorizontal = 10;

        public Enemy(GameWorld game, string path) : base(game) {
            Bitmap b = new Bitmap(path);
            b.MakeTransparent(Color.Black);
            image = b;
        }

        public override void UpdateMovement() {
            X += speedHorizontal;

            if (X >= MAX_X - this.image.Width || X <= MIN_X) {
                speedHorizontal *= -1;
                Y += speedVertical;
            }

            if (Y >= MAX_Y) {
                gameWorldInstance.RemoveObject(this);
            }
        }
    }
}
