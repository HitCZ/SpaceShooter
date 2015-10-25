using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter {
    class Projectile : GameObject {
        protected int speed = 20;

        public Projectile(GameWorld game) : base(game) {
            image = new Bitmap("Graphics\\Strela.bmp");

        }

        public override void UpdateMovement() {
            Y -= speed;

            if (Y <= 0) {
                gameWorldInstance.RemoveObject(this);
            }
        }
    }
}
