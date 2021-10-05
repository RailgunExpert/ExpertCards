using System;
using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using UnboundLib.GameModes;
using UnboundLib.Networking;
using UnboundLib.Utils;
using UnityEngine;
using ExpertCards.Cards;
using ModdingUtils.Extensions;
using ModdingUtils.Utils;

namespace ExpertCards
{
    // hard dependencies for Unbound and ModdingUtils
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin("org.bepinex.plugins.ExpertCards", "ExpertCards", "0.2")]
    [BepInProcess("ROUNDS.exe")]
    public class ExpertCards : BaseUnityPlugin
    {
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
            "idk what to put here",
            "i just wanted a credits page"
        }, new string[2]
        {
            "",
            ""
        });

            CustomCard.BuildCard<MadKing>();
            CustomCard.BuildCard<SmashBro>();
            CustomCard.BuildCard<Recall>();
            CustomCard.BuildCard<SizeDifference>();
            CustomCard.BuildCard<SecondWind>();
            CustomCard.BuildCard<Instability>();
        }
    }

}
