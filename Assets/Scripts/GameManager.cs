using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject floor;
    public Player player;
    private void Start()
    {
        floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floor.tag = "Plane";

        var playerObject = Resources.Load<GameObject>("Prefabs/Player/Player");
        playerObject = Instantiate(playerObject, Vector3.zero, Quaternion.Euler(0, 90f, 0));

        player = playerObject.AddComponent<Player>();

        player.JumpPower = 7.5f;
    }

    private void Update()
    {

    }
}
