using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserImageService
    {

        IResult Add(UserImageDto userImage);
        IResult Update(UserImageDto userImage);
        IResult Delete(UserImageDto userImage);
        IDataResult<UserImage> Get(int imageId);
        IDataResult<List<UserImage>> GetAll();
        IDataResult<List<UserImage>> GetImagesByUserId(int userId);
        IResult DeleteByUserId(int userId);
    }
}
