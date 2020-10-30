using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject WASD;
    [SerializeField] GameObject spaceBar;
    // Start is called before the first frame update
    void Start()
    {
        spaceBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WASD.SetActive(false);
        spaceBar.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GameObject.Find("player").transform.position.y > 3.0f)
        {
            spaceBar.SetActive(false);
        }
    }
}
