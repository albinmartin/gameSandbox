using GameSandbox.Entities;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSandbox.Systems
{
    public abstract class DrawSystem : GameSystem
    {
        private ContentManager _content;
        private GraphicsDevice _graphics;

        protected ContentManager Content { get => _content; }
        protected GraphicsDevice Graphics { get => _graphics; }

        public DrawSystem(EntityManager entityManager, ContentManager content, GraphicsDevice graphics) 
            :base(entityManager)
        {
            _content = content;
            _graphics = graphics;
        }

        public abstract void Draw();

    }
}
