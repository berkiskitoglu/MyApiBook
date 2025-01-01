using MyApiBook.DataAccessLayer.Abstract;
using MyApiBook.DataAccessLayer.Context;
using MyApiBook.DataAccessLayer.Repository;
using MyApiBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiBook.DataAccessLayer.EntityFramework
{
    public class EfSocialMediaDal : GenericRepositories<SocialMedia>, ISocialMediaDal
    {
        public EfSocialMediaDal(ApiContext context) : base(context)
        {
        }
    }
}
