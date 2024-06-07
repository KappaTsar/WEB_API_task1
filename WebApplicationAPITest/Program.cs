using System;
using System.Net.Http.Headers;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();


//var url = new Uri("https://dummyapi.io/data/v1/user?page=1&limit=10");
//var head_value = "65eec7d4f88b2863bdc09cc1";

//var client = new HttpClient();
//client.BaseAddress = url;
// ACCEPT header
//client.DefaultRequestHeaders.Accept.Add(  new MediaTypeWithQualityHeaderValue("application/json"));

//- use "app-id" header with value "65eec7d4f88b2863bdc09cc1" to authenticate to dummy api
//- add possibility to override "app-id" header value through environment variables
//- - code must be testable, if we have time you should write unit tests for produced code


//var request = new HttpRequestMessage(HttpMethod.Get, url);
// CONTENT-TYPE header
//request.Headers.Add("app-id", head_value);
//request.Content = new StringContent("boomba");


//request.Headers["app-id"] = "65eec7d4f88b2863bdc09cc1";

//client.SendAsync(request).ContinueWith(responseTask =>     Console.WriteLine("Response: {0}", responseTask.Result));

//pp.MapGet("/", () => request.Content.ReadAsStringAsync());

app.Run();
