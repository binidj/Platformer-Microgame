using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer.Mechanics 
{
    [RequireComponent(typeof(Collider2D))]
    public class FlyingEnemyController : MonoBehaviour
    {
        public PatrolPath path;
        public GameObject slimePrefab;
        internal PatrolPath.Mover mover;
        internal AnimationController control;
        private GameObject player;
        private bool isPatroling = true;
        [SerializeField]
        private float throwCooldown;
        private float throwCount = 0f;

        void Awake()
        {
            control = GetComponent<AnimationController>();
        }
        public void ChasePlayer(GameObject player) 
        {
            isPatroling = false;
            this.player = player;
            throwCount = throwCooldown / 2.0f;
        }

        public void Patrol() 
        {
            isPatroling = true;
            this.player = null;
            throwCount = 0;
        }

        void Update()
        {
            if (isPatroling) 
            {
                if (path != null)
                {
                    if (mover == null) mover = path.CreateMover(control.maxSpeed);
                    control.move.x = Mathf.Clamp(mover.Position.x - transform.position.x, -1, 1);
                }
            } 
            else 
            {
                control.move.x = Mathf.Clamp(player.transform.position.x - transform.position.x, -1, 1);
                if (throwCount > throwCooldown) {
                    ThrowMonster();
                    throwCount = 0f;
                } 
                else 
                {
                    throwCount += Time.deltaTime;
                }
            }
        }

        void ThrowMonster()
        {
            float sng = Mathf.Sign(player.transform.position.x - transform.position.x);
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0f);
            GameObject slimeObj = Instantiate(slimePrefab, pos, Quaternion.identity);
            slimeObj.GetComponent<EnemyController>().destroyIfNotMoving = true;
            AnimationController control = slimeObj.GetComponent<AnimationController>();
            control.move.x = sng;
        }
    }
}

