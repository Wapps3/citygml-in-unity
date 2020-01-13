using System.Collections.Generic;
using UnityEngine;
using System;

public class ParserGml
{
    static float[] StringArrayToFloatArray(string[] sa)
    {
        float[] res;

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
        // foreach (string l in sublines)
            {

            if (l.Contains("</bldg:Building") )
            {
                
                city.Add(buildingtmp);
                buildingtmp = new Building();

            }

            if ( l.Contains("<gml:posList") )
            {

                //Debug.Log(l);

                string tmp = l.Substring(l.IndexOf(">")+1);

                //Debug.Log(tmp);

                tmp = tmp.Substring(0, tmp.Length - "</gml:posList>".Length);

                //Debug.Log(tmp);

                string[] valueString = tmp.Split(' ');

                float[] valueFloat = StringArrayToFloatArray(valueString);


                buildingtmp.AddPoly(valueFloat);
               
            }
        }

        return city;
    }



}

