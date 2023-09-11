using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_Scene : MonoBehaviour
{
    public GameObject levbtn_prefrb, levalBodyHolder;
    public Sprite lock_img,tick;
    int max = 1,level_no=0;
    int total_level = 5;
    string[] leval_list = { "Play_scene 1", "Play_scene 2", "Play_scene 3", "Play_scene 4", "Play_scene 5" };
    void Start()
    {
        level_no = PlayerPrefs.GetInt("level_no",0);
        max = PlayerPrefs.GetInt("max",max);
        for (int i = 0; i < total_level; i++)
        {
            int n = (i + 1);
           GameObject g = Instantiate(levbtn_prefrb, levalBodyHolder.transform);
            g.tag = "Level_btn";
            g.GetComponentInChildren<Image>().sprite = lock_img;   
            g.GetComponent<Button>().interactable= false;
            g.GetComponent<Button>().onClick.AddListener(()=>lev_btn_click(n));         
        }
        if (max < level_no || level_no==5)
        { 
            max= level_no;
            PlayerPrefs.SetInt("max",max);
        }
        GameObject[] lev_btn = GameObject.FindGameObjectsWithTag("Level_btn");
        for (int j = 0; j < max; j++)
        {
            
            lev_btn[j].GetComponentInChildren<Image>().sprite = null;
            if (j<max-1||max==5)
            {
                lev_btn[j].GetComponentInChildren<Image>().sprite = tick;
            }

            lev_btn[j].GetComponentInChildren<Text>().text = (j + 1).ToString();
            lev_btn[j].GetComponent<Button>().interactable= true;
        }       
    }
    void lev_btn_click(int n)
    {
        PlayerPrefs.SetInt("level_no",n);
        SceneManager.LoadScene(leval_list[n-1]);
    }
}
