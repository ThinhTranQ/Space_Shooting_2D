using MainGame.Script.Base;
using MainGame.Script.Controller;
using UnityEngine;

namespace MainGame.Script.Common
{
    public class PlaneController : MoveController, IDamageable
    {
        public GameObject bullet;
        public Transform  spawnBulletPosition;

        protected Vector3 direction;

        private float fireRate;
        public  float defaultFireRate;
        protected virtual void Update()
        {
            Move(direction);
            CooldownFireRate();

        }

        protected void CooldownFireRate()
        {
            fireRate -= Time.deltaTime;
            if (fireRate <= 0) 
            {
                Fire();
                fireRate = defaultFireRate;
            }
        }
        
        protected void Fire()
        {
            var tempBullet = Instantiate(bullet, spawnBulletPosition.position, spawnBulletPosition.rotation);
        }

        public void TakeDamage()
        {
            gameObject.SetActive(false);
        }
    }
}