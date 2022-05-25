using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    private Vector3 ToGo;

    void Update()
    {
        Follow();
        ObjectInvisible();
    }

    private void Follow()
    {
        float angle = (player.rotation.eulerAngles.y + 80) * Mathf.Deg2Rad;

        float x = Mathf.Cos(angle);
        float y = Mathf.Sin(angle);

        ToGo = player.position + new Vector3(y, 0.5f, x) * 20;
        transform.position += (ToGo - transform.position) * Time.deltaTime;

        transform.LookAt(player);
    }

    private void ObjectInvisible()
    {
        Vector3 angle = transform.forward;
        Vector3 pos = transform.position;
        float distance = Vector3.Distance(player.position, pos);


        Debug.DrawRay(pos, angle, Color.green, 0.1f);

        RaycastHit ray;

        if (Physics.Raycast(pos, angle, out ray, distance, LayerMask.GetMask("Object")))
        {
            GameObject touchedObject = ray.collider.gameObject;
            Renderer renderer = touchedObject.GetComponent<Renderer>();

            renderer.enabled = false;
        }
    }
}
