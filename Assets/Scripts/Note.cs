using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public int type = 0;

    public void OnTriggerExit(Collider other)
    {
        if (other is SphereCollider)
        {
            Destroy(this.gameObject);
        }
    }

    public void Update()    
    {
        transform.Rotate(0, Time.deltaTime * 88, 0);
    }
}
