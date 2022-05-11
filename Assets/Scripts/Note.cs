using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public int type;
    public int speed;

    void Update()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
    }
}
