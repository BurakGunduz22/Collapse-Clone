using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBox : MonoBehaviour
{
    Collider2D[] blueBox;
    Collider2D[] bluebox2;
    GameManager gameManager;
    private int numBlue,numBlue2;
    public GameObject bigObject;
    void Start()
    {
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
    
    }
    public void OnMouseEnter() {
        isBlueNear();
    }
    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(0)){
            desBlue();
        }
    }
    private void OnMouseExit(){
        blueExit();
    }
    public void isBlueNear(){
        Debug.Log("Blue");
        gameObject.tag="Blue2";        
        blueBox=Physics2D.OverlapBoxAll(transform.position,new Vector2(1f,1f),45);
        numBlue=0;
        numBlue2=0;
        if(GameObject.Find("BigC")==null){
            bigObject=new GameObject();
            bigObject.name="BigC";
            bigObject.transform.SetParent(GameObject.Find("BigBox").transform,true);
        }
        for (int i = 0; i < blueBox.Length; i++)
        {
            if(blueBox[i].gameObject.CompareTag("Blue")){
               Debug.Log("Blue 2");
               bluebox2=new Collider2D[numBlue+1];
               numBlue++;
            }
        }
        for (int i = 0; i < blueBox.Length; i++)
        {
            if(blueBox[i].gameObject.CompareTag("Blue")){
               bluebox2[numBlue2]=blueBox[i];
               bluebox2[numBlue2].transform.SetParent(GameObject.Find("BigC").transform,true);
               bluebox2[numBlue2].gameObject.GetComponent<BlueBox>().isBlueNearSeq();
               numBlue2++;
            }
        }
        Debug.Log(GameObject.Find("BigC").transform.childCount);
        gameObject.tag="Blue";
        if(GameObject.Find("BigC").transform.childCount>1){
            gameObject.transform.SetParent(GameObject.Find("BigC").transform,true);
            for (int i = 0; i < numBlue2; i++)
            {
                bluebox2[i].tag="Blue";
            }
            for (int i = 0; i <GameObject.Find("BigC").transform.childCount; i++)
            {
                GameObject.Find("BigC").transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color=new Color(0,0.454902f,1);
            }
            this.gameObject.GetComponent<SpriteRenderer>().color=new Color(0,0.454902f,1);
            gameObject.tag="Blue";
        }
    }
    public void isBlueNearSeq(){
        Debug.Log("Blue");
        gameObject.tag="Blue2";        
        blueBox=Physics2D.OverlapBoxAll(transform.position,new Vector2(1f,1f),45);
        numBlue=0;
        numBlue2=0;
        for (int i = 0; i < blueBox.Length; i++)
        {
            if(blueBox[i].gameObject.CompareTag("Blue")){
               Debug.Log("Blue 2");
               bluebox2=new Collider2D[numBlue+1];
               numBlue++;
            }
        }
        for (int i = 0; i < blueBox.Length; i++)
        {
            if(blueBox[i].gameObject.CompareTag("Blue")){
               if(blueBox[i].transform.parent=GameObject.Find("BigBox").transform){
                    bluebox2[numBlue2]=blueBox[i];
                    bluebox2[numBlue2].transform.SetParent(GameObject.Find("BigC").transform,true);
                    bluebox2[numBlue2].gameObject.GetComponent<BlueBox>().isBlueNearSeq();
                    numBlue2++;
               }
            }
        }
        if(numBlue2>0){
            for (int i = 0; i < numBlue2; i++)
            {
                bluebox2[i].tag="Blue";
            }
            gameObject.tag="Blue";
        }
    }
    public void blueExit(){
        if(GameObject.Find("BigC").transform.childCount>0){
        GameObject[] BluesBox = new GameObject[GameObject.Find("BigC").transform.childCount];
            for (int i = 0; i < GameObject.Find("BigC").transform.childCount; i++)
            {
               GameObject.Find("BigC").transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color=new Color(0,0.03529412f,1);
               GameObject.Find("BigC").transform.GetChild(i).gameObject.tag="Blue";
               BluesBox[i]=GameObject.Find("BigC").transform.GetChild(i).gameObject;
            }
            gameObject.GetComponent<SpriteRenderer>().color=new Color(0,0.03529412f,1);
            GameObject.Find("BigC").transform.DetachChildren();
            for (int i = 0; i < BluesBox.Length; i++)
            {
               BluesBox[i].transform.SetParent(GameObject.Find("BigBox").transform,true);
            }
        }
    }
    public void desBlue(){
        if(GameObject.Find("BigC").transform.childCount>1){
              Destroy(GameObject.Find("BigC"));  
        }
    }
}
