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
    class BlackHoleCircleEffect : MonoBehaviour
    {
        private static GameObject lineEffect = null;
        public GameObject blackHoleLineEffect = null;
        public GameObject blackHoleObj = null;
        public static Color color = new Color(0, 0, 0);
        private void Start()
        {

            blackHoleObj = new GameObject();
            blackHoleObj.transform.SetParent(this.transform);
            blackHoleObj.transform.position = this.transform.position;
            if (lineEffect == null)
            {
                GetLineEffect();
            }
            blackHoleLineEffect = Instantiate(lineEffect, blackHoleObj.transform);
            var effect = blackHoleObj.GetComponentInChildren<LineEffect>();
            effect.colorOverTime = new Gradient()
            {
                alphaKeys = new GradientAlphaKey[]
                {
                    new GradientAlphaKey(1,0)
                },
                colorKeys = new GradientColorKey[]
                {
                    new GradientColorKey(color,0)
                },
                mode = GradientMode.Fixed
            };
            effect.widthMultiplier = 1f;
            effect.radius = 5f;
            effect.raycastCollision = false;
            effect.useColorOverTime = true;
        }
        private void GetLineEffect()
        {
            var card = CardChoice.instance.cards.First(c => c.name.Equals("ChillingPresence"));
            var statMods = card.gameObject.GetComponentInChildren<CharacterStatModifiers>();
            lineEffect = statMods.AddObjectToPlayer.GetComponentInChildren<LineEffect>().gameObject;
        }
    }
}
