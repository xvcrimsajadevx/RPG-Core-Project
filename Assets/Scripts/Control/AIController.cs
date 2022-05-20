using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Combat;
using RPG.Core;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5;

        Fighter fighter;
        GameObject player;
        Health health;

        private void Start() {
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
            health =GetComponent<Health>();
        }

        private void Update()
        {
            if (health.IsDead()) return;
            
            if (InAttackRangeOfPlayer() && fighter.CanAttack(player))
            {
                print(gameObject.name + " Should Chase");
                fighter.Attack(player);
            }
            else
            {
                fighter.Cancel();
            }
        }

        private bool InAttackRangeOfPlayer()
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;
        }
    }
}
