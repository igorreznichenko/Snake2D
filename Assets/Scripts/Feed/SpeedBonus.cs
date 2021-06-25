using UnityEngine;

namespace Snake
{
    public class SpeedBonus : Feed
    {
		[SerializeField] float _bonusSpeedTime = 0.05f;
		protected override void OnTriggerEnter2D(Collider2D collision)
		{
			base.OnTriggerEnter2D(collision);
			if(collision.CompareTag("Head"))
			{
				_snakeBehavior.AddSpeed(_bonusSpeedTime);
				_feedSpawner.UnSpawnBonus();
			}
		}
	}
}