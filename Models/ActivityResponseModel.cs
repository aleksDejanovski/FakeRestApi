using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeRestApiTest.Models
{
    public class ActivityResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DueDate { get; set; }
        public bool Completed { get; set; }
    }
}
