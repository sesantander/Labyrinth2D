using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI _text;
  [SerializeField] private TextMeshProUGUI _levelText;
  [SerializeField] private TextMeshProUGUI _timeText;

  void Start()
  {
    string endText = PlayerPrefs.GetString("EndText");
    string levelText = PlayerPrefs.GetString("LevelText");
    string timeText = PlayerPrefs.GetString("TimeText");

      _text.text = endText;
    _levelText.text = "Max " + levelText;
    _timeText.text = "Time: " + timeText;
  }

      // Update is called once per frame
      public void OnRestartClick()
      {
        SceneManager.LoadScene("SampleScene");
      }

      
}
