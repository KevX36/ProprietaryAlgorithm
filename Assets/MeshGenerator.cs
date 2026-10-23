using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        GenerateCity();
        UpdateMesh();
    }

    
    void Update()
    {
        
    }
    public int xSize = 20;
    public int zSize = 20;
    public int ySize = 5;

    public void GenerateCity()
    {
        vertices = new Vector3[(xSize + 1) * (zSize +1)*(ySize+1)];
        
        for(int y = 0; y <= ySize; y++)
        {
            for (int i = 0, z = 0; z <= zSize; z++)
            {
                for (int x = 0; x <= xSize; x++)
                {
                    vertices[i] = new Vector3(x, y, z);





                    i++;
                }
            }
        }
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                vertices[i] = new Vector3(x, 0, z);





                i++;
            }
        }
        triangles = new int[xSize*zSize*6];
        for (int j = 0, vert = 0, tris = 0; j<zSize; j++)
        {
            for (int i = 0; i < xSize; i++)
            {
                
                triangles[tris + 0] = vert;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;
                vert++;
                tris += 6;

            }
            vert++;
        }
        



    }
    public void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
    private void OnDrawGizmos()
    {
        if(vertices==null) return;
        for(int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }
}
