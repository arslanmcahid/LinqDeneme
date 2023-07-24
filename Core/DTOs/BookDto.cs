﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.DTOs
{
    public class BookDto
    {
        //public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}