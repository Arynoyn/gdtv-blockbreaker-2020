using UnityEngine;

public class Paddle : MonoBehaviour
{
    // configuration variables
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        var paddleTransform = transform;
        var mousePositionInScreenWidthUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePosition = paddleTransform.position;
        paddlePosition.x = Mathf.Clamp(mousePositionInScreenWidthUnits, minX, maxX);
        paddleTransform.position = paddlePosition;
    }
}
