using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class IconCreator : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeScreenShot();
        }
    }

    void TakeScreenShot()
    {
        if (cam == null)
        {
            cam = GetComponent<Camera>();
        }

        RenderTexture renderTexture = new RenderTexture(256, 256, 24);
        cam.targetTexture = renderTexture;
        Texture2D screenShot = new Texture2D(256, 256, TextureFormat.RGBA32, false);
        cam.Render();
        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);
        cam.targetTexture = null;
        RenderTexture.active = null;

        if (Application.isEditor)
        {
            DestroyImmediate(renderTexture);
        }
        else
        {
            Destroy(renderTexture);
        }

        byte[] bytes = screenShot.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.dataPath + "/Icons", bytes);
#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }
}
