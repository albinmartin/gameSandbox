using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSandbox.Entities;
using GameSandbox.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GameSandbox.Systems
{
    class RenderSystem : DrawSystem
    {
        private SpriteBatch _spriteBatch;

        public RenderSystem(EntityManager entityManager, ContentManager content, GraphicsDevice graphics)
            :base(entityManager, content, graphics)
        {
            _spriteBatch = new SpriteBatch(graphics);
            _entitySet = ComponentType.Sprite;
        }

        public override void Draw()
        {
            List<Entity> sprites = _entityManager.GetEntities(ComponentType.Sprite);

            _spriteBatch.Begin();
            foreach(var entity in sprites)
            {
                Vector2 pos = GetPosition(entity);
                Texture2D texture = GetTexture(entity);
                _spriteBatch.Draw(texture, pos, Color.White);
            }
            _spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            Draw();
        }

        private Vector2 GetPosition(Entity entity)
        {
            return ((Movement)entity.GetComponent(ComponentType.Movement)).Position;
        }

        private Texture2D GetTexture(Entity entity)
        {
            return Content.Load<Texture2D>(((Sprite)entity.GetComponent(ComponentType.Sprite)).TextureName);
        }


    }
}
