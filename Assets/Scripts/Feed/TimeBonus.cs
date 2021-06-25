using UnityEngine;

namespace Snake {
	public class TimeBonus : Feed
	{
		[SerializeField] private float _bonusTime;
		protected override void OnTriggerEnter2D(Collider2D collision)
		{
			base.OnTriggerEnter2D(collision);
			if(collision.CompareTag("Head"))
			{
				_feedSpawner.AddSpawnTime(_bonusTime);
				_feedSpawner.UnSpawnBonus();
			}
		}
	}
}