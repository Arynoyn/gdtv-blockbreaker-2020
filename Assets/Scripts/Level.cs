
using UnityEngine;

public class Level : MonoBehaviour {
    [SerializeField] int breakableBlocks; //Serialized for debugging purposes
    private SceneLoader sceneLoader;

    private void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void IncreaseBlockCount() {
        breakableBlocks++;
    }

    public void BlockDestroyed() {
        breakableBlocks--;
        if (breakableBlocks <= 0) {
            sceneLoader.LoadNextScene();
        }
    }
}
