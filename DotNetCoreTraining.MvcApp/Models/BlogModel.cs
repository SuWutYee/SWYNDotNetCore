﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreTraining.MvcApp.Models
{
    [Table("Tbl_Blog")]
    public class BlogModel
    {
        [Key]
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
    }

    [Table("Tbl_Chart")]
    public class ChartModel
    {
        [Key]
        public int Id { get; set; }
        public int TeamA { get; set; }
        public int TeamB { get; set; }
        public int TeamC { get; set; }
        public DateTime Label { get; set; }
    }

    [Table("Tbl_Pyramid")]
    public class PyramidModel
    {
        [Key]
        public int Id { get; set; }
        public int Series { get; set; }
        public string Color { get; set; }
        public string Category { get; set; }
    }

    public class BlogMessageResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
