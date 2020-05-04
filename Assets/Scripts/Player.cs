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
    bool grounded;

    private void Start () {
        initLocation = transform.position;

        rb = GetComponent<Rigidbody2D> ();
        rb.freezeRotation = true;
    }

    private void OnEnable () {
        FindObjectOfType<CameraFollow> ().SetTarget (this);
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
        if (rb.velocity.y < 0) {
            rb.gravityScale = 2.5f;
        } else {
            rb.gravityScale = 1;
        }
    }

    private void OnCollisionEnter2D (Collision2D other) {

        Debug.Log (other.collider.gameObject.layer);
        if (other.collider.gameObject.layer == 8) {
            grounded = true;
            if (hit) {
                GenerateSplat ();
            }
        }

        if (other.collider.gameObject.tag == "Wall") {
            hit = true;
            GenerateSplat ();

            rb.freezeRotation = false;
            rb.velocity = Vector3.zero;
            rb.AddForce (new Vector2 (-3.5f, 2.25f), ForceMode2D.Impulse);
            rb.AddTorque (2, ForceMode2D.Impulse);

            StartCoroutine (Next ());
        }
    }

    IEnumerator Next () {
        Destroy (gameObject, 1.5f);

        yield return new WaitForSeconds (1f);

        GameObject _player_clone = Instantiate (player_prefab, initLocation, Quaternion.Euler (Vector3.zero));
        _player_clone.name = "Player";

        this.enabled = false;
    }

    void Jump () {
        rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void GenerateSplat () {
        int _rand = UnityEngine.Random.Range (0, splats.Length);
        Instantiate (splats[_rand], transform.position, Quaternion.identity);
    }
}