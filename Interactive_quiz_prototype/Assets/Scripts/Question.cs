using UnityEngine;

public class Question : MonoBehaviour
{
        [Header("Title of question")]
        public string title;

        [Header("Question text")]
        public string question;
        
        [Header("Answers A,B,C,D")]
        public string[] answers = {"","","",""};
}
