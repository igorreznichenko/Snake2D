using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Snake
{
	public class SnakeBehavior : MonoBehaviour
	{
		private List<SnakeBody> _snakeBody;
		[SerializeField] float _moveTime = 0.5f;
		[SerializeField] GameObject _snakeBodyPrefab;
		private float _deltaTime;
		private SnakeBody Head;
		private void Awake()
		{
			_snakeBody = GetComponentsInChildren<SnakeBody>().ToList();
			Head = _snakeBody[0];
			_deltaTime = Time.time + _moveTime;
		}

		private void Update()
		{
			if (_deltaTime - Time.time <= 0)
			{
				_deltaTime = Time.time + _moveTime;
				Move();
			}
		}
		public void SetHeadDirection(Direction direction) => Head.Forward = direction;

		public Direction GetCurrentDirection() => Head.Forward;
		public SnakeBody GetTile() => _snakeBody[_snakeBody.Count - 1];

		public bool isOnSnakePosition(Vector3 position)
		{
			return _snakeBody.Exists(x => x.transform.position == position);
		}

		public void Grow() 
		{
			Vector3 newTilePosition = GetTile().transform.position + DirectionConverter.ConvertToVector(GetTile().Forward);
			GameObject snakeBody = Instantiate(_snakeBodyPrefab, newTilePosition, Quaternion.identity);
			_snakeBody.Add(snakeBody.GetComponent<SnakeBody>());
		}

		private void Move()
		{
			Head.MoveForward(Direction.Default);
			for (int i = _snakeBody.Count-1; i> 0; i--)
			{
				_snakeBody[i].MoveForward(_snakeBody[i - 1].Forward);
			}

		}


	}
}