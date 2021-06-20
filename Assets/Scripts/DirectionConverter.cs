using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Snake
{
	public static class DirectionConverter
	{
		public static Vector3 ConvertToVector(Direction direction)
		{
			switch (direction)
			{
				case Direction.Right:
					return Vector3.right;
				case Direction.Left:
					return Vector3.left;
				case Direction.Up:
					return Vector3.up;
				case Direction.Down:
					return Vector3.down;
				default:
					return Vector3.zero;
			}
		}
		public static Direction GetOpposite(Direction direction)
		{
			switch (direction)
			{
				case Direction.Right:
					return Direction.Left;
				case Direction.Left:
					return Direction.Right;
				case Direction.Up:
					return Direction.Down;
				case Direction.Down:
					return Direction.Up;
				default:
					return Direction.Default;
			}
		}
	}
}