using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using VRGIN.Controls;
using VRGIN.Core;
using VRGIN.Helpers;
using VRGIN.Modes;

namespace IkenieVR
{
    class GenericSeatedMode : SeatedMode
    {
        protected override IEnumerable<IShortcut> CreateShortcuts()
        {
            return base.CreateShortcuts().Concat(new IShortcut[] {
                new MultiKeyboardShortcut(new KeyStroke("Ctrl+C"), new KeyStroke("Ctrl+C"), () => { VR.Manager.SetMode<GenericStandingMode>(); })
            });
        }
        
        /// <summary>
        /// Disables controllers for seated mode.
        /// </summary>
        protected override void CreateControllers()
        {
        }

        /// <summary>
        /// Uncomment to automatically switch into Standing Mode when controllers have been detected.
        /// </summary>
        //protected override void ChangeModeOnControllersDetected()
        //{
        //    VR.Manager.SetMode<GenericStandingMode>();
        //}

        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (VR.Camera.Origin.position.y > 10)
            {
                VR.Camera.Origin.position += Vector3.down * 8 + Vector3.forward * 2;
            }
        }
    }
}
