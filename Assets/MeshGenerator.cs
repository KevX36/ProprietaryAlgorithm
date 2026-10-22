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

    public void GenerateCity()
    {
        vertices = new Vector3[(xSize + 1) * (zSize +1)];
        
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                vertices[i] = new Vector3(x, 0, z);





                i++;
            }
        }





    }
    public void UpdateMesh()
    {

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
