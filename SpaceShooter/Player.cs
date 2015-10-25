using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter {
    class Player : GameObject {
        public Player(GameWorld game) : base(game) {
            image = new Bitmap("Graphics\\Hrac.bmp");
            this.Y = MAX_Y - image.Height;
            this.X = (MAX_X - image.Width) / 2;
        }

        public override void PlayerInput(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Right:
                    X += 5;
                    break;
                case Keys.Left:
                    X -= 5;
                    break;
                case Keys.Space:
                    Projectile p = new Projectile(this.gameWorldInstance);
                    p.X = this.X + this.image.Width / 2;
                    p.Y = this.Y;
                    gameWorldInstance.AddObject(p);
                    break;
            }
        }
    }
}
