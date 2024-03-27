using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 8.0f;
    private float zBound = 15;
    private float xBound = 15;
    private float PlayerHP = 10;

    void Start()
    {

    }

    void Update()
    {
        //Player movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.left * Time.deltaTime * speed * verticalInput);

        //Boundary
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
    }

    //Check if player gets hit by enemies
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            Debug.Log("Your character has lost 1 hp!");
        }
    }
}
