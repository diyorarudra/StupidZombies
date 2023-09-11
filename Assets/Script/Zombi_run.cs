using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Zombi_run : MonoBehaviour
{
    public Text scorec_text;
    Animator animator;
    bool rightwalk = false, leftwalk = false;
    int total_point = 0,level_no,SCORE_NO;
    void Start()
    {
        SCORE_NO = PlayerPrefs.GetInt("SCORE_NO", 20);
        scorec_text.text = SCORE_NO.ToString(); 
        level_no = PlayerPrefs.GetInt("level_no",0);
        rightwalk = true;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || leftwalk)
            {
                transform.position = new Vector2(transform.position.x - 0.02f, transform.position.y);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                animator.SetBool("IsWalk", true);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || rightwalk)
            {
                transform.position = new Vector2(transform.position.x + 0.02f, transform.position.y);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                animator.SetBool("IsWalk", true);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("IsWalk", false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Right_tag")
        {
            rightwalk = false;
            leftwalk = true;
        }
        if (col.gameObject.tag == "Left_tag")
        {
            rightwalk = true;
            leftwalk = false;
        }
        if (col.gameObject.tag == "Bullet_tag")
        {
            SCORE_NO++;
            scorec_text.text = SCORE_NO.ToString();
            PlayerPrefs.SetInt("SCORE_NO",SCORE_NO);
            animator.SetBool("Isdead", true);
            this.gameObject.tag = "ddd";
            leftwalk = false;
            rightwalk = false;
            print("boom");
            total_point++;
        }
    }
 

}