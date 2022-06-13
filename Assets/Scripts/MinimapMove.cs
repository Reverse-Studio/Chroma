using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapMove : MonoBehaviour
{
    private Player Player;
    // Start is called before the first frame update
    void Start()
    {
        GameManager gm =GameObject.Find("GameManager").GetComponent<GameManager>();
        Player = gm.player;
    }
    // Update is called once per frame
    void Update()
    {
        var pos = Player.transform.position;
        Player.transform.forward = this.transform.forward;
        pos.y = transform.position.y;

        transform.position = pos;
    }
}
