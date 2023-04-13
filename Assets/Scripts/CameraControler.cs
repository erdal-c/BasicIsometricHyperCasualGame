using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Transform playerPosition;
    public Vector3 camPositon;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.gameObject.transform.position = new Vector3(playerPosition.position.x,0,0);
        this.gameObject.transform.position = playerPosition.position + camPositon;
    }
}
