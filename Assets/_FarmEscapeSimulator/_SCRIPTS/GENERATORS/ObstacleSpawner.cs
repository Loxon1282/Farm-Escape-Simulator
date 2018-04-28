using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

   ObstacleGenerator generator;
    public int[] height= new int[12];
    float startWidth;
    int generateDistance;
    void Awake()
    {
        generator = ObstacleGenerator.Instance;
    }
    void Start () {
        generator = ObstacleGenerator.Instance;
        SetHeights();
        for (int i = 0; i < 12; i++)
        {
            height[i] = (i * 2);
        }
        GenerateObstacles(500);


    }

    private void SetHeights()
    {
       
    }
    public void GenerateObstacles(int genDistance)
    {
        for(int h = 0;h<height.Length;h++)
        {
            int parts = 0;
            int distanceParts = genDistance / 80;
            while (parts < distanceParts)
            {
                int rand = Random.Range(0, generator.obstacles.Count);

                if (generator.obstacles[rand].heights[h])
                {
                    if (Random.Range(0, 100) < generator.obstacles[rand].chances)
                    {
                        float position = parts * 80.0f + Random.Range(0, 75.0f) + 5.0f;
                        generator.SpawnObstacle(generator.obstacles[rand].tag, new Vector3(0, height[h], position)).SetActive(true);
                        parts++;
                    }
                    else
                        continue;
                }
            }
        }
    }


}
