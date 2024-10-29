using MauiApp1.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MauiApp1.ViewModels;

namespace MauiApp1.Services
{
    public class APIService
    {
        private HttpClient client;
        private string baseUrl;
        public static string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://bszjflq2-5045.uks1.devtunnels.ms/api/" : "http://localhost:5045/api/";
        private static string ImageBaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://bszjflq2-5045.uks1.devtunnels.ms/" : "http://localhost:5045";

        public APIService()
        {
            //Set client handler to support cookies!!
            // יצירת אובייקט בשם HANDLER
            // שהוא מסוג מחלקה מובנית של C
            HttpClientHandler handler = new HttpClientHandler();
            // הוספת תמיכה בCOOKIES 
            handler.CookieContainer = new System.Net.CookieContainer();

            // הגדרת אובייקט הלקוח של המחלקה כאובייקט מסוג HTTPCLIENT שתומך בעוגיות
            this.client = new HttpClient(handler);
            // הגדרת הנתיב אל השרת
            this.baseUrl = BaseAddress;
        }
        
        public async Task<bool> Register(User user)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUrl}Register";
            try
            {
                //Call the server API
                string json = JsonSerializer.Serialize(user);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                  /*  JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    User? result = JsonSerializer.Deserialize<User>(resContent, options);*/
                    
                    return resContent == "true";
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<User?> Login(LoginInfo userInfo)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUrl}login";
            try
            {
                //Call the server API
                string json = JsonSerializer.Serialize(userInfo);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    User? result = JsonSerializer.Deserialize<User>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<User>?> GetAllUsers()
        {
            // הגדרת כתובת URL לפונקציה ה-API
            string url = $"{this.baseUrl}GetAllUsers";
            try
            {
                // קריאה לשרת ה-API
                HttpResponseMessage response = await client.GetAsync(url);
                // בדיקת סטטוס התגובה
                if (response.IsSuccessStatusCode)
                {
                    // שליפת התוכן כמחרוזת
                    string resContent = await response.Content.ReadAsStringAsync();
                    // המרת התוצאה לרשימה של משתמשים
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    List<User>? result = JsonSerializer.Deserialize<List<User>>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<bool> DeleteUserByEmail(string email)
        {
            // הגדרת URL לפונקציה בשרת
            string url = $"{this.baseUrl}deleteUserByEmail/{email}";

            try
            {
                // קריאה לשרת ה-API
                HttpResponseMessage response = await client.DeleteAsync(url);

                // בדיקת סטטוס התגובה
                if (response.IsSuccessStatusCode)
                {
                    // אם התגובה מוצלחת, המשתמש נמחק
                    return true;
                }
                else
                {
                    // אם יש בעיה, מחזירים false
                    return false;
                }
            }
            catch (Exception ex)
            {
                // טיפול בשגיאות
                Console.WriteLine($"Error deleting user: {ex.Message}");
                return false;
            }
        }

        public async Task<User?> GetCurrentUser()
        {
            // הגדרת כתובת URL לפונקציה ה-API
            string url = $"{this.baseUrl}getCurrentUser";

            try
            {
                // קריאה לשרת ה-API
                HttpResponseMessage response = await client.GetAsync(url);
                // בדיקת סטטוס התגובה
                if (response.IsSuccessStatusCode)
                {
                    // שליפת התוכן כמחרוזת
                    string resContent = await response.Content.ReadAsStringAsync();
                    // המרת התוצאה למשתמש
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    User? result = JsonSerializer.Deserialize<User>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            // הגדרת URL לפונקציה ה-API
            string url = $"{this.baseUrl}updateUser";

            try
            {
                // קריאה לשרת ה-API
                string json = JsonSerializer.Serialize(user);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);

                // בדיקת סטטוס התגובה
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
                return false;
            }
        }



    }
}
