using System;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using ExpertCards.Cards;
using ExpertCards.MonoBehaviours;

namespace ExpertCards.Cards
{
    class Recall : CustomCard
    {
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            RecallEffect recallEffect = player.gameObject.AddComponent<RecallEffect>();
            recallEffect.player = player;
            recallEffect.block = block;
            recallEffect.data = data;
            block.cooldown += 1f;
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
            return "Blocking causes you to teleport to where you were 3 seconds ago";
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
                    positive = false,
                    stat = "Block Cooldown",
                    amount = "-1 Second",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }

        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.DefensiveBlue;
        }

        protected override string GetTitle()
        {
            return "Recall";
        }
        public override void OnRemoveCard()
        {
        }

        public override string GetModName()
        {
            return "EXC";
        }
    }
}
