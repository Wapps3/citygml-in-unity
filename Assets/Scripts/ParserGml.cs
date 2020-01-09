using System.Collections.Generic;
using UnityEngine;
using System;

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

        return res;
    }

    public static List<Building> LoadGml(string path)
    {
        List<Building> city = new List<Building>();

        string[] lines = System.IO.File.ReadAllLines(path);

        Building buildingtmp = new Building();

        // string[] sublines = new string[1000000];
        // Array.Copy(lines, 0, sublines, 0, 1000000);


        foreach (string l in lines )
        // foreach (string l in sublines)
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

