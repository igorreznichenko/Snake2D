using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Snake
{
	public class SnakeBehavior : MonoBehaviour
	{
		public int SnakeLength => _snakeLength;
		private int _snakeLength;
		private List<SnakeBody> _snakeBody;
		[SerializeField] private UIManager _UIManager;
		[SerializeField] private float _moveTime = 0.5f;
		[SerializeField] private GameObject _snakeBodyPrefab;
		[SerializeField] private SnakeMovement _snakeMovement;
		private float _deltaTime;
		private SnakeBody Head;
		private void Awake()
		{
			_snakeBody = GetComponentsInChildren<SnakeBody>().ToList();
			Head = _snakeBody[0];
			_snakeLength = _snakeBody.Count;
			_deltaTime = Time.time + _moveTime;
		}

		private void Update()
		{
			if (_deltaTime - Time.time <= 0)
			{
				_deltaTime = Time.time + _moveTime;
				Move();
			}
			if (Input.GetKeyDown(KeyCode.K))
				Grow();
		}
		public void SetHeadDirection(Direction direction) => Head.Forward = direction;

		public Direction GetCurrentDirection() => Head.Forward;

		public SnakeBody GetTile() => _snakeBody[_snakeBody.Count - 1];

		public void AddSpeed(float bonusSpeedTime)
		{
			if (_moveTime-bonusSpeedTime > 0.1f)
				_moveTime -= bonusSpeedTime;
		}

		public bool isOnSnakePosition(Vector3 position)
		{
			return _snakeBody.Exists(x => x.transform.position == position);
		}

		public void Grow() 
		{
			MakeNewBodyPart();
			_snakeLength++;
			_UIManager.SetSnakeLength(_snakeLength);
		}
		private void MakeNewBodyPart()
		{
			SnakeBody tile = GetTile();
			Direction opposite = DirectionConverter.GetOpposite(tile.Forward);
			Vector3 newTilePosition = tile.transform.position + DirectionConverter.ConvertToVector(opposite);
			GameObject snakeBody = Instantiate(_snakeBodyPrefab, newTilePosition, Quaternion.identity, transform);
			SnakeBody body = snakeBody.GetComponent<SnakeBody>();
			body.Forward = tile.Forward;
			_snakeBody.Add(body);
		}

		private void Move()
		{
			_snakeMovement.Move(_snakeBody);
		}
	}
}