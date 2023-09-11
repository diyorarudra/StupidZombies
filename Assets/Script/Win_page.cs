using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win_page : MonoBehaviour
{
    public Text win_text;
    string[] leval_list11 = { "Play_scene 1", "Play_scene 2", "Play_scene 3", "Play_scene 4", "Play_scene 5" };
    int win_no,level_no;
    // Start is called before the first frame update
    void Start()
    {
        win_no = PlayerPrefs.GetInt("win_no",0);
        win_text.text = "you won "+win_no.ToString();
      //  print("win_no"+win_no);
        level_no = PlayerPrefs.GetInt("level_no",0);
       print("lev"+level_no);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void continu_btn()
    {
        if (win_no<5)
        {
            SceneManager.LoadScene(leval_list11[level_no-1]);
        }
    }
    public void home_btn()
    {
        SceneManager.LoadScene("Level_Scene");

    }
}
