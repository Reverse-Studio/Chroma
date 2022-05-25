using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    private Vector3 ToGo;

    void Update()
    {
        float angle = (player.rotation.eulerAngles.y + 80) * Mathf.Deg2Rad;

        float x = Mathf.Cos(angle);
        float y = Mathf.Sin(angle);

        ToGo = player.position + new Vector3(y, 0.5f, x) * 20;
        transform.position += (ToGo - transform.position) * Time.deltaTime;

        transform.LookAt(player);
    }
}
