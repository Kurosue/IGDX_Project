using UnityEngine;
using UnityEditor;

public class CameraPreviewWindow : EditorWindow
{
    Camera selectedCamera;

    [MenuItem("Window/Camera Preview")]
    public static void ShowWindow()
    {
        GetWindow<CameraPreviewWindow>("Camera Preview");
    }

    void OnGUI()
    {
        selectedCamera = (Camera)EditorGUILayout.ObjectField("Camera", selectedCamera, typeof(Camera), true);

        if (selectedCamera != null)
        {
            Rect previewRect = GUILayoutUtility.GetRect(256, 256, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            if (selectedCamera.targetTexture == null)
            {
                selectedCamera.targetTexture = new RenderTexture(256, 256, 16);
            }
            EditorGUI.DrawPreviewTexture(previewRect, selectedCamera.targetTexture);
            selectedCamera.Render();
        }
        else
        {
            EditorGUILayout.LabelField("No camera selected.");
        }
    }
}
