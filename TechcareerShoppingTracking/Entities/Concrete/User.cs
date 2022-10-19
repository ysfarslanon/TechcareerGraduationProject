﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int RoleId { get; set; }

       
        public virtual ICollection<ShoppingList> ShoppingLists { get; set; }
       
        public virtual Role Role { get; set; }

        public User(int roleId = 2)
        {
            RoleId = roleId;
        }

        public User(int id, string firstName, string lastName, string email, byte[] passwordHash, byte[] passwordSalt, int roleId = 2) : this(roleId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            
        }
    }
}
