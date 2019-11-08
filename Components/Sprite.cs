﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSandbox.Entities;
using Microsoft.Xna.Framework;

namespace GameSandbox.Components
{
    class Sprite : Component
    {
        public string TextureName { get; set; }
        public Vector2 TextureCoord { get; set; }

        public Sprite(Entity entity)
            :base(entity)
        {
            this._type = ComponentType.Sprite;
            TextureName = "entities/default";
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
