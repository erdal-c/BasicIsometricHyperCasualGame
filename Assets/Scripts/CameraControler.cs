using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Transform playerPosition;
    public Vector3 camPositon;

    void Update()
    {
         this.gameObject.transform.position = playerPosition.position + camPositon;
    }
}
