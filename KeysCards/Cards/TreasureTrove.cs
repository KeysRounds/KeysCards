using ModdingUtils.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnboundLib.GameModes;
using UnityEngine;

namespace KeysCards.Cards
{
    class TreasureTrove : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            GameModeManager.AddOnceHook(GameModeHooks.HookPlayerPickStart, (gm) => { KeysCards.instance.StartCoroutine(TreasurePick(player)); return new List<object>().GetEnumerator(); ; });
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
        }

        protected override string GetTitle()
        {
            return "Treasure Trove";
        }
        protected override string GetDescription()
        {
            return "Select from one of five <b><color=#ede624>Treasures</b></color> for your next card choice";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Rare;
        }
        protected override CardInfoStat[] GetStats()
        {
            return null;
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.FirepowerYellow;
        }
        public override string GetModName()
        {
            return KeysCards.ModInitials;
        }

        public static IEnumerator TreasurePick(Player player)
        {
            while (!CardChoice.instance.IsPicking) yield return null;
            if (CardChoice.instance.pickrID == player.playerID)
            {
                player.data.stats.GetAdditionalData().blacklistedCategories.Add(KeysCards.NonTreasure);
                player.data.stats.GetAdditionalData().blacklistedCategories.Remove(KeysCards.Treasure);
                GameModeManager.AddOnceHook(GameModeHooks.HookPlayerPickEnd,(gm) => EndTreasurePick(player));
            }
            else
                GameModeManager.AddOnceHook(GameModeHooks.HookPlayerPickStart, (gm) => { KeysCards.instance.StartCoroutine(TreasurePick(player)); return new List<object>().GetEnumerator(); });
            yield break;
        }

        public static IEnumerator EndTreasurePick(Player player)
        {
            player.data.stats.GetAdditionalData().blacklistedCategories.Add(KeysCards.Treasure);
            player.data.stats.GetAdditionalData().blacklistedCategories.Remove(KeysCards.NonTreasure);
            yield break;
        }
    }
}

