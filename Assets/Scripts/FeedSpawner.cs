using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake {
	public class FeedSpawner : MonoBehaviour
	{
		public float FeedTime;
		[SerializeField] GameObject _feed;
		[SerializeField] private SnakeBehavior _snakeBehavior;
		private const int _fieldWidth = 78;
		private const int _fieldHeight = 48;
		private void Start()
		{
			SpawnFeed();
		}

		public void SpawnFeed()
		{
			Vector2 position;
			do
			{
				int YPos = Random.Range(-_fieldHeight / 2, _fieldHeight / 2);
				int XPos = Random.Range(-_fieldWidth / 2, _fieldWidth / 2);
				position = new Vector2(XPos, YPos);
			} while (_snakeBehavior.isOnSnakePosition(position));
			Instantiate(_feed, position, Quaternion.identity);
		}
	}
}