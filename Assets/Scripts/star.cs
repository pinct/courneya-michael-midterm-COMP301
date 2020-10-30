using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 750));
        StartCoroutine(DestroyTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }
}
