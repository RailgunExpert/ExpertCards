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
    class BlackHoleEffect : MonoBehaviour
    {
        private void Awake()
        {
            if (transform.parent != null)
            {
                transform.parent.gameObject.AddComponent<BlackHoleEffect>();
                transform.parent.gameObject.AddComponent<BlackHoleCircleEffect>();
                transform.parent.gameObject.AddComponent<BlackHoleSecondaryCircleEffect>();
                return;
            }
            else
            {
                foreach (var obj in GetComponentsInChildren<BlackHoleEffect>().Where(bullet => bullet != this))
                {
                    Destroy(obj.gameObject);
                }
            }
        }

        private void Update()
        {
            if (RangeCheck())
            {
                foreach (Player enemy in GetEnemyPlayers())
                {
                    CharacterData enemyData = enemy.GetComponent<CharacterData>();
                    Vector3 enemyPos = enemyData.transform.position;
                    float dist = Vector2.Distance(this.transform.position, enemyPos);
                    if (dist <= 5f)
                    {
                        Vector3 direction = this.transform.position - enemyData.transform.position;
                        direction = direction.normalized;
                        enemyData.transform.position += direction * 25f * Time.deltaTime;
                    }
                }
                
            }
        }
        private bool RangeCheck()
        {
            foreach (Player enemy in GetEnemyPlayers())
            {
                CharacterData enemyData = enemy.GetComponent<CharacterData>();
                float distance = Vector2.Distance(this.transform.position, enemyData.playerVel.position);
                if (distance <= 5f)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Player> GetEnemyPlayers()
        {
            return PlayerManager.instance.players.ToList();
        }
    }
}
