using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AVynohradovaFinalProject
{
    public enum MenuItems
    {
        Start,
        Help,
        HighScore,
        Credit,
        Quit
    }

    public class Menu : GameScene
    {
        List<string> menuItems = new List<string>(new string[]
                                  {"Start",
                                   "Help",
                                   "High Score",
                                   "Credit",
                                   "Quit"});

        public Menu(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            this.GameComponents.Add(new MenuComponents(Game, menuItems));
            this.Show();
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
