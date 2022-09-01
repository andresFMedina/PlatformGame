using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Player.transform.position.x;       

        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    position.y = transform.position.y * 2.0f;
        //}

        transform.position = position;
    }
}
