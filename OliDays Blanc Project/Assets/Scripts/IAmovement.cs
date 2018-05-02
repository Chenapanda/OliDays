using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IAmovement : MonoBehaviour {

    public class MouvementsIA : MonoBehaviour
    {


        public float enemyLook;

        Transform Oli;
        NavMeshAgent enemy;


        void Start()
        {
            Oli = PlayManager.instance.player.transform;
            enemy = GetComponent<NavMeshAgent>(); // trouve le composant sur notre game object
        }


        void Update()
        {
            float distance = Vector3.Distance(Oli.position, transform.position);

            if (distance <= enemyLook)
            {
                enemy.SetDestination(Oli.position);

                if (distance <= enemy.stoppingDistance)
                {
                    // on pourra attaquer la cible ici (dans cette fonction)
                    FaceTarget();// regarder la cible
                }
            }
        }

        void FaceTarget()
        {
            Vector3 direction = (Oli.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, enemyLook); //le champ de regarde de l'ennemi correspond aux limitations de la sphère
        }
    }
}
