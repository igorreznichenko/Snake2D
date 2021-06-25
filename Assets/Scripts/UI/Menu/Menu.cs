using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snake
{
	public abstract class Menu : MonoBehaviour
	{
		[SerializeField] protected GameObject _menuBackground;
		protected bool _isActive = false;

		public void ChangeState()
		{
			_isActive = !_isActive;
			gameObject.SetActive(_isActive);
			_menuBackground.SetActive(_isActive);
			SetTimeScale();
		}

		public void OnRestart()
		{
			Time.timeScale = 1;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		public void OnContinue()
		{
			ChangeState();
		}
		private void SetTimeScale()
		{
			if (_isActive)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
		}

	}
}