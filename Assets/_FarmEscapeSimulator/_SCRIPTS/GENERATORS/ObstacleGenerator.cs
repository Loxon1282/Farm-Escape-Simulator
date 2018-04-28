using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {

    [System.Serializable]
    public class Obstacle
    {

        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    public static ObstacleGenerator Instance;
    #endregion


    public List<Obstacle> obstacles;
    public Dictionary<string, Queue<GameObject>> obstaclePoolDictionary;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        CrateObstaclesDictionary();
    }
    void Start () {

       // CrateObstaclesDictionary();

    }
    public void CrateObstaclesDictionary()
    {
        obstaclePoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Obstacle ob in obstacles)
        {
            Queue<GameObject> obstacleObj = new Queue<GameObject>();

            for (int i = 0; i < ob.size; i++)
            {
                GameObject obj = Instantiate(ob.prefab);
                obj.SetActive(false);
                obstacleObj.Enqueue(obj);

            }

            obstaclePoolDictionary.Add(ob.tag, obstacleObj);
        }

    }
	
    public GameObject SpawnObstacle(string tag,Vector3 position)
    {
        if (!obstaclePoolDictionary.ContainsKey(tag))
        {
            Debug.Log("DODAJ SE PULAPKE Z TYM TAGIEM CFELU");
            return null;
        }
        GameObject objectToSpawn = obstaclePoolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;

        obstaclePoolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
	void Update () {
		
	}
}
