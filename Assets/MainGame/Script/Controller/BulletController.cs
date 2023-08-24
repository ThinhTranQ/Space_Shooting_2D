using System;
using MainGame.Script.Base;
using UnityEngine;

namespace MainGame.Script.Controller
{
    public class BulletController : MoveController
    {
        [SerializeField] protected float lifeTime;
        [SerializeField] protected Transform source;
        // private float
        private void Update()
        {
            CountDownLifeTime();
            Move(transform.up);
        }

        protected virtual void CountDownLifeTime()
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }
                                                                            
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform == source) return;
            if (col.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage();
            }
        }
    }
}