using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public GameObject currentWall;
    [Range(0,1)]
    public float speed;
    public Vector3 offset;
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    public void SetWall(Wall wall)
    {
        currentWall = wall.gameObject;
    }

    private void Update()
    {
        _camera.gameObject.transform.position = Vector3.Lerp(_camera.gameObject.transform.position,
            currentWall.transform.position + offset, speed);
    }
}