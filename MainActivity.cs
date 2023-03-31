using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace AppXamarinWs
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            EditText txtId = FindViewById<EditText>(Resource.Id.txtId);
            EditText txtName = FindViewById<EditText>(Resource.Id.txtName);
            EditText textDescription = FindViewById<EditText>(Resource.Id.txtDescription);
            Button btnConsultar = FindViewById<Button>(Resource.Id.btnConsultar);

            //btnConsultar += BtnConsultar_click;

            string urlServicio = "https://jsonplaceholder.typicode.com/posts";

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
        }

        public void BtnConsultar_click(object sender, System.EventArgs e)
        {
            try
            {

            }
            catch
            {

            }
        }

    }

    public class Entrada
    {
        public Entrada()
        {
            userId = 1;
            id = 0;
            title = "";
            body = "";
        }
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }

    public class Cliente
    {
        public Cliente()
        {
            codigoHTTP = 200;
        }

        public int codigoHTTP { get; set; }

        //GET
        public async Task<T> Get<T>(string url)
        {
            HttpClient cliente = new HttpClient();
            var response = await cliente.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            codigoHTTP = (int)response.StatusCode;
            return JsonConvert.DeserializeObject<T>(json);
        }

        //POST

        public async Task<T> Post<T>(Entrada item, string url)
        {
            HttpClient cliente = new HttpClient();
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "aplication/json");

            HttpResponseMessage response = null;
            response = await cliente.PostAsync(url, content);
            json = await response.Content.ReadAsStringAsync();
            codigoHTTP = (int)response.StatusCode;
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}