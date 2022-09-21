using UnityEngine;

public class ScreenManager : MonoBehaviour
{
	[SerializeField] private Board _board;
	[SerializeField] private float _offset;

	private void Awake()
	{
		PrepareCamera();
	}

	private void PrepareCamera()
	{
		var cam = GetComponent<Camera>();
		cam.orthographicSize = ((_board.GetGrid.width + _offset) / cam.aspect) / 2;
	}
}