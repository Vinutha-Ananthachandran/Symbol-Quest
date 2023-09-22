using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public char dir;
    public bool symbol = false;
    Vector3 position = new Vector3(-3.5f, 0.5f, 0.0f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            position = this.transform.position;
            position.x--;
            dir = 'a';
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            position = this.transform.position;
            position.x++;
            dir = 'd';
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            position = this.transform.position;
            position.y++;
            dir = 'w';
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            position = this.transform.position;
            position.y--;
            dir = 's';
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Collide.");
        var wall = collision.gameObject.GetComponent<WallController>();
        var star = collision.gameObject.GetComponent<StarController>();
        var door_star = collision.gameObject.GetComponent<StarDoorController>();
        if (wall != null || (door_star != null && !symbol)) {
            if (dir == 'a') {
                position.x++;
            }
            else if (dir == 'd') {
                position.x--;
            }
            else if (dir == 'w') {
                position.y--;
            }
            else if (dir == 's') {
                position.y++;
            }
        }
        else if (star != null) {
            symbol = true;
            collision.gameObject.SetActive(false);
        }
        else if (door_star != null) {
            if (symbol) {
                SceneManager.LoadScene("Level 1");
            }
        }
    }
    
    void LateUpdate() {
        this.transform.position = position;
    }
}
