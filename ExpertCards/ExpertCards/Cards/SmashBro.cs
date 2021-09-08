using System;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace ExpertCards.Cards
{
    class SmashBro : CustomCard
    {
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            gun.knockback = 500f / (gun.projectiles.Length * 2);
            gun.damage *= .1f;
        }

        public override void OnRemoveCard()
        {
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
        }

        protected override GameObject GetCardArt()
        {
            return null;
        }

        protected override string GetDescription()
        {
            return "Knock em out.";
        }

        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Uncommon;
        }

        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[2]
        {
            new CardInfoStat
            {
                positive = false,
                stat = "Damage",
                amount = "Almost none",
                simepleAmount = CardInfoStat.SimpleAmount.notAssigned
            },
            new CardInfoStat
            {
                positive = true,
                stat = "Knockback",
                amount = "A HUGE AMOUNT",
                simepleAmount = CardInfoStat.SimpleAmount.aHugeAmountOf
            },
        };
        }

        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.FirepowerYellow;
        }

        protected override string GetTitle()
        {
            return "Smash Brother";
        }
    }
}
