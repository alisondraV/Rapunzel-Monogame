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
    public abstract class GameScene : GameComponent
    {
        protected List<GameComponent> GameComponents { get; set; }
        public GameScene(Game game) : base(game)
        {
            GameComponents = new List<GameComponent>();
            Hide();
        }

        public virtual void Hide()
        {
            this.Enabled = false;
            foreach(GameComponent component in GameComponents)
            {
                component.Enabled = false;
                if (component is DrawableGameComponent)
                {
                    ((DrawableGameComponent)component).Visible = false;
                }
            }
        }

        public virtual void Show()
        {
            this.Enabled = true;
            foreach(GameComponent component in GameComponents)
            {
                component.Enabled = true;
                if(component is DrawableGameComponent)
                {
                    ((DrawableGameComponent)component).Visible = true;
                }
            }
        }

        public override void Initialize()
        {
            foreach(GameComponent component in GameComponents)
            {
                if (Game.Components.Contains(component) == false)
                {
                    Game.Components.Add(component);
                }
            }
            base.Initialize();
        }
    }
}
