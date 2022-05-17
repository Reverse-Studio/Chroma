using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class NoteManager : MonoBehaviour
{

    public GameObject note;
    float xPos;
    Note noteCs;

    void Awake()
    {
        noteCs = GameObject.Find("Note").GetComponent<Note>();
        noteCs.speed = 10f;
        noteGenerator(note);
    }

    void FixedUpdate()
    {
        Debug.Log(noteCs.type);
    }

    public void noteGenerator(GameObject note)
    {
        Instantiate(note, new Vector3(6.4f, 0, 0), Quaternion.identity);
        noteCs.type = 1;    
    }
}
