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
        player.GetComponent<PlayerScript>().OnPlayerDeath += ShowGameOverUI; 
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
            case 5:
            case 10:
            case 15: difficulty++; break;
        }

        if(score > PlayerPrefs.GetInt("HighScore", 0)){
            PlayerPrefs.SetInt("HighScore", score);
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

    // show game over ui with relevant scores
    void ShowGameOverUI(){

        Transform gameOverUI = transform.Find("GameOverUI");

        gameOverUI.transform.Find("ScoreText").GetComponent<Text>().text = "SCORE: " + score.ToString();
        gameOverUI.transform.Find("HighScoreText").GetComponent<Text>().text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

        gameOverUI.gameObject.SetActive(true);
    }

    
}
