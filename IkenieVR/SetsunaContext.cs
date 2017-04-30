using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using VRGIN.Controls.Speech;
using VRGIN.Core;
using VRGIN.Helpers;
using VRGIN.Visuals;

namespace IkenieVR
{
    class SetsunaContext : DefaultContext
    {

        public override bool ConfineMouse
        {
            get
            {
                return false;
            }
        }
        
        public override float GuiFarClipPlane
        {
            get
            {
                return 100;
            }
        }

        public override float GuiNearClipPlane
        {
            get
            {
                return -100;
            }
        }
        

        public override bool SimulateCursor
        {
            get
            {
                return false;
            }
        }
        
        public override int UILayerMask
        {
            get
            {
                return LayerMask.GetMask(UILayer, "UI_front", "UI_back");
            }
        }

        protected override IMaterialPalette CreateMaterialPalette()
        {
            var palette = new DefaultMaterialPalette();
            palette.UnlitTransparent = new Material(UnityHelper.GetShader("UnlitColorCutout"));
            palette.UnlitTransparentCombined = new Material(UnityHelper.GetShader("UnlitColorCutoutCombined"));

            return palette;
        }
    }
}
