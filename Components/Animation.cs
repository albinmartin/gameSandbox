using GameSandbox.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSandbox.Components
{
    // Enum for spritesheet indexes
    // TODO: Fix spritesheet and update indexes, idle should be 0 IMO!
    public enum SpriteLoop { IdleLeft = 0, Left = 1, Right = 2, IdleRight = 3}

    public class Animation : Component
    {
        public int CurrentFrame { get; set; }
        public SpriteLoop SpriteLoop { get; set; }
        public int LoopLenght { get; set; }
        public bool Animating { get; set; }
        // Make array where spriteloop is index and store object with looplenght, framerate, currentframe

        // Frame transitions per second
        public float Framerate { get; set; }

        public Animation(Entity entity, SpriteLoop spriteLoop, int loopLenght, float framerate)
            : base(entity)
        {
            _type = ComponentType.Animation;
            CurrentFrame = 0;
            SpriteLoop = spriteLoop;
            LoopLenght = loopLenght;
            Animating = true;
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
