using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    //public CharacterController2D controller;
    //public float MovementSpeed = 3;

    [SerializeField] float speed;
    [SerializeField] GameObject bullet;

    float minX, minY, maxX, maxY;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esqInfIzq = (Camera.main).ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 esqSupDer = (Camera.main).ViewportToWorldPoint(new Vector2(1, 1));

        minX = esqInfIzq.x;
        minY = esqInfIzq.y;
        maxX = esqSupDer.x;
        maxY = esqSupDer.y;

        //Debug.Log("Min X: " + minX);
    }

    // Update is called once per frame
    void Update()
    {
        var dirH = Input.GetAxisRaw("Horizontal");
        var dirV = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector2(dirH * speed * Time.deltaTime, dirV * speed * Time.deltaTime));
        //Debug.Log(transform.localScale.x);

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minX+(transform.localScale.x / 1.5f), maxX - (transform.localScale.x / 1.5f)),
            Mathf.Clamp(transform.position.y, minY+(transform.localScale.y / 1.5f), maxY - (transform.localScale.y / 1.5f))
            );

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet,transform.position, transform.rotation);
        }

        /*if (transform.position.x < 9.72 && transform.position.y < 3.4)
        {
            transform.position += new Vector3(Movement, Movement2, 0) * Time.deltaTime * MovementSpeed;
        }
        else if(transform.position.x > 9.72)
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * MovementSpeed;
        }else if (transform.position.y > 3.4)
        {
            transform.position += new Vector3(0, -1, 0) * Time.deltaTime * MovementSpeed;
        }

        if (transform.position.x > -9.72 && transform.position.y > -3)
        {
            transform.position += new Vector3(Movement, Movement2, 0) * Time.deltaTime * MovementSpeed;
        }
        else if(transform.position.x < -9.72)
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * MovementSpeed;
        }else if (transform.position.y < -3)
        {
            transform.position += new Vector3(0, 1, 0) * Time.deltaTime * MovementSpeed;
        }
        */


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisionando con:");
        Debug.Log(collision.gameObject.name);
    }
}
