using UnityEngine;

namespace Snake
{
	[CreateAssetMenu(fileName = "SpeedBonusInfo", menuName = "SpeedBonusInfo")]
	public class SpeedBonusInfo : FeedInfo
	{
		public float BonusSpeedTime = 0.05f;
	}
}