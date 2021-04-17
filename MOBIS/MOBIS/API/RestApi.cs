using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using MOBIS.Models;
using Xamarin.Forms.Internals;

namespace MOBIS.API
{
    public class RestApi
    {
        public class ContenListParams
        {
            public int UserId { get; set; }

            public string Type { get; set; }
        }

        public class ContentLoadParams
        {
            public string Id { get; set; }
        }

        public const bool Local = true;

        public static List<User> Users { get; set; } = new List<User>()
        {
            new User("uzivatel@v.cz", "") {Exists = true, Workplace = "Praha", Role = "Běžný uživatel", Id = 1},
            new User("editor@v.cz", ""){Exists = true, Workplace = "Praha", Role = "Editor", Id = 2},
            new User("admin@v.cz", ""){Exists = true, Workplace = "Praha", Role = "Admin", Id = 3},
            new User("superadmin@v.cz", ""){Exists = true, Workplace = "Praha", Role = "SuperAdmin", Id = 4}
        };

        public static List<Paper> Content { get; set; } = new List<Paper>()
        {
            new Paper()
            {
                Id = 1, Type = "Novinka", Title = "Nové jízdní řády", Workplace = "Praha", Category = "Oznámení",
            },
            new Paper()
            {
                Id = 2, Type = "Novinka", Title = "Zaměstnanecké karty", Workplace = "Rakovník", Category = "Oznámení",
            },
            new Paper()
            {
                Id = 3, Type = "Novinka", Title = "Státní podpora", Workplace = "Humpolec", Category = "Oznámení",
            },
            new Paper()
            {
                Id = 4, Type = "Informace", Title = "Shrnutí za rok 2020", Workplace = "Vše", Category = "Důležité",
            },
            new Paper()
            {
                Id = 5, Type = "Informace", Title = "Obědy zdarma", Workplace = "Praha", Category = "Důležité",
            },
        };

        public static string Post(string url, string jsonData, out bool ok)
        {
            ok = Local;

            if (!Local)
            {
                var request = WebRequest.Create("http://10.0.0.5/" + url);
                request.Method = "POST";
                byte[] byteArray = Encoding.UTF8.GetBytes(jsonData);
                request.ContentType = "application/json";
                request.ContentLength = byteArray.Length;
                var reqStream = request.GetRequestStream();
                reqStream.Write(byteArray, 0, byteArray.Length);

                var response = request.GetResponse();
                ok = ((HttpWebResponse) response).StatusCode == HttpStatusCode.OK;

                var respStream = response.GetResponseStream();

                var reader = new StreamReader(respStream);
                string data = reader.ReadToEnd();
                return data;
            }
            else
            {
                if (url == "user/login")
                {
                    var user = JsonSerializer.Deserialize<User>(jsonData);
                    if (Users.Any(u => u.Email == user.Email))
                    {
                        return JsonSerializer.Serialize(Users.First(u => u.Email == user.Email));
                    }
                    else
                    {
                        return JsonSerializer.Serialize(new User(){Exists = false});
                    }
                }
                else if (url == "content/list")
                {
                    var data = new List<Paper>();
                    var obj = JsonSerializer.Deserialize<ContenListParams>(jsonData);

                    foreach (var paper in Content)
                    {
                        if (paper.Workplace == User.Current.Workplace || paper.Workplace == "Vše" ||
                            (User.Current.Role != "Běžný uživatel" && User.Current.Role != "Editor") &&
                            paper.Type == obj.Type)
                        {
                            data.Add(paper);
                        }
                    }

                    return JsonSerializer.Serialize(data);
                }
                else if (url == "content/load")
                {
                    var obj = JsonSerializer.Deserialize<ContentLoadParams>(jsonData);
                    return JsonSerializer.Serialize(Content.First(p => p.Id.ToString() == obj.Id));
                }
                else if (url == "content/update")
                {
                    var obj = JsonSerializer.Deserialize<Paper>(jsonData);
                    var index = Content.IndexOf(p => p.Id == obj.Id);
                    Content[index] = obj;
                }
            }

            return "";
        }
    }
}
