using System;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace ExpertCards.Cards
{
    class MadKing : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            cardInfo.allowMultiple = false;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            data.health *= .9f;
            gravity.gravityForce = -3f;
        }

        protected override string GetTitle()
        {
            return "Boots of the Mad King";
        }

        protected override string GetDescription()
        {
            return "Ascend to kinghood";
        }

        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[2]
        {
            new CardInfoStat
            {
                positive = true,
                stat = "Gravity",
                amount = "Negative",
                simepleAmount = CardInfoStat.SimpleAmount.notAssigned
            },
            new CardInfoStat
            {
                positive = false,
                stat = "Health",
                amount = "Slightly lower",
                simepleAmount = CardInfoStat.SimpleAmount.notAssigned
            },
        };
        }

        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Rare;
        }

        protected override GameObject GetCardArt()
        {
            return null;
        }

        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }

        public override void OnRemoveCard()
        {
        }
    }
}
