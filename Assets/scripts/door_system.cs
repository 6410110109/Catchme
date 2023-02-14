using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_system : MonoBehaviour
{
    public bool Isopen = false;
    void Start()
    {
        
    }

  
    void Update()
    {
        transform.rotation = Isopen ? Quaternion.Euler(0,90,0) : Quaternion.Euler(Vector3.zero);
    }
}
