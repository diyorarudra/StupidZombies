using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gun_controlor : MonoBehaviour
{
    public GameObject gunpoint, prefrb,scope_prefrb, goli_finish_scene,loss_scene;
    public LineRenderer LineRenderer;
    public GameObject goli_show_prefrb, full_show_holder;
    int[] bullet_levelvise = { 4,4,4,5,5,5,6,6,6,7,7,7,8,8,8};
    int this_lev_bullet=0;
    int press_add = 0;
    int bullet_stock,level_no;
    string[] leval_list = { "Play_scene 1", "Play_scene 2", "Play_scene 3", "Play_scene 4", "Play_scene 5" };
    // Start is called before the first frame update
    void Start()
    {
        level_no = PlayerPrefs.GetInt("level_no",0);
         this_lev_bullet = bullet_levelvise[0];
        Instantiate(scope_prefrb, transform.position, Quaternion.identity);
        for (int i = 0; i < this_lev_bullet; i++)
        {
           GameObject BULL = Instantiate(goli_show_prefrb, full_show_holder.transform);
            BULL.tag = "Titel_show";
        }
    }
    void Update()
    {
     
        Vector2 mouseposs =Camera.main.ScreenToWorldPoint( Input.mousePosition);
        Vector2 gunposs = transform.position;
        Vector2 offset = mouseposs- gunposs;
        LineRenderer.SetPosition(0, gunposs);
        LineRenderer.SetPosition(1, mouseposs);
        float angle = Mathf.Clamp(Mathf.Atan2(offset.y,offset.x)*Mathf.Rad2Deg, 0f, 90f);
        transform.rotation = Quaternion.Euler(0,0,angle);
        if (Input.GetMouseButtonUp(0))
        {
            fir();
        }
        if(GameObject.FindGameObjectsWithTag("Zombi_tag").Length==0)
        {
            PlayerPrefs.SetInt("win_no",level_no);
            level_no++;
            PlayerPrefs.SetInt("level_no",level_no);
            SceneManager.LoadScene("Win_scene");
        }
    }
    void fir()
    {
        if (bullet_stock < this_lev_bullet)
        {
            GameObject[] bull = GameObject.FindGameObjectsWithTag("Titel_show");
            Destroy(bull[0].gameObject);
            bullet_stock++;
            Vector2 directon = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - gunpoint.transform.position).normalized;
            GameObject g = Instantiate(prefrb, gunpoint.transform.position, Quaternion.identity);
            g.tag = "Bullet_tag";
            g.GetComponent<Rigidbody2D>().AddForce(directon * 1300);
            Destroy(g, 3f);
        }
        else if (press_add!=0)
        {
            GameObject BULL = Instantiate(goli_show_prefrb, full_show_holder.transform);
            BULL.tag = "Titel_show";
            this_lev_bullet++;
            press_add--;
            StartCoroutine(wait());
        }
        else {
            StartCoroutine(finish());
        }

    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        loss_scene.SetActive(false);
    }
    public void add_bullet_btn()
    {
        press_add++;
        Time.timeScale = 1f;
    }
    IEnumerator finish()
    {
        goli_finish_scene.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        goli_finish_scene.SetActive(false);
        yield return new WaitForSeconds(0.6f);
        loss_scene.SetActive(true);
    }
    public void restart_btn()
    {
        SceneManager.LoadScene(leval_list[level_no-1]);
    }
    public void home_btn()
    { 
        SceneManager.LoadScene("Level_Scene");
    }
}
