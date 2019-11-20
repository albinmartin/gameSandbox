using GameSandbox.Entities;
using GameSandbox.MathExtended;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSandbox.Components
{
    class Collision : Component
    {
        // Entities that has collided with this. Cleared after collision event.
        public List<Entity> CollidedWith { get; set; }
        public Rectangle BoundingBox { get; set; }

        public Collision(Entity entity) 
            : base(entity)
        {
            _type = ComponentType.Collision;
            CollidedWith = new List<Entity>();
            
            // Default bounding box
            BoundingBox = new Rectangle(0, 0, 40,170 );
        }

        public override void OnShutdown()
        {
        }

        public override void OnStartup()
        {
        }
    }
}
