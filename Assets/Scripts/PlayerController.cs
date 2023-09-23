using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text counter;
    public Text result;
    public Text starSymbol;
    public Text triangleSymbol;
    private int steps = 30;
    private int starCount = 0;
    private int triangleCount = 0;
    private const string status = "GAME OVER!!";
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject star;
    public GameObject triangle;
    private Vector3 position;

    public char dir;
    public bool symbol = false; 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // game over condition
        if(steps == 0)
        {
            result.text = status;
        }
        position = this.transform.position;
        // player movement - up down right left
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            if(steps > 0)
            {
                position.x--;
                this.transform.position = position;
                diminish_steps(); // step counter
                dir = 'a';
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            if(steps > 0)
            {
                position.x++;
                this.transform.position = position;
                diminish_steps(); // step counter
                dir = 'd';
            }
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            if(steps > 0)
            {
                position.y++;
                this.transform.position = position;
                diminish_steps(); // step counter
                dir = 'w';
            }
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            if(steps > 0)
            {
                position.y--;
                this.transform.position = position;
                diminish_steps(); // step counter
                dir = 's';
            }
        }

    }

    void diminish_steps()
    {
        // reduce the step count by 1
        steps--;
        counter.text = steps.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //game checkpoint logic
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Wall2") || (collision.gameObject.CompareTag("StarDoor") && starCount == 0))
        {
            if (dir == 'a')
            {
                position.x++;
            }
            else if (dir == 'd')
            {
                position.x--;
            }
            else if (dir == 'w')
            {
                position.y--;
            }
            else if (dir == 's')
            {
                position.y++;
            }
            this.transform.position = position;
        }
        if (collision.gameObject.CompareTag("StarDoor"))
        {
            if(starCount == 1)
            {
                SceneManager.LoadScene("Level 1");
            }
        }

        // Check if the collision involves a specific tag
        if (collision.gameObject.CompareTag("Water"))
        {
            // reducing player lifeline on collision with water
            if(heart1.activeSelf || heart2.activeSelf || heart3.activeSelf)
            {
                if (heart3.activeSelf)
                {
                    heart3.SetActive(false);
                    reset_player();
                }
                else
                {
                    if (heart2.activeSelf)
                    {
                        heart2.SetActive(false);
                        reset_player();
                    }
                    else
                    {
                        heart1.SetActive(false);
                        steps = 0;
                        reset_player();
                    }
                }
            }
            else
            {
                steps = 0;
            }
        }else if (collision.gameObject.CompareTag("Star"))
        {
            star.SetActive(false);
            starCount++;
            starSymbol.text = starCount.ToString();
        }else if (collision.gameObject.CompareTag("Triangle"))
        {
            triangle.SetActive(false);
            triangleCount++;
            triangleSymbol.text = triangleCount.ToString();
        }
    }

    void reset_player()
    {
        position.x = -8.5f;
        position.y = -1;
        this.transform.position = position;
    }
}
