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
        public string TextureName { get; set; }

        public Sprite(Entity entity)
            :base(entity)
        {
            this._type = ComponentType.sprite;
            TextureName = "entities/default";
        }

        public override void OnStartup()
        {
        }

        public override void OnShutdown()
        {
        }
    }
}
