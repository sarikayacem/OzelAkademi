using OzelAkademi.Business.Abstract;
using OzelAkademi.Data.Abstract;
using OzelAkademi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Business.Concrete
{
    public class ImageManager : IImageService
    {
        private IImageRepository _imageRepository;

        public ImageManager(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task CreateAsync(Image image)
        {
            await _imageRepository.CreateAsync(image);
        }

        public void Delete(Image image)
        {
            _imageRepository.Delete(image);
        }

        public async Task<List<Image>> GetAllAsync()
        {
            return await _imageRepository.GetAllAsync();
        }

        public async Task<Image> GetByIdAsync(int id)
        {
            return await _imageRepository.GetByIdAsync(id);
        }

        public int ImageCount(int advertId)
        {
            return _imageRepository.ImageCount(advertId);
        }

        public void Update(Image image)
        {
            _imageRepository.Update(image);
        }
    }
}
