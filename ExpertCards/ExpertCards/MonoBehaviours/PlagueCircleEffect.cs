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
{   //I took basically the whole thing from HDC, please don't be mad lol
    class PlagueCircleEffect : MonoBehaviour
    {
        private Player player;
        private static GameObject lineEffect = null;

        public GameObject plagueEffect = null;
        public GameObject plagueObj = null;
        public static Color color = new Color(0, 100, 0);

        private void Start()
        {
            player = gameObject.GetComponent<Player>();

            plagueObj = new GameObject();
            plagueObj.transform.SetParent(player.transform);
            plagueObj.transform.position = player.transform.position;
            if (lineEffect == null)
            {
                GetLineEffect();
            }
            plagueEffect = Instantiate(lineEffect, plagueObj.transform);
            var effect = plagueObj.GetComponentInChildren<LineEffect>();
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
            effect.radius = 10f;
            effect.raycastCollision = true;
            effect.useColorOverTime = true;

        }

        private void GetLineEffect()
        {
            var card = CardChoice.instance.cards.First(c => c.name.Equals("ChillingPresence"));
            var statMods = card.gameObject.GetComponentInChildren<CharacterStatModifiers>();
            lineEffect = statMods.AddObjectToPlayer.GetComponentInChildren<LineEffect>().gameObject;
        }
        public void Destroy()
        {
            UnityEngine.GameObject.Destroy(this.plagueObj);
            UnityEngine.GameObject.Destroy(this.plagueEffect);
            UnityEngine.GameObject.Destroy(this);
        }
    }
}