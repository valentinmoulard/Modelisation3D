using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	public Material material;
	public int taille;

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<MeshFilter> ();
		gameObject.AddComponent<MeshRenderer> ();
		CreerCube (taille);
	}


	public void CreerCube(int taille){

		//vertices
		Vector3[] vertices = {
			new Vector3 (0, 0, 0),
			new Vector3 (1, 0, 0),
			new Vector3 (1, 1, 0),
			new Vector3 (0, 1, 0),
			new Vector3 (0, 1, 1),
			new Vector3 (1, 1, 1),
			new Vector3 (1, 0, 1),
			new Vector3 (0, 0, 1),
		};

		//triangles
		int[] triangles = {
			0, 2, 1, //face front
			0, 3, 2,
			2, 3, 4, //face top
			2, 4, 5,
			1, 2, 5, //face right
			1, 5, 6,
			0, 7, 4, //face left
			0, 4, 3,
			5, 4, 7, //face back
			5, 7, 6,
			0, 6, 7, //face bottom
			0, 1, 6
		};

		Mesh mesh = new Mesh ();
		mesh.vertices = vertices;
		mesh.triangles = triangles;

		gameObject.transform.localScale = new Vector3(taille,taille,taille);
		gameObject.GetComponent<MeshRenderer> ().material = material;
		gameObject.GetComponent<MeshFilter> ().mesh = mesh;
	}



	// Update is called once per frame
	void Update () {
		gameObject.transform.localScale = new Vector3(taille,taille,taille);
	}
}
