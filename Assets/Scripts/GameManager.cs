using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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

  private string _level;
  private string _time;


  [SerializeField] private TextMeshProUGUI levelPlaceHolder;
  [SerializeField] private TextMeshProUGUI timePlaceHolder;
  public int timeInSeconds = 0;
  private float startTime;

  private void Awake()
  {
    Instance = this;
  }

  void Start()
  {
    ChangeState(GameState.FirstLevel);
    startTime = Time.time;
  }

  void Update()
  {
    float t = Time.time - startTime;
    string minutes = ((int)t / 60).ToString();
    string seconds = (t % 60).ToString("f0");
    string firstMinute = "0";
    if (minutes == firstMinute)
    {
      timePlaceHolder.text = "00 : " + seconds;
    }
    else
    {
      timePlaceHolder.text = minutes + " : " + seconds;
    }
    _time = timePlaceHolder.text;
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

  void ChangeLevel(string level)
  {
    levelPlaceHolder.text = "Level" + " " + level;
    _level = "Level" + " " + level;
  }

  public void ChangeState(GameState newState)
  {
    state = newState;
    switch (newState)
    {
      case GameState.FirstLevel:
        ManageEnemies(1);
        ChangeLevel("1");
        break;
      case GameState.SecondLevel:
        ManageEnemies(2);
        ChangeLevel("2");
        break;
      case GameState.ThirdLevel:
        ManageEnemies(3);
        ChangeLevel("3");
        break;
      case GameState.FourthLevel:
        ManageEnemies(4);
        ChangeLevel("4");
        break;
      case GameState.Win:
        PlayerPrefs.SetString("EndText", "You Won!");
        PlayerPrefs.SetString("LevelText", _level);
        PlayerPrefs.SetString("TimeText", _time);
        SceneManager.LoadScene("EndScene");
        break;
      case GameState.Lose:
        PlayerPrefs.SetString("EndText", "You Lost");
        PlayerPrefs.SetString("LevelText", _level);
        PlayerPrefs.SetString("TimeText", _time);
        SceneManager.LoadScene("EndScene");
        break;
    }
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