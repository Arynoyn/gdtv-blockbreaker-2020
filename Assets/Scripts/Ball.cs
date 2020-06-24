using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] private Paddle paddle1;
    [SerializeField] private float xInitialVelocity = 2f;
    [SerializeField] private float yInitialVelocity = 15f;

    [SerializeField] private AudioClip[] ballSounds;
    //state
    private Vector2 _paddleToBallVector;
    private Rigidbody2D _rigidBody;
    private bool _hasStarted;
    
    //Cached component references
    private AudioSource _myAudioSource;

    // Start is called before the first frame update
    void Start() {
        _rigidBody = GetComponent<Rigidbody2D>();
        _paddleToBallVector = transform.position - paddle1.transform.position;
        _hasStarted = false;
        _myAudioSource = GetComponent<AudioSource>();
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

    private void OnCollisionEnter2D(Collision2D other) {
        if (_hasStarted) {
            var clip = ballSounds[Random.Range(0, ballSounds.Length)];
            _myAudioSource.PlayOneShot(clip);
        }
    }
}
