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
						bodyTransfom.position += Vector3.right * (_fieldWidth+1);
						break;
					}
				case "RightWall":
					{
						bodyTransfom.position += Vector3.left * (_fieldWidth+1);
						break;
					}
				case "UpWall":
					{
						bodyTransfom.position += Vector3.down * (_fieldHeight+1);
						break;
					}
				case "BottomWall":
					{
						bodyTransfom.position += Vector3.up * (_fieldHeight+1);
						break;
					}
			}
		}
	}
}