using System;
using MainGame.Script.Common;
using UnityEngine;

public class PlayerController : PlaneController
{
    protected override void Update()
    {
        GetInput();
        base.Update();
        
    }

    private void GetInput()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        direction = new Vector3(horizontal, vertical, 0).normalized;
    }
}  