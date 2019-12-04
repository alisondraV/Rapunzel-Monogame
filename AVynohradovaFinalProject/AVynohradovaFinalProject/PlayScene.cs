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
    

    public class PlayScene : GameScene
    {
        

        public PlayScene(Game game) : base(game)
        {
        }
        
        public override void Initialize()
        {
            this.GameComponents.Add(new PlayBackground(Game));
            this.GameComponents.Add(new Boat(Game));
            this.GameComponents.Add(new PlaySong(Game));
            this.GameComponents.Add(new LightManager(Game));
            
            base.Initialize();
        }

        public override void Show()
        {
            base.Show();
        }
        
        public override void Update(GameTime gameTime)
        {
            if (Enabled)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    int componentsN = Game.Components.Count;
                    for (int i = 0; i < componentsN; i++)
                    {
                        if (Game.Components.ElementAt(i) is Light ||
                            Game.Components.ElementAt(i) is UserScore)
                        {
                            Game.Components.Remove(Game.Components.ElementAt(i));
                            componentsN--;
                            i--;
                        }
                    }
                    LightManager.gameDone = false;
                    ((Game1)Game).HideAllScenes();
                    Game.Services.GetService<Menu>().Show();
                }
            }
            base.Update(gameTime);
        }
    }
}
