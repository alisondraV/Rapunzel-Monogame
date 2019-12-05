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
    public class MenuComponents : DrawableGameComponent
    {
        SpriteFont regularFont;
        SpriteFont highlightFont;

        private List<string> menuItems;
        private int SelectedIndex { get; set; }
        private Vector2 position;

        private Color regularColor = Color.MistyRose;
        private Color higlightColor = Color.Plum;

        Texture2D main;

        private KeyboardState oldState;

        public MenuComponents(Game game, List<string>menuNames) : base(game)
        {
            menuItems = menuNames;
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Right) && oldState.IsKeyUp(Keys.Right))
            {
                SelectedIndex++;
                if (SelectedIndex == menuItems.Count)
                {
                    SelectedIndex = 0;
                }
            }
            if (keyboardState.IsKeyDown(Keys.Left) && oldState.IsKeyUp(Keys.Left))
            {
                SelectedIndex--;
                if (SelectedIndex == -1)
                {
                    SelectedIndex = menuItems.Count - 1;
                }
            }
            oldState = keyboardState;

            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                SwitchScenedBasedOnSelection();
            }

            base.Update(gameTime);
        }

        private void SwitchScenedBasedOnSelection()
        {
            ((Game1)Game).HideAllScenes();

            switch ((MenuItems)SelectedIndex)
            {
                case MenuItems.Start:
                    PlayScene.gameDone = false;
                    Boat.reset = true;
                    Game.Services.GetService<PlayScene>().Show();
                    break;
                case MenuItems.Help:
                    Game.Services.GetService<HelpScene>().Show();
                    break;
                case MenuItems.HighScore:
                    Game.Services.GetService<HighScoreScene>().Show();
                    break;
                case MenuItems.Credit:
                    Game.Services.GetService<CreditScene>().Show();
                    break;
                case MenuItems.Quit:
                    Game.Exit();
                    break;
                default:
                    Game.Services.GetService<Menu>().Show();
                    break;
            }
        }

        public override void Initialize()
        {
            position = new Vector2(Game.GraphicsDevice.Viewport.Width / 6,
                Game.GraphicsDevice.Viewport.Height * 6 / 7);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            regularFont = Game.Content.Load<SpriteFont>("regularFont");
            highlightFont = Game.Content.Load<SpriteFont>("highlightFont");
            main = Game.Content.Load<Texture2D>("main");
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();
            Vector2 tempPosition = position;
            sb.Begin();
            sb.Draw(main,
                new Rectangle(0, 0, Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height),
                Color.White);

            for (int i = 0; i < menuItems.Count; i++)
            {
                SpriteFont activeFont = regularFont;
                Color activeColor = regularColor;

                if (SelectedIndex == i)
                {
                    activeFont = highlightFont;
                    activeColor = higlightColor;
                }
                sb.DrawString(activeFont, menuItems[i], tempPosition, activeColor);
                tempPosition.X += regularFont.MeasureString(menuItems[i]).X + 50;
            }

            sb.End();

            base.Draw(gameTime);
        }
    }
}
