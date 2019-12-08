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
    /// The text which is drawn on the CreditScene
    /// </summary>
    class CreditTextDraw : DrawableGameComponent
    {
        Texture2D rapunzelTexture;
        Texture2D credit;
        const int UPPER_OFFSET = 110;

        SpriteFont creditFont;
        SpriteFont fontHeader;
        private string headerCredits;
        private string credits;
        private string headerRecourses;
        private string recourses;

        public CreditTextDraw(Game game) : base(game)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Thistle);
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();
            sb.Begin();
            int colCount = Game.GraphicsDevice.Viewport.Width / rapunzelTexture.Width + 1;
            int rowCount = Game.GraphicsDevice.Viewport.Height / rapunzelTexture.Height + 1;

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    sb.Draw(rapunzelTexture,
                        new Vector2(col * rapunzelTexture.Width, row * rapunzelTexture.Height),
                        Color.White * 0.4f);
                }
            }

            sb.DrawString(fontHeader,
                headerCredits,
                new Vector2(70, UPPER_OFFSET),
                Color.Black);

            sb.DrawString(creditFont,
                credits,
                new Vector2(70, UPPER_OFFSET + fontHeader.LineSpacing),
                Color.Maroon);
            
            sb.DrawString(fontHeader,
                headerRecourses,
                new Vector2(70, Game.GraphicsDevice.Viewport.Height / 2),
                Color.Black);

            sb.DrawString(creditFont,
                recourses,
                new Vector2(70, Game.GraphicsDevice.Viewport.Height /2 + fontHeader.LineSpacing),
                Color.Maroon);
            
            sb.Draw(credit,
                new Vector2(Game.GraphicsDevice.Viewport.Width - credit.Width - 130, 40),
                Color.White);

            sb.End();
            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            headerCredits = "Credit";
            credits = "Game created by Alisa Vynohradova\n2019";

            headerRecourses = "Recourses";
            recourses = "1.\"help.png\": https://disney.fandom.com/wiki/Rapunzel/Gallery?file=Rapunzel_-_KH3.png#Kingdom_Hearts_III \n" +
                "2.\"boat.png\": https://www.uihere.com/free-cliparts/rapunzel-flynn-rider-light-art-lantern-tangled-1575674 \n" +
                "3.\"main.jpg\": https://wallpapercave.com/disney-tangled-wallpaper \n" +
                "4.\"background.jpg\": https://www.deviantart.com/tella-in-sa/art/Portrait-of-a-Kingdom-Corona-288384395 \n" +
                "5.\"light.png\": https://weheartit.com/entry/18377266 \n" +
                "6.\"textura.jpeg\": https://www.fabricgateway.com/topic/tangled+sun \n" +
                "7.\"song.mp3\": https://www.youtube.com/watch?v=cJyJCz8uIFU \n" +
				"8.\"s1.mp3\": https://zvukipro.com/audio/918-zvuki-lucha-sveta.html \n" +
                "9.\"credit.jpg\": http://www.rabstol.net/oboi/rapunzel/2180-rapuncel-flinn-i-maksimus.html \n" +
                "10.\"highscore.png\": https://estudiante812.files.wordpress.com/2016/02/tangled";
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            creditFont = Game.Content.Load<SpriteFont>("creditFont");
            fontHeader = Game.Content.Load<SpriteFont>("highlightFont");
            rapunzelTexture = Game.Content.Load<Texture2D>("textura");
            credit = Game.Content.Load<Texture2D>("credit");
            base.LoadContent();
        }
    }
}
