using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Object = System.Object;

public class Block : MonoBehaviour {
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject blockSparklesVFX;
    
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
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVfx();
    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameSession>().IncreaseScore();
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        }
    }

    private void TriggerSparklesVfx()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}