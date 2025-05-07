using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    float _offsetX;
    float _offsetY;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            return;
        }
        _offsetX = transform.position.x - target.position.x;
        _offsetY = transform.position.y - target.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 pos = transform.position;
        pos = new Vector3(target.position.x + _offsetX, target.position.y + _offsetY, transform.position.z);
        transform.position = pos;
    }
}
