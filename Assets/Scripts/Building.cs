using System.Collections.Generic;
using UnityEngine;

public class Building
{
    private List<Polygon> listPolys = new List<Polygon>();   

    public void AddPoly(float[] listFloat)
    {
        List<Vector3> tmp = new List<Vector3>();

        if (listFloat.Length % 3 == 0)
        {
            for (int i = 0; i < listFloat.Length; i = i + 3)
            {
                tmp.Add(new Vector3(listFloat[i], listFloat[i + 2], listFloat[i+1])/100 );
            }
            listPolys.Add(new Polygon(tmp));
        }
    }

    public void Draw()
    {
        foreach(Polygon p in listPolys)
        {
            p.Draw();
        }
    }
}
