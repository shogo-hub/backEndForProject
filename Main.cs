using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

class Program{
    static void Main(string[] args){
        //Get data base usr and password from .env
        string dpUser = Settings.Env("DATABASE_USER");
        string dbPassword = Settings.Env("DATABASE_USER_PASSWORD");


        //Print values 
        Console.WriteLine($"Local database username: {dbUser}");

        //Hash password
        var passwordHasher = new PasswordHasher<object>();
        string hashedPassword = passwordHasher.HashPassword(null, dbPassword);
        Console.WriteLine($"Local database password (hashed): {hashedPassword}");

    }
}

