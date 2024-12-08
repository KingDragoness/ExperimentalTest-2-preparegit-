using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CameraTest : MonoBehaviour
{

    public Vector2Int maxSize = new Vector2Int(512, 512);
    public float speed = 12;

    private float pos_y = 0;

    private void Start()
    {
        pos_y = transform.position.y;
    }

    private void Update()
    {
        Vector3 pos = transform.position;

        //INPUT
        {
            if (Input.GetKey(KeyCode.W))
            {
                pos.z += speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                pos.z -= speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                pos.x += speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                pos.x -= speed * Time.deltaTime;
            }
        }

        {
            if (transform.position.x > maxSize.x)
            {
                pos.x = maxSize.x;
            }
            else if (transform.position.x < 0)
            {
                pos.x = 0;
            }

            if (transform.position.z > maxSize.y)
            {
                pos.z = maxSize.y;
            }
            else if (transform.position.z < 0)
            {
                pos.z = 0;
            }

            pos.y = pos_y;
        }

        transform.position = pos;
    }

}
