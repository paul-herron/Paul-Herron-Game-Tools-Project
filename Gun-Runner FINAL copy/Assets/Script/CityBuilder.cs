using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBuilder : MonoBehaviour
{
    public Renderer Core;
    public GameObject[] buildings;
    public int mapHeight = 10;
    public int mapWidth = 10;
    public int buildingSpace = 5;


    void OnEnable()
    {
        float seed = Random.Range(0, 100);
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                int result = (int)(Mathf.PerlinNoise(w / 10.0f + seed, h / 10.0f + seed) * 10);
                Vector3 pos = Core.bounds.center + Random.onUnitSphere * 100;

                int index;
                //int index = result < 2 ? 0 : result < 4 ? 1 : result < 6 ? 2 : result < 8 ? 3 : result < 10 ? 4 : 4;

                if (result < 2)
                    index = 0;
                else if (result < 4)
                    index = 1;
                else if (result < 6)
                    index = 2;
                else if (result < 8)
                    index = 3;
                else
                    index = 4;


                GameObject building = Instantiate(buildings[index], pos, Quaternion.identity);
                BuildingGenerator bg = building.GetComponentInChildren<BuildingGenerator>();
                bg.normal = Core.bounds.center;
                bg.Build();
               //building.transform.LookAt(Core.bounds.center);
               //building.GetComponent<BuildingGenerator>().InitialRotation = Quaternion.LookRotation(building.transform.position - Core.bounds.center);
            }
        }

    }
}
