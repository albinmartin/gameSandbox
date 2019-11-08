using GameSandbox.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSandbox.Components
{
    public class Animation : Component
    {
        public int StartIndex { get; set; }
        public int StopIndex { get; set; }
        public int Row { get; set; }
        public float Framerate { get; set; }

        public Animation(Entity entity, int startIndex, int stppIndex, int row, float framerate)
            : base(entity)
        {
            _type = ComponentType.Animation;
            StartIndex = startIndex;
            StopIndex = stppIndex;
            Row = row;
            Framerate = framerate;
        }

        public override void OnShutdown()
        {
        }

        public override void OnStartup()
        {
        }
    }
}
