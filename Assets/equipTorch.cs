using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipTorch : MonoBehaviour
{
    public GameObject torch;

    private bool _toggleTorch;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            _toggleTorch = !_toggleTorch;

            torch.SetActive(!_toggleTorch);
            torch.SetActive(_toggleTorch);
        }
       
    }
}
