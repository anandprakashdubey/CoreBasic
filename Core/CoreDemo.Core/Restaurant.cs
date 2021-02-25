using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreDemo.Core
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*required")]
        public string Location { get; set; }
        public CusineType Cusine { get; set; }
    }
}
