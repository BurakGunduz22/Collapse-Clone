using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBox : MonoBehaviour
{
    Collider2D[] redBox;
    Collider2D[] redbox2;
    GameManager gameManager;
    private int numRed,numRed2;
    public GameObject bigObject;
    void Start()
    {
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
    
    }
    public void OnMouseEnter() {
        isRedNear();
    }
    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(0)){
            desRed();
        }
    }
    private void OnMouseExit(){
        RedExit();
    }
    public void isRedNear(){
        Debug.Log("Red");
        gameObject.tag="Red2";        
        redBox=Physics2D.OverlapBoxAll(transform.position,new Vector2(1f,1f),45);
        numRed=0;
        numRed2=0;
        if(GameObject.Find("BigC")==null){
            bigObject=new GameObject();
            bigObject.name="BigC";
            bigObject.transform.SetParent(GameObject.Find("BigBox").transform,true);
        }
        for (int i = 0; i < redBox.Length; i++)
        {
            if(redBox[i].gameObject.CompareTag("Red")){
               Debug.Log("Red 2");
               redbox2=new Collider2D[numRed+1];
               numRed++;
            }
        }
        for (int i = 0; i < redBox.Length; i++)
        {
            if(redBox[i].gameObject.CompareTag("Red")){
               redbox2[numRed2]=redBox[i];
               redbox2[numRed2].transform.SetParent(GameObject.Find("BigC").transform,true);
               redbox2[numRed2].gameObject.GetComponent<RedBox>().isRedNearSeq();
               numRed2++;
            }
        }
        gameObject.tag="Red";
        if(GameObject.Find("BigC").transform.childCount>1){
            gameObject.transform.SetParent(GameObject.Find("BigC").transform,true);
            for (int i = 0; i < numRed2; i++)
            {
                redbox2[i].transform.SetParent(GameObject.Find("BigC").transform,true);
                redbox2[i].tag="Red";
            }
            for (int i = 0; i <GameObject.Find("BigC").transform.childCount; i++)
            {
                GameObject.Find("BigC").transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color=new Color(1,0,0);
            }
            this.gameObject.GetComponent<SpriteRenderer>().color=new Color(1,0,0);
            gameObject.tag="Red";
        }
    }
    public void isRedNearSeq(){
        Debug.Log("Red");
        gameObject.tag="Red2";        
        redBox=Physics2D.OverlapBoxAll(transform.position,new Vector2(1f,1f),45);
        numRed=0;
        numRed2=0;
        for (int i = 0; i < redBox.Length; i++)
        {
            if(redBox[i].gameObject.CompareTag("Red")){
               Debug.Log("Red 2");
               redbox2=new Collider2D[numRed+1];
               numRed++;
            }
        }
        for (int i = 0; i < redBox.Length; i++)
        {
            if(redBox[i].gameObject.CompareTag("Red")){
               if(redBox[i].transform.parent==GameObject.Find("BigBox").transform){
                    redbox2[numRed2]=redBox[i];        
                    redbox2[numRed2].transform.SetParent(GameObject.Find("BigC").transform,true);
                    redbox2[numRed2].gameObject.GetComponent<RedBox>().isRedNearSeq();
                    numRed2++;
               }
            }
        }
        if(numRed2>0){
            gameObject.transform.SetParent(GameObject.Find("BigC").transform,true);
            for (int i = 0; i < numRed2; i++)
            {
                redbox2[i].transform.SetParent(GameObject.Find("BigC").transform,true);
                redbox2[i].tag="Red";
            }
            gameObject.tag="Red";
        }
    }

    public void RedExit(){
        if(GameObject.Find("BigC").transform.childCount>0){
        GameObject[] BluesBox = new GameObject[GameObject.Find("BigC").transform.childCount];
            for (int i = 0; i < GameObject.Find("BigC").transform.childCount; i++)
                {
                GameObject.Find("BigC").transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color=new Color(0.85f,0,0);
                GameObject.Find("BigC").transform.GetChild(i).gameObject.tag="Red";
                BluesBox[i]=GameObject.Find("BigC").transform.GetChild(i).gameObject;
                }
            gameObject.GetComponent<SpriteRenderer>().color=new Color(0.85f,0,0);
            GameObject.Find("BigC").transform.DetachChildren();
            for (int i = 0; i < BluesBox.Length; i++)
            {
                BluesBox[i].transform.SetParent(GameObject.Find("BigBox").transform,true);
            }
        }
    }
    public void desRed(){
        if(GameObject.Find("BigC").transform.childCount>1){
              Destroy(GameObject.Find("BigC"));  
        }
    }
}
