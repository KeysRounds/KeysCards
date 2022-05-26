using BepInEx;
using UnboundLib;
using UnboundLib.GameModes;
using UnboundLib.Cards;
using KeysCards.Cards;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using UnityEngine;


namespace KeysCards
{

    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin(ModId, ModName, Version)]
    [BepInProcess("Rounds.exe")]
    public class KeysCards : BaseUnityPlugin
    {


        public static KeysCards instance { get; private set; }

        private const string ModId = "com.keys.rounds.KeysCards";
        private const string ModName = "KeysCards";
        public const string Version = "0.2.0";
        public const string ModInitials = "KEYS";

        void Awake()
        {
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }

        IEnumerator GameStart(IGameModeHandler gm)
        {

            foreach (var player in PlayerManager.instance.players)
            {
                if (!ModdingUtils.Extensions.CharacterStatModifiersExtension.GetAdditionalData(player.data.stats).blacklistedCategories.Contains(YvrellsStaff.componentCategory))
                {
                    ModdingUtils.Extensions.CharacterStatModifiersExtension.GetAdditionalData(player.data.stats).blacklistedCategories.Add(YvrellsStaff.componentCategory);
                }
                if (!ModdingUtils.Extensions.CharacterStatModifiersExtension.GetAdditionalData(player.data.stats).blacklistedCategories.Contains(IronCarapace.componentCategory))
                {
                    ModdingUtils.Extensions.CharacterStatModifiersExtension.GetAdditionalData(player.data.stats).blacklistedCategories.Add(IronCarapace.componentCategory);
                }
            }
            yield break;
        }

        void Start()
        {

            instance = this;

            CustomCard.BuildCard<Nimble>();
            CustomCard.BuildCard<LootBox>();
            CustomCard.BuildCard<Warpath>();
            CustomCard.BuildCard<MendingReload>();
            CustomCard.BuildCard<Opportunist>();
            CustomCard.BuildCard<SnipersNest>();
            CustomCard.BuildCard<Sentry>();
            CustomCard.BuildCard<ChargeShot>();
            CustomCard.BuildCard<Mirror>();
            CustomCard.BuildCard<RaidBoss>();
            CustomCard.BuildCard<Virus>();
            CustomCard.BuildCard<Critical>();
            CustomCard.BuildCard<CrimsonPotion>();
            CustomCard.BuildCard<DruidsBlessing>();
            CustomCard.BuildCard<Moonwalker>();
            CustomCard.BuildCard<WallSkater>();
            CustomCard.BuildCard<TreasureTrove>();
            CustomCard.BuildCard<TreasureMap>();
            CustomCard.BuildCard<CompassCard>();
            CustomCard.BuildCard<GiantsGauntlet>();
            CustomCard.BuildCard<DeadMans>();
            CustomCard.BuildCard<YvrellsStaff>();
            CustomCard.BuildCard<GrovetendersShield>();
            CustomCard.BuildCard<PickpocketsDagger>();
            CustomCard.BuildCard<Metamorphosis>();
            CustomCard.BuildCard<IronCarapace>();
            CustomCard.BuildCard<IronPincers>();
            CustomCard.BuildCard<Bounce>();
            GameModeManager.AddHook(GameModeHooks.HookGameStart, GameStart);
        }
    }
}
