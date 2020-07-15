using UnityEngine;

public class Paddle : MonoBehaviour
{
    // configuration variables
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;
    private GameSession _gameSession;
    private Ball _ball;

    // Start is called before the first frame update
    void Start() {
        _gameSession = FindObjectOfType<GameSession>();
        _ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update() {
        var paddleTransform = transform;
        Vector2 paddlePosition = paddleTransform.position;
        paddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);
        paddleTransform.position = paddlePosition;
    }

    private float GetXPos() {
        if (_gameSession.IsAutoPlayEnabled()) {
            return _ball.transform.position.x;
        }
        else {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
