using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float speed = 1f;

    public int type;
   
    private void Update()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
    }
}
