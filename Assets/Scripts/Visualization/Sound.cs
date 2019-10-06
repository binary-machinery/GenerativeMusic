using UnityEngine;

namespace Visualization
{
    public class Sound : MonoBehaviour
    {
        public PlayableSound playableSound { get; set; }

        public void SetSize(float width, float height)
        {
            var t = transform;
            Vector3 scale = t.localScale;
            scale.x = width;
            scale.y = height;
            t.localScale = scale;
        }

        public void SetColor(Color color)
        {
            Renderer renderer = transform.GetChild(0).GetComponent<Renderer>();
            Material material = renderer.material;
            material.color = color;
        }
    }
}