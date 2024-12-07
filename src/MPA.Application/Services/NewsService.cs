using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MPA.DTOs;
using MPA.Entities;
using MPA.EntityFrameworkCore;
using MPA.Handlers;

namespace MPA.Services
{
    public class NewsService : MPAAppServiceBase 
    {
        private readonly IRepository<News> _newsRepository;

        public NewsService(IRepository<News> newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<News> CreateNewsAsync(CreateNewsDTO data)
        {

            if(data == null)
                return null;

            News newData = new News
            {
                Title = data.Title,
                Body = data.Body,
                PhotoPath = await UploadHandler.UploadAsync(data.Image),
                CreationTime = DateTime.Now
            };

            _newsRepository.Insert(newData);
            return newData;

        }

        public async Task<List<News>> GetAllNewsAsync()
        {
            return await _newsRepository.GetAll()
                .OrderByDescending(news => news.CreationTime)
                .ToListAsync();
        }
        public async Task<List<News>> GetNewsByMonthAsync(int year, int month)
        {
            return await _newsRepository.GetAll()
                .Where(news => news.CreationTime.Year == year && news.CreationTime.Month == month)
                .OrderByDescending(news => news.CreationTime)
                .ToListAsync();
        }
        public async Task<List<ArchiveDataDTO>> GetArchiveDataAsync()
        {
            var archiveData = await _newsRepository.GetAll()
                .GroupBy(news => new { news.CreationTime.Year, news.CreationTime.Month })
                .Select(group => new
                {
                    group.Key.Year,
                    group.Key.Month,
                    NewsCount = group.Count()
                })
                .OrderByDescending(data => data.Year)
                .ThenByDescending(data => data.Month)
                .ToListAsync();

            var monthNames = new[]
            {
        "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    };

            return archiveData.Select(data => new ArchiveDataDTO
            {
                Year = data.Year,
                Month = monthNames[data.Month - 1], 
                NewsCount = data.NewsCount,
                MonthNumber = data.Month
            }).ToList();
        }



    }
}
