using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    private bool canOpen = false;
    [SerializeField] GameObject star;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canOpen && Input.GetAxis("Submit") > 0 && !GetComponent<Animator>().GetBool("isOpen"))
        {
            GetComponent<Animator>().SetBool("isOpen", true);
            StartCoroutine(StarSpawn());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            canOpen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            canOpen = false;
        }
    }
    IEnumerator StarSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(star, transform);
        }
    }
}