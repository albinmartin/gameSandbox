using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameSandbox.Controls;

namespace GameSandbox.GameState
{
    class MainMenu : GameState
    {
        GraphicsDevice _graphics;
        Texture2D _texture;
        SpriteBatch _spritebatch;
        ContentManager _content;

        public MainMenu (GraphicsDevice graphics, ContentManager content, GameStateManager manager)
            :base(manager)
        {
            _graphics = graphics;
            _content = content;
            _spritebatch = new SpriteBatch(_graphics);
        }

        public override void Draw(GameTime gameTime)
        {
            _spritebatch.Begin();
            _spritebatch.Draw(_texture, Vector2.Zero, Color.White);
            _spritebatch.End();
        }

        public override void LoadContent()
        {
            _texture = _content.Load<Texture2D>("menu/main1");
        }

        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
