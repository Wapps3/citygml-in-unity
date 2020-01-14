# CityGML Parser in Unity


A program to load `.gml` file and displays the meshes in Unity. 



The city of Bron (69500) : 



![Bron_Satellite](https://user-images.githubusercontent.com/14167172/72252618-e7cb1480-35ff-11ea-8f69-082cf975c93c.PNG)
![Bron_Unity](https://user-images.githubusercontent.com/14167172/72252543-be11ed80-35ff-11ea-91e4-ad32a2003483.PNG)


![Bron_Bati](https://user-images.githubusercontent.com/14167172/72252770-455f6100-3600-11ea-8eef-3b22e7315b4a.PNG)


Resources for `.gml` files : https://data.beta.grandlyon.com/jeux-de-donnees/maquette-3d-texturee-commune-bron-metropole-lyon/ressources

##  How to use

- Create an empty GameObject in the Scene and attach the script `Load.cs`. 
- Fill the parameter `filename` with the name your `.glm` file. Your files must be in the directory `Assets/Citygml/`. 

## GML Format

The Geography Markup Language (GML) is the XML grammar defined by the Open Geospatial Consortium (OGC) to express geographical features. GML serves as a modeling language for geographic systems as well as an open interchange format for geographic transactions on the Internet. Key to GML's utility is its ability to integrate all forms of geographic information, including not only conventional "vector" or discrete objects, but coverages (see also GMLJP2) and sensor data.

### Example

Here is an example of the file `campus.gml` :

```xml
 <cityObjectMember>
    <bldg:Building gml:id="BRON_00179_29">
      <bldg:boundedBy>
        <bldg:RoofSurface gml:id="BRON_00179_29_Roof">
          <bldg:lod2MultiSurface>
            <gml:MultiSurface srsDimension="3">
              <gml:surfaceMember>
                <gml:Polygon gml:id="UUID_299451e8-6609-46a3-9553-49ccc2d42ae7">
                  <gml:exterior>
                    <gml:LinearRing gml:id="UUID_37607cc1-4227-4488-b681-0663758d2094">
                      <gml:posList srsDimension="3">1849213.935011 5170908.292654 201.995585 1849206.919993 5170909.691149 201.995585 1849210.423701 5170891.864977 201.995585 1849213.935011 5170908.292654 201.995585</gml:posList>
                    </gml:LinearRing>
                  </gml:exterior>
                </gml:Polygon>
              </gml:surfaceMember>
              <gml:surfaceMember>
                <gml:Polygon gml:id="UUID_4811d228-aeb6-4c09-a98a-a2233e09addb">
                  <gml:exterior>
                    <gml:LinearRing gml:id="UUID_eb6d19fe-d52f-460c-92cf-ba8ed9f3ba7e">
                      <gml:posList srsDimension="3">1849210.423701 5170891.864977 201.995585 1849206.919993 5170909.691149 201.995585 1849201.366204 5170883.963818 201.995585 1849210.423701 5170891.864977 201.995585</gml:posList>
                    </gml:LinearRing>
                  </gml:exterior>
                </gml:Polygon>
              </gml:surfaceMember>
              ....
    </bldg:Building>
</cityObjectMember>
```
The tags we will be using to parse the file are : 

`<bldg:Building>` : Mark the beginning of a new building

`<gml:posList>` : List of coordinates, grouped by 3, to draw one face of a building. 

## Parsing GML

### 1. Structure

First, we create a City wich is a list of `Building`. <br/>
Inside each class `Building`, we create a list of `Polygon` wich represents each side of a building. <br/>
Finally, each class `Polygon` contains a list of `Points` corresponding to the vertices of the polygon. 

![archi](https://user-images.githubusercontent.com/14167172/72326930-6c756b80-36b0-11ea-8cfe-00a65561dbda.PNG)

### 2. Step by step

In the script `ParserGml.cs` we create an empty object Building. <br />
With each line starting with `<gml:posList`  we add a new polygon to the building. In the script `Polygon.cs` we split the line to get the values of the points and we group them by 3 to obtain a point with the 3 coordinates x, y and z.

Example : 

```
<gml:posList srsDimension="3">1849213.935011 5170908.292654 201.995585 1849206.919993 5170909.691149 201.995585 1849210.423701 5170891.864977 201.995585 1849213.935011 5170908.292654 201.995585</gml:posList>
```

This a polygon with 4 vertices because there is 12 values. The coordinates of the 4 points are : 
<ul>
<li> (1849213.935011, 5170908.292654, 201.995585)</li>
<li> (1849206.919993, 5170909.691149, 201.995585)</li>
<li> (1849210.423701, 5170891.864977, 201.995585)</li>
<li> (1849213.935011, 5170908.292654, 201.995585)</li>
</ul>

When detecting the tag `</bldg:Bulding>` the building is complete, we add it to the list of `Building` (the city) and we clear the building to start a new one. 
