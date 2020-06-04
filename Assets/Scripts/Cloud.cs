using UnityEngine;

public class Cloud : MonoBehaviour {

    [SerializeField] float x_min;
    [SerializeField] float x_max;

    [SerializeField] float moveSpeed;

    void Update () {
        transform.Translate (Vector2.left * moveSpeed * Time.deltaTime);
        if (transform.position.x <= x_min) {
            Vector2 _newPos = transform.position;
            _newPos.x = x_max;
            transform.position = _newPos;
        }
    }
}