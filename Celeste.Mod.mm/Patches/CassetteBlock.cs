﻿#pragma warning disable CS0626 // Method, operator, or accessor is marked external and has no attributes on it
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value
#pragma warning disable CS0169 // The field is never used

using Celeste.Mod;
using Microsoft.Xna.Framework.Input;
using MonoMod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Xna.Framework;
using System.IO;
using FMOD.Studio;
using Monocle;
using Celeste.Mod.Meta;

namespace Celeste {
    class patch_CassetteBlock : CassetteBlock {

        public patch_CassetteBlock(EntityData data, Vector2 offset, EntityID id)
            : base(data, offset, id) {
        }

        // 1.3.0.0 gets rid of the 1-arg ctor.
        // We're adding a new ctor, thus can't call the constructor without a small workaround.
        [MonoModLinkTo("Celeste.CassetteBlock", "System.Void .ctor(Celeste.EntityData,Microsoft.Xna.Framework.Vector2,Celeste.EntityID)")]
        [MonoModForceCall]
        [MonoModRemove]
        public extern void ctor(EntityData data, Vector2 offset, EntityID id);
        [MonoModConstructor]
        public void ctor(EntityData data, Vector2 offset) {
            ctor(data, offset, new EntityID(data.Level.Name, data.ID));
        }

    }
}
