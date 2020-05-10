using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeChallenge.Models
{
    public class AsciiForm
    {
        [Required]
        public HttpPostedFileBase AsciiMap { get; set; }
    }
}