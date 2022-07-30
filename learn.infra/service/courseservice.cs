using learn.core.Data;
using learn.core.Repository;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class courseservice : Icourseservice
    {
        private readonly ICourserepository courserepository;
        public courseservice(ICourserepository courserepository)
        {
            this.courserepository = courserepository;
        }
        public bool deletecourse(int id)
        {
            return courserepository.deletecourse(id);
        }

        public List<course1_api> getallcourse()
        {
            return courserepository.getallcourse();
        }

        public bool createinsertcourse(course1_api course)
        {
            return courserepository.createinsertcourse(course);
        }

        public double Price()
        {
            return courserepository.Price();
        }
        public List<course1_api> Lastrecords()
        {
            return courserepository.Lastrecords();
        }

        public List<course1_api> Orderby()
        {
            return courserepository.Orderby();
        }

        //public bool updatecourse(course1_api course)
        //{
        //    return courserepository.updatecourse(course);
        //}
    }
}
