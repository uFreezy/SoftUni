using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Battleships.Client
{
    internal class Client
    {
        // private static string _authToken = "";

        private static void Main()
        {
            const string url = "http://localhost:62859";

            var httpClient = new HttpClient();

            using (httpClient)
            {
                while (true)
                {
                    var operation = Console.ReadLine();

                    switch (operation.Split(' ')[0])
                    {
                        case "register":
                            RegisterUser(httpClient, url, operation);
                            break;
                        case "login":
                            LoginUser(httpClient, url, operation);
                            break;
                        case "create-game":
                            CreateGame(httpClient, url);
                            break;
                        case "join-game":
                            JoinGame(httpClient, url, operation);
                            break;
                        case "play":
                            Play(httpClient, url, operation);
                            break;
                        case "exit":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Unrecognised command.");
                            break;
                    }
                }
            }
        }

        private static async Task RegisterUser(HttpClient httpClient, string url, string operation)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Email", operation.Split(' ')[1]),
                new KeyValuePair<string, string>("Password", operation.Split(' ')[2]),
                new KeyValuePair<string, string>("ConfirmPassword", operation.Split(' ')[3])
            });

            var response = await httpClient.PostAsync(url + "/api/account/register", content);

            Console.WriteLine(!response.IsSuccessStatusCode
                ? response.Content.ReadAsStringAsync().Result
                : "Registration successful!");
        }

        private static async Task LoginUser(HttpClient httpClient, string url, string operation)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Username", operation.Split(' ')[1]),
                new KeyValuePair<string, string>("Password", operation.Split(' ')[2]),
                new KeyValuePair<string, string>("grant_type", "password")
            });

            var response = await httpClient.PostAsync(url + "/token", content);

            Console.WriteLine(!response.IsSuccessStatusCode
                ? response.Content.ReadAsStringAsync().Result
                : "Successfully logged!");

            var result = await response.Content.ReadAsStringAsync();

            var googleSearch = JObject.Parse(result);

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + googleSearch["access_token"]);
            ;
        }

        private static async Task CreateGame(HttpClient httpClient, string url)
        {
            var response = await httpClient.PostAsync(url + "/api/games/create", null);

            Console.WriteLine(!response.IsSuccessStatusCode
                ? response.Content.ReadAsStringAsync().Result
                : "Game created successfully!");
        }

        private static async Task JoinGame(HttpClient httpClient, string url, string operation)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("GameId", operation.Split(' ')[1])
            });

            var response = await httpClient.PostAsync(url + "/api/games/join", content);

            Console.WriteLine(!response.IsSuccessStatusCode
                ? response.Content.ReadAsStringAsync().Result
                : "Successfully joined game!");
        }

        private static async Task Play(HttpClient httpClient, string url, string operation)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("GameId", operation.Split(' ')[1]),
                new KeyValuePair<string, string>("PositionY", operation.Split(' ')[2]),
                new KeyValuePair<string, string>("PositionX", operation.Split(' ')[3])
            });

            var response = await httpClient.PostAsync(url + "/api/games/play", content);

            Console.WriteLine(!response.IsSuccessStatusCode
                ? response.Content.ReadAsStringAsync().Result
                : "Success!");
        }
    }
}