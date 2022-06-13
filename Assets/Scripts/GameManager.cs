using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject floor;
    public Player player;
    public NoteManager noteManager;

    private void Awake()
    {
        PlayerInit();
        CameraInit();
    }

    private void PlayerInit()
    {
        var playerObject = Resources.Load<GameObject>("Prefabs/Player/Player");
        playerObject = Instantiate(playerObject, Vector3.zero, Quaternion.Euler(0, 90f, 0));

        player = playerObject.AddComponent<Player>();
        player.transform.position = new Vector3(10f, 0, -230f);

        player.JumpPower = 7.5f;

        player.ways = new Vector3[]{
            new Vector3(11f, 0, -231f),
            new Vector3(11f, 0, -66f),
            new Vector3(-101f, 0, -66f),
            new Vector3(-101f, 0, 101f),
        };

        player.speed = 13f;
    }

    private void CameraInit()
    {
        CameraMove cameraMove = Camera.main.gameObject.AddComponent<CameraMove>();
        cameraMove.player = player.transform;
        cameraMove.speed = 5;
    }

    private void Update()
    {

    }
}
