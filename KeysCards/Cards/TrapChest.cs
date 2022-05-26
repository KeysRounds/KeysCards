using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace KeysCards.Cards
{
    class TrapChest : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            System.Random rnd = new System.Random();
            int randomInt = rnd.Next(0, player.data.currentCards.Count);

            CardInfo addedCard = ModdingUtils.Utils.Cards.instance.GetCardWithName("Giants Gauntlet");
            ModdingUtils.Utils.Cards.instance.AddCardToPlayer(player, addedCard, addToCardBar: true);
            ModdingUtils.Utils.CardBarUtils.instance.ShowAtEndOfPhase(player, addedCard);

            Unbound.Instance.ExecuteAfterSeconds(1, () =>
            {
                ModdingUtils.Utils.Cards.instance.RemoveCardFromPlayer(player, UnityEngine.Random.Range(0, player.data.currentCards.Count()));
            }
            );

        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
        }

        protected override string GetTitle()
        {
            return "Trap Chest";
        }
        protected override string GetDescription()
        {
            return "Lose a random card and gain a random <b><color=#ede624>Treasure</b></color>";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Uncommon;
        }
        protected override CardInfoStat[] GetStats()
        {
            return null;
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.DestructiveRed;
        }
        public override string GetModName()
        {
            return KeysCards.ModInitials;
        }
    }
}

