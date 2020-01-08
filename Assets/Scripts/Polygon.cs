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
        foreach(Vector3 point in listPoints)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = point;
            cube.transform.localScale = cube.transform.localScale / 100;
        }
    }
}
