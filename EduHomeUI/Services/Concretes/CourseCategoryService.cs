﻿using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHomeUI.Areas.EHMasterPanel.ViewModels.CourseCategoryViewModels;
using EduHomeUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduHomeUI.Services.Concretes
{
    public class CourseCategoryService:ICourseCategoryService
    {
        private readonly AppDbContext _context;
        public CourseCategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CourseCategory>> GetAllCategoriesAsync()
        {
            return await _context.CourseCategories.ToListAsync();
        }

        public async Task<bool> CreateCategoryAsync(CourseCategoryViewModel newCategory)
        {
            if (newCategory == null) return false;

            CourseCategory newCourseCategory = new()
            {
                Category = newCategory.Category,
            };
            await _context.CourseCategories.AddAsync(newCourseCategory);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCourseCategoryById(Guid categoryId)
        {
            var category = await _context.CourseCategories.FindAsync(categoryId);

            if (category is null)
            {
                return false;
            }

            category.IsDeleted = true;
            _context.CourseCategories.Update(category);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> GetCategoryById(Guid categoryId)
        {
            var category = await _context.CourseCategories.FindAsync(categoryId);
            if (category is null) return false;
            return true;
        }

        public async Task<CourseCategory> GetCategoryByIdCategory(Guid categoryId)
        {
            return await _context.CourseCategories.FindAsync(categoryId);
        }

        public async Task<bool> UpdateCourseCategory(Guid categoryId, string newCategory)
        {
            var category = await _context.CourseCategories.FindAsync(categoryId);

            if (category == null)
            {
                return false;
            }

            category.Category = newCategory;
            category.DateModified = DateTime.Now;

            _context.CourseCategories.Update(category);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
