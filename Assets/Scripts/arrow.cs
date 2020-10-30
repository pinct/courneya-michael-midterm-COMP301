using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class arrow : MonoBehaviour
{
    private bool movingUp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movingUp == false)
        {
            if (GetComponent<RectTransform>().position.y > 7.8f)
            {
                GetComponent<RectTransform>().position = new Vector3(GetComponent<RectTransform>().position.x, GetComponent<RectTransform>().position.y - 0.01f, GetComponent<RectTransform>().position.z);
            }
            else
            {
                movingUp = true;
            }
        }
        else
        {
            if (GetComponent<RectTransform>().position.y < 8.1f)
            {
                GetComponent<RectTransform>().position = new Vector3(GetComponent<RectTransform>().position.x, GetComponent<RectTransform>().position.y + 0.01f, GetComponent<RectTransform>().position.z);
            }
            else
            {
                movingUp = false;
            }
        }
    }
}
