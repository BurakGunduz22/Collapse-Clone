using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBox : MonoBehaviour
{
    Collider2D[] greenBox;
    Collider2D[] greenbox2;
    GameManager gameManager;
    private int numGreen,numGreen2;
    public GameObject bigObject;
    void Start()
    {
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
    
    }
    public void OnMouseEnter() {
        isGreenNear();
    }
    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(0)){
            desGreen();
        }
    }
    private void OnMouseExit(){
        GreenExit();
    }
    public void isGreenNear(){
        Debug.Log("Green");
        gameObject.tag="Green2";        
        greenBox=Physics2D.OverlapBoxAll(transform.position,new Vector2(1.25f,1.25f),90);
        numGreen=0;
        numGreen2=0;
        if(GameObject.Find("BigC")==null){
            bigObject=new GameObject();
            bigObject.name="BigC";
            bigObject.transform.SetParent(GameObject.Find("BigBox").transform,true);
        }
        for (int i = 0; i < greenBox.Length; i++)
        {
            if(greenBox[i].gameObject.CompareTag("Green")){
               Debug.Log("Green 2");
               greenbox2=new Collider2D[numGreen+1];
               numGreen++;
            }
        }
        for (int i = 0; i < greenBox.Length; i++)
        {
            if(greenBox[i].gameObject.CompareTag("Green")){
               greenbox2[numGreen2]=greenBox[i];
               greenbox2[numGreen2].gameObject.GetComponent<GreenBox>().isGreenNearSeq();
               numGreen2++;
            }
        }
        gameObject.transform.SetParent(GameObject.Find("BigC").transform,true);
        if(GameObject.Find("BigC").transform.childCount>2){
            for (int i = 0; i < numGreen2; i++)
            {
                greenbox2[i].GetComponent<SpriteRenderer>().color=new Color(0,1,0);
                greenbox2[i].transform.SetParent(GameObject.Find("BigC").transform,true);
                greenbox2[i].tag="Green";
            }
            this.gameObject.GetComponent<SpriteRenderer>().color=new Color(0,1,0);
            gameObject.tag="Green";
        }
    }
    public void isGreenNearSeq(){
        Debug.Log("Green");
        gameObject.tag="Green2";        
        greenBox=Physics2D.OverlapBoxAll(transform.position,new Vector2(1.25f,1.25f),90);
        numGreen=0;
        numGreen2=0;
        for (int i = 0; i < greenBox.Length; i++)
        {
            if(greenBox[i].gameObject.CompareTag("Green")){
               Debug.Log("Green 2");
               greenbox2=new Collider2D[numGreen+1];
               numGreen++;
            }
        }
        for (int i = 0; i < greenBox.Length; i++)
        {
            if(greenBox[i].gameObject.CompareTag("Green")){
               if(greenBox[i].transform.parent==null){
                    greenbox2[numGreen2]=greenBox[i];
                    greenbox2[numGreen2].gameObject.GetComponent<GreenBox>().isGreenNearSeq();
                    greenbox2[numGreen2].transform.SetParent(GameObject.Find("BigC").transform,true);
                    numGreen2++;
               }
            }
        }
        gameObject.transform.SetParent(GameObject.Find("BigC").transform,true);
        if(numGreen2>0){
            for (int i = 0; i < numGreen2; i++)
            {
                greenbox2[i].GetComponent<SpriteRenderer>().color=new Color(0,1,0);
                greenbox2[i].transform.SetParent(GameObject.Find("BigC").transform,true);
                greenbox2[i].tag="Green";
            }
            gameObject.GetComponent<SpriteRenderer>().color=new Color(0,1,0);
            gameObject.tag="Green";
        }
    }

    public void GreenExit(){
        if(GameObject.Find("BigC").transform.childCount>2){
        GameObject[] BluesBox = new GameObject[GameObject.Find("BigC").transform.childCount];    
            for (int i = 0; i < GameObject.Find("BigC").transform.childCount; i++)
            {
               GameObject.Find("BigC").transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color=new Color(0,0.75f,0);
               GameObject.Find("BigC").transform.GetChild(i).gameObject.tag="Green";
               BluesBox[i]=GameObject.Find("BigC").transform.GetChild(i).gameObject;
            }
            gameObject.GetComponent<SpriteRenderer>().color=new Color(0,0.75f,0);
        
            GameObject.Find("BigC").transform.DetachChildren();    
            for (int i = 0; i < BluesBox.Length; i++)
            {
            BluesBox[i].transform.SetParent(GameObject.Find("BigBox").transform,true);
            }
        }
    }
    public void desGreen(){
        if(GameObject.Find("BigC").transform.childCount>1){
              Destroy(GameObject.Find("BigC"));  
        }
    }
}
