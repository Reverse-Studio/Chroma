using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class NoteManager : MonoBehaviour
{
    List<int> notes = new List<int>{ 1, 2, 2, 2, 1, 2, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2 };
    GameObject note;
    float yPos = 0;
    Note noteCs;
    public int noteMark = 0;
    public string timeReset = "y";

    void Start()
    {
        note = Resources.Load<GameObject>("Prefabs/Note/note");

    }       

    private void Update()
    {
        if (timeReset == "y")
        {
            StartCoroutine(noteGenerator());
            timeReset = "n";
        }
    }
    void FixedUpdate()
    {
    
    }

    IEnumerator noteGenerator()
    {
        yield return new WaitForSeconds(1);

        if (notes[noteMark] == 1)
            yPos = 1f;

        if (notes[noteMark] == 2)
            yPos = 5f;


        noteMark += 1;
        timeReset = "y";
        Instantiate(note, new Vector3(10.8f, yPos, 0f), transform.rotation);
    }

    public void Destroy()
    {
        
    }
}
