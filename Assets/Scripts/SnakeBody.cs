using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Snake
{
	public class SnakeBody : MonoBehaviour
	{
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
				this._forward = direction;
		}		
	}
}