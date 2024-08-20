using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGizmoHighlighter : MonoBehaviour
{
    public bool DrawGizmo;
    void OnDrawGizmos()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter != null && meshFilter.sharedMesh != null && DrawGizmo == true)
        {
            Gizmos.color = Color.yellow; // Set the color of the outline
            Gizmos.DrawWireMesh(meshFilter.sharedMesh, transform.position, transform.rotation, transform.localScale);
        }
    }
}