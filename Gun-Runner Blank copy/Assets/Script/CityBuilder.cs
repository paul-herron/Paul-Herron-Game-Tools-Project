using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBuilder : MonoBehaviour
{
    public Transform Core;
    public GameObject[] buildings;
    public int mapHeight = 10;
    public int mapWidth = 10;
    public int buildingSpace = 5;
    

    void Start()
    {
        //Transform corePos = Core.transform;
        float seed = Random.Range(0, 100);
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                float x = Mathf.Cos(360) * 100;
                float z = Mathf.Sin(360) * 100;
                int result = (int)(Mathf.PerlinNoise(w/10.0f + seed, h/10.0f + seed) * 10);
                //Vector3 pos = new Vector3(w * buildingSpace, 0, h * buildingSpace);
                Vector3 pos = Random.onUnitSphere  * 100;
                if (result < 2)
                {
                    Instantiate(buildings[0], pos, Quaternion.identity);
                    this.gameObject.transform.LookAt(Core);
                }
                else if (result < 4)
                {
                    Instantiate(buildings[1], pos, Quaternion.identity);
                    this.gameObject.transform.LookAt(Core);
                }
                else if (result < 6)
                {
                    Instantiate(buildings[2], pos, Quaternion.identity);
                    this.gameObject.transform.LookAt(Core);
                }
                else if (result < 8)
                {
                    Instantiate(buildings[3], pos, Quaternion.identity);
                    this.gameObject.transform.LookAt(Core);
                }
                else if (result < 10)
                {
                    Instantiate(buildings[4], pos, Quaternion.identity);
                    this.gameObject.transform.LookAt(Core);
                }
            }
        }
    }
}
