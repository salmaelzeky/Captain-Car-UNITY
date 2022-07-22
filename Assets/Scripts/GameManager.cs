using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{

    int score;
    public static GameManager inst;

    [SerializeField] Text scoreText;
    [SerializeField] PlayerMovement playerMovement;
   

    public void IncreamentScore()
    { 
        score= score + 10;
        scoreText.text = "SCORE: " + score;

        //increases the player speed
       
        if (score%50 == 0)
        {
            playerMovement.speed += playerMovement.speedIncreasePerPoint;
        }
    }

    public void DecreamentScore()
    {
        score = score - 50;
        scoreText.text = "SCORE: " + score;

            playerMovement.speed -= 0.5f;

    }

    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
