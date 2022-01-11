using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (isOpen)
            {
                transform.Translate(0, -5, 0);
            }
            else
            {
                transform.Translate(0, 5, 0);
            }
            isOpen = !isOpen;
        }
    }
}
