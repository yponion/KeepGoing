using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class TrapezoidMesh : MonoBehaviour
{
    public float topWidth = 1f;
    public float bottomWidth = 2f;
    public float height = 1f;
    public float depth = 1f;

    void Start()
    {
        CreateTrapezoid();
    }

    void CreateTrapezoid()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();

        // Define vertices
        Vector3[] vertices = new Vector3[8];

        float halfTopWidth = topWidth / 2;
        float halfBottomWidth = bottomWidth / 2;
        float halfDepth = depth / 2;

        // Top vertices
        vertices[0] = new Vector3(-halfTopWidth, height, -halfDepth);
        vertices[1] = new Vector3(halfTopWidth, height, -halfDepth);
        vertices[2] = new Vector3(halfTopWidth, height, halfDepth);
        vertices[3] = new Vector3(-halfTopWidth, height, halfDepth);

        // Bottom vertices
        vertices[4] = new Vector3(-halfBottomWidth, 0, -halfDepth);
        vertices[5] = new Vector3(halfBottomWidth, 0, -halfDepth);
        vertices[6] = new Vector3(halfBottomWidth, 0, halfDepth);
        vertices[7] = new Vector3(-halfBottomWidth, 0, halfDepth);

        // Define triangles
        int[] triangles = new int[]
        {
            // Top
            0, 1, 2,
            0, 2, 3,

            // Bottom
            4, 6, 5,
            4, 7, 6,

            // Front
            0, 4, 5,
            0, 5, 1,

            // Back
            2, 6, 7,
            2, 7, 3,

            // Left
            0, 3, 7,
            0, 7, 4,

            // Right
            1, 5, 6,
            1, 6, 2
        };

        // Assign vertices and triangles
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // Recalculate normals for proper lighting
        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;
    }
}
