using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class player_in_room : NetworkBehaviour
{
    public GameObject[] start_pos;
    
    void Start()
    {
        start_pos = GameObject.FindGameObjectsWithTag("start_pos");

        if (isLocalPlayer)
        {
            transform.position = GameObject.FindGameObjectWithTag("start_pos_me").transform.position;
        }
        else
        {
            foreach (GameObject item in start_pos)
            {
                if (!item.GetComponent<start_pos_system>().Ispos)
                {
                    transform.position = item.transform.position;
                    item.GetComponent<start_pos_system>().set_pos();
                    break;
                }
               
            }
        }
    }
}
