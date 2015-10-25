using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter {
    public abstract class GameObject {
        protected Image image;
        protected GameWorld gameWorldInstance;
        public const int MAX_X = 1280;
        public const int MIN_X = 0;
        public const int MAX_Y = 720;

        public int X { get; set; }
        public int Y { get; set; }

        public GameObject(GameWorld game) {
            gameWorldInstance = game;
        }

        public virtual void UpdateMovement() {

        }

        public virtual void Paint(Graphics g) {
            g.DrawImage(image, X, Y);
        }

        public virtual void PlayerInput(object sender, KeyEventArgs e) {

        }

        public virtual RectangleF GetObjectBounds() {
            GraphicsUnit unit = GraphicsUnit.Pixel;
            RectangleF relativeBounds = image.GetBounds(ref unit);
            relativeBounds.Offset(this.X, this.Y);

            return relativeBounds;
        }
    }
}
