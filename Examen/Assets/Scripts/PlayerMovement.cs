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
    public GameObject PlayerShotUp;

    public GameObject ShotSpawner;
    public GameObject ShotSpawnerUp;
    public GameObject ShotSpawnerCrouch;

    public int health= 10;
    bool death = false;

    bool shootingUp = false;

    //private Vector2 direction;

    private void Start()
    {
        ShotSpawnerUp.SetActive(false);
        ShotSpawnerCrouch.SetActive(false);
    }

    void Update()
    {

        if (health == 0)
        {
            death = true;
        }

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
            speed = 0;

            ShotSpawnerUp.gameObject.SetActive(true);
            ShotSpawner.gameObject.SetActive(false);
            shootingUp = true;


        } else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool("IsShootingUp", false);
            speed = 40;

            ShotSpawnerUp.gameObject.SetActive(false);
            ShotSpawner.gameObject.SetActive(true);
            shootingUp = false;
        }



        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("IsCrouching", true);

            ShotSpawnerCrouch.gameObject.SetActive(true);
            ShotSpawner.gameObject.SetActive(false);

        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("IsCrouching", false);

            ShotSpawnerCrouch.gameObject.SetActive(false);
            ShotSpawner.gameObject.SetActive(true);
        }

        if (Input.GetButtonDown("Shoot"))
        {

            if (shootingUp == true)
            {
                if (Input.GetButtonDown("Shoot"))
                {
                    Instantiate(PlayerShotUp, ShotSpawnerUp.transform.position, Quaternion.identity);
                }
            } 
            else
            {
                animator.SetBool("IsShooting", true);

                if (direction == false)
                {
                    if (crouch == true)
                    {
                        if (Input.GetButtonDown("Shoot"))
                        {
                            Instantiate(PlayerShotLeft, ShotSpawnerCrouch.transform.position, Quaternion.identity);
                        }
                    }
                    else
                    {
                        if (Input.GetButtonDown("Shoot"))
                        {
                            Instantiate(PlayerShotLeft, ShotSpawner.transform.position, Quaternion.identity);
                        }
                    }
                    
                }
                else
                {
                    if (crouch == true)
                    {
                        if (Input.GetButtonDown("Shoot"))
                        {
                            Instantiate(PlayerShotRight, ShotSpawnerCrouch.transform.position, Quaternion.identity);
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
            }

            
        }

        else if (Input.GetButtonUp("Shoot"))
        {
            animator.SetBool("IsShooting", false);
        }

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EShot"))
        {
            health--;
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
