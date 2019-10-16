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
using GameSandbox.Systems;

namespace GameSandbox.GameState
{
    /*
     * TODO: Consider replacing this with world as they are the same at the moment.
     * Functions as a way of separating state logic from world (like controlling menus and switching state).
     */
    class WorldState : GameState
    {
        World _world;
        ContentManager _content;
        GraphicsDevice _graphics;

        public WorldState(GameStateManager stateManager, ContentManager content, GraphicsDevice graphicsDevice) : base(stateManager)
        {
            _content = content;
            _graphics = graphicsDevice;
            _world = new World();
        }

        public override void Draw(GameTime gameTime)
        {
            _world.Draw();
        }

        public override void LoadContent()
        {
            _world.LoadContent(_content, _graphics);
        }

        public override void UnloadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            _world.Update(gameTime);
        }
    }
}
