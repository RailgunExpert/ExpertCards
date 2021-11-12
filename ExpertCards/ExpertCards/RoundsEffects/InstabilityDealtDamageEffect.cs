using System;
using Photon.Pun;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnboundLib;
using UnboundLib.Networking;
using UnityEngine;
using ModdingUtils.RoundsEffects;
using ExpertCards.MonoBehaviours;

namespace ExpertCards.RoundsEffects
{
    class InstabilityDealtDamageEffect : HitEffect
    {
        public override void DealtDamage(Vector2 damage, bool selfDamage, Player damagedPlayer = null)
        {
            if (damagedPlayer == null) { return; }
            if(damagedPlayer.data.dead) { return; }
            InstabilityTeleportEffect ite = damagedPlayer.gameObject.GetOrAddComponent<InstabilityTeleportEffect>();
        }
    }
}
