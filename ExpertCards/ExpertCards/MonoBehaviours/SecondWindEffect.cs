using System;
using Photon.Pun;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnboundLib;
using UnboundLib.Networking;
using UnityEngine;
using ModdingUtils.MonoBehaviours;

namespace ExpertCards.MonoBehaviours
{
    class SecondWindEffect : CounterReversibleEffect
    {
        internal float regenAmount;

        private float targetTime = defaultTargetTime;

        private float regenTime = 0f;

        private float lastFrameHp;

        private const float defaultTargetTime = 1f;

        private const float defaultRegenTime = 3f;


        public override void OnApply()
        {
        }

        public override void Reset()
        {
            this.lastFrameHp = base.data.health;
            this.regenTime = 0f;
        }

        public override CounterStatus UpdateCounter()
        {
            this.regenTime -= Time.deltaTime;
            if (base.data.health < lastFrameHp)
            {
                this.regenTime = SecondWindEffect.defaultRegenTime;
            }
            this.lastFrameHp = base.data.health;

            if (regenTime > 0f)
            {
                this.targetTime -= Time.deltaTime;
                if (this.targetTime < 0f)
                {
                    this.targetTime = SecondWindEffect.defaultTargetTime;
                    return CounterStatus.Apply;
                }
                else
                {
                    return CounterStatus.Wait;
                }
            }
            else
            {
                return CounterStatus.Wait;
            }
        }

        public override void UpdateEffects()
        {
            base.data.health += (base.data.maxHealth * regenAmount) / 3;
            base.data.health = UnityEngine.Mathf.Clamp(base.data.health, 0, base.data.maxHealth);
        }
    }
}
