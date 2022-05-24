using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

[RequireComponent(typeof(HeadBobController))]
[RequireComponent(typeof(PlayerInteractions))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Variables")]
    public CharacterController controller;

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

    [SerializeField, Range(0, 50)] private float staminaRegen = 0.5f;
    [SerializeField, Range(0, 50)] private float staminaDrain = 0.5f;

    [Header("Reputation Variables")]
    public float maxReputation = 100f;
    public float playerReputation = 15f;

    [Header("UI")]
    [SerializeField] private Image staminaProgressUI = null;
    [SerializeField] private CanvasGroup sliderCanvasGroup = null;

    [Space(20)]
    public Flowchart flowchart;
    // public Flowchart flowchart2;
    // bool canInteract1 = false;
    // bool canInteract2 = false;

    public AudioSource[] sound;

    void Start()
    {
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

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("You have triggered an object");
        if(collider.gameObject.name == "BranchSFX_Trigger")
        {
            Debug.Log("Playing sound 1");
            sound[0].Play();
        }
        else if(collider.gameObject.name == "HameringSFX_Trigger")
        {
            Debug.Log("Playing sound 2");
            sound[1].Play();
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.name == "Water")
        {
            if(!sound[2].isPlaying)
            {
                Debug.Log("Play sound 3");
                sound[2].Play(1);

                if(sound[2].clip.length > 1.0f)
                {
                    sound[2].Stop();
                }
            }
        }
        else if(collider.gameObject.name == "Ground")
        {
            if (!sound[3].isPlaying)
            {
                Debug.Log("Play sound 3");
                sound[3].Play(1);

                if (sound[3].clip.length > 1.0f)
                {
                    sound[3].Stop();
                }
            }
        }
        else if(collider.gameObject.name == "Grass")
        {
            if (!sound[4].isPlaying)
            {
                Debug.Log("Play sound 3");
                sound[4].Play(1);

                if (sound[4].clip.length > 1.0f)
                {
                    sound[4].Stop();
                }
            }
        }
    }
}
