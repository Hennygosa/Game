using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject obj;
    void Start()
    {
        Instantiate(obj, gameObject.transform);
    }
<<<<<<< HEAD

    // Update is called once per frame
    void Update()
    {
        
    }
=======
>>>>>>> dev
}
