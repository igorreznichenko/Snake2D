using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace Snake
{
	public class UIManager : MonoBehaviour
	{
		[SerializeField] private GameOverMenu _gameOverMenu;
		[SerializeField] private PauseMenu _pauseMenu;
		[SerializeField] private Slider _feedSpawnTime;
		[SerializeField] private Slider _bonusSpawnTime;
		[SerializeField] private FeedSpawner _feedSpawner;
		[SerializeField] private TextMeshProUGUI _scoreInfo;
		[SerializeField] private TextMeshProUGUI _lengthInfo;
		[SerializeField] private TextMeshProUGUI _timeInfo;
		private float _startTime;
		private int _deltaTime;
		private int _score = 0;
		private void Start()
		{
			_startTime = Time.time;
		}
		private void Update()
		{
			UpdateTimeInfo();
			CheckInput();
		}

		public void SetFeedTime(float time)
		{
			_feedSpawnTime.value = time;
		}

		public void SetBonusTime(float time)
		{
			_bonusSpawnTime.value = time;
		}

		public void SetFeedMaxTime(float maxTime)
		{
			_feedSpawnTime.maxValue = maxTime;
		}

		public void SetBonusMaxTime(float maxTime)
		{
			_bonusSpawnTime.maxValue = maxTime;
		}

		public void UpdateScore(int score)
		{
			AddScore(score);
			UpdateScoreUI();
		}
		public void SetSnakeLength(int length)
		{
			_lengthInfo.text = length.ToString();
			CheckBonuse(length);
		}
		public void AddScore(int score)
		{
			_score += score;
			UpdateScoreUI();
		}
		public void GameOver()
		{
			AudioManager.Instance.GameOver();
			_gameOverMenu.SetActive(_scoreInfo.text, _timeInfo.text);
		}
		private void CheckBonuse(int length)
		{
			if (length % 5 == 0)
				_feedSpawner.SpawnBonus();
		}
		private void UpdateScoreUI()
		{
			_scoreInfo.text = _score.ToString();
		}
		private void UpdateTimeInfo()
		{
			_deltaTime = Convert.ToInt32(Time.time - _startTime);
			int seconds = _deltaTime % 60;
			_deltaTime /= 60;
			int minutes = _deltaTime % 60;
			int hours = _deltaTime /60;
			_timeInfo.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
		}

		private void CheckInput()
		{
			if (Input.GetKeyDown(KeyCode.Escape) && !_gameOverMenu.IsActive)
			{
				_pauseMenu.ChangeState();
			}
		}
	}
}