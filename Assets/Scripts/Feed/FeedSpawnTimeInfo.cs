using UnityEngine;

namespace Snake
{
	[CreateAssetMenu(fileName = "TimeInfo", menuName = "TimeInfo", order = 1)]
	public class FeedSpawnTimeInfo : ScriptableObject
	{
		public float FeedSpawnTime;
		public float BonusSpawnTime;

	}
}