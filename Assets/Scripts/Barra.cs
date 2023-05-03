using UnityEngine;
using UnityEngine.UI;

public class Barra : MonoBehaviour
{
    public RectTransform squirrelIcon;
    public RectTransform lumberjackIcon;
    public float progressBarLength = 100f;
    public float timeToReachEnd = 5f;
    public float lumberjackDistancePerTree = 5f;

    private float currentProgress = 0f;

    private void Start()
    {
        // Set initial position of icons
        squirrelIcon.anchoredPosition = new Vector2(-progressBarLength / 22f, 0f);
        lumberjackIcon.anchoredPosition = new Vector2(-progressBarLength / 0f, 0f);
    }

    private void Update()
    {
        // Move squirrel icon
        float squirrelDistance = currentProgress * progressBarLength;
        squirrelIcon.anchoredPosition = new Vector2(squirrelDistance - progressBarLength / 2f, 0f);

        // Move lumberjack icon
        float lumberjackDistance = (int)(currentProgress / (lumberjackDistancePerTree / progressBarLength)) * (lumberjackDistancePerTree / progressBarLength) * progressBarLength;
        lumberjackIcon.anchoredPosition = new Vector2(lumberjackDistance - progressBarLength / 2f, 0f);
    }

    public void UpdateProgress(float newProgress)
    {
        currentProgress = Mathf.Clamp01(newProgress);

        // Check if squirrel reached end
        if (currentProgress >= 1f)
        {
            // Do something when squirrel reaches end
        }
    }
}