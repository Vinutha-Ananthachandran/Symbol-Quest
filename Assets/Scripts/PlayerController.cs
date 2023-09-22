using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text counter;
    public Text result;
    public Text starSymbol;
    public Text triangleSymbol;
    private int steps = 23;
    private int starCount = 0;
    private int triangleCount = 0;
    private const string status = "GAME OVER!!";
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject star;
    public GameObject triangle;
    private Vector3 position;
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
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            if(steps > 0)
            {
                position.x++;
                this.transform.position = position;
                diminish_steps(); // step counter
            }
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            if(steps > 0)
            {
                position.y++;
                this.transform.position = position;
                diminish_steps(); // step counter
            }
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            if(steps > 0)
            {
                position.y--;
                this.transform.position = position;
                diminish_steps(); // step counter
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
