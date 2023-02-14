using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_system : MonoBehaviour
{
    public bool Isopen = false;
    public float smooth = 2.0f;

    private Quaternion targetRotaion;

    private void Start()
    {
        targetRotaion= transform.rotation;
    }

    public void ToggleDoor(bool b)
    {
        Isopen = !Isopen;

        if (Isopen)
        {
            targetRotaion = Quaternion.Euler(0, (b ? -90 : 90), 0);
        }
        else
        {
            targetRotaion = Quaternion.Euler(Vector3.zero);
        }
    }

  
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation , targetRotaion , smooth * Time.deltaTime);
  
    }

}
