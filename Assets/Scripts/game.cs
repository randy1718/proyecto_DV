using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    //public CharacterController2D controller;
    //public float MovementSpeed = 3;

    [SerializeField] float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject PowerBullet;
    float timer;
    [SerializeField] float intervaloSeg;
    float modoDisparo = 1;
    float contador;

    float minX, minY, maxX, maxY;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        contador = Time.time;
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
        Debug.Log(Time.time);
        Debug.Log(timer);

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minX+(transform.localScale.x / 1.5f), maxX - (transform.localScale.x / 1.5f)),
            Mathf.Clamp(transform.position.y, minY+(transform.localScale.y / 1.5f), maxY - (transform.localScale.y / 1.5f))
            );

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Oprimiendo Q");
            if (modoDisparo == 1)
            {
                modoDisparo = 2;
            }
            else
            {
                modoDisparo = 1;
            }
        }

        Debug.Log(modoDisparo);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            contador = Time.time;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Oprimiendo");
            Debug.Log("Numero: " + contador);
            Debug.Log("Time: " + Time.time);

            if (Time.time >= contador+3.0f && Time.time < contador + 3.1f)
            {
                if (modoDisparo == 2)
                {
                    Instantiate(PowerBullet, transform.position, transform.rotation);
                    contador = -Time.time;
                }
            }
        }

            if (Input.GetKeyDown(KeyCode.Space) && Time.time > timer)
        {
            timer = Time.time + intervaloSeg;
            if (modoDisparo == 1)
            {
                Instantiate(bullet, transform.position, transform.rotation);
            }
            /*else if(modoDisparo == 2)
            {
                Instantiate(PowerBullet, transform.position, transform.rotation);
            }*/
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
