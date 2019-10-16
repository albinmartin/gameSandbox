using GameSandbox.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSandbox.Components
{
    public class Movement : Component
    {
        public Movement(Entity entity) 
            :base(entity)
        {
            this._type = ComponentType.movement;
            Position = Vector2.Zero;
        }

        public Vector2 Position { get; set; }

        public override void OnShutdown()
        {
        }

        public override void OnStartup()
        {
        }
    }
}
