using HarmonyLib;

namespace KebabMultiplayerLimit.Patches.Runtime
{
    [HarmonyPatch(typeof(PhotonMultiplayerHandler), nameof(PhotonMultiplayerHandler.OnClickCreateRoom))]
    internal class PhotonButtonsPatch
    {
        static void Prefix(string roomName, string roomPassword, ref int maxPlayers, bool inviteOnly)
        {
            maxPlayers = 6;
        }
    }
}
