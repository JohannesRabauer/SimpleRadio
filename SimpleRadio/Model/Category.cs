using SimpleRadio.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRadio.Model
{
    class Category : BaseModel
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }


        private String _title;

        public String title
        {
            get { return _title; }
            set { _title = value; }
        }

        private String _description;

        public String description
        {
            get { return _description; }
            set { _description = value; }
        }

        private String _slug;

        public String slug
        {
            get { return _slug; }
            set { _slug = value; }
        }
    }
}
