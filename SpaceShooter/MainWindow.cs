using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter {
    public partial class MainWindow : Form {
        MainMenu menu;

        public MainWindow() {
            InitializeComponent();
            this.ClientSize = new Size(1280, 720);
            menu = new MainMenu();
            menu.Parent = this;
            menu.Dock = DockStyle.Fill;
            menu.selectItem += Menu_selectedItem;
            menu.Show();
        }

        private void Menu_selectedItem(MenuItems m) {
            switch (m) {
                case MenuItems.NewGame:
                    menu.Dispose();
                    menu = null;
                    StartGame();
                    break;
                case MenuItems.Quit:
                    Application.Exit();
                    break;
            }
        }

        private void StartGame() {
            this.BackColor = Color.Black;
            GameWorld game = new GameWorld(this);
        }
    }
}
