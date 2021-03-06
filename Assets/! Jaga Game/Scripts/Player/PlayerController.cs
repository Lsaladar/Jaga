using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

[RequireComponent (typeof(HeadBobController))]
[RequireComponent (typeof(PlayerInteractions))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Variables")]
    public CharacterController controller;

    public HeadBobController headcontrol;

    public float speed = 4f;
    public float runSpeed = 8f;

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

    [Header("Sprinting Variables")]
    public bool staminaFull = true;
    public float maxStamina = 100f;
    public float playerStamina = 100f;

    [SerializeField, Range (0, 50)] private float staminaRegen = 0.5f;
    [SerializeField, Range (0, 50)] private float staminaDrain = 0.5f;

    [Header("Reputation Variables")]
    public float maxReputation = 100f;
    public float playerReputation = 70f;

    [Header("UI")]
    [SerializeField] private Image staminaProgressUI = null;
    [SerializeField] private CanvasGroup sliderCanvasGroup = null;

    [Space(20)]
    public Flowchart flowchart;
    // public Flowchart flowchart2;
    // bool canInteract1 = false;
    // bool canInteract2 = false;

    [Space(20)]
    [Header("Journal Variables")]
    public GameObject journal;
    public GameObject journalIcon;
    public bool journalOn = false;

    void Start()
    {
        journal.SetActive(false);
        sliderCanvasGroup.alpha = 0;
    }

    void Update()
    {
        playerReputation = flowchart.GetFloatVariable("Reputation");

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
            speed = 9f;

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




        if(!journalOn)
        {
            if(Input.GetKeyDown(KeyCode.J))
            {
                journal.SetActive(true);
                journalIcon.SetActive(false);
                journalOn = true;
                canMove = false;
                headcontrol = GetComponent<HeadBobController>();
                headcontrol.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.J))
            {
                journal.SetActive(false);
                journalIcon.SetActive(true);
                journalOn = false;
                canMove = true;
                headcontrol = GetComponent<HeadBobController>();
                headcontrol.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void Sprinting()
    {
        if (staminaFull)
        {
            staminaProgressUI.color = new Vector4(255, 255, 255, 255);
            isWalking = false;
            speed = runSpeed;
            playerStamina -= staminaDrain * Time.deltaTime;
            UpdateStamina(1);

            if (playerStamina <= 0.1)
            {
                staminaFull = false;
                staminaProgressUI.color = new Vector4(255, 0, 0, 255);
                speed = 9f;
                sliderCanvasGroup.alpha = 0;
            }
        }
    }

    void UpdateStamina(int num)
    {
        staminaProgressUI.fillAmount = playerStamina / maxStamina;

        if (num == 0)
        {
            sliderCanvasGroup.alpha = 0;
        }
        else
        {
            sliderCanvasGroup.alpha = 1;
        }
    }
}
