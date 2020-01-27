using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Text scoreText;
    public Text winText;
    public Text loseText;
    public float speed = 0.4f;
    public int score;
    private int nextScene;
    Vector2 dest = Vector2.zero;



     void Start() {
         dest = transform.position;
         score = PlayerPrefs.GetInt("PlayerScore", 0);
         winText.text = "";
         loseText.text = "";
         nextScene = SceneManager.GetActiveScene().buildIndex + 1;
         SetScoreText();
     }

     void FixedUpdate()
     {


         Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
         GetComponent<Rigidbody2D>().MovePosition(p);

         if ((Vector2)transform.position == dest)
      {
       if (Input.GetKey(KeyCode.UpArrow))
           dest = (Vector2)transform.position + Vector2.up;
       if (Input.GetKey(KeyCode.RightArrow))
           dest = (Vector2)transform.position + Vector2.right;
       if (Input.GetKey(KeyCode.DownArrow))
           dest = (Vector2)transform.position - Vector2.up;
       if (Input.GetKey(KeyCode.LeftArrow))
           dest = (Vector2)transform.position - Vector2.right;
      }

     }

    /* bool valid(Vector2 dir) {
         Vector2 pos = transform.position;
         RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
         return (hit.collider == GetComponent<Collider2D>());

    if (hit.collider.gameObject.CompareTag("Pickup") && hit.collider.gameObject.CompareTag("Enemy"))
    {
      return true;
    }
    else
    {
      return (hit.collider == GetComponent<Collider2D>());
    }
     }
    */
     void OnTriggerEnter2D(Collider2D other)
         {
             if (other.gameObject.CompareTag ("Pickup"))
             {
                 other.gameObject.SetActive (false);
                 score = score + 10;
                 SetScoreText();
             }
             if (other.gameObject.CompareTag("Enemy"))
             {
                 gameObject.SetActive (false);
                 SceneManager.LoadScene("GameOver");

             }
        }

        void SetScoreText()
        {
        scoreText.text = "Score: " + score.ToString ();
        if (score == 10)
        {
            SceneManager.LoadScene("LevelTwo");
            score = PlayerPrefs.GetInt ("PlayerScore");

            //winText.text = "You Win!";
        }
        if (score == 40)
        {
          SceneManager.LoadScene("Win");
        }
    }
}
