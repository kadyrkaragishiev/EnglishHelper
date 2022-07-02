using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace GameCore
{
    public class QuizLoader: MonoBehaviour
    {
        [SerializeField] 
        private TextAsset quizData;
        
        public async Task Load(Action<Quiz> quiz)
        {
            var client = new HttpClient() { BaseAddress = new Uri("https://api.jsonbin.io/b/62c0023c402a5b3802472753") };
            client.DefaultRequestHeaders.Add("secret-key", "$2b$10$YlTmqGjU.62rtLUzCDDLLu40olV6XXBi7V5OwXGL4TBYeFElQZ7T2");
            var dataService = new DataService(client);
            var item = await dataService.GetItemsAsync(); 
            Quiz t = JsonUtility.FromJson<Quiz>(item);
            quiz?.Invoke(t);
        }
        public void QuizLoad(Action<Quiz> quiz) => StartCoroutine(LoaderCallback(quiz));
        private IEnumerator LoaderCallback(Action<Quiz> quiz){
            Quiz t = JsonUtility.FromJson<Quiz>(quizData.text);
            quiz?.Invoke(t);
            yield return null;
        }
    }
    public class DataService 
    {
        private readonly HttpClient _httpClient;
        public DataService(HttpClient httpClient) => _httpClient = httpClient;
	
        public async Task<string> GetItemsAsync() {
            using HttpResponseMessage resp = await _httpClient.GetAsync("");
            var json = await resp.Content.ReadAsStringAsync();
            Debug.Log(json);
            return json;
        }
    }
}
