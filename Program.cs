//using cookingsimulatormultiplayer.Commands;
//using cookingsimulatormultiplayer.helpers;
//using cookingsimulatormultiplayer.Util;
using HarmonyLib;
using KebabMultiplayerLimit.Util;
using System.Diagnostics;
using System.Reflection;
using UnityEngine.SceneManagement;

namespace Doorstop
{
    public static class Entrypoint
    {
        public static void Start()
        {
            Harmony.DEBUG = true;

            ConsoleHelper.CreateConsole();

            SceneManager.sceneLoaded += SceneLoaded;
        }

        static bool runtime = false;
        private static void Runtime()
        {
            //Debugger.Info("Runtime patching");
            //CommandInternal.Instance = new CommandInternal();
            //CommandInternal.Instance.RefreshModel();

            Harmony harmony = new Harmony("KebabMultiplayerLimit.Patches.Runtime");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            runtime = true;
        }

        private static void SceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode loadSceneMode)
        {
            Logger.Info($"Scene loaded: {scene.name} ({loadSceneMode})");
            // Execute patching after unity has finished it's startup and loaded at least the first game scene
            if (!runtime)
                Runtime();
        }
    }
}