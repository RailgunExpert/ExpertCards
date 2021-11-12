using System;
using Photon.Pun;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnboundLib;
using UnboundLib.Networking;
using UnityEngine;
using ModdingUtils.MonoBehaviours;
using ModdingUtils.Extensions;

namespace ExpertCards.MonoBehaviours
{
    class InstabilityTeleportEffect : ReversibleEffect
    {
        private Player player;

        internal int numTeleports = 5;

        private const float defaultTeleportTime = .3f;

        private float targetTime = defaultTeleportTime;

        private int currentTeleport = 0;

        private Vector3 initialPos;

        public override void OnStart()
        {
            player = base.gameObject.GetComponent<Player>();
            initialPos = player.transform.position;
        }

        public override void OnUpdate()
        {
            targetTime -= Time.deltaTime;
            if (this.targetTime < 0)
            {
                if (this.currentTeleport < this.numTeleports)
                {
                    initialPos.x += UnityEngine.Random.Range(-5f, 5f);
                    initialPos.y += UnityEngine.Random.Range(-5f, 5f); 
                    player.transform.position = initialPos;
                    player.GetComponentInParent<PlayerCollision>().IgnoreWallForFrames(2);
                    this.currentTeleport++;
                    player.data.playerVel.SetFieldValue("velocity", Vector2.zero);
                    initialPos = player.transform.position;
                }
                else
                    Destroy(this);
                targetTime = InstabilityTeleportEffect.defaultTeleportTime;
            }
        }
        public override void OnOnDisable()
        {
            Destroy(this);
        }
    }
}
