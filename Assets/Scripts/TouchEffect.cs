using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEffect : MonoBehaviour
{
    public float BreakTime;

    private void Update()
    {
        if(BreakTime > 0)
        {
            BreakTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
