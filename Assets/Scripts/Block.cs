using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Block : MonoBehaviour {
    [SerializeField] AudioClip breakSound;
    
    //cached reference
    private Level level;

    private void Start() {
        level = FindObjectOfType<Level>();
        level.IncreaseBreakableBlockCount();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        DestroyBlock();
    }

    private void DestroyBlock() {
        if (Camera.main != null) {
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        }

        Destroy(gameObject);
        level.BlockDestroyed();
    }
}