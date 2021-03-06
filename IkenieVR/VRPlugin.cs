﻿using IllusionPlugin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using VRGIN.Core;
using VRGIN.Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace IkenieVR
{

    /// <summary>
    /// This is an example for a VR plugin. At the same time, it also functions as a generic one.
    /// </summary>
    public class VRPlugin : IPlugin
    {

        /// <summary>
        /// Put the name of your plugin here.
        /// </summary>
        public string Name
        {
            get
            {
                return "My Kick-Ass VR Plugin";
            }
        }

        public string Version
        {
            get
            {
                return "1.0";
            }
        }

        private class Interpreter : GameInterpreter
        {
            public override bool IsIgnoredCanvas(Canvas canvas)
            {
                return base.IsIgnoredCanvas(canvas);
            }

            protected override void OnStart()
            {
                base.OnStart();
                VR.Camera.CopiedCamera += (s, e) =>
                {
                    var renderCameraUI = e.Camera.GetComponent("RenderCameraUI") as MonoBehaviour;
                    if(renderCameraUI)
                    {
                        renderCameraUI.enabled = false;
                        VRLog.Info("found RenderCameraUI {0}", e.Camera.name);
                    }
                    else
                    {
                        VRLog.Info("Not found RenderCameraUI {0}", e.Camera.name);
                    }
                };
            }

            public override bool IsIrrelevantCamera(Camera blueprint)
            {
                return blueprint.CompareTag("MainCamera");
            }
        }

        /// <summary>
        /// Determines when to boot the VR code. In most cases, it makes sense to do the check as described here.
        /// </summary>
        public void OnApplicationStart()
        {
            bool vrDeactivated = Environment.CommandLine.Contains("--novr");
            bool vrActivated = Environment.CommandLine.Contains("--vr");

            if (vrActivated || (!vrDeactivated && SteamVRDetector.IsRunning))
            {
                // Boot VRManager!
                // Note: Use your own implementation of GameInterpreter to gain access to a few useful operatoins
                // (e.g. characters, camera judging, colliders, etc.)
                VRManager.Create<Interpreter>(new SetsunaContext());
                VR.Manager.SetMode<GenericSeatedMode>();
            }
        }
        

        #region Unused
        public void OnApplicationQuit() { }
        public void OnFixedUpdate() { }
        public void OnLevelWasInitialized(int level) { }
        public void OnLevelWasLoaded(int level) { }
        public void OnUpdate() { }
            #endregion
        }
}
