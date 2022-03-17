using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using Fungus;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 4f;
    public float runSpeed = 8f;

    public float maxStamina = 100f;
    public float playerStamina = 100f;

    public float x;
    public float z;

    public bool staminaFull = true;

    [SerializeField, Range (0, 50)] private float staminaRegen = 0.5f;
    [SerializeField, Range (0, 50)] private float staminaDrain = 0.5f;

    public float gravity = -9.81f;

    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    Vector3 velocity;

    public Vector3 move;

    public bool canMove = true;
    public bool isWalking = true;
    public bool isMoving = false;

    [SerializeField] private Slider staminaProgressUI = null;
    [SerializeField] private CanvasGroup sliderCanvasGroup = null;

    // public Flowchart flowchart1;
    // public Flowchart flowchart2;
    // bool canInteract1 = false;
    // bool canInteract2 = false;

    void Start()
    {
        sliderCanvasGroup.alpha = 0;
    }

    void Update()
    {
        if(canMove)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(move.magnitude > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isWalking)
        {
            speed = 4f;

            if(playerStamina <= maxStamina - 0.01)
            {
                playerStamina += staminaRegen * Time.deltaTime;
                UpdateStamina(1);

                if (playerStamina >= maxStamina - 0.1)
                {
                    sliderCanvasGroup.alpha = 0;
                    staminaFull = true;
                }
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprinting();
        }
        else
        {
            isWalking = true;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);  
        }
        

        // if(canInteract1)
        // {
        //     if(Input.GetKeyDown(KeyCode.E))
        //     {
        //         flowchart1.ExecuteBlock("BeginSpeaking");
        //         canInteract1 = false;
        //     }
        // }
        // if (canInteract2)
        // {
        //     if (Input.GetKeyDown(KeyCode.E))
        //     {
        //         flowchart2.ExecuteBlock("BeginSpeaking");
        //         canInteract2 = false;
        //     }
        // }
    }

    public void Sprinting()
    {
        if (staminaFull)
        {
            isWalking = false;
            speed = runSpeed;
            playerStamina -= staminaDrain * Time.deltaTime;
            UpdateStamina(1);

            if (playerStamina <= 0.1)
            {
                staminaFull = false;
                speed = 4f;
                sliderCanvasGroup.alpha = 0;
            }
        }
    }

    void UpdateStamina(int num)
    {
        staminaProgressUI.value = playerStamina / maxStamina;

        if (num == 0)
        {
            sliderCanvasGroup.alpha = 0;
        }
        else
        {
            sliderCanvasGroup.alpha = 1;
        }
    }

    // void OnTriggerEnter(Collider collider)
    // {
    //     if(collider.gameObject.tag == "Christian_NPC")
    //     {
    //         canInteract1 = true;
    //     }
    //     if (collider.gameObject.tag == "Pagen_NPC")
    //     {
    //         canInteract2 = true;
    //     }
    // }
}
