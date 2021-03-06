﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteWork.Data
{
    public class Category
    {
        public Category()
        {
            Favorites = new HashSet<Favorite>();
            Commands = new HashSet<Command>();
        }
        [Key]
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string CategoryName { get; set; }
        [Required]
        public bool EnableModeRequired { get; set; }
        //анонимный вход на устройство, когда не требуется вводить пользователя, а лишь пароль
        [Required]
        public bool AnonymousLogin { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Command> Commands { get; set; }
    }
}
