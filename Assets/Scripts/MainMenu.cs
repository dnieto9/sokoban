using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame(){
    SceneManager.LoadSceneAsync("Level1");
   }

   public void Play1(){
    SceneManager.LoadSceneAsync("Level1");
   }

    public void Play2(){
    SceneManager.LoadSceneAsync("Level2");
   }

    public void Play3(){
    SceneManager.LoadSceneAsync("Level3");
   }




}
