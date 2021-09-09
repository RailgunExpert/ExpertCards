using System;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using ExpertCards.Cards;
using ExpertCards.MonoBehaviours;

namespace ExpertCards.Cards
{
    class SizeDifference : CustomCard
    {
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            SizeDifferenceEffect sizeDifferenceEffect = player.gameObject.AddComponent<SizeDifferenceEffect>();
            //characterStats.sizeMultiplier *= 2f;
            sizeDifferenceEffect.stats = characterStats;
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
            return "Become massive, but shrink during the round.";
        }

        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Rare;
        }

        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[1]
            {
                new CardInfoStat
                {
                    positive = true,
                    stat = "Size",
                    amount = "100%",
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
            return "Size Difference";
        }
    }
}
