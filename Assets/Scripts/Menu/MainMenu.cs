using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   [SerializeField] private GameObject levelSelect;

   public void PlayGame()
   {
      levelSelect.SetActive(true);
   }
   
   public void GoBack()
   {
      levelSelect.SetActive(false);
   }


   public void PlayLevel(int levelIndex)
   {
      SceneManager.LoadScene(levelIndex);
   }

}
