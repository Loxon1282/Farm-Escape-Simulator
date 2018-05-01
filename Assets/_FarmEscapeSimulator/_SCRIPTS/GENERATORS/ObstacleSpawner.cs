using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

   ObstacleGenerator generator;
    public int[] height= new int[12];
    float startWidth;

    private int readyDistance = 0;

    [Range(200, 1500)]
    public int generateDistance = 150;

    [Range(100.0f,500.0f)]
    public float spacing = 100.0f;

    [Range(4,30)]
    public int verticalSpacing = 8;

    public Transform player;

    void Start () {
        generator = ObstacleGenerator.Instance;
        if (player == null)
            player = Camera.main.transform;

        SetHeights();        
        GenerateObstacles(generateDistance*2);
    }

    private void Update()
    {
        if (player.position.z > readyDistance - generateDistance)
        {
            GenerateObstacles(generateDistance);
        }
    }

    private void SetHeights()
    {
        for (int i = 0; i < 12; i++)
        {
            height[i] = (i * verticalSpacing);
        }
    }

    public void GenerateObstacles(int genDistance)
    {
        for(int h = 0;h<height.Length;h++)
        {
            int parts = 0;
            int distanceParts = genDistance / Mathf.FloorToInt(spacing);

            while (parts < distanceParts)
            {
                int rand = Random.Range(0, generator.obstacles.Count);

                if (generator.obstacles[rand].heights[h])
                {
                    if (Random.Range(0, 100) < generator.obstacles[rand].chances)
                    {
                        float position = parts * spacing + Random.Range(0, spacing-20.0f) + 20.0f;
                        generator.SpawnObstacle(generator.obstacles[rand].tag, new Vector3(-2.0f, height[h], position+readyDistance)).SetActive(true);
                        parts++;
                    }
                    else
                        continue;
                }
            }
            
        }
        readyDistance += genDistance;
    }


}
