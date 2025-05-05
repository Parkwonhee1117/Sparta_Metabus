using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected AnimationHandler animationHandler;


    public float MoveSpeed = 5f;
    protected virtual void Awake()
    {
        animationHandler = GetComponent<AnimationHandler>();
    }

    protected virtual void Update()
    {
        Move();
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;

        transform.position += (Vector3)(moveDirection * MoveSpeed * Time.deltaTime);

        animationHandler.Move(moveDirection);
        Rotate(moveDirection);
    }


    public void Rotate(Vector2 obj)
    {
        if (obj.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (obj.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
