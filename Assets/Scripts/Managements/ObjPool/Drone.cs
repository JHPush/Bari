using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace ObjPool
{
    public class Drone : MonoBehaviour
    {
        public IObjectPool<Drone> pool { get; set; }

        public float currentHealth;

        [SerializeField]
        private float maxHealth = 100f;

        [SerializeField]
        private float timeToSelfDestruct = 3f;

        void Start()
        {
            currentHealth = maxHealth;
        }
        void OnEnable()
        {
            AttackPlayer();
            StartCoroutine(SelfDestruct());
        }
        void OnDisable()
        {
            ResetDrone();
        }
        IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(timeToSelfDestruct);
            TakeDamage(maxHealth);
        }
        private void ReturnToPool()
        {
            pool.Release(this);
        }
        private void ResetDrone()
        {
            currentHealth = maxHealth;
        }
        public void AttackPlayer()
        {
            Debug.Log("Att Player ~");
        }
        public void TakeDamage(float amount)
        {
            currentHealth -= amount;
            if (currentHealth <= 0f)
                ReturnToPool();
        }
    }


}