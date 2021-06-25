using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
	public class SnakeMovement : MonoBehaviour
	{
		[SerializeField] private SnakeBehavior _snakeBehavior;
		private Direction _currentDirection;
		[HideInInspector]
		public bool isHeadMoved;

		private void Start()
		{
			_currentDirection = _snakeBehavior.GetCurrentDirection();
			isHeadMoved = true;
		}
		void FixedUpdate()
		{
			if(isHeadMoved)
			ChangeDirection();
		}

		private void ChangeDirection()
		{
			float horizontal = Input.GetAxis("Horizontal");
			float vertical = Input.GetAxis("Vertical");
			if (Mathf.Abs(horizontal) > 0.1f)
			{
				if (horizontal > 0)
					ChangeHorizontalDirection(Direction.Right);
				else
					ChangeHorizontalDirection(Direction.Left);
				isHeadMoved = false;
			}
			else
				if (Mathf.Abs(vertical) > 0.1f)
			{
				if (vertical > 0)
					ChangeVerticalDirection(Direction.Up);
				else
					ChangeVerticalDirection(direction: Direction.Down);
				isHeadMoved = false;
			}
		}

		private void ChangeVerticalDirection(Direction direction)
		{
			if (_currentDirection == Direction.Up || _currentDirection == Direction.Down)
				return;
			_snakeBehavior.SetHeadDirection(direction);
			_currentDirection = direction;
		}

		private void ChangeHorizontalDirection(Direction direction)
		{
			if (_currentDirection == Direction.Right || _currentDirection == Direction.Left)
				return;
			_snakeBehavior.SetHeadDirection(direction);
			_currentDirection = direction;
		}

		internal void Move(List<SnakeBody> snakeBody)
		{
			SnakeBody Head = snakeBody[0];
			Head.MoveForward(Direction.Default);
			for (int i = snakeBody.Count - 1; i > 0; i--)
			{
				snakeBody[i].MoveForward(snakeBody[i - 1].Forward);
			}
			isHeadMoved = true;
		}
	}
}