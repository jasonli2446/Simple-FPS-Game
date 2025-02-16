using UnityEngine;
using TMPro;

public class GameOverTextController : MonoBehaviour
{
  public float speedX = 100.0f;
  public float speedY = 50.0f;
  private RectTransform _rectTransform;
  private Vector2 _direction;
  private RectTransform _canvasRectTransform;

  private float textWidth = 400f;
  private float textHeight = 50f;

  void Start()
  {
    _rectTransform = GetComponent<RectTransform>();
    _direction = new Vector2(speedX, speedY);
    _canvasRectTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
  }

  void Update()
  {
    _rectTransform.anchoredPosition += _direction * Time.deltaTime;

    float canvasWidth = _canvasRectTransform.rect.width;
    float canvasHeight = _canvasRectTransform.rect.height;

    float minX = -canvasWidth / 2 + textWidth / 2;
    float maxX = canvasWidth / 2 - textWidth / 2;
    float minY = -canvasHeight / 2 + textHeight / 2;
    float maxY = canvasHeight / 2 - textHeight / 2;

    if (_rectTransform.anchoredPosition.x <= minX || _rectTransform.anchoredPosition.x >= maxX)
    {
      _direction.x = -_direction.x;
      _rectTransform.anchoredPosition = new Vector2(Mathf.Clamp(_rectTransform.anchoredPosition.x, minX, maxX), _rectTransform.anchoredPosition.y);
    }

    if (_rectTransform.anchoredPosition.y <= minY || _rectTransform.anchoredPosition.y >= maxY)
    {
      _direction.y = -_direction.y;
      _rectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x, Mathf.Clamp(_rectTransform.anchoredPosition.y, minY, maxY));
    }
  }
}