using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSandbox.Entities;

namespace GameSandbox.Components
{
    class Sprite : Component
    {
        string textureName;
        public Sprite(Entity entity)
            :base(entity)
        {
            this._type = ComponentType.sprite;
        }

        public override void OnStartup()
        {
            // Registrera till renderer
        }

        public override void OnShutdown()
        {
            // Avregistrera från renderer
        }
    }
}
