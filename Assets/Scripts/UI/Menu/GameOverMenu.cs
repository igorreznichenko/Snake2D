using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Snake {
	public class GameOverMenu : Menu
	{
		[SerializeField] private TextMeshProUGUI _score;
		[SerializeField] private TextMeshProUGUI _time;

		public bool IsActive => _isActive;

		public void SetActive(string score, string time)
		{
			SetupUI(score, time);
			ChangeState();
		}

		private void SetupUI(string score, string time)
		{
			_score.text = "Score: " + score;
			_time.text = "Time: " + time;
		}
	}
}