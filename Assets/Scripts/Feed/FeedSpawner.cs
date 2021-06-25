using UnityEngine;

namespace Snake
{
	public class FeedSpawner : MonoBehaviour
	{
		public float FeedTime;
		[HideInInspector]
		public bool IsSpawnedBonus;
		[SerializeField] private GameObject _feed;
		[SerializeField] GameObject[] _bonuses;
		[SerializeField] private SnakeBehavior _snakeBehavior;
		[SerializeField] private UIManager _UIManager;
		private const int _fieldWidth = 78;
		private const int _fieldHeight = 48;
		private GameObject _spawnedFeed;
		private GameObject _spawnedBonus;
		[SerializeField] private FeedSpawnTimeInfo _feedSpawnTimeInfo;
		private float _feedEndTime;
		private float _bonusEndTime;
		private float _feedDeltaTime;
		private float _bonusDeltaTime;

		private void Start()
		{
			SpawnFeed();
		}

		private void Update()
		{
			UpdateFeedTime();
			if (_feedDeltaTime < 0)
			{
				Destroy(_spawnedFeed);
				SpawnFeed();
			}
			if (IsSpawnedBonus)
			{
				UpdateBonuseTime();
				if (_bonusDeltaTime < 0)
				{
					Destroy(_spawnedBonus);
					UnSpawnBonus();
				}
			}

		}

		public void SpawnFeed()
		{
			_spawnedFeed = InstantiateFeed(_feed);
			_feedEndTime = Time.time + _feedSpawnTimeInfo.FeedSpawnTime;
		}

		public void SpawnBonus()
		{
			if (!IsSpawnedBonus)
			{
				AudioManager.Instance.SpawnBonus();
				int index = Random.Range(0, _bonuses.Length);
				_spawnedBonus = InstantiateFeed(_bonuses[index]);
				_bonusEndTime = Time.time + _feedSpawnTimeInfo.BonusSpawnTime;
				IsSpawnedBonus = true;
			}
		}

		public GameObject InstantiateFeed(GameObject feed)
		{
			SetUpTimeUI();
			Vector2 position;
			_feedEndTime = Time.time + _feedSpawnTimeInfo.FeedSpawnTime;
			do
			{
				int YPos = Random.Range(-_fieldHeight / 2, _fieldHeight / 2);
				int XPos = Random.Range(-_fieldWidth / 2, _fieldWidth / 2);
				position = new Vector2(XPos, YPos) + (Vector2)transform.position;
			} while (_snakeBehavior.isOnSnakePosition(position));
			return Instantiate(feed, position, Quaternion.identity, transform);
		}

		public void AddSpawnTime(float time)
		{
			_feedSpawnTimeInfo.FeedSpawnTime += time;
			_feedEndTime += time;
			_UIManager.SetFeedMaxTime(_feedSpawnTimeInfo.FeedSpawnTime);
		}
		public void UnSpawnBonus()
		{
			IsSpawnedBonus = false;
			_UIManager.SetBonusTime(0);
		}

		private void UpdateFeedTime()
		{
			_feedDeltaTime = _feedEndTime - Time.time;
			_UIManager.SetFeedTime(_feedDeltaTime);

		}

		private void UpdateBonuseTime()
		{
			_bonusDeltaTime = _bonusEndTime - Time.time;
			_UIManager.SetBonusTime(_bonusDeltaTime);
		}

		private void SetUpTimeUI()
		{
			_UIManager.SetFeedMaxTime(_feedSpawnTimeInfo.FeedSpawnTime);
			_UIManager.SetFeedTime(_feedSpawnTimeInfo.FeedSpawnTime);
			_UIManager.SetBonusMaxTime(_feedSpawnTimeInfo.BonusSpawnTime);

		}
	}
}