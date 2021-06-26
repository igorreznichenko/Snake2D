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
				TimeBonusInfo bonusInfo = (TimeBonusInfo)_feedInfo;
				_feedSpawner.AddSpawnTime(bonusInfo.bonusTime);
				_feedSpawner.UnSpawnBonus();
			}
		}
	}
}