using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSandbox.Entities;

namespace GameSandbox.Systems
{
    class RenderSystem
    {
        List<Entity> _renderables;
        public RenderSystem()
        {
            _renderables = new List<Entity>();
        }

        public void Register(Entity entity)
        {
            _renderables.Add(entity);
        }

        public void Draw()
        {
            
        }
    }
}
