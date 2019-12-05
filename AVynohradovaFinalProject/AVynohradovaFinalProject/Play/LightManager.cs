using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AVynohradovaFinalProject
{
    class LightManager : GameComponent
    {
        Random rand = new Random();
        const double CREATION_INTERVAL = 1;
        double creationTimer = 0.0;
        SoundEffect soundEffect;

        const int Y_OFFSET = -150;
        const int X_LIMIT = 100;

        public List<Light> lights = new List<Light>();
        public Boat boat;

        public LightManager(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            boat = Game.Services.GetService<Boat>();
            base.Initialize();
        }

        private Vector2 GenerateRandPosition()
        {
            int x = rand.Next(100, Game.GraphicsDevice.Viewport.Width - X_LIMIT);
            return new Vector2(x, Y_OFFSET);
        }

        public override void Update(GameTime gameTime)
        {
            if (PlayScene.gameDone == false)
            {
                CreateLight(gameTime);
                CheckCollision();
            }
            
            base.Update(gameTime);
        }

        private void CheckCollision()
        {
            Rectangle boatBounds = boat.Bounds;
            for (int i = 0; i < lights.Count; i++)
            {
                Rectangle lightBounds = lights[i].Bounds;

                if (boatBounds.Intersects(lightBounds))
                {
                    lights[i].HandleCollision();
                    lights.Remove(lights[i]);
                    i--;
                    PlayScene.points++;
                }
            }
        }

        private void CreateLight(GameTime gameTime)
        {
            creationTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (creationTimer >= CREATION_INTERVAL)
            {
                Light light = new Light(Game, GenerateRandPosition());
                Game.Components.Add(light);
                lights.Add(light);
                creationTimer = 0;
            }
        }
    }
}
