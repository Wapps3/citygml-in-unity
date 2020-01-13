using System.Collections.Generic;
using UnityEngine;
using System;

public class ParserGml
{
    static float[] StringArrayToFloatArray(string[] sa)
    {
        float[] res;

        // Remove last element if null
        if(sa[sa.Length-1] == "")
            res = new float[sa.Length-1];
        else
            res = new float[sa.Length];

        for (int i = 0; i < sa.Length;i++)
        {
            try
            {
                res[i] = float.Parse(sa[i].Replace('.', ','));
            }
            catch
            {

            }
        }

        return res;
    }


    public static List<Building> LoadGml(string path)
    {
        List<Building> city = new List<Building>();
        string[] lines = System.IO.File.ReadAllLines(path);
        Building buildingtmp = new Building();

        foreach (string l in lines )
        {
            // When reaching end of building tag, Add the current building to the city
            if (l.Contains("</bldg:Building"))
            {                
                city.Add(buildingtmp);
                buildingtmp = new Building();
            }

            if ( l.Contains("<gml:posList"))
            {
                string tmp = l.Substring(l.IndexOf(">")+1);
                tmp = tmp.Substring(0, tmp.Length - "</gml:posList>".Length);
                string[] valueString = tmp.Split(' ');
                float[] valueFloat = StringArrayToFloatArray(valueString);
                buildingtmp.AddPoly(valueFloat);               
            }
        }
        return city;
    }
}

