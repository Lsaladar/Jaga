using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(YAI2))]
public class FOVEditor : MonoBehaviour
{
    private void OnSceneGUI()
    {
        YAI2 fov = (YAI2)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);
    }
    
}
