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
    class RecallEffect : MonoBehaviour
    {
        public Player player;

        public Block block;

        public CharacterData data;

        private Action<BlockTrigger.BlockTriggerType> recallAction;

        private float[] posArrayX = new float[180];

        private float[] posArrayZ = new float[180];

        private int counter = 0;

        private bool init = false;

        private float targetTime = 0.01666666666f;

        private void Awake()
        {
            player = base.gameObject.GetComponent<Player>();
        }
        private void Start()
        {
            if ((bool)block)
            {
                recallAction = GetDoBlockAction(player, block, data).Invoke;
                block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Combine(block.BlockAction, recallAction);
            }
        }

        public Action<BlockTrigger.BlockTriggerType> GetDoBlockAction(Player player, Block block, CharacterData data)
        {
            return delegate
            {
                if (this.init == false)
                {
                    player.GetComponentInParent<PlayerCollision>().IgnoreWallForFrames(2);
                    player.transform.position = new Vector3(posArrayX[0], posArrayZ[0], player.transform.position.y);
                }
                else
                {
                    if (this.counter == 179)
                    {
                        player.GetComponentInParent<PlayerCollision>().IgnoreWallForFrames(2);
                        player.transform.position = new Vector3(posArrayX[0], posArrayZ[0], player.transform.position.y);
                    }
                    else
                    {
                        player.GetComponentInParent<PlayerCollision>().IgnoreWallForFrames(2);
                        player.transform.position = new Vector3(posArrayX[counter + 1], posArrayZ[counter + 1], player.transform.position.y);
                    }
                }
            };
        }

        private void Update()
        {
            targetTime -= Time.deltaTime;
            if (this.counter == 180)
            {
                this.counter = 0;
                this.init = true;
            }

            if (targetTime <= 0.0f)
            {
                posArrayX[counter] = player.transform.position.x;
                posArrayZ[counter] = player.transform.position.y;
                counter++;
                targetTime = 0.01666666666f;
            }
        }
    }
}
