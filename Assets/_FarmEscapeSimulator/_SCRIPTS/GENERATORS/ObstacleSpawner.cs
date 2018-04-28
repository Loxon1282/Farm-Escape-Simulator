using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

   ObstacleGenerator generator;

    void Awake()
    {
        generator = ObstacleGenerator.Instance;
    }
    void Start () {



    }
    public IEnumerator lateSpawn()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(.5f);
            ObstacleGenerator.Instance.SpawnObstacle("a", new Vector3(i, 0, 0));

        }
    }


}
