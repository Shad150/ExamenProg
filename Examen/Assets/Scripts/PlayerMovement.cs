using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float speed = 40f;

    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;

    public bool direction = true;

    public GameObject PlayerShotLeft;
    public GameObject PlayerShotRight;

    public GameObject ShotSpawner;

    //private Vector2 direction;


    void Update()
    {
        DirectionFaced();

        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKeyDown(KeyCode.Z))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetBool("IsShootingUp", true);

        } else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool("IsShootingUp", false);

        }



        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("IsCrouching", true);

        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("IsCrouching", false);
        }

        if (Input.GetButtonDown("Shoot"))
        {
            animator.SetBool("IsShooting", true);

            if (direction == false)
            {
                if (Input.GetButtonDown("Shoot"))
                {
                    Instantiate(PlayerShotLeft, ShotSpawner.transform.position, Quaternion.identity);
                }
            }
            else
            {
                if (Input.GetButtonDown("Shoot"))
                {
                    Instantiate(PlayerShotRight, ShotSpawner.transform.position, Quaternion.identity);
                }
            }
        }

        else if (Input.GetButtonUp("Shoot"))
        {
            animator.SetBool("IsShooting", false);
        }

        

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void DirectionFaced()
    {
        

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = false;
        }

        return;
    }

}
