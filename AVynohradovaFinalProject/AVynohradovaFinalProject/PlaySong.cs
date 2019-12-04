using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AVynohradovaFinalProject
{
    class PlaySong : DrawableGameComponent
    {
        private Song song;

        public PlaySong(Game game) : base(game)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            song = Game.Content.Load<Song>("song");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.8f;
            MediaPlayer.Play(song);
            
            base.LoadContent();
        }
    }
}
