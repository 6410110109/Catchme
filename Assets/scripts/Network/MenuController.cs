using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MenuController : NetworkBehaviour
{
   public NetworkRoomManager roomManager;

    private void Start()
    {
        if (isLocalPlayer)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }

    public void onCreateMatch()
    {
        roomManager.StartHost();
    }

    public void JoinMatch()
    {
        roomManager.StartClient();
    }
}
