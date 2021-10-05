using System;
using UnboundLib;
using UnboundLib.Cards;
using ModdingUtils.Extensions;
using ModdingUtils.RoundsEffects;
using UnityEngine;
using ExpertCards.RoundsEffects;

namespace ExpertCards.Cards
{
    class Instability : CustomCard
    {
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            player.gameObject.GetOrAddComponent<InstabilityDealtDamageEffect>();
        }

        public override void OnRemoveCard()
        {
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            cardInfo.allowMultiple = false;
        }

        protected override GameObject GetCardArt()
        {
            return null;
        }

        protected override string GetDescription()
        {
            return "Your shots cause the enemy to teleport randomly for a bit";
        }

        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Uncommon;
        }

        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[1]
            {
                new CardInfoStat
                {
                    positive = true,
                    stat = "Instability Bullets",
                    amount = "+",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }

        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.EvilPurple;
        }

        protected override string GetTitle()
        {
            return "Instability";
        }
        public override string GetModName()
        {
            return "EXC";
        }
    }
}
