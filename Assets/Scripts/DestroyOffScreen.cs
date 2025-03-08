using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    void Update()
    {
        // ����������� ������� ���������� ������� � ���������� viewport (�������� �� 0 �� 1)
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        // ���� ������ ����� �� ������� ������, ���������� ���.
        if (viewPos.x < -0.5 || viewPos.x > 1.5 || viewPos.y < -0.5 || viewPos.y > 1.5)
        {
            Destroy(gameObject);
        }
    }
}
