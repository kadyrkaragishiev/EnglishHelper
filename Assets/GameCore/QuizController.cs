using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

namespace GameCore
{
    public class QuizController : MonoBehaviour
    {
        // [SerializeField]
        // private Quiz _scriptableQuiz;

        [SerializeField]
        private QuizLoader _loader;

        private Quiz _currentQuiz;

        [SerializeField]
        private QuestionView _questionView;

        private int _currentProgress = -1;

        [SerializeField]
        private TextMeshProUGUI scoreText;

        private int _score;

        private int _scoreToAdd
        {
            get => _score;
            set
            {
                _score = value;
                scoreText.text = _score.ToString() + "/" + _currentQuiz.questions.Count + "\n" +
                                 "Пройдено вопросов: " + _currentProgress + "/" + _currentQuiz.questions.Count;
            }
        }

        private async void Start() =>
            await _loader.Load((quiz =>
            {
                _currentQuiz = quiz;
                Shuffle(_currentQuiz.questions);
                ChangeQuestion();
            }));

        public void ChangeQuestion()
        {
            _currentProgress++;
            if (_currentProgress >= _currentQuiz.questions.Count - 1)
            {
                SceneManager.LoadScene(0);
                return;
            }

            _scoreToAdd = _score;

            _questionView.ChangeQuestion(_currentQuiz.questions[_currentProgress]);
        }

        public void ChangeAnswer() => _questionView.ChangeAnswer(_currentQuiz.questions[_currentProgress]);
        private static Random _rng = new Random();

        public void UpdateScore() => _scoreToAdd++;

        public static void Shuffle<T>(IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = _rng.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }
    }
}
