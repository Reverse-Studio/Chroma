using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{

    List<int> notePos = new List<int>() { 1, 2, 2, 1, 3, 1, 2, 3, 2, 3, 1, 2, 3, 1, 3, 1, 2, 3, 3, 2, 3, 1, 2, 3, 1, 3, 2, 3, 1, 3, 2, 1, 2, 1, 3, 1, 2 };

    public static  List<GameObject> notes = new List<GameObject>();

    public int noteMark = 0;

    public Transform noteObj;

    public string timeReset = "y";

    public float yPos;

    public float xPos;
    // Update is called once per frame
    void Update()
    {
        if (timeReset == "y")
        {
            StartCoroutine(spawnNote());
            timeReset = "n";
        }
    }

    IEnumerator spawnNote()
    {
        yield return new WaitForSeconds(1);

        if (notePos[noteMark] == 1)
        {
            yPos = .38f;
        }

        if (notePos[noteMark] == 2)
        {
            yPos = 1.48f;
        }

        if (notePos[noteMark] == 3)
        {
            yPos = 2.45f;
        }
        timeReset = "y";

        Transform note = Instantiate(noteObj, new Vector3(6.2f, yPos, -2), noteObj.rotation);
        NoteTypes types = note.gameObject.AddComponent<NoteTypes>();
        types.type = notePos[noteMark];
        note.parent = GameObject.Find("Note").transform;
        notes.Add(note.gameObject);
        noteMark += 1;
    }
}
