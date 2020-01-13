using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    public string filename;

    void Start()
    {
        try
        {
            List<Building> city = ParserGml.LoadGml(@"Assets/Citygml/" + filename);
            foreach (Building b in city)
            {
                b.Draw();
            }
        }
        catch
        {
            Debug.Log(" File " + filename + " does not exist");
        }             
    }
}
