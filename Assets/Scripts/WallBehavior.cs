using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Snake {
	public class WallBehavior : MonoBehaviour
	{
		private const int _fieldWidth = 78;
		private const int _fieldHeight = 48;
		private void OnTriggerEnter2D(Collider2D other)
		{

			Transform bodyTransfom = other.GetComponent<SnakeBody>().transform;
			switch (tag)
			{
				case "LeftWall":
					{
						bodyTransfom.position += Vector3.right * _fieldWidth;
						break;
					}
				case "RightWall":
					{
						bodyTransfom.position += Vector3.left * _fieldWidth;
						break;
					}
				case "UpWall":
					{
						bodyTransfom.position += Vector3.down * _fieldHeight;
						break;
					}
				case "BottomWall":
					{
						bodyTransfom.position += Vector3.up * _fieldHeight;
						break;
					}
			}
		}
	}
}