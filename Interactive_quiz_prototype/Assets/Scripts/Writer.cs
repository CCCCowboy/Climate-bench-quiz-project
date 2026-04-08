using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Writer : MonoBehaviour
{
  public GameManager gameManager;

  /*References to each respective UI element of question UI*/
  public TextMeshProUGUI questionTitle;
  public TextMeshProUGUI questionText;
  public TextMeshProUGUI buttonA;
  public TextMeshProUGUI buttonB;
  public TextMeshProUGUI buttonC;
  public TextMeshProUGUI buttonD;

  /*References to each respective UI element of Fun Fact UI*/
  public TextMeshProUGUI funFactTitle;
  public TextMeshProUGUI funFactText;

  /*References to each respective UI element of Personality UI*/
  public TextMeshProUGUI personalityTitle;
  public TextMeshProUGUI personalityText;
  public TextMeshProUGUI energy;
  public Transform personalityImageTransform;
  public Image personalityImage;
  public Sprite personalityImageSprite;

  /*References to each respective UI element of levelup UI*/
  public TextMeshProUGUI tip;
  public TextMeshProUGUI howTo;
  public TextMeshProUGUI mission;

  
  public void Question(){
      //Replaces each UI elememnt text with that of the text from the current question from the Index
      questionTitle.text = gameManager.qList[gameManager.index].title + " of " + gameManager.numberOfQuestions;
      questionText.text = gameManager.qList[gameManager.index].question;
      buttonA.text = gameManager.qList[gameManager.index].answers[0];
      buttonB.text = gameManager.qList[gameManager.index].answers[1];
      buttonC.text = gameManager.qList[gameManager.index].answers[2];
      buttonD.text = gameManager.qList[gameManager.index].answers[3];
  }

  public void FunFact(){
      funFactTitle.text = gameManager.fList[gameManager.factIndex].title + " of " + gameManager.numberOfFacts;
      funFactText.text = gameManager.fList[gameManager.factIndex].fact;

  }
  
  public void Personality(int index){
      personalityImage = personalityImageTransform.GetComponent<Image>();
      personalityImageSprite = gameManager.pList[index].character;
      personalityImage.sprite = personalityImageSprite;
      personalityText.text = gameManager.pList[index].description;
      personalityTitle.text = gameManager.pList[index].title;
      energy.text = gameManager.pList[index].energy;
      tip.text = gameManager.pList[index].tip;
      howTo.text = gameManager.pList[index].levelUp;
      mission.text = gameManager.pList[index].mission;


  }

}