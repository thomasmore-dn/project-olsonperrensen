using Dapper;
using MySql.Data.MySqlClient;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


using var connection = new MySqlConnection("Server=mysql;Port=3306;Database=pets;Uid=Webuser;Pwd=Lab2021;");
var users = connection.Query<User>("SELECT * FROM users");
Console.WriteLine(string.Join(Environment.NewLine, users.Select(u => $"{u.naam}, " +
$"{u.email}, {u.zipcode}")));


app.Run();

public record User(System.Int32 user_id, System.String email, System.String password, System.String naam, System.String zipcode, System.String looking_for, System.Boolean can_advertise, System.Boolean isAdmin, System.Int32 warnings);



