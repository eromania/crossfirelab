using System.Data;
using CFL.Domain;
using Dapper;
using Microsoft.Data.SqlClient;
using RestSharp;

var n = 10;

var connectionString = "Server=localhost;Database=CflTestDb;User Id=CflLogin;Password=123!abc!; connection timeout=30;";
var sqlQuery = "INSERT INTO ExchangeRates (AssetId, QuoteId, Time, Rate, Created, CreatedBy, IsValid)" +
               "VALUES ('BTC', 'USD', @Time, @Rate, @Created, @CreatedBy, @IsValid)";

while (n >= 0)
{
    using (IDbConnection db = new SqlConnection(connectionString))
    {
        var client = new RestSharp.RestClient("https://rest.coinapi.io/v1/exchangerate/BTC/USD");
        var request = new RestSharp.RestRequest("", Method.Get);
        request.AddHeader("X-CoinAPI-Key", "3EF62006-EE89-4A49-AFA0-A57F09226CA5");
        var response = client.GetAsync<ExchangeRate>(request);


        var rowsAffected = db.Execute(sqlQuery, response.Result);
        if (rowsAffected > 0)
            Console.WriteLine($"price for BTC/USD :{response.Result.Rate.ToString()}");

        Thread.Sleep(10000);
        n--;
    }
}