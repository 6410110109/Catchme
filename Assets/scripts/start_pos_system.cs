using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_pos_system : NetworkBehaviour
{
    [SyncVar( hook = nameof(change_pos))] 
    public bool Ispos = false;

    public void set_pos()
    {
        Ispos = true; 
    }

    private void change_pos(bool old_set , bool new_set)
    {
        Ispos = new_set;
    }
}
