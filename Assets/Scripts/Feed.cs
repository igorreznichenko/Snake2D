using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake {
    public class Feed : MonoBehaviour
    {
        [SerializeField] private FeedSpawner _feedSpawner;
		[SerializeField] private SnakeBehavior _snakeBehavior;
		private bool _isAte = false;
		private void OnTriggerEnter2D(Collider2D collision)
		{
			//Add point ti UI
			_isAte = true;
		}
		private void Update()
		{
			if (_isAte && transform.position == _snakeBehavior.GetTile().transform.position)
			{
				_snakeBehavior.Grow();
				Destroy(gameObject);
			}
		}
	}
}