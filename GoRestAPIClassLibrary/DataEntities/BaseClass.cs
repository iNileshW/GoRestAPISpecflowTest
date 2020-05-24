using System;
using System.Collections.Generic;
using System.Text;

namespace GoRestAPITesting.DataEntities
{
    public class BaseClass
    {
        public static readonly string baseURL = "https://gorest.co.in/public-api/";
        public static readonly string MyToken = "XTyKB6-Pr-Fk11uNOwDwFov-t75MXK2URWUE";
        public readonly string usersEndPoint = "users";
        public readonly string postsEndPoint = "posts";
        public readonly string commentsEndPoint = "comments";
        public readonly string albumsEndPoint = "albums";
        public readonly string photosEndPoint = "photos";
        public readonly int firstId = 1454;
        public readonly int lastId = 1506;
        public readonly string userCount = "2027";
        //public readonly string xmlCount = "2027";
    }
}
