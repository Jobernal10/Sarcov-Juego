using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_script : MonoBehaviour
{
  
  public void iniciarPartida(){
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

  }
}
