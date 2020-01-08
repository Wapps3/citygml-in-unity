using System.Collections.Generic;
using UnityEngine;

public class ParserGml
{
    static float[] StringArrayToFloatArray(string[] sa)
    {
        //LE -1 EST IMMONDE
        float[] res = new float[sa.Length-1];

        for(int i = 0; i < sa.Length;i++)
        {
            try
            {
                res[i] = float.Parse(sa[i].Replace('.', ','));
            }
            catch
            {

            }
        }

        Debug.Log(res.Length);
        return res;
    }

    public static List<Building> LoadGml(string path)
    {
        List<Building> city = new List<Building>();

        string[] lines = System.IO.File.ReadAllLines(path);

        Building buildingtmp = new Building();

        foreach (string l in lines )
        {

            if (l.Contains("</bldg:Building>") )
            {
                
                city.Add(buildingtmp);
                buildingtmp = new Building();

            }

            if ( l.Contains("<gml:posList>") )
            {
                
                string tmp = l.Substring(l.IndexOf("<gml:posList>")+13, l.Length - (l.IndexOf("<gml:posList>") + 27) );

                string[] valueString = tmp.Split(' ');
                float[] valueFloat = StringArrayToFloatArray(valueString);

                buildingtmp.AddPoly(valueFloat);
               
            }
        }

        return city;
    }



}

