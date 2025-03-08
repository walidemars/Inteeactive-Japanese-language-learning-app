using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    void Update()
    {
        // Преобразуем мировые координаты объекта в координаты viewport (значения от 0 до 1)
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        // Если объект вышел за пределы экрана, уничтожаем его.
        if (viewPos.x < -0.5 || viewPos.x > 1.5 || viewPos.y < -0.5 || viewPos.y > 1.5)
        {
            Destroy(gameObject);
        }
    }
}
