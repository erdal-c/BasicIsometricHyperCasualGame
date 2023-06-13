using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    GameObject platform;
    [SerializeField]
    GameObject oldPlatform;
    [SerializeField]
    GameObject platformParent;

    Vector3 platformSet;
    Vector3 destination;

    bool playerClose;
    Transform playerTransform;
    
    
    void Start()
    {
        platformSet = oldPlatform.transform.position + destination;

        playerTransform = FindObjectOfType<PlayerControler>().gameObject.transform;
        //playerTransform = PlayerControler.GetInstance().gameObject.transform;
    }

    void Update()
    {
        IsPlayerClose();
<<<<<<< Updated upstream
        PlatformDestroyer3();
=======
        PlatformDestroyer();
>>>>>>> Stashed changes
    }

    public void AddPlatform()
    {
        if (playerClose == true && platformParent.transform.childCount < 35)
        {
            platformSet += destination;
            Instantiate(platform, platformSet, Quaternion.identity, platformParent.transform);
        }
        else if (playerClose == true && platformParent.transform.childCount >= 35)
        {
<<<<<<< Updated upstream
            //GameObject gameobject = ObjectPool.instance.RemoveQueue();
            platformSet += destination;
            //gameobject.transform.position = platformSet;
=======
            platformSet += destination;
>>>>>>> Stashed changes
            ObjectPool.instance.RemoveQueue().transform.position = platformSet;
        }
    }

    void IsPlayerClose()
    {
        if (Vector3.Distance(playerTransform.position, platformSet)<5f) 
        {
            playerClose = true;
            PlatformDestination();
            AddPlatform();
        }
    }

    void PlatformDestination()
    {
        if (Random.value <= 0.5f)
        {
            destination = new Vector3(0.6f, 0, 0);
        }
        else
        {
            destination = new Vector3(0, 0, 0.6f);
        }
    }

    void PlatformDestroyer()
    {
        foreach(Transform child in platformParent.transform)
        {
            if (Vector3.Distance(playerTransform.position, child.position) > 7.5f && child.gameObject.activeSelf == true)
            {
<<<<<<< Updated upstream
                Destroy(child.gameObject);   //child Transform objeci bu yüzden sadece Destroy(child) yazýnca destroy olmuyor. Destroy edebilmek için GameOject olmasý lazým.
=======
                ObjectPool.instance.AddQueue(child.gameObject);
>>>>>>> Stashed changes
            }
        }
        
    }
    void PlatformDestroyer3()
    {
        foreach(Transform child in platformParent.transform)
        {
            if (Vector3.Distance(playerTransform.position, child.position) > 7.5f && child.gameObject.activeSelf == true)
            {
                ObjectPool.instance.AddQueue(child.gameObject);
            }
        }


    }
}
