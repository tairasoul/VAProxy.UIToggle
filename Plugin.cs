using BepInEx;
using BepInEx.Configuration;
using System;
using UnityEngine;

namespace UIToggle
{
    internal class PluginInfo
    {
        public const string GUID = "tairasoul.uitoggle";
        public const string Name = "UIToggle";
        public const string Version = "1.0.0";
    }
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    internal class Plugin : BaseUnityPlugin
    {
        internal bool keyDown = false;
        internal ConfigEntry<KeyCode> hide;
        void Awake()
        {
            hide = Config.Bind("Keybinds", "toggle", KeyCode.P);
            Logger.LogInfo($"Plugin {PluginInfo.GUID} ({PluginInfo.Name}) version {PluginInfo.Version} loaded.");
        }

        void Update()
        {
            try
            {
                if (UnityInput.Current.GetKeyDown(hide.Value))
                {
                    if (!keyDown)
                    {
                        GameObject UI = GameObject.Find("UI");
                        GameObject ui = UI?.transform.Find("ui").gameObject;
                        ui?.SetActive(!ui.activeSelf);
                    }
                    keyDown = true;
                }
                else
                {
                    keyDown = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
