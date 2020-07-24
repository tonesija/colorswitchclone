using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public ClusterManager clustersScript;

    public float clusterDistance;

    int score;

    int difficulty;

    GameObject[] aliveClusters;

    GameObject player;

    void Start()
    {
        aliveClusters = new GameObject[3];
        difficulty = 1;
        score = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerScript>().OnScorePickup += IncreaseScore;
        AddCluster(clustersScript.SpawnCluster(1, 3f));
    }

    void Update(){
        float playerY = player.transform.position.y;
        if(playerY > aliveClusters[aliveClusters.Length - 1].transform.position.y){
            AddCluster(clustersScript.SpawnCluster(1, playerY + clusterDistance));
        }
    }

    void IncreaseScore(){
        score++;
        switch (score){
            case 8:
            case 16:
            case 24: difficulty++; break;
        }
    }

    void AddCluster(GameObject cluster){
        if(aliveClusters[0] != null){
            print("destroying oldest cluster");
            Destroy(aliveClusters[0]);
        }

        for(int i = 0; i < aliveClusters.Length - 1; ++i){
            GameObject temp = aliveClusters[i];
            aliveClusters[i] = aliveClusters[i + 1];
            aliveClusters[i + 1] = temp;
        }

        aliveClusters[aliveClusters.Length - 1] = cluster;
    }

    
}
