using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 7f;
    public float grav = 9.81f;
    public float jumpSpeed = 3f;
    public float dirY;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //WASD movement control
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        //jump control
        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                dirY = jumpSpeed;
            }
        }

        dirY -= grav * Time.deltaTime;

        direction.y = dirY;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }
    }
}
