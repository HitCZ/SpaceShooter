using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter {
    public class GameWorld {
        private Timer timer = new Timer();
        private Timer enemyGenerator = new Timer();
        private List<GameObject> listOfGameObjects = new List<GameObject>();
        private Form mainWindow;

        public GameWorld(Form form) {
            mainWindow = form;
            MessageBox.Show("Hra bude spuštěna", "Zpráva hry");
            timer.Interval = 100;
            mainWindow.Paint += MainWindow_Paint;
            timer.Tick += UpdateGame;
            timer.Start();

            Player player = new Player(this);
            listOfGameObjects.Add(player);
            Enemy enemy = new Enemy(this, "Graphics\\Nepritel1.bmp");
            listOfGameObjects.Add(enemy);

            mainWindow.KeyDown += MainWindow_KeyDown;

            enemyGenerator.Interval = 2000;
            enemyGenerator.Tick += EnemyGenerator_Tick;
            enemyGenerator.Start();

        }

        private void UpdateGame(object sender, EventArgs e) {
            for (int i = 0; i < listOfGameObjects.Count; i++) {
                listOfGameObjects[i].UpdateMovement();
            }
            CheckCollisions();
            mainWindow.Invalidate();
        }

        private void MainWindow_Paint(object sender, PaintEventArgs e) {
            foreach (GameObject o in listOfGameObjects) {
                o.Paint(e.Graphics);
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e) {
            for (int i = 0; i < listOfGameObjects.Count; i++) {
                listOfGameObjects[i].PlayerInput(sender, e);
            }
        }

        public void AddObject(GameObject o) {
            listOfGameObjects.Add(o);
        }

        public void RemoveObject(GameObject o) {
            listOfGameObjects.Remove(o);
        }

        private bool ObjectsCollide(GameObject first, GameObject second) {
            RectangleF rectFirst = first.GetObjectBounds();
            RectangleF rectSecond = second.GetObjectBounds();

            return rectFirst.IntersectsWith(rectSecond);
        }

        private void CheckCollisions() {
            for (int i = 0; i < listOfGameObjects.Count; i++) {
                for (int j = 0; j < listOfGameObjects.Count; j++) {
                    GameObject first = listOfGameObjects[i];
                    GameObject second = listOfGameObjects[j];

                    if ((first is Enemy) && (second is Projectile) ||
                        (first is Projectile) && (second is Enemy)) {
                        if (ObjectsCollide(first, second)) {
                            RemoveObject(first);
                            RemoveObject(second);
                        }
                    }
                    else if ((first is Player) && (second is Enemy) ||
                        (first is Enemy) && (second is Player)) {
                        if (ObjectsCollide(first, second)) {
                            RemoveObject(first);
                            RemoveObject(second);
                            MessageBox.Show("Konec hry!");
                        }
                    }
                }
            }
        }

        private void EnemyGenerator_Tick(object sender, EventArgs e) {
            Random enemyTypeGenerator = new Random();
            Enemy enemy = null;

            if (enemyTypeGenerator.Next(0, 2) == 0) {
                enemy = new Enemy(this, "Graphics\\Nepritel1.bmp");
            }
            else {
                enemy = new Enemy(this, "Graphics\\Nepritel2.bmp");
            }

            enemy.X = enemyTypeGenerator.Next(GameObject.MAX_X - 100);

            for (int i = 0; i < this.listOfGameObjects.Count; i++) {
                if (ObjectsCollide(listOfGameObjects[i], enemy)) {
                    return;
                }
            }

            listOfGameObjects.Add(enemy);
        }
    }
}
