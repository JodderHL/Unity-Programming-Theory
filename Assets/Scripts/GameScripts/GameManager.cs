using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ChangeToPlayMode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeToPlayMode()
    {
        Cursor.visible = false;
    }

    void ChangeToMenuMode()
    {
        Cursor.visible = true;
    }
}
