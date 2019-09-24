using UnityEngine;

public class Grid : MonoBehaviour
{
    private const float Z_DEPTH = 9f;

    [SerializeField]
    private float _width;

    [SerializeField]
    private float _height;

    [SerializeField]
    private float _beatsStep;

    [SerializeField]
    private float _notesStep;

    [SerializeField]
    private float _offsetX;

    [SerializeField]
    private float _offsetY;

    void Update()
    {
        if (_beatsStep > 0f)
        {
            int stepsCount = Mathf.CeilToInt(_width / _beatsStep);
            for (int i = -stepsCount / 2; i <= stepsCount / 2; ++i)
            {
                float x = i * _beatsStep + _offsetX;
                Color color;
                if (i == 0)
                {
                    color = Color.blue;
                }
                else
                {
                    color = i % 4 == 0 ? Color.red : Color.white;
                }
                Debug.DrawLine(new Vector3(x, -_height / 2f, Z_DEPTH), new Vector3(x, _height / 2f, Z_DEPTH), color);
            }
        }

        if (_notesStep > 0f)
        {
            int stepsCount = Mathf.CeilToInt(_height / _notesStep);
            for (int i = -stepsCount / 2; i <= stepsCount / 2; ++i)
            {
                float y = i * _notesStep + _offsetY;
                Debug.DrawLine(new Vector3(-_width / 2f, y, Z_DEPTH), new Vector3(_width / 2f, y, Z_DEPTH));
            }
        }
    }
}