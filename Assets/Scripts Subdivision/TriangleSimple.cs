using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleSimple : MonoBehaviour {

    List<int> trianglev2 = new List<int>();
    List<Vector3> vertices = new List<Vector3>();

    // Use this for initialization
    void Start () {
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        Mesh mesh = filter.mesh;
        mesh.Clear();

        float cote = 1.0f;
        
        vertices.Add(new Vector3(0, 0, 0));
        vertices.Add(new Vector3(cote, 0, 0));
        vertices.Add(new Vector3(cote, cote, 0));

        
        trianglev2.Add(2);
        trianglev2.Add(1);
        trianglev2.Add(0);

        Subdiviser(trianglev2, vertices);
        


        mesh.vertices = vertices.ToArray();
        mesh.triangles = trianglev2.ToArray();
        mesh.RecalculateBounds();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Subdiviser(List<int> triangles, List<Vector3> vertices)
    {
        vertices.Add((vertices[trianglev2[2]] + vertices[trianglev2[0]])/2);  //vertice 3
        vertices.Add((vertices[trianglev2[2]] + vertices[trianglev2[1]])/2);  //vertice 4
        vertices.Add((vertices[trianglev2[1]] + vertices[trianglev2[0]])/2);  //vertice 5

        trianglev2.RemoveRange(0,3);
        //T1
        trianglev2.Add(0);
        trianglev2.Add(3);
        trianglev2.Add(4);
        //T2
        trianglev2.Add(4);
        trianglev2.Add(3);
        trianglev2.Add(5);
        //T3
        trianglev2.Add(4);
        trianglev2.Add(5);
        trianglev2.Add(1);
        //T4
        trianglev2.Add(3);
        trianglev2.Add(2);
        trianglev2.Add(5);
    }
}
