using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongGenerator : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        SongManager.Instance.Playsingle(SongManager.Instance.stage1BGM, new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
