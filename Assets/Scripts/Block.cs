using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Object = System.Object;

public class Block : MonoBehaviour {
    // config params
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject blockSparklesVFX;
    [SerializeField] private int maxHits;
    [SerializeField] private Sprite[] hitSprites;
    
    //cached reference
    private Level level;
    
    //state variables
    [SerializeField] private int timesHit; //TODO: Only serialized for debug purposes
    
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
        if (tag == "Breakable") {
            timesHit++;
            if (timesHit >= maxHits) {
                DestroyBlock();
            }
            else {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite() {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
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