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
        private IOptions_responseRepository? _options_response;
        private IQuestionsRepository? _questions;
        private ISub_questionsRepository? _sub_questions;
        private IOption_questionsRepository? _option_questions;
        private ISumaryoptionsRepository? _sumaryoptions;

        // Add 
        private IUserMemberRepository? _userMember;
        private IRolRepository? _rol;
        private IMemberRolsRepository? _memberRols;
        // ---

        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        
        public ICategories_catalogRepository Categories_catalog
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

        public IOptions_responseRepository Options_response
        {
            get
            {
                if (_options_response == null)
                {
                    _options_response = new Options_responseRepository(_context);
                }
                return _options_response;
            }
        }

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

        public ISub_questionsRepository Sub_questions
        {
            get
            {
                if (_sub_questions == null)
                {
                    _sub_questions = new Sub_questionsRepository(_context);
                }
                return _sub_questions;
            }
        }

        public IOption_questionsRepository Option_questions
        {
            get
            {
                if (_option_questions == null)
                {
                    _option_questions = new Option_questionsRepository(_context);
                }
                return _option_questions;
            }
        }

        public ISumaryoptionsRepository Sumaryoptions
        {
            get
            {
                if (_sumaryoptions == null)
                {
                    _sumaryoptions = new SumaryoptionsRepository(_context);
                }
                return _sumaryoptions;
            }
        }


        // Add

        public IUserMemberRepository UserMember
        {
            get
            {
                if (_userMember == null)
                {
                    _userMember = new UserMemberRepository(_context);
                }
                return _userMember;
            }
        }
        public IRolRepository Rol
        {
            get
            {
                if (_rol == null)
                {
                    _rol = new RolRepository(_context);
                }
                return _rol;
            }
        }

        public IMemberRolsRepository MemberRol
        {
            get
            {
                if (_memberRols == null)
                {
                    _memberRols = new MemberRolsRepository(_context);
                }
                return _memberRols;
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