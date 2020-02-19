using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leguar.TotalJSON;

public class JsonGeneration : MonoBehaviour
{
    public TextAsset raw;
    public GameObject wall;
    public GameObject floor;

    JSON level;

    int size;

    int[] levelData;

    // Start is called before the first frame update
    void Start()
    {
        //parse the text file into the unity object
        level = JSON.ParseString(raw.text);

        size = level.GetInt("Size");

        levelData = level.GetJArray("Data").AsIntArray();

        //go through the data array and generate geometry for the level
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                switch(levelData[index(x,y)])
                {
                    case 1:
                        //generate floor
                        Instantiate(floor, new Vector3(x, 0, y), Quaternion.identity, this.transform);
                        break;
                    case 2:
                        //generate wall
                        Instantiate(wall, new Vector3(x, 0, y), Quaternion.identity, this.transform);
                        break;
                }
            }
        }
    }

    int index(int x, int y)
    {
        return x + size * y;
    }
}
