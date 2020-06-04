
using UnityEngine;

public class MenuCharacterAnimation : MonoBehaviour {
    [SerializeField] float x_min;
    [SerializeField] float x_max;

    [SerializeField] float moveSpeed;

    void Update () {
        transform.Translate (Vector2.right * moveSpeed * Time.deltaTime);
        if (transform.position.x >= x_max) {
            Vector2 _newPos = transform.position;
            _newPos.x = x_min;
            transform.position = _newPos;
        }
    }
}