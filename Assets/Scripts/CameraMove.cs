using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    public float speed;
    private Vector3 ToGo;

    void Update()
    {
        Follow();
        ObjectInvisible();
    }

    private void Follow()
    {
        float angle = (player.rotation.eulerAngles.y + 90) * Mathf.Deg2Rad;

        float x = Mathf.Cos(angle);
        float y = Mathf.Sin(angle);

        ToGo = player.position + new Vector3(y, 0.5f, x) * 20;
        transform.position += (ToGo - transform.position) * Time.deltaTime * speed;

        transform.LookAt(player);
    }

    private void ObjectInvisible()
    {
        Vector3 pos = transform.position;
        Vector3 angle = (player.transform.position - transform.position).normalized;
        float distance = Vector3.Distance(player.position, pos);


        Debug.DrawRay(pos, angle, Color.green, 0.1f);

        RaycastHit hit;

        if (Physics.Raycast(pos, angle, out hit, distance) && hit.transform.tag == "Object")
        {
            GameObject touchedObject = hit.collider.gameObject;
            Renderer hitRenderer = touchedObject.GetComponent<Renderer>();

            StartCoroutine(HitDelay(hitRenderer));
            hitRenderer.enabled = false;
        }
    }
    IEnumerator HitDelay(Renderer hitRenderer)
    {
        yield return new WaitForSeconds(2.4f);
        hitRenderer.enabled = true;
    }
}
