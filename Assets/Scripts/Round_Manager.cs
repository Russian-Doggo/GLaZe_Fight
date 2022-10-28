using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round_Manager : MonoBehaviour
{
    Game_Timer game_timer;

    public GameObject stage;
    public GameObject stagePrefab;
    public GameObject stageSpawn;

    [SerializeField] GameObject canvas;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject leftWall;
    [SerializeField] GameObject rightWall;

    Player_Health playerOneHealth;
    Player_Health playerTwoHealth;
    Wall_Behavior_Left wall_behavior_left;
    Wall_Behavior_Right wall_behavior_right;

    public int totalRounds = 3;
    public int currentRound;

    // Start is called before the first frame update
    void Awake()
    {
        currentRound = 1;
        game_timer = canvas.GetComponent<Game_Timer>();

        playerOneHealth = player1.GetComponent<Player_Health>();
        playerTwoHealth = player2.GetComponent<Player_Health>();
        wall_behavior_left = leftWall.GetComponent<Wall_Behavior_Left>();
        wall_behavior_right = rightWall.GetComponent<Wall_Behavior_Right>();
    }

    // Update is called once per frame
    void Update()
    {
        if(game_timer.currentTime == 0)
        {
            Destroy(stage);

            playerOneHealth.MaxHeal();
            playerTwoHealth.MaxHeal();

            wall_behavior_left.currentHealth = wall_behavior_left.maxHealth;
            wall_behavior_right.currentHealth = wall_behavior_right.maxHealth;

            player1.GetComponent<Player_Movement>().enabled = false;
            player2.GetComponent<Player_Movement>().enabled = false;

            player1.transform.position = new Vector2(-5f, -2.4f);
            player2.transform.position = new Vector2(5f, -2.4f);

            player1.GetComponent<Player_Movement>().enabled = true;
            player1.GetComponent<Player_Movement>().enabled = true;

            game_timer.currentTime = game_timer.startingTime;

            Instantiate(stagePrefab, stageSpawn.transform);

            Debug.Log("Time!!");
        }
    }
}
