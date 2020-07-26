using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public ClusterManager clustersScript;

    public float clusterDistance;

    int score;

    int difficulty;

    GameObject[] aliveClusters;

    GameObject player;

    Text scoreText;

    

    void Start()
    {
        aliveClusters = new GameObject[3];
        difficulty = 1;
        score = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerScript>().OnScorePickup += IncreaseScore; //subscribe IncreaseScore() on player pickup score event
        AddCluster(clustersScript.SpawnCluster(1, 3f)); //spawn first cluster
        scoreText = GetComponentInChildren<Text>(); //get reference to scoreText child
    }

    //adds clusters if player has reached certain height
    void Update(){
        float playerY = player.transform.position.y;
        if(playerY > aliveClusters[aliveClusters.Length - 1].transform.position.y){
            AddCluster(clustersScript.SpawnCluster(difficulty, playerY + clusterDistance));
        }
    }

    //increase score and difficulty
    void IncreaseScore(){
        score++;
        scoreText.text = score.ToString();
        switch (score){
            case 8:
            case 16:
            case 24: difficulty++; break;
        }
    }

    //add new cluster to the aliveClusters array (order)
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
