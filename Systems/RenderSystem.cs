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

        // Spritesheet related
        private Texture2D _spritesheet;
        private Rectangle[,] _spriteParts;
        
        public RenderSystem(EntityManager entityManager, ContentManager content, GraphicsDevice graphics)
            :base(entityManager, content, graphics)
        {
            _spriteBatch = new SpriteBatch(graphics);
            _entitySet = ComponentType.Sprite;

            // Load spritesheets.
            _spritesheet = Content.Load<Texture2D>("entities/spritesheet1");

            // Create source rectangles
            _spriteParts = new Rectangle[1,4];
            int width = _spritesheet.Bounds.Width;
            int height = _spritesheet.Bounds.Height;
            int spritesPerRow = 4; 
            for(int i = 0; i<spritesPerRow; i++)
            {
                _spriteParts[0, i] = new Rectangle(i*(width/spritesPerRow), 0, width / spritesPerRow, height);
            }
            

        }

        public override void Draw()
        {
            // Collect entities.
            List<Entity> sprites = _entityManager.GetEntities(ComponentType.Sprite);

            _spriteBatch.Begin();
            foreach(var entity in sprites)
            {
                Vector2 pos = GetPosition(entity);
                Rectangle sourceRect;

                // Get animation frame if animated sprite.
                Animation animation = GetAnimation(entity);
                if (animation != null)
                {
                    sourceRect = _spriteParts[GetSprite(entity).TextureIndex, animation.CurrentFrame];
                }
                else
                {
                    sourceRect = _spriteParts[GetSprite(entity).TextureIndex, 0];
                }

                // Draw sprite.
                _spriteBatch.Draw(_spritesheet,pos, sourceRect, Color.White);
            }
            _spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            Draw();
        }

        private Animation GetAnimation(Entity entity)
        {
            return (Animation)entity.GetComponent(ComponentType.Animation);
        }

        private Sprite GetSprite(Entity entity)
        {
            return (Sprite)entity.GetComponent(ComponentType.Sprite);
        }

        private Vector2 GetPosition(Entity entity)
        {
            return ((Movement)entity.GetComponent(ComponentType.Movement)).Position;
        }
    }
}
