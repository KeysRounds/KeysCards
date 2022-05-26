using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnboundLib;
using UnboundLib.Utils;
using System.Reflection;
using UnityEngine;
using System.Linq;
using Photon.Pun;
using System.Collections;

namespace KeysCards.Patches
{
    [Serializable]
    [HarmonyPatch(typeof(CardChoice), "Spawn")]
    internal class PatchTreasureTroveCardChoice
    {
        [HarmonyPriority(int.MinValue)]
        private static bool Prefix(CardChoice __instance, ref GameObject objToSpawn, ref AdjustedCards __state, int ___pickrID, List<GameObject> ___spawnedCards, Transform[] ___children, ref GameObject __result, Vector3 pos, Quaternion rot)
        {
            __state = new AdjustedCards();
            if (__instance.IsPicking)
            {
                var player = GetPlayerWithID(___pickrID);

                if(player.transform.gameObject.GetComponent<Cards.TreasureTroveMono>() != null)
                {
                    CardInfo[] spawnedCards = ___spawnedCards.Select(obj => obj.GetComponent<CardInfo>().sourceCard).ToArray();
                    if (spawnedCards.Length == 0)
                    {
                        __state.adjusted = true;
                        __state.newCard = ModdingUtils.Utils.Cards.instance.GetCardWithName("Giants Gauntlet");
                        objToSpawn = __state.newCard.gameObject;
                        __result = PhotonNetwork.Instantiate(objToSpawn.name, pos, rot, 0, null);
                        return false;
                    }
                    else if (spawnedCards.Length == 1)
                    {
                        __state.adjusted = true;
                        __state.newCard = ModdingUtils.Utils.Cards.instance.GetCardWithName("Dead Mans Boots");
                        objToSpawn = __state.newCard.gameObject;
                        __result = PhotonNetwork.Instantiate(objToSpawn.name, pos, rot, 0, null);
                        return false;
                    }
                    else if (spawnedCards.Length == 2)
                    {
                        __state.adjusted = true;
                        __state.newCard = ModdingUtils.Utils.Cards.instance.GetCardWithName("Yvrells Staff");
                        objToSpawn = __state.newCard.gameObject;
                        __result = PhotonNetwork.Instantiate(objToSpawn.name, pos, rot, 0, null);
                        return false;
                    }
                    else if (spawnedCards.Length == 3)
                    {
                        __state.adjusted = true;
                        __state.newCard = ModdingUtils.Utils.Cards.instance.GetCardWithName("Grovetenders Shield");
                        objToSpawn = __state.newCard.gameObject;
                        __result = PhotonNetwork.Instantiate(objToSpawn.name, pos, rot, 0, null);
                        return false;
                    }
                    else if (spawnedCards.Length == 4)
                    {
                        __state.adjusted = true;
                        __state.newCard = ModdingUtils.Utils.Cards.instance.GetCardWithName("Pickpockets Dagger");
                        objToSpawn = __state.newCard.gameObject;
                        __result = PhotonNetwork.Instantiate(objToSpawn.name, pos, rot, 0, null);
                        if (player.transform.gameObject.GetComponent<Cards.TreasureTroveMono>() != null)
                        {
                            player.transform.gameObject.GetComponent<Cards.TreasureTroveMono>().DestroySelf();
                        }
                            return false;
                    }
                }
                
            }
            return true;
        }
        internal static Player GetPlayerWithID(int playerID)
        {
            for (int i = 0; i < PlayerManager.instance.players.Count; i++)
            {
                if (PlayerManager.instance.players[i].playerID == playerID)
                {
                    return PlayerManager.instance.players[i];
                }
            }
            return null;
        }

        [HarmonyPriority(Priority.First)]
        private static void Postfix(CardChoice __instance, GameObject __result, AdjustedCards __state)
        {
            if (__state.adjusted)
            {
                KeysCards.instance.ExecuteAfterFrames(1, () => { __result.GetComponent<CardInfo>().sourceCard = __state.newCard; });
            }
        }

        private class AdjustedCards
        {
            public bool adjusted = false;
            public CardInfo newCard;
        }   
    }
}