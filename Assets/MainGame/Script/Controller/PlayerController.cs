using System;
using MainGame.Script.Common;
using MainGame.Script.Controller;
using UnityEngine;

public class PlayerController : PlaneController
{
    [SerializeField] private PlayerInput playerInput;
    private                  Vector2     screenBounds;
    
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    protected override void Update()
    {
        direction = playerInput.GetMovementInput();
        base.Update();
        
    }


    protected override void Move(Vector3 inputDirection) 
    {
        var playerPos = transform.position;
        if (playerPos.y >= screenBounds.y)
        {
            transform.position = new Vector2(playerPos.x , screenBounds.y);
        }
        else if (playerPos.y <= -screenBounds.y)
        {
            transform.position = new Vector2(playerPos.x , -screenBounds.y);
        }
        else if (playerPos.x >= screenBounds.x)
        {
            transform.position = new Vector2(screenBounds.x  , playerPos.y);
        }
        else if (playerPos.x <= -screenBounds.x)
        {
            transform.position = new Vector2(-screenBounds.x, playerPos.y);
        }
       
        base.Move(inputDirection);
    }
}  