using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationPractice.ViewModels
{
    public class Post_Integer
    {
        public Post_Integer(List<RegistrationPractice.Entities.Item> Items, int Post_index_start)
        {
            items = Items;
            post_index_start = Post_index_start;
        }
        public List<RegistrationPractice.Entities.Item> items;
        public int post_index_start;
    }

    public class applepie
    {

    }
}