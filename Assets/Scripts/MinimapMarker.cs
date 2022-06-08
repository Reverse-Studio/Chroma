using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapMarker : MonoBehaviour
{
    private Player player;
    public GameObject Marker;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update() {
        Marker.transform.position = new Vector3(this.transform.position.x, Marker.transform.position.y, this.transform.position.z);
        Marker.transform.forward = this.transform.forward;
    }
}
