using System;
using Photon.Pun;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnboundLib;
using UnboundLib.Networking;
using UnityEngine;

namespace ExpertCards.MonoBehaviours
{
    class SizeDifferenceEffect : MonoBehaviour
    {
        public Player player;

        public CharacterStatModifiers stats;

        public Gun gun;

        public CharacterData data;

        private float preModifiedSize = 1f;

        private float currentSizeMult = 10f;

        private float targetTime = 2f;

        private void Awake()
        {
            player = base.gameObject.GetComponent<Player>();
            stats = player.gameObject.GetComponent<CharacterStatModifiers>();
            preModifiedSize = stats.sizeMultiplier;
            stats.sizeMultiplier *= currentSizeMult;
        }

        private void Update()
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
