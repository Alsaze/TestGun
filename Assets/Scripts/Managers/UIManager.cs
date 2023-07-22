using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Text _currentScoreGold;
        [SerializeField] private Text _currentScoreTime;
        [SerializeField] private Text _currentScore; // счётчик общих очков и рекордов

        private void Start()
        {
            StartCoroutine(StartTimer());
        }

        private IEnumerator StartTimer()
        {
            var startTime = Time.time;
            bool isTimerRunning = true;

            while (isTimerRunning)
            {
                ConfigManager.ElapsedTime = Time.time - startTime;
                string minutes = ((int)ConfigManager.ElapsedTime / 60).ToString("00");
                string seconds = (ConfigManager.ElapsedTime % 60).ToString("00");
                _currentScoreTime.text = minutes + ":" + seconds;

                yield return null;
            }
        }

        private void Update()
        {
            _currentScoreGold.text = ConfigManager.Gold.ToString();
            _currentScoreTime.text = ConfigManager.Time.ToString();
            _currentScore.text = ConfigManager.Score.ToString();
        }
    }
}
