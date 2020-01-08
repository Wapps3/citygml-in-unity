using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         //List<Building> city = ParserGml.LoadGml(@"Assets/Citygml/test1.gml") ;
         List<Building> city = ParserGml.LoadGml(@"Assets/Citygml/BRON_BATI_2009.gml") ;

        foreach (Building b in city)
        {
            b.Draw();
        }


        
    }

   
   
 
}
