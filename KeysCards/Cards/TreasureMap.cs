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
    class TreasureMap : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            statModifiers.lifeSteal = 0.3f;
            gun.attackSpeed = 0.8695f;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            if (player.transform.gameObject.GetComponent<MapCompassMono>() == null)
            {
                player.gameObject.AddComponent<MapCompassMono>();
            }
            player.transform.gameObject.GetComponent<MapCompassMono>().maps++;
            player.transform.gameObject.GetComponent<MapCompassMono>().checkCards();
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            if (player.transform.gameObject.GetComponent<MapCompassMono>() != null && CardCheck.Amount(player, "Treasure Map") == 1 && CardCheck.Amount(player, "Compass") == 0)
            {
                Destroy(player.transform.gameObject.GetComponent<MapCompassMono>());
            }
        }

        protected override string GetTitle()
        {
            return "Treasure Map";
        }
        protected override string GetDescription()
        {
            return "Gain a random <b><color=#ede624>Treasure</b></color> if you find a matching Compass card";
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
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Lifesteal",
                    amount = "+30%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Attack speed",
                    amount = "+15%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }
        public override string GetModName()
        {
            return KeysCards.ModInitials;
        }
    }
}

