using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Realms;

namespace MuseumFusion.Model;

public class User : RealmObject
{
    [PrimaryKey]
    [MapTo("_id")]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    [MapTo("name")]
    [Required]
    public string Name { get; set; }

    [MapTo("email")]
    [Required]
    public string Email { get; set; }

    [MapTo("password")]
    [Required]
    public string Password { get; set; }

    [MapTo("is_admin")]
    public bool IsAdmin { get; set; }
}

