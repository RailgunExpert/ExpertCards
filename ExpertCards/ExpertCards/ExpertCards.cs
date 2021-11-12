using System;
using System.Collections;
using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using UnboundLib.GameModes;
using UnboundLib.Networking;
using UnboundLib.Utils;
using UnityEngine;
using ExpertCards.Cards;
using ExpertCards.MonoBehaviours;
using ModdingUtils.Extensions;
using ModdingUtils.Utils;

namespace ExpertCards
{
    // hard dependencies for Unbound and ModdingUtils
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.legraycasterspatch", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin("org.bepinex.plugins.ExpertCards", "ExpertCards", "0.2")]
    [BepInProcess("ROUNDS.exe")]
    public class ExpertCards : BaseUnityPlugin
    {
        internal static bool BattleOngoing = false;
        void Awake()
        {

        }

        void Start()
        {
            Unbound.RegisterCredits("Expert Cards", new string[1]
        {
            "RailgunExpert"
        }, new string[2]
        {
            "If yall play Duck Game",
            "Check out my mod for that"
        }, new string[2]
        {
            "",
            "https://steamcommunity.com/sharedfiles/filedetails/?id=801068255"
        });

            CustomCard.BuildCard<MadKing>();
            CustomCard.BuildCard<SmashBro>();
            CustomCard.BuildCard<Recall>();
            CustomCard.BuildCard<SizeDifference>();
            CustomCard.BuildCard<SecondWind>();
            CustomCard.BuildCard<Instability>();
            CustomCard.BuildCard<Plague>();
            //CustomCard.BuildCard<BlackHole>();

            GameModeManager.AddHook(GameModeHooks.HookBattleStart, (gm) => ExpertCards.BattleStatus(true));
            GameModeManager.AddHook(GameModeHooks.HookGameStart, (gm) => ExpertCards.BattleStatus(false));
            GameModeManager.AddHook(GameModeHooks.HookPointEnd, (gm) => ExpertCards.BattleStatus(false));
        }
        internal static IEnumerator BattleStatus(bool status)
        {
            ExpertCards.BattleOngoing = status;
            if (!ExpertCards.BattleOngoing)
            {
                foreach (Player player in PlayerManager.instance.players)
                {
                    if (player.gameObject.GetComponent<InstabilityTeleportEffect>() != null)
                    {
                        Destroy(player.gameObject.GetComponent<InstabilityTeleportEffect>());
                    }
                }
            }
            yield break;
        }
    }
}
