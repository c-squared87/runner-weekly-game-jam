using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] GameObject player_prefab;
    Vector2 initLocation;

    [SerializeField] GameObject[] splats;
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;

    Rigidbody2D rb;

    bool hit = false;

    private void Start () {
        initLocation = transform.position;
        FindObjectOfType<CameraFollow> ().SetTarget (this);
        rb = GetComponent<Rigidbody2D> ();
    }

    private void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            Jump ();
        }
    }

    private void FixedUpdate () {
        if (!hit) {
            Vector2 _vel = rb.velocity;
            _vel.x = 2 * moveSpeed;
            rb.velocity = _vel;
        }
    }

    private void OnCollisionEnter2D (Collision2D other) {
        if (other.collider.gameObject.tag == "Wall") {
            hit = true;
            GenerateSplat ();
            rb.freezeRotation = false;
            rb.AddForce (new Vector2 (-3, 1.25f), ForceMode2D.Impulse);
            this.enabled = false;
            Instantiate (player_prefab, initLocation, Quaternion.identity);
            Destroy (gameObject, 2f);
        }
    }

    void Jump () {
        rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void GenerateSplat () {
        int _rand = UnityEngine.Random.Range (0, splats.Length);
        Instantiate (splats[_rand], transform.position, Quaternion.identity);
    }
}