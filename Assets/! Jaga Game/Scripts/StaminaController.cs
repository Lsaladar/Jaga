//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class StaminaController : MonoBehaviour
//{
//    [Header("Stamina Main Parameters")]
//    public float playerStamina = 100.0f;
//    [SerializeField] private float maxStamina = 100.0f;
//    [HideInInspector] public bool hasRegenerated = true;
//    [HideInInspector] public bool isSprinting = false;

//    [Header("Stamina Regen parameters")]
//    [Range(0, 50)] [SerializeField] private float staminaDrain = 0.5f;
//    [Range(0, 50)] [SerializeField] private float staminaRegen = 0.5f;

//    [Header("Stamina Speed parameters")]
//    [SerializeField] private int normalRunSpeed = 8;

//    [Header("Stamina UI Elements")]
//    // [SerializeField] private Image staminaProgressUI = null;
//    [SerializeField] private Slider staminaProgressUI = null;
//    [SerializeField] private CanvasGroup sliderCanvasGroup = null;

//    private PlayerController playerController;

//    private void Start()
//    {
//        playerController = GetComponent<PlayerController>();
//    }

//    private void Update()
//    {
//        if(!isSprinting)
//        {
//            if(playerStamina <= maxStamina - 0.01)
//            {
//                playerStamina += staminaRegen * Time.deltaTime;
//                UpdateStamina(1);

//                if(playerStamina >= maxStamina)
//                {
//                    playerController.SetRunSpeed(normalRunSpeed);
//                    sliderCanvasGroup.alpha = 0;
//                    hasRegenerated = true;
//                }
//            }
//        }    
//    }

//    public void Sprinting()
//    {
//        if(hasRegenerated)
//        {
//            isSprinting = true;
//            playerStamina -= staminaDrain * Time.deltaTime;
//            UpdateStamina(1);

//            if(playerStamina <= 0)
//            {
//                hasRegenerated = false;
//                sliderCanvasGroup.alpha = 0;
//            }
//        }
//    }

//    void UpdateStamina(int num)
//    {
//        staminaProgressUI.value = playerStamina / maxStamina;
        
//        if(num == 0)
//        {
//            sliderCanvasGroup.alpha = 0;
//        }
//        else
//        {
//            sliderCanvasGroup.alpha = 1;
//        }
//    }
//}
