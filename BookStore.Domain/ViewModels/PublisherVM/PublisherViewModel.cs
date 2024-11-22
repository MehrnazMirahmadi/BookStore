using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.ViewModels.PublisherVM
{
    public class PublisherViewModel
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public int BookCount { get; set; }
    }
}
