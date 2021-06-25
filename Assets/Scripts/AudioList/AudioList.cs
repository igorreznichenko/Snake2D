using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake 
{
	[CreateAssetMenu(fileName = "AudioList", menuName = "AudioList",order=0)]
	public class AudioList : ScriptableObject
	{
		public AudioClip FeedPickUp;
		public AudioClip GameOver;
		public AudioClip SpawnBonus;
	}
}