using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    Rigidbody2D myBody;
    [SerializeField] float speed;
    [SerializeField] float vida = 6;
    PhysicsMaterial2D material;
    float minX, minY, maxX, maxY;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        Vector2 esqInfIzq = (Camera.main).ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 esqSupDer = (Camera.main).ViewportToWorldPoint(new Vector2(1, 1));

        minX = esqInfIzq.x;
        minY = esqInfIzq.y;
        maxX = esqSupDer.x;
        maxY = esqSupDer.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (transform.position.x >= maxX - (transform.localScale.x / 1.5f))
        {
            speed *= -1;
        }
        else if (transform.position.x <= minX + (transform.localScale.x / 1.5f))
        {
            speed *= -1;
        }


        myBody.velocity = new Vector2(speed, myBody.velocity.y);

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minX + (transform.localScale.x / 1.5f), maxX - (transform.localScale.x / 1.5f)),
            Mathf.Clamp(transform.position.y, minY + (transform.localScale.y / 1.5f), maxY - (transform.localScale.y / 1.5f))
            );


        //Debug.Log(maxX);
        //Debug.Log(maxX - (transform.localScale.x / 2));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("whattt");
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            Destroy(collision.gameObject);

            vida -= 1;
            if (vida == 0)
            {
                Destroy(gameObject);
            }
            Debug.Log("Pierde vida");
            Debug.Log(vida);
        }else if (collision.gameObject.name == "powerBullet(Clone)")
        {
            Destroy(collision.gameObject);

            vida = 0;
            if (vida == 0)
            {
                Destroy(gameObject);
            }
            Debug.Log("Pierde vida");
            Debug.Log(vida);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Colisionando con:");
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            Destroy(collision.gameObject);
            material.bounciness = 0;
            

            if (vida == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                vida -= 1;
                Debug.Log("Pierde vida");
                Debug.Log(vida);
            }
        }
    }*/

}
