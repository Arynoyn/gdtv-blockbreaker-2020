using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Block : MonoBehaviour {
    [SerializeField] AudioClip breakSound;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (Camera.main != null) {
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        }

        Destroy(gameObject);
    }
}