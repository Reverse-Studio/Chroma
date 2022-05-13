using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    NoteManager manager;

    private void Start()
    {
        manager = GameObject.Find("NoteManager").GetComponent<NoteManager>();
    }
    private void Update()
    {
        transform.position -= new Vector3(manager.speed * Time.deltaTime, 0f, 0f);
    }
}
