using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class DayCycleController : MonoBehaviour
{
    public bool isEnabled = true;
    [Range(0, 24)] public float timeOfDay;

    public float orbitSpeed = 1.0f;
    public Light sun;
    public Light moon;
    public Volume skyVolume;
    public AnimationCurve starCurve;

    public bool isNight;
    private PhysicallyBasedSky sky;

    [Header("YAGA disable/enable (drag yaga gameobject here)")]
    public GameObject yaga;

    public GameObject nightShrooms;

    // Start is called before the first frame update
    void Start()
    {
        skyVolume.profile.TryGet(out sky);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
        {
            timeOfDay += Time.deltaTime * orbitSpeed;
            if (timeOfDay > 24)
            {
                timeOfDay = 0;
            }

            UpdateTime();
        }

        if (isNight)
        {
            yaga.SetActive(true);
            nightShrooms.SetActive(true);
        }
        else if (!isNight)
        {
            yaga.SetActive(false);
            nightShrooms.SetActive(false);
        }
        
    }

    private void OnValidate()
    {
        skyVolume.profile.TryGet(out sky);
        UpdateTime();
    }

    void UpdateTime()
    {
        float alpha = timeOfDay / 24.0f;
        float sunRotation = Mathf.Lerp(-90, 270, alpha);
        float moonRotation = sunRotation - 180;

        sun.transform.rotation = Quaternion.Euler(sunRotation, 0, 0);
        moon.transform.rotation = Quaternion.Euler(moonRotation, 0, 0);

        sky.spaceRotation = new Vector3Parameter(moon.transform.rotation.eulerAngles, false);

        sky.spaceEmissionMultiplier.value = starCurve.Evaluate(alpha) * 50.0f;



        CheckNightDayTransition();
    }

    void CheckNightDayTransition()
    {
        if (isNight)
        {
            if(moon.transform.rotation.eulerAngles.x > 180)
            {
                StartDay();
            }
        }
        else
        {
            if (sun.transform.rotation.eulerAngles.x > 180)
            {
                StartNight();
            }
        }
    }

    void StartDay()
    {
        isNight = false;
        sun.shadows = LightShadows.Soft;
        moon.shadows = LightShadows.None;
    }

    void StartNight()
    {
        isNight = true;
        moon.shadows = LightShadows.Soft;
        sun.shadows = LightShadows.None;
    }
}
