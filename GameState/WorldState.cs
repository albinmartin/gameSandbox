using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using GameSandbox.Entities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using GameSandbox.Components;

namespace GameSandbox.GameState
{
    class WorldState : GameState
    {
        World _world;
        ContentManager _content;
        Texture2D _texture;
        SpriteBatch _spriteBatch;

        public WorldState(GameStateManager stateManager, ContentManager content, GraphicsDevice graphicsDevice) : base(stateManager)
        {
            _content = content;
            _spriteBatch = new SpriteBatch(graphicsDevice);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(_texture, Vector2.Zero, Color.White);
            _spriteBatch.End();
        }

        public override void LoadContent()
        {
            _world = new World();
            _texture = _content.Load<Texture2D>("menu/world");

            Entity entity = new Entity();
            entity.AddComponent(new Sprite(entity));
            entity.Startup();
        }

        public override void UnloadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
