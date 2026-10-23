using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public List<GameObject> buildings = new List<GameObject>();

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
    public System.Random RNG = new System.Random();
    public int buildingSpawnRate = 10;
    public int buildingSideRange = 3;
    public int buildingHightRange = 3;

    public GameObject buildingPrefab;
    public void GenerateCity()
    {
        vertices = new Vector3[(xSize + 1) * (zSize +1)];
        
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                vertices[i] = new Vector3(x, 0, z);

                if(x > 0 && z > 0 && x < xSize && z < zSize)
                {
                    int makeBuilding = RNG.Next(0, 150);
                    if(makeBuilding <= buildingSpawnRate)
                    {
                        GameObject newBuilding = Instantiate(buildingPrefab);
                        int xScale = RNG.Next(0, buildingSideRange) + 1;
                        float yScale = RNG.Next(0, buildingHightRange) + 1;
                        int zScale = RNG.Next(0, buildingSideRange) + 1;
                        newBuilding.transform.localScale = new Vector3(xScale, yScale, zScale);
                        newBuilding.transform.position = new Vector3(vertices[i].x,yScale/2, vertices[i].z);
                        if(buildings == null)
                        {
                            buildings.Add(newBuilding);
                        }
                        else if (true)
                        {

                        }
                        else
                        {
                            Destroy(newBuilding);
                        }
                    }
                }



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
