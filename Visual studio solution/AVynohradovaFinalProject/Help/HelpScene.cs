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
    /// <summary>
    /// The scene with the the rules and basic info about the game
    /// </summary>
    class HelpScene : GameScene
    {
        public HelpScene(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            this.GameComponents.Add(new HelpTextDraw(Game));
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (Enabled)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    ((Game1)Game).HideAllScenes();
                    Game.Services.GetService<Menu>().Show();
                }
            }
            base.Update(gameTime);
        }
    }
}
