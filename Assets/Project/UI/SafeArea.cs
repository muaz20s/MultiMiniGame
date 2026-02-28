using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SafeArea : MonoBehaviour
{
    private RectTransform _panel;
    private Rect _lastSafeArea = Rect.zero;

    private void Awake()
    {
        _panel = GetComponent<RectTransform>();
        ApplySafeArea();
    }

    private void Update()
    {
        if (Screen.safeArea != _lastSafeArea)
            ApplySafeArea();
    }

  
    private void ApplySafeArea()
    {
        _lastSafeArea = Screen.safeArea;
        Rect safeArea = Screen.safeArea;
       
        Vector2 anchorMin = safeArea.position;      
        Vector2 anchorMax = safeArea.position + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;
        
        _panel.anchorMin = anchorMin;
        _panel.anchorMax = anchorMax;
    }
}
