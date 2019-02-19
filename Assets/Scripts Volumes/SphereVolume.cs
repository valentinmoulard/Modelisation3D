using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereVolume : MonoBehaviour {
    
    public GameObject Cube;

    public Transform Origine1;
    public int radius1;
    public Transform Origine2;
    private List<Vector3> listePosition = new List<Vector3>();
    
    void Start () {
        creerSphere(Origine1, Origine2, radius1);        
    }
    
    void creerSphere(Transform centre1, Transform centre2, int radius)
    {
        for (int i = -radius; i <= radius; i++)
        {
            for (int j = -radius; j <= radius; j++)
            {
                for (int k = -radius; k <= radius; k++)
                {
                    if (true)
                    {
                        /*
                        //sphere volume
                        Vector3 position = new Vector3(i, j, k);
                        Vector3 position2 = position;
                        position += centre1.position;
                        position2 += centre2.position;
                        float distance = Vector3.Distance(position, centre1.position);
                        if (distance <= radius)
                        {
                            Instantiate(Cube, position, Quaternion.identity);
                        }
                        float distance2 = Vector3.Distance(position2, centre2.position);
                        if (distance2 <= radius)
                        {
                            Instantiate(Cube, position2, Quaternion.identity);
                        }
                        */

                        
                        //intersection
                        Vector3 position = new Vector3(i, j, k);
                        position += centre1.position;
                        float distance = Vector3.Distance(position, centre1.position);
                        float distance2 = Vector3.Distance(position, centre2.position);
                        if (distance <= radius && distance2 < radius)
                        {
                            Instantiate(Cube, position, Quaternion.identity);
                        }
                        


                        /*
                        //union
                        Vector3 position = new Vector3(i, j, k);
                        Vector3 position2 = position;
                        position += centre1.position;
                        position2 += centre2.position;
                        float distance = Vector3.Distance(position, centre1.position);
                        float distance2 = Vector3.Distance(position, centre2.position);
                        if (distance <= radius && distance2 < radius)
                        {
                            
                        }
                        else
                        {
                            if (distance <= radius)
                            {
                                Instantiate(Cube, position, Quaternion.identity);
                            }
                            distance2 = Vector3.Distance(position2, centre2.position);
                            if (distance2 <= radius)
                            {
                                Instantiate(Cube, position2, Quaternion.identity);
                            }
                        }
                        */
                        

                        
                    }
                }
            }
        }
    }

}
