using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int BoxScore=0,highScore;
    public int factorBox=0;
    [SerializeField]GameObject[] RGBboxes;
    GameObject BigBox;
    [SerializeReference]TextMeshProUGUI scoreText;
    void Start()
    {
        BigBox=GameObject.Find("BigBox");
        for (int i = 0; i < 30; i++)
        {
            startBox();
        }
        InvokeRepeating("spawnBox",5,0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(Time.timeScale==1){
                Time.timeScale=0;
            }
            else{
                Time.timeScale=1;
            }
        }
        scoreText.text="Score:"+BoxScore;
    }
    void spawnBox(){
        float newPoint=1.1f*factorBox;
        Vector2 RGBspawnPoint=new Vector2(-2.2f+newPoint,-4.45f);
        int RandomBox=Random.Range(0,3);
        Instantiate(RGBboxes[RandomBox],RGBspawnPoint,RGBboxes[RandomBox].transform.rotation,BigBox.transform);
        factorBox++;
        if(factorBox==5){
            StartCoroutine("goBrr");
            factorBox=0;
        }
    }
    void startBox(){
        float newPoint=1.1f*factorBox;
        Vector2 RGBspawnPoint=new Vector2(-2.2f+newPoint,-4.45f);
        int RandomBox=Random.Range(0,3);
        Instantiate(RGBboxes[RandomBox],RGBspawnPoint,RGBboxes[RandomBox].transform.rotation,BigBox.transform);
        factorBox++;
        if(factorBox==5){
            BigBox.transform.position+=new Vector3(0,1.1f,0);
            factorBox=0;
        }
    }
    IEnumerator goBrr(){
        yield return new WaitForSeconds(0.5f);
        BigBox.transform.position+=new Vector3(0,1.1f,0);
    }
    
}
