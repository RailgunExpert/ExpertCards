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
    // since this effect is time-dependent, use CounterReversibleEffect instead
    // ReversibleEffect applies only once (unless you manually apply it again)
    // CounterReversibleEffect applies however often you tell it to
    class SizeDifferenceEffect : CounterReversibleEffect
    {

        internal float baseSizeMult = 2f; // size multiplier when effect has just started, can be increased externally (i.e. in OnAddCard)

        internal float baseHpMult = 2f;

        private float currentSizeMult;

        private float currentHpMult;

        // I've made the effect apply more smoothly, feel free to change these values
        private const float defaultTargetTime = 0.05f;
        private const float deltaSizeMult = 0.005f;
        private const float deltaHpMult = 0.0025f;

        private float targetTime = defaultTargetTime;

        private const float minimumSizeMult = 0.25f;
        private const float minimumHpMult = 0.05f;

        // for CounterReversibleEffects do NOT override OnStart, OnUpdate, OnOnEnable, OnOnDisable, etc

        public override void OnApply()
        {
            // executed immediately AFTER effects are applied
        }

        public override void Reset()
        {
            // executed after OnEnable and OnDisable i.e. when the player dies and is revived, as well as at the beginning of each battle
            this.currentSizeMult = this.baseSizeMult;
            this.currentHpMult = this.baseHpMult;
            base.characterDataModifier.maxHealth_mult = this.baseHpMult;
            this.data.health = this.data.maxHealth * base.characterDataModifier.maxHealth_mult;
        }

        public override CounterStatus UpdateCounter()
        {
            // needs to return the current status of the counter effect which can be:
            /*
             * Apply - apply the effects now
             * Wait - don't do anything
             * Remove - remove the effects now
             * Destroy - remove the effects and completely remove this monobehaivor from the player
             */

            this.targetTime -= Time.deltaTime;
            if (this.targetTime < 0f)
            {
                this.targetTime = SizeDifferenceEffect.defaultTargetTime;

                // once time is up, apply the effects
                return CounterStatus.Apply;
            }
            else
            {
                // otherwise, just wait
                return CounterStatus.Wait;
            }
        }

        public override void UpdateEffects()
        {
            // this is only called immediately after UpdateCounter returns Apply, which is immediately before the effects are applied

            // update currentSizeMult, then edit the characterStatModifiersModifier
            if (base.characterStatModifiers.sizeMultiplier + this.currentSizeMult > SizeDifferenceEffect.minimumSizeMult)
            {
                currentSizeMult -= SizeDifferenceEffect.deltaSizeMult;

                // clamp to minimum size
                currentSizeMult = UnityEngine.Mathf.Clamp(base.characterStatModifiers.sizeMultiplier + this.currentSizeMult, SizeDifferenceEffect.minimumSizeMult, float.MaxValue) - base.characterStatModifiers.sizeMultiplier;
            }
            if (this.currentHpMult > SizeDifferenceEffect.minimumHpMult)
            {
                currentHpMult -= SizeDifferenceEffect.deltaHpMult;

                // clamp to minimum size
                currentHpMult = UnityEngine.Mathf.Clamp(this.currentHpMult, SizeDifferenceEffect.minimumHpMult, float.MaxValue);
            }

            // use sizeMultiplier_add since it is already a multiplier, unless you want exponential growth/decay, then use _mult
            // use = for the stat since it will be applied like: sizeMultiplier += sizeMultiplier_add
            base.characterStatModifiersModifier.sizeMultiplier_add = this.currentSizeMult;
            base.characterDataModifier.maxHealth_mult = this.currentHpMult;
            UnityEngine.Debug.Log(base.data.health);

            base.data.health = UnityEngine.Mathf.Clamp(base.data.health, 0, base.characterDataModifier.maxHealth_mult * this.data.maxHealth);
            
        }
    }
}
