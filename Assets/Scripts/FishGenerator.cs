using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public GameObject[] CommonFishs;
    public GameObject[] RareFishs;
    public GameObject[] EpicFishs;
    public GameObject[] WaveFishs;
    public GameObject Pike;
    // верхний и нижний пределы передвижения обычных рыб
    [SerializeField] float CommUpperLimit = -0.65f;
    [SerializeField] float CommLowerLimit = -4.55f;
    // верхний и нижний пределы передвижения редких рыб
    [SerializeField] float RareUpperLimit = -1f;
    [SerializeField] float RareLowerLimit = -4.52f;
    // верхний и нижний пределы передвижения эпических рыб
    [SerializeField] float EpicUpperLimit = -0.65f;
    [SerializeField] float EpicLowerLimit = -4.55f;

    // Время спавна обычных рыб
    [SerializeField][Tooltip("минимальное время спавна обычных рыб")] float Cmin = 1f;
    [SerializeField][Tooltip("максимальное время спавна обычных рыб")] float Cmax = 2f;
    // Время спавна редких рыб
    [SerializeField][Tooltip("минимальное время спавна редких рыб")] float Rmin =2f;
    [SerializeField][Tooltip("максимальное время спавна редких рыб")] float Rmax = 3f;
    // Время спавна эпических рыб
    [SerializeField] [Tooltip("минимальное время спавна эпических рыб")] float Emin = 3f;
    [SerializeField][Tooltip("максимальное время спавна эпических рыб")] float Emax = 4f;
    // Время спавна косяка рыб
    [SerializeField][Tooltip(" время спавна первой волны рыб")] float Wave1 = 3f;
    [SerializeField][Tooltip(" время спавна второй волны рыб")] float Wave2 = 4f;
    [SerializeField][Tooltip(" время спавна третьей волны рыб")] float Wave3 = 61f;
    // Время спавна хищника
    [SerializeField] float Pmin = 4f;
    [SerializeField] float Pmax = 5f;
    private bool Play = true;
    void Awake() => ManagerScene.StopGame+= StopGenerate;
    void Start()
    {
        StartCoroutine(createCommFish());
        StartCoroutine(createRareFish());
        StartCoroutine(createEpicFish());
        Invoke ("FishWave",Wave1);
        Invoke ("FishWave",Wave2);
        Invoke ("FishWave",Wave3); 
        StartCoroutine(createPike());
    }
    // Спавн рыб обычной редкости
      IEnumerator createCommFish()
    { if(Play)
      {
        yield return new WaitForSeconds (Random.Range (Cmin,Cmax));
        int common = Random.Range(0, CommonFishs.Length);
        GameObject fish = Instantiate(CommonFishs[common]); 
        bool rightFish = Random.Range(0,2) == 1;
        float y = Random.Range(CommLowerLimit,CommUpperLimit);
        float x;
        if(rightFish)
        {
          x = -10.6f;
          fish.GetComponent<fishmove>().movment.x = -0.5f;
          fish.GetComponent<Transform>().Rotate(0f,180f,0f);
        }
        else
        {
          x = 10.6f;
          fish.GetComponent<fishmove>().movment.x = 0.5f;
        }
        fish.GetComponent<Transform>().position = new Vector2(x,y);
        StartCoroutine(createCommFish());
      }   
    }
     // Спавн  редких рыб
    IEnumerator createRareFish()
    { if(Play)
      {
        yield return new WaitForSeconds (Random.Range (Rmin,Rmax));
        int rare = Random.Range(0, RareFishs.Length);
        GameObject fish = Instantiate(RareFishs[rare]); 
        bool rightFish = Random.Range(0,2) == 1;
        float y = Random.Range(RareLowerLimit,RareUpperLimit);
        float x;
        if(rightFish)
        {
          x = -10.6f;
          fish.GetComponent<fishmove>().movment.x = -0.5f;
          fish.GetComponent<Transform>().Rotate(0f,180f,0f);
        }
        else
        {
          x = 10.6f;
          fish.GetComponent<fishmove>().movment.x = 0.5f;
        }
        fish.GetComponent<Transform>().position = new Vector2(x,y);
        StartCoroutine(createRareFish());
      }
    }
    // Спавн  эпических рыб
    IEnumerator createEpicFish()
    { if(Play)
      { yield return new WaitForSeconds (Random.Range (Emin,Emax));
        int epic = Random.Range(0, EpicFishs.Length);
        GameObject fish = Instantiate(EpicFishs[epic]); 
        bool rightFish = Random.Range(0,2) == 1;
        float y = Random.Range(EpicLowerLimit,EpicUpperLimit);
        float x;
        if(rightFish)
        {
          x = -10.6f;
          fish.GetComponent<fishmove>().movment.x = -0.5f;
          fish.GetComponent<Transform>().Rotate(0f,180f,0f);
        }
        else
        {
          x = 10.6f;
          fish.GetComponent<fishmove>().movment.x = 0.5f;
        }
        fish.GetComponent<Transform>().position = new Vector2(x,y);
        StartCoroutine(createEpicFish());
      }
    }
    // Спавн  Щуки
    IEnumerator createPike()
    { if(Play)
      {
       yield return new WaitForSeconds (Random.Range(Pmin,Pmax));
       GameObject fish = Instantiate(Pike);
       bool rightFish = Random.Range(0,2) == 1;
        float y = Random.Range(-4.55f,-0.6f);
        float x;
        if(rightFish)
        {
          x = -10.6f;
          fish.GetComponent<fishmove>().movment.x = -0.5f;
          fish.GetComponent<Transform>().Rotate(0f,180f,0f);
        }
        else
        {
          x = 10.6f;
          fish.GetComponent<fishmove>().movment.x = 0.5f;
        }
        fish.GetComponent<Transform>().position = new Vector2(x,y);
        StartCoroutine(createPike());
      }
    } 
    // Создание косяка рыбы(ограничено 6 единицами)
     public void FishWave()
    { if(Play)
          foreach (GameObject WaveFish in WaveFishs)
         {
         GameObject fish = Instantiate(WaveFish);
         bool rightFish = Random.Range(0,2) == 1;
         float y = Random.Range(-4.55f,-0.65f);
         float x;
         if(rightFish)
          {
           x = -10.6f;
           fish.GetComponent<fishmove>().movment.x = -0.5f;
           fish.GetComponent<Transform>().Rotate(0f,180f,0f);
          }
          else
          {
           x = 10.6f;
           fish.GetComponent<fishmove>().movment.x = 0.5f;
          }
        fish.GetComponent<Transform>().position = new Vector2(x,y);
         } 
    }
      private void StopGenerate()
       {
         Play = false;
         ManagerScene.StopGame -= StopGenerate;
       }
        
      
     
}
