using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    float offsetX;
    float offsetY;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            return;
        }
        offsetX = transform.position.x - target.position.x;
        offsetY = transform.position.y - target.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 pos = transform.position;
        pos = new Vector3(target.position.x + offsetX, target.position.y + offsetY, transform.position.z);
        transform.position = pos;
    }
}
