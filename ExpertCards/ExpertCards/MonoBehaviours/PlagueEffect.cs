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
    class PlagueEffect : MonoBehaviour
    {
        private Player player;
        private CharacterData data;
        private PlagueCircleEffect plagueCircleEffect;
        public static Color color = new Color(0, 100, 0);
        internal float damagePercent = 0f;

        private void Start()
        {
            player = base.gameObject.GetComponent<Player>();
            data = this.player.GetComponent<CharacterData>();
            plagueCircleEffect = this.player.gameObject.AddComponent<PlagueCircleEffect>();

        }
        private void Update()
        {
            if (!ExpertCards.BattleOngoing)
                return;
            if (RangeCheck())
            {
                foreach (Player enemy in GetEnemyPlayers())
                {
                    CharacterData enemyData = enemy.GetComponent<CharacterData>();
                    Vector2 enemyPos = enemyData.playerVel.position;
                    float dist = Vector2.Distance(this.data.playerVel.position, enemyPos);
                    if (dist <= 10f && PlayerManager.instance.CanSeePlayer(this.player.transform.position, enemy).canSee)
                    {
                        Vector2 damage = new Vector2(0, (enemyData.maxHealth * this.damagePercent) * Time.deltaTime);
                        enemyData.healthHandler.DoDamage(damage, enemyPos, color, null, this.player, false, true, true);
                    }
                }
            }
        }
        private bool RangeCheck()
        {
            foreach (Player enemy in GetEnemyPlayers())
            {
                CharacterData enemyData = enemy.GetComponent<CharacterData>();
                float distance = Vector2.Distance(this.data.playerVel.position, enemyData.playerVel.position);
                if (distance <= 10f && PlayerManager.instance.CanSeePlayer(this.player.transform.position, enemy).canSee)
                {
                    return true;
                }
            }
            return false;
        }
        public List<Player> GetEnemyPlayers()
        {
            return PlayerManager.instance.players.Where(player => player.teamID != this.player.teamID).ToList();
        }
    }
}
