using UnityEngine;

namespace MainGame.Script.Controller
{
    public class PlayerInput : MonoBehaviour
    {
        public Vector3 GetMovementInput()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            return new Vector3(horizontal, vertical, 0).normalized;
        }
    }
}