# citygml-in-unity


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

## 