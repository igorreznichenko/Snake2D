using UnityEngine;

namespace Snake
{
    public class SpeedBonus : Feed
    {
		protected override void OnTriggerEnter2D(Collider2D collision)
		{
			base.OnTriggerEnter2D(collision);
			if(collision.CompareTag("Head"))
			{
				SpeedBonusInfo bonusInfo= (SpeedBonusInfo)_feedInfo;				
				_snakeBehavior.AddSpeed(bonusInfo.BonusSpeedTime);
				_feedSpawner.UnSpawnBonus();
			}
		}
	}
}