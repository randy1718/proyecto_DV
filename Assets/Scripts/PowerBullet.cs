using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("AHGGGGG FALLE!");
        if (collision.gameObject.name == "Square")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Square")
        {
            Destroy(gameObject);
        }
    }
}
