using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public Enemy enemy_1_1;
  public Enemy enemy_2_1;
  public Enemy enemy_2_2;
  public Enemy enemy_3_1;
  public Enemy enemy_3_2;
  public Enemy enemy_3_3;
  public Enemy enemy_4_1;
  public Enemy enemy_4_2;
  public Enemy enemy_4_3;
  public Enemy enemy_4_4;

  public static GameManager Instance;

  private GameState state;
  public GameState GetState => state;


  private void Awake()
  {
    Instance = this;
  }

  void Start()
  {
    ChangeState(GameState.FirstLevel);
  }

  void setMultipleSpeeds(
    float enemy_1_1Speed,
    float enemy_2_1Speed, float enemy_2_2Speed,
    float enemy_3_1Speed, float enemy_3_2Speed, float enemy_3_3Speed,
    float enemy_4_1Speed, float enemy_4_2Speed, float enemy_4_3Speed, float enemy_4_4Speed
  )
  {
    enemy_1_1.SetSpeed(enemy_1_1Speed);
    enemy_2_1.SetSpeed(enemy_2_1Speed);
    enemy_2_2.SetSpeed(enemy_2_2Speed);
    enemy_3_1.SetSpeed(enemy_3_1Speed);
    enemy_3_2.SetSpeed(enemy_3_2Speed);
    enemy_3_3.SetSpeed(enemy_3_3Speed);
    enemy_4_1.SetSpeed(enemy_4_1Speed);
    enemy_4_2.SetSpeed(enemy_4_2Speed);
    enemy_4_3.SetSpeed(enemy_4_3Speed);
    enemy_4_4.SetSpeed(enemy_4_4Speed);
  }


  void ManageEnemies(int level)
  {
    if (level == 1)
    {
      setMultipleSpeeds(3.5f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f);
    }
    if (level == 2)
    {
      setMultipleSpeeds(0f, 3.5f, 3.5f, 0f, 0f, 0f, 0f, 0f, 0f, 0f);
    }
    if (level == 3)
    {
      setMultipleSpeeds(0f, 0f, 0f, 3.5f, 3.5f, 3.5f, 0f, 0f, 0f, 0f);
    }
    if (level == 4)
    {
      setMultipleSpeeds(0f, 0f, 0f, 0f, 0f, 0f, 3.5f, 3.5f, 3.5f, 3.5f);
    }
  }


  public void ChangeState(GameState newState)
  {
    state = newState;
    switch (newState)
    {
      case GameState.FirstLevel:
        ManageEnemies(1);
        break;
      case GameState.SecondLevel:
        ManageEnemies(2);
        break;
      case GameState.ThirdLevel:
        ManageEnemies(3);
        break;
      case GameState.FourthLevel:
        ManageEnemies(4);
        break;
      case GameState.Win:
        // PlayerPrefs.SetString("EndText", "You Won!");
        break;
      case GameState.Lose:
        // PlayerPrefs.SetString("EndText", "You Lost");
        // SceneManager.LoadScene("EndScene");
        break;

    }
  }
  void GenerateBoard()
  {

    // for (int i = 0; i < width; i++)
    // {
    //   for (int j = 0; j < height; j++)
    //   {
    //     var node = Instantiate(NodePrefab, new Vector2(i, j), Quaternion.identity);
    //     var position = i.ToString() + " , " + j.ToString();
    //     node.Init(position);
    //     nodes.Add(node);
    //   }

    // }
    // var center = new Vector2((float)5 / 2 - 0.5f, (float)5 / 2 - 0.5f);
    // Camera.main.transform.position = new Vector3(center.x, center.y, -10);
  }


}

public enum GameState
{
  FirstLevel,
  SecondLevel,
  ThirdLevel,
  FourthLevel,
  Win,
  Lose
}