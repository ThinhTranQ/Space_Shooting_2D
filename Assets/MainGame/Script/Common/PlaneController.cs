using MainGame.Script.Base;
using MainGame.Script.Controller;
using UnityEngine;

namespace MainGame.Script.Common
{
    public class PlaneController : MoveController, IDamageable
    {
      
        protected Vector3 direction;

        
        protected virtual void Update()
        {
            Move(direction);
           

        }

      
       

        public void TakeDamage()
        {
            gameObject.SetActive(false);
        }
    }
}