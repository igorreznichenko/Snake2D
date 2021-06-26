using UnityEngine;

namespace Snake
{
    [CreateAssetMenu(fileName = "FeedInfo", menuName = "FeedInfo")]
    public class FeedInfo : ScriptableObject
    {
        public int Score;
    }
}