using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    public float MoveSpeed = 5f;

    void Update()
    {
        OnMove();
    }

    public void OnMove()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;

        transform.position += (Vector3)(moveDirection * MoveSpeed * Time.deltaTime);

        animationHandler.Move(moveDirection);
        
    }
}
