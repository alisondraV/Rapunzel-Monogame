using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AVynohradovaFinalProject
{
    /// <summary>
    /// Song, which plays in the background throughout the game
    /// </summary>
    class PlaySong : DrawableGameComponent
    {
        private Song song;

        public PlaySong(Game game) : base(game)
        {
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
