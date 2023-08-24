using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;

    protected virtual void Move(Vector3 inputDirection)
    {
        transform.position += inputDirection * (Time.deltaTime * moveSpeed);
    }
    
    
    
    
}