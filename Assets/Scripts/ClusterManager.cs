using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterManager : MonoBehaviour
{
    public GameObject[] origClusters;

    //4 difficulties [1, 4]
    public GameObject SpawnCluster(int difficulty, float spawnLoc){
        int i = Random.Range(0, (int) ((float) difficulty*(float) (origClusters.Length)/4.0f));
        GameObject cluster = Instantiate(origClusters[i] , new Vector2(0f, spawnLoc), Quaternion.identity);
        return cluster;
    }
}
