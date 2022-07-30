using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface Icourseservice
    {
        public List<course1_api> getallcourse();

        public bool createinsertcourse(course1_api course);

        public bool deletecourse(int id);
        public double Price();
        public List<course1_api> Lastrecords();
        public List<course1_api> Orderby();
    }
}
