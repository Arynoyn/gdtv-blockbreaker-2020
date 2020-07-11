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
    
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            level = FindObjectOfType<Level>();
            level.IncreaseBlockCount();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (tag == "Breakable")
        {
            DestroyBlock();
        }
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