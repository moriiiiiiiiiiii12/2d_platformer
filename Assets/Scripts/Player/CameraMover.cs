using UnityEngine;

class CameraMover : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _speed = 4f;

    private void LateUpdate()
    {
        Vector2 playerPosition = new Vector2(_player.position.x, _player.position.y);
        Vector2 cameraPosition = new Vector2(transform.position.x, transform.position.y);

        Vector2 targetPosition = Vector2.Lerp(cameraPosition, playerPosition, _speed * Time.deltaTime);

        transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
    }
}