using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLevel1 : MonoBehaviour
{
    public Text squareCount;
    public Text triangleCount;
    public Text starCount;
    public Text logCount;
    private int scount = 0;
    private int tcount = 0;
    private int stCount = 0;
    private int lcount = 0;
    public GameObject square1;
    public GameObject square2;
    public GameObject star;
    public GameObject triangle;
    public GameObject tree;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject log1;
    public GameObject log2;
    public GameObject button;

    private Vector3 position;

    public char dir;

    private int steps = 40; 
    public Text counter;
    public Text result;

    private const string status = "GAME OVER!!";

    // Start is called before the first frame update
    void Start()
    {
        reset_player();
        // button.SetActive(true);
        log1.SetActive(false);
        log2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (steps == 0)
        {
            result.text = status;

            button.SetActive(true);
        }
        position = this.transform.position;
        // player movement - up down right left
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (steps > 0)
            {
                position.x--;
                this.transform.position = position;
                diminish_steps(); // step counter
                dir = 'a';
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (steps > 0)
            {
                position.x++;
                this.transform.position = position;
                diminish_steps(); // step counter
                dir = 'd';
            }
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (steps > 0)
            {
                position.y++;
                this.transform.position = position;
                diminish_steps(); // step counter
                dir = 'w';
            }
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (steps > 0)
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

    void reset_player()
    {
        position.x = -8.5f;
        position.y = -1;
        this.transform.position = position;

        button.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //game checkpoint logic
        if (collision.gameObject.CompareTag("Square Door") && scount > 0)
        {
            SceneManager.LoadScene("Level 2A");
        }

        if (collision.gameObject.CompareTag("Triangle Door") && tcount > 0)
        {
            SceneManager.LoadScene("Level 2B");
        }
        if (collision.gameObject.CompareTag("Lvl1 Wall1") || collision.gameObject.CompareTag("Lvl1 Wall2") || collision.gameObject.CompareTag("Lvl1 Wall3") || (collision.gameObject.CompareTag("Triangle Door") && tcount == 0) || (collision.gameObject.CompareTag("Square Door") && scount == 0))
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

        // Check if the collision involves a specific tag
        if (collision.gameObject.CompareTag("Lvl1 Water"))
        {
            // reducing player lifeline on collision with water
            if(lcount == 0)
            {
                if (heart1.activeSelf || heart2.activeSelf || heart3.activeSelf)
                {
                    if (heart3.activeSelf)
                    {
                        heart3.SetActive(false);
                        
                    }
                    else
                    {
                        if (heart2.activeSelf)
                        {
                            heart2.SetActive(false);
                            
                        }
                        else
                        {
                            heart1.SetActive(false);
                            steps = 0;
                            
                        }
                    }
                    reset_player();
                }
                else
                {
                    steps = 0;
                }
            }
        }

        if (collision.gameObject.CompareTag("Square"))
        {
            scount++;
            squareCount.text = scount.ToString();
            square1.SetActive(false);
        }
        if(collision.gameObject.CompareTag("Lvl1 Square"))
        {
            scount++;
            squareCount.text = scount.ToString();
            square2.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Lvl1 Triangle"))
        {
            tcount++;
            triangleCount.text = tcount.ToString();
            triangle.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Tree"))
        {
            lcount++;
            logCount.text = lcount.ToString();
            tree.SetActive(false);
            log1.SetActive(true);
            log2.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Lvl1 Star"))
        {
            stCount++;
            starCount.text = stCount.ToString();
            star.SetActive(false);
        }
    }
}
