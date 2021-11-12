using System;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using ExpertCards.Cards;
using ExpertCards.MonoBehaviours;

namespace ExpertCards.Cards
{
    class BlackHole : CustomCard
    {
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            gun.gravity = 0f;
            gun.projectileSpeed *= .5f;
            var obj = new GameObject("BlackHole", typeof(BlackHoleEffect));
            gun.objectsToSpawn = new[]
            {
                new ObjectsToSpawn()
                {
                    AddToProjectile = obj
                }
            };
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
            return "Bullets drag nearby enemies towards the bullet.";
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
                    stat = "Bullet Speed",
                    amount = "-50%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat
                {
                    positive = true,
                    stat = "Bullet Gravity",
                    amount = "None",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
          };
        }

        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.TechWhite;
        }

        protected override string GetTitle()
        {
            return "Black Hole";
        }
        public override string GetModName()
        {
            return "EXC";
        }
    }
}
