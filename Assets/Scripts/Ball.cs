using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] private Paddle paddle1;
    [SerializeField] private float xInitialVelocity = 2f;
    [SerializeField] private float yInitialVelocity = 15f;
    
    //state
    private Vector2 _paddleToBallVector;
    private Rigidbody2D _rigidBody;
    private bool _hasStarted;

    // Start is called before the first frame update
    void Start() {
        _rigidBody = GetComponent<Rigidbody2D>();
        _paddleToBallVector = transform.position - paddle1.transform.position;
        _hasStarted = false;
    }

    // Update is called once per frame
    void Update() {
        if (!_hasStarted) {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            _hasStarted = true;
            _rigidBody.velocity = new Vector2(xInitialVelocity, yInitialVelocity);
        }
    }

    private void LockBallToPaddle() {
        var paddle1TransformPosition = paddle1.transform.position;
        var paddlePosition = new Vector2(paddle1TransformPosition.x, paddle1TransformPosition.y);
        transform.position = paddlePosition + _paddleToBallVector;
    }
}
