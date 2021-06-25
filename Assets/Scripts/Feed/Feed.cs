using UnityEngine;

namespace Snake
{
	public class Feed : MonoBehaviour
	{
		[SerializeField] protected int _feedScore;
		[SerializeField] protected GameObject _particleSystem;
		protected UIManager _UIManager;
		protected FeedSpawner _feedSpawner;
		protected SnakeBehavior _snakeBehavior;
		protected bool _isAte = false;

		protected void Awake()
		{
			_feedSpawner = FindObjectOfType<FeedSpawner>();
			_snakeBehavior = FindObjectOfType<SnakeBehavior>();
			_UIManager = FindObjectOfType<UIManager>();
			Debug.Log(GetComponentInChildren<ParticleSystem>());
		}

		protected virtual void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Head"))
			{
				AudioManager.Instance.FeedPickUp();
				_UIManager.AddScore(_feedScore);
				_isAte = true;
				_particleSystem.SetActive(true);
				if (tag == "Feed")
					_feedSpawner.SpawnFeed();
			}
		}

		protected void Update()
		{
			if (_isAte && IsFeedInTile())
			{
				_snakeBehavior.Grow();
				Destroy(gameObject);
			}
		}

		protected bool IsFeedInTile() => (Vector2)transform.position == (Vector2)_snakeBehavior.GetTile().transform.position;
	}
}