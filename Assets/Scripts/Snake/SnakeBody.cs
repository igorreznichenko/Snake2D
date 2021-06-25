using UnityEngine;

namespace Snake
{
	public class SnakeBody : MonoBehaviour
	{
		private UIManager _UIManager;
		private void Awake()
		{
			_UIManager = FindObjectOfType<UIManager>();
		}
		public Direction Forward
		{
			get { return _forward; }
			set { _forward = value; }
		}
		private Direction _forward = Direction.Right;
		public void MoveForward(Direction direction)
		{
			transform.position += DirectionConverter.ConvertToVector(Forward);
			if (direction != Direction.Default)
				_forward = direction;
		}
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Head"))
			{
				_UIManager.GameOver();
			}
		}
	}
}