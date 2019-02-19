using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereV2 : MonoBehaviour
{
    public float radius;
    public int nbLong;
    public int nbLat;

    void Start()
    {
        CreerSphere(radius, nbLong, nbLat);
    }

    public void CreerSphere(float radius, int nbLong, int nbLat)
    {
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        Mesh mesh = filter.mesh;
        mesh.Clear();

        //+2 pour gerer les pôles
        Vector3[] vertices = new Vector3[(nbLong + 1) * nbLat + 2];
        float _pi = Mathf.PI;
        float _2pi = _pi * 2f;

        //Vector3.up == Vector3(0,1,0) le pôle nord
        vertices[0] = Vector3.up * radius;

        //les points de la spheres
        for (int lat = 0; lat < nbLat; lat++)
        {
            float a1 = _pi * (lat + 1) / (nbLat + 1);
            float sin1 = Mathf.Sin(a1);
            float cos1 = Mathf.Cos(a1);

            for (int lon = 0; lon <= nbLong; lon++)
            {
                float a2 = _2pi * (lon == nbLong ? 0 : lon) / nbLong;
                float sin2 = Mathf.Sin(a2);
                float cos2 = Mathf.Cos(a2);

                vertices[lon + lat * (nbLong + 1) + 1] = new Vector3(sin1 * cos2, cos1, sin1 * sin2) * radius;
            }
        }

        //le pôle sud
        vertices[vertices.Length - 1] = Vector3.up * -radius;


        //les vecteurs normaux de chaque triangles
        Vector3[] normales = new Vector3[vertices.Length];
        for (int n = 0; n < vertices.Length; n++)
            normales[n] = vertices[n].normalized;




        int nbFaces = vertices.Length;
        int nbTriangles = nbFaces * 2;
        int nbIndexes = nbTriangles * 3;
        int[] triangles = new int[nbIndexes];

        //triangles autour du pole nord
        int i = 0;
        for (int lon = 0; lon < nbLong; lon++)
        {
            triangles[i++] = lon + 2;
            triangles[i++] = lon + 1;
            triangles[i++] = 1;
        }

        //Sphere
        for (int lat = 0; lat < nbLat - 1; lat++)
        {
            for (int lon = 0; lon < nbLong; lon++)
            {
                int current = lon + lat * (nbLong + 1) + 1;
                int next = current + nbLong + 1;

                triangles[i++] = current;
                triangles[i++] = current + 1;
                triangles[i++] = next + 1;

                triangles[i++] = current;
                triangles[i++] = next + 1;
                triangles[i++] = next;
            }
        }

        //triangles autour du pole sud
        for (int lon = 0; lon < nbLong; lon++)
        {
            triangles[i++] = vertices.Length - 2;
            triangles[i++] = vertices.Length - (lon + 2) - 1;
            triangles[i++] = vertices.Length - (lon + 1) - 1;
        }


        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normales;
        mesh.RecalculateBounds();
    }


    void simplification()
    {
        
    }
    
}
