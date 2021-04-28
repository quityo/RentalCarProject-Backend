using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProfilImageService
    {
        
            IResult Add(ProfilImagesDto profilImage);
            IResult Update(ProfilImagesDto profilImage);
            IResult Delete(ProfilImagesDto profilImage);
            IDataResult<ProfilImage> Get(int profilImageId);
            IDataResult<List<ProfilImage>> GetAll();
            IDataResult<List<ProfilImage>> GetImagesByUserId(int userId);
            IResult DeleteByUserId(int userId);
        
    }
}
