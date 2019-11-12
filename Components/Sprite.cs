using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSandbox.Entities;
using Microsoft.Xna.Framework;

namespace GameSandbox.Components
{
    // Enum for spritesheet index
    public enum SpriteType { Goatman = 0 }

    class Sprite : Component
    {
        public SpriteType SpriteType { get; set; }
        public Vector2 TextureCoord { get; set; }
        public int TextureIndex { get => (int)this.SpriteType; }

        public Sprite(Entity entity)
            :base(entity)
        {
            this._type = ComponentType.Sprite;
            SpriteType = SpriteType.Goatman;
            TextureCoord = Vector2.Zero;
        }

        public Sprite(Entity entity, SpriteType spriteType)
            :base(entity)
        {
            this._type = ComponentType.Sprite;
            SpriteType = spriteType;
            TextureCoord = Vector2.Zero;
        }

        public override void OnStartup()
        {
        }

        public override void OnShutdown()
        {
        }
    }
}
