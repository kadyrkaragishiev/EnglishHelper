using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameCore
{
    public class QuestionView:MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI questionText;

        [SerializeField]
        private GameObject CheckButton;
        
        [SerializeField]
        private GameObject NextButton;

        public void ChangeQuestion(Question question)
        {
            questionText.text = question.QuestionText;
            CheckButton.SetActive(true);
            NextButton.SetActive(false);
        } 

        public void ChangeAnswer(Question question)
        {
            questionText.text = question.AnswerText;
            CheckButton.SetActive(false);
            NextButton.SetActive(true);
        } 
    }
}
