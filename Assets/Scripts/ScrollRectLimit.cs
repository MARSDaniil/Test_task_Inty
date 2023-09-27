using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScrollRectLimit : MonoBehaviour
{
    [Header("Scroll Rect")]
    public bool isHorizontal = false;
    private RectTransform rectTransform;
    [SerializeField] Vector2 slideLimitsStart = new Vector2(0, 0);
    [SerializeField] Vector2 slideLimitsEnd = new Vector2(0, 3240);
    private void Awake() {
        Init();
    }
    public void Init() {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHorizontal) Limit(rectTransform.localPosition.x, slideLimitsStart.x, slideLimitsEnd.x);
        else Limit(rectTransform.localPosition.y, slideLimitsStart.y, slideLimitsEnd.y);
    }

    private void Limit(float value, float start, float finish) {
        if (value < start)
            rectTransform.localPosition = new Vector2(slideLimitsStart.x, slideLimitsStart.y);
        if (value > finish)
            rectTransform.localPosition = new Vector2(slideLimitsEnd.x, slideLimitsEnd.y);
    }
}
