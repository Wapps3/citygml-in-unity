using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polygon 
{
    

    List<Vector3> listPoints;

    public Polygon(List<Vector3> listPoints)
    {
        this.listPoints = listPoints;
    }

    public void Draw()
    {
        GameObject face = new GameObject();

        Mesh msh = new Mesh();

        Vector3[] vertices = new Vector3[listPoints.Count];
        for (int i = 0; i < listPoints.Count; i++)
            vertices[i] = listPoints[i];

        int[] triangles = new int[ (int)Mathf.Ceil(listPoints.Count / 2) * 3 *2];

        int lastIndex = 0;
        for(int i = 0; i < listPoints.Count-1; i = i +2)
        {
            if( i == listPoints.Count - 1)
            {
                triangles[lastIndex] = i;
                lastIndex++;
                triangles[lastIndex]  = 0;
                lastIndex++;
                triangles[lastIndex] = 1;
                lastIndex++;
            }
            else if( i == listPoints.Count -2)
            {
                triangles[lastIndex] = i;
                lastIndex++;
                triangles[lastIndex] = i+1;
                lastIndex++;
                triangles[lastIndex] = 0;
                lastIndex++;
            }
            else
            {
                triangles[lastIndex] = i;
                lastIndex++;
                triangles[lastIndex] = i + 1;
                lastIndex++;
                triangles[lastIndex] = i + 2;
                lastIndex++;

                triangles[lastIndex] = i;
                lastIndex++;
                triangles[lastIndex] = i + 2;
                lastIndex++;
                triangles[lastIndex] = i + 1;
                lastIndex++;
            }
        }



        msh.vertices = vertices;
        msh.triangles = triangles;

        MeshFilter mshFilter = face.AddComponent<MeshFilter>();
        face.AddComponent<MeshRenderer>().material.color = Color.white ;
      
        mshFilter.mesh = msh;
    }
}
