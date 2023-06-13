using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    public Queue<GameObject> pool = new Queue<GameObject>();

    void Start()
    {
        if(instance == null) 
        {
            instance = this;
        }
    }

    public void AddQueue(GameObject gameobject)
    {
        pool.Enqueue(gameobject);
        gameobject.SetActive(false);
    }

    public GameObject RemoveQueue()
    {
        GameObject gameobject = pool.Dequeue();
        gameobject.SetActive(true);
        return gameobject;
    }
}
