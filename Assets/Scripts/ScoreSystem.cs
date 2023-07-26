using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

    public class ScoreSystem : MonoBehaviour {
        public static ScoreSystem instance { get; private set; }
        public int score;
        public int highScore;

        /*public TextMeshProUGUI scoreText;
        public TextMeshProUGUI scoreText2;
        public TextMeshProUGUI highScoreText;*/

         void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }

        private void Start()
        {
            ResetScore();
        }

        
        public int AddScore(int amount) {
            score += amount;
            PlayerPrefs.SetInt("score",score);
            if (score > highScore) {
                highScore = score;
                PlayerPrefs.SetInt("highScore",highScore);
                //highScoreText.text = "" + highScore;
            }

            return score;

            /* scoreText.text = "" + score;
             scoreText2.text = "Your Score: " + score;
             scoreText.transform.DOScale(1.5f, 0.1f).OnComplete(() => {
                 scoreText.transform.DOScale(1f, 0.1f);
             });*/
        }
        
        public void RemoveScore(int amount) {
            score -= amount;
            PlayerPrefs.SetInt("score",score);
            if (score < 0) score = 0;
            
           // scoreText.text = "" + score ;
            //scoreText2.text = "Your Score: " + score;
        }
        
        public void ResetScore() {
            score = PlayerPrefs.GetInt("score", 0);
            highScore =PlayerPrefs.GetInt("highScore", 0);
            /*scoreText.text = score+"";
            highScoreText.text = highScore+"";
            scoreText2.text = "Your Score: "+score;*/
        }
        
        


    }
