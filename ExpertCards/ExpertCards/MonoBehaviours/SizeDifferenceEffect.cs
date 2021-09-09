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
    class SizeDifferenceEffect : ReversibleEffect
    {
        public CharacterStatModifiers stats;

        private float preModifiedSize = 1f;

        private float currentSizeMult = 5f;

        private float targetTime = 2f;

        public override void OnStart()
        {
            preModifiedSize = characterStatModifiersModifier.sizeMultiplier_mult;
            base.characterStatModifiersModifier.sizeMultiplier_mult *= currentSizeMult;
            UnityEngine.Debug.Log(base.characterStatModifiersModifier.sizeMultiplier_mult);
            ApplyModifiers();
        }

        public override void OnUpdate()
        {
            targetTime -= Time.deltaTime;
            if(targetTime < 0.0f)
            {
                stats.sizeMultiplier = preModifiedSize * currentSizeMult;
                if (currentSizeMult > .25f)
                {
                    currentSizeMult -= 1f;
                }
                targetTime = 2f;
            }
        }
    }
}
