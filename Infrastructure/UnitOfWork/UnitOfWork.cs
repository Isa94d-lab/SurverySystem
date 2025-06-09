using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private ICategories_catalogRepository? _categories_catalog;
        private ICategory_optionsRepository? _category_options;
        private IChaptersRepository? _chapters;
        private ISurveysRepository? _surveys;

        // Add 
        private IQuestionsRepository? _questions;
        // ---
        
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        
        public ICategories_catalogRepository Categories_catalogs
        {
            get
            {
                if (_categories_catalog == null)
                {
                    _categories_catalog = new Categories_catalogRepository(_context);
                }
                return _categories_catalog;
            }
        }

        public ICategory_optionsRepository Category_options
        {
            get
            {
                if (_category_options == null)
                {
                    _category_options = new Category_optionsRepository(_context);
                }
                return _category_options;
            }
        }


        public IChaptersRepository Chapters
        {
            get
            {
                if (_chapters == null)
                {
                    _chapters = new ChaptersRepository(_context);
                }
                return _chapters;
            }
        }

        public ISurveysRepository Surveys
        {
            get
            {
                if (_surveys == null)
                {
                    _surveys = new SurveysRepository(_context);
                }
                return _surveys;
            }
        }

        // Add

        public IQuestionsRepository Questions
        {
            get
            {
                if (_questions == null)
                {
                    _questions = new QuestionsRepository(_context);
                }
                return _questions;
            }
        }

        // ----


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}