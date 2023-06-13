using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    static DontDestroy instance;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
<<<<<<< Updated upstream

    // Update is called once per frame
    void Update()
    {
        
    }
=======
>>>>>>> Stashed changes
}
