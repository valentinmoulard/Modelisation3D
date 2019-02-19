using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylindreV2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MeshFilter filter = gameObject.AddComponent<MeshFilter>();
		Mesh mesh = filter.mesh;
		mesh.Clear();
		float _2pi = Mathf.PI * 2f;

		float height = 2f;
		int nbSides = 5;
		float radius = 1f;

		Vector3[] vertices = new Vector3[2 * nbSides + 2];

		float x = 0;
		float y = 0;
		float z = 0;

        //socle top
		vertices [0] = Vector3.up * radius;
        //socle down
		vertices [vertices.Length - 1] = Vector3.up * -radius;

        //cotés
		int indice = 1;
		for (int i = 0; i < nbSides; i++) {
			x = radius * Mathf.Cos ((_2pi * i) / nbSides);
			y = radius * Mathf.Sin ((_2pi * i) / nbSides);
			z = -height / 2;
			vertices [indice++] = new Vector3 (x, y, z);
		}
		for (int i = 0; i < nbSides; i++) {
			x = radius * Mathf.Cos ((_2pi * i) / nbSides);
			y = radius * Mathf.Sin ((_2pi * i) / nbSides);
			z = height / 2;
			vertices [indice++] = new Vector3 (x, y, z);
		}


        //les vecteurs normaux de chaque triangles
        Vector3[] normales = new Vector3[vertices.Length];

        for (int n = 0; n < vertices.Length; n++)
            normales[n] = vertices[n].normalized;


        List<int> trianglev2 = new List<int>();

		for (int i = 0; i < nbSides; i++) {
			trianglev2.Add (1);
			trianglev2.Add (i+2);
			trianglev2.Add (i+1);
		}
		for (int i = 1; i <= nbSides; i++) {
			trianglev2.Add (i);
			trianglev2.Add (i+1);
			trianglev2.Add (i+nbSides);

			trianglev2.Add (i+1);
			trianglev2.Add (i+nbSides+1);
			trianglev2.Add (i+nbSides);
		}

		for (int i = 0; i < nbSides; i++) {
			trianglev2.Add (nbSides *2);
			trianglev2.Add (i+ nbSides + 1);
			trianglev2.Add (i+nbSides+2);
		}

		int[] triangles = trianglev2.ToArray();

	
		mesh.vertices = vertices;
        mesh.normals = normales;
        mesh.triangles = triangles;
		mesh.RecalculateBounds();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
