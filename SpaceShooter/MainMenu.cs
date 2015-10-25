using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter {
    public partial class MainMenu : UserControl {
        private MenuItems selectedItem;
        private const int ITEM_WIDTH = 400;
        private const int ITEM_HEIGHT = 100;
        private Rectangle rectNewGame;
        private Rectangle rectQuit;
        public delegate void DelegateSelectItem(MenuItems m);
        public event DelegateSelectItem selectItem;
        
        public MainMenu() {
            InitializeComponent();
            this.BackColor = Color.Black;
            this.DoubleBuffered = true;
            this.Paint += PaintServiceEvent;
            this.MouseDoubleClick += MainMenu_MouseClick;
        }

        private void MainMenu_Load(object sender, EventArgs e) {
            rectNewGame = new Rectangle((this.Parent.ClientRectangle.Width - 
                ITEM_WIDTH) / 2, (this.Parent.ClientRectangle.Height - 
                ITEM_HEIGHT) / 2, ITEM_WIDTH, ITEM_HEIGHT);

            rectQuit = new Rectangle((this.Parent.ClientRectangle.Width -
                ITEM_WIDTH) / 2, (this.Parent.ClientRectangle.Height -
                ITEM_HEIGHT) / 2 + ITEM_HEIGHT * 2, ITEM_WIDTH, ITEM_HEIGHT);
        }

        private void PaintServiceEvent(object sender, PaintEventArgs e) {
            Image imageNewGame = Properties.Resources.NovaHraNeoznaceno;
            Image imageQuit = Properties.Resources.KonecNeoznaceno;

            switch (selectedItem) {
                case MenuItems.NewGame:
                    imageNewGame = Properties.Resources.NovaHraOznaceno;
                    break;
                case MenuItems.Quit:
                    imageQuit = Properties.Resources.KonecOznaceno;
                    break;
            }
            e.Graphics.DrawImage(imageNewGame, rectNewGame);
            e.Graphics.DrawImage(imageQuit, rectQuit);
        }

        private void MainMenu_MouseClick(object sender, MouseEventArgs e) {
            int clickCount = e.Clicks;

            if (clickCount == 2) {
                selectItem(MenuItems.NewGame);
            }

            if (rectNewGame.Contains(e.Location)) {
                selectedItem = MenuItems.NewGame;
            }
            else if (rectQuit.Contains(e.Location)) {
                selectedItem = MenuItems.Quit;
            }

            this.Invalidate();
        }
    }
}
