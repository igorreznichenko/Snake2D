using System;
using UnityEngine;

namespace Snake
{
	public class AudioManager : MonoBehaviour
	{
		public static AudioManager Instance;
		[SerializeField] AudioSource _audioSource;
		[SerializeField] AudioList _audioList;

		private void Awake()
		{
			if (Instance == null)
				Instance = this;
		}

		public void GameOver() => PlayClip(_audioList.GameOver);

		public void FeedPickUp() => PlayClip(_audioList.FeedPickUp);

		public void SpawnBonus() => PlayClip(_audioList.SpawnBonus);

		private void PlayClip(AudioClip clip)
		{
			_audioSource.clip = clip;
			_audioSource.Play();
		}
	}
}