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
    class BlackHoleSecondaryCircleEffect : MonoBehaviour
    {
        private static GameObject lineEffect = null;
        public GameObject blackHoleLineEffect = null;
        public GameObject blackHoleObj = null;
        public LineEffect effect;
        public static Color color = new Color(255, 255, 255);
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
            this.effect = blackHoleObj.GetComponentInChildren<LineEffect>();
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
            this.effect.widthMultiplier = 1f;
            this.effect.radius = 4.5f;
            this.effect.raycastCollision = false;
            this.effect.useColorOverTime = true;
        }
        private void Update()
        {
            this.effect.radius -= Time.deltaTime;
            if (this.effect.radius < 1f)
            {
                this.effect.radius = 4.5f;
            }
        }
        private void GetLineEffect()
        {
            var card = CardChoice.instance.cards.First(c => c.name.Equals("ChillingPresence"));
            var statMods = card.gameObject.GetComponentInChildren<CharacterStatModifiers>();
            lineEffect = statMods.AddObjectToPlayer.GetComponentInChildren<LineEffect>().gameObject;
        }
    }
}
