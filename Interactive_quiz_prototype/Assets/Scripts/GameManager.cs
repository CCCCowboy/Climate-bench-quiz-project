using UnityEngine; 
using System.Collections.Generic;
using Unity.VisualScripting;


public class GameManager : MonoBehaviour
{
    //Writer script for changing text and images in UI elements
    public Writer writer;

    //UI transforms
    public Transform QuizUI;
    public Transform FunFactUI;
    public Transform personalityUI;
    public Transform resultUI;
    public Transform startUI;
    public Transform LevelUpUI;
    public Transform contactUI;

    //Questions
    public Transform questions; //Reference to parent transform of questions
    public List<Question> qList; //List of questions
    public int numberOfQuestions; //Number of questions in the quiz
    public int index = 0; //Current question
    public int finalQuestion; //Index of last question

    //Answers and score
    public List<float> aList; //List of answers 
    public float totalScore; //total score
    public float averageScore; //The average score, ccalculated at the end
    
    private bool firstTime = true; //Guard to prevent populating lists more than once

    //Fun facts
    public Transform funFacts;
    public List<Fact> fList;
    public int numberOfFacts;
    public int factIndex = 0;

    //Personalities
    public Transform personalities;
    public List<Personality> pList;




    public void Begin (){ //This replaces Start function an is called when player presses "take quiz" button
        startUI.gameObject.SetActive(false);
        QuizUI.gameObject.SetActive(true);
        if (firstTime){
            Initialize();
        }

        writer.Question();

        /*Debug.Log("number of questions in this quiz: " + numberOfQuestions);
        Debug.Log("Question index 0 title: " + qList[0].title);
        Debug.Log("Question index 1 title: " + qList[1].title);
        Debug.Log("Question index 2 title: " + qList[2].title);
        Debug.Log("Nubmer of answers to this quiz: "+ aList.Count);*/

    }
    private void Initialize(){
        //Questions
        foreach (Transform question in questions){
            qList.Add(question.GetComponent<Question>()); //Adds a direct reference to each Question component found under question transform to the question list
            aList.Add(0); //Adds an answer of 0 to the answer list for each question in the question list
        }

        numberOfQuestions = qList.Count; /*Number of questions in the quiz should be the same as the amount of questions in the question list*/
        finalQuestion = numberOfQuestions -1;

        //Facts
        foreach (Transform funFact in funFacts){
            fList.Add(funFact.GetComponent<Fact>());
        }
        numberOfFacts = fList.Count;

        //Personalities
        foreach (Transform personality in personalities){
            pList.Add(personality.GetComponent<Personality>());
        }

        firstTime = false;
    }
    public void Progress(){
        if (index == finalQuestion){
        QuizUI.gameObject.SetActive(false);
        resultUI.gameObject.SetActive(true);
        writer.FunFact();
          return;
        }

        else {
          index++; 
          writer.Question();
          Debug.Log("Index = " + index);
        }
    }

    //Go back to previous question
    public void Return(){
        if (index == 0){//return to menu
        QuizUI.gameObject.SetActive(false);
        startUI.gameObject.SetActive(true); 
        return;
        }
        resultUI.gameObject.SetActive(false);
        QuizUI.gameObject.SetActive(true);
        index--;
        aList[index] = 0; //Remove score from question
        writer.Question();
        Debug.Log("Index = " + index);
    }

    public void NextFact(){
        if (factIndex == (numberOfFacts-1)){
            EndGame();
            return;
        }
        factIndex++;
        writer.FunFact();

    }

    public void PreviousFact(){
        if (factIndex == 0){//return to results
        FunFactUI.gameObject.SetActive(false);
        resultUI.gameObject.SetActive(true); 
        return;
        }
        personalityUI.gameObject.SetActive(false);
        FunFactUI.gameObject.SetActive(true);
        factIndex--;
        writer.FunFact();
    }

    public void BackToFacts(){
        personalityUI.gameObject.SetActive(false);
        FunFactUI.gameObject.SetActive(true);
        writer.FunFact();

    }

    public void StartFunFact(){
        resultUI.gameObject.SetActive(false);
        FunFactUI.gameObject.SetActive(true);
        factIndex = 0;
        writer.FunFact();
    }

    public void LevelUp(){
        personalityUI.gameObject.SetActive(false);
        LevelUpUI.gameObject.SetActive(true);
        contactUI.gameObject.SetActive(false);


    }

    public void Contact(){
        contactUI.gameObject.SetActive(true);
        LevelUpUI.gameObject.SetActive(false);
    }

    //Calculate score and give result
    public void EndGame(){
        LevelUpUI.gameObject.SetActive(false);
        FunFactUI.gameObject.SetActive(false);
        personalityUI.gameObject.SetActive(true);
        totalScore = 0;
        foreach (int score in aList){
        //Debug.Log("Each question score " + score);
        totalScore += score;
        }
        //Debug.Log("Total score" + totalScore);
        Debug.Log("Total score" + totalScore);
        averageScore = Mathf.Round(totalScore/numberOfQuestions);
        Debug.Log("Average score" + averageScore);

        switch(averageScore) 
        {
        case 1:
            writer.Personality(0);
            break;
        case 2:
            writer.Personality(1);
            break;
        case 3:
            writer.Personality(2);
            break;
        case 4:
            writer.Personality(3);
            break;
        default:
            break;
        }
    }



    //Scoring functions
    public void A (){
        aList[index] = 1;
        Progress();
    }
    public void B (){
        aList[index] = 2;
        Progress();
    }

    public void C (){
        aList[index] = 3;
        Progress();
    }

    public void D (){
        aList[index] = 4;
        Progress();
    }
}
