using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig : NetworkBehaviour
{
    [SerializeField]
    private GameObject[] gameObject_to_disable;

    [SerializeField]
    private Behaviour[] behaviour_to_disable;

    [SerializeField]
    private GameObject[] gameObject_to_disable_local;
    
    void Start()
    {
        if (!isLocalPlayer)
        {
            foreach (GameObject item in gameObject_to_disable)
            {
                item.SetActive(false);
            }

            foreach (Behaviour item in behaviour_to_disable)
            {
                item.enabled = false;
            }
        }
        else
        {
            foreach (GameObject item in gameObject_to_disable_local)
            {
                item.SetActive(false);
            }
        }

        
    }
   
}
