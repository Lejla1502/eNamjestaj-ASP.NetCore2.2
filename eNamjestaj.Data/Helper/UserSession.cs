﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Data.Helper
{
    public class User
    {
        public string Username { get; set; }
    }

    public interface IUserSession
    {
        User User { get; }
    }

    public class UserSession:IUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public User User => _httpContextAccessor.HttpContext.Session.GetObjectFromJson<User>("korisnik");

        //public Korisnik Korisnik => throw new NotImplementedException();
    }

    public static class SessionExtensions
{
    public static User GetObjectFromJson<User>(
        this ISession sesson, string json) where User : new()
    {
        return new User(); // Dummy extension method just to test OP's code
    }
}
}
