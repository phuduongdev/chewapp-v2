using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace ChewApp.Data.Access.Infrastructure {

    public interface GenericRepository<TEntity> where TEntity : class {

        TEntity Insert(TEntity entity);

        IEnumerable<TEntity> InsertMulti(IEnumerable<TEntity> entities);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAllAndFilter(Expression<Func<TEntity, bool>> filter);

        IQueryable<TEntity> GetAllAndInclude(string[] includeProperties);

        IQueryable<TEntity> GetAllAndOrderBy(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);

        IQueryable<TEntity> GetAllAndPaging(out int total, int? page, int? pageSize);

        TEntity GetSingleByID(object id);

        void Update(TEntity entityToUpdate);

        void Delete(TEntity entityToDelete);

        void Delete(object id);

        void DeleteMulti(Expression<Func<TEntity, bool>> where);

        int Count(Expression<Func<TEntity, bool>> where);

        bool CheckContains(Expression<Func<TEntity, bool>> predicate);
    }

    public abstract class GenericRepositoryImplement<TEntity> : GenericRepository<TEntity> where TEntity : class {

        #region field

        private ChewAppContext _dbContext;
        private DbFactory _dbFactory;
        private IDbSet<TEntity> _dbSet;
        private string _errorMessage = string.Empty;

        #endregion field

        #region contructor

        public GenericRepositoryImplement(DbFactory dbFactory) {
            this._dbFactory = dbFactory;
        }

        #endregion contructor

        #region properties

        public ChewAppContext DbContext {
            get { return this._dbContext ?? (_dbContext = _dbFactory.DbContext); }
        }

        public virtual IDbSet<TEntity> DbSet {
            get { return _dbSet ?? (_dbSet = DbContext.Set<TEntity>()); }
        }

        #endregion properties

        #region implementation methods

        public virtual TEntity Insert(TEntity entity) {
            try {
                if(entity == null)
                    throw new ArgumentNullException("entity");
                return DbSet.Add(entity);
                ////commented out call to SaveChanges as DbContext save changes will be called with Unit of work
                //if(DbContext == null || _disposed)
                //    _dbContext = new ChewAppContext();
                //DbContext.SaveChanges();
            } catch(DbEntityValidationException dbEx) {
                _errorMessage = FormatDbEntityValidationExceptionErrorMessage(dbEx);
                throw new Exception(_errorMessage, dbEx);
            }
        }

        public virtual IEnumerable<TEntity> InsertMulti(IEnumerable<TEntity> entities) {
            try {
                if(entities == null) {
                    throw new ArgumentNullException("entities");
                }
                DbContext.Configuration.AutoDetectChangesEnabled = false;
                return DbContext.Set<TEntity>().AddRange(entities);
                ////commented out call to SaveChanges as DbContext save changes will be called with Unit of work
                //if(DbContext == null || _disposed)
                //    _dbContext = new ChewAppContext();
                //DbContext.SaveChanges();
            } catch(DbEntityValidationException dbEx) {
                _errorMessage = FormatDbEntityValidationExceptionErrorMessage(dbEx);
                throw new Exception(_errorMessage, dbEx);
            }
        }

        public virtual IQueryable<TEntity> GetAll() {
            // creates an IQueryable object
            return DbSet;
        }

        public virtual IQueryable<TEntity> GetAllAndOrderBy(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) {
            var query = DbSet;
            //applies the orderBy expression if there is one and returns the results;
            //otherwise it returns the results from the unordered query
            if(orderBy != null) {
                return orderBy(query);
            }
            return query;
        }

        public virtual IQueryable<TEntity> GetAllAndInclude(string[] includeProperties) {
            var query = DbSet.AsQueryable();
            // applies the eager - loading expressions after parsing the comma - delimited list
            if(includeProperties != null && includeProperties.Count() > 0) {
                query = DbContext.Set<TEntity>().Include(includeProperties.First());
                //var parsingTheComma = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach(var includeProperty in includeProperties.Skip(1)) {
                    query = query.Include(includeProperty);
                }
            }
            return query;
        }

        public virtual IQueryable<TEntity> GetAllAndFilter(Expression<Func<TEntity, bool>> filter) {
            var query = DbSet;
            // applies the filter expression if there is one
            if(filter != null) {
                return query.Where(filter);
            }
            return query;
        }

        public IQueryable<TEntity> GetAllAndPaging(out int total, int? page, int? pageSize) {
            var query = DbSet.AsQueryable();
            int index = page ?? 1;
            int size = pageSize ?? 10;
            if(page < 0 || page == 0)
                index = 1;
            int skipCount = (index - 1) * size;
            query = skipCount == 0 ? query.Take(size) : query.Skip(skipCount).Take(size);
            total = query.Count();
            return query;
        }

        public virtual TEntity GetSingleByID(object id) {
            try {
                if(id == null) {
                    throw new ArgumentNullException("ID is null");
                }
                return DbSet.Find(id);
            } catch(Exception dbEx) {
                throw new Exception(dbEx.StackTrace);
            }
        }

        public virtual void Update(TEntity entityToUpdate) {
            try {
                if(entityToUpdate == null)
                    throw new ArgumentNullException("entity");
                DbContext.Entry(entityToUpdate).State = EntityState.Modified;
                //DbContext.SaveChanges(); commented out call to SaveChanges as DbContext save changes will be called with Unit of work
            } catch(DbEntityValidationException dbEx) {
                _errorMessage = FormatDbEntityValidationExceptionErrorMessage(dbEx);
                throw new Exception(_errorMessage, dbEx);
            }
        }

        public virtual void Delete(TEntity entityToDelete) {
            try {
                if(entityToDelete == null)
                    throw new ArgumentNullException("entity");
                DbSet.Remove(entityToDelete);
                //DbContext.SaveChanges(); commented out call to SaveChanges as DbContext save changes will be called with Unit of work
            } catch(DbEntityValidationException dbEx) {
                _errorMessage = FormatDbEntityValidationExceptionErrorMessage(dbEx);
                throw new Exception(_errorMessage, dbEx);
            }
        }

        public virtual void Delete(object id) {
            TEntity entityToDelete = GetSingleByID(id);
            Delete(entityToDelete);
        }

        public virtual void DeleteMulti(Expression<Func<TEntity, bool>> where) {
            //IEnumerable<TEntity> entitiesCollectionToDelete = DbSet.Where<TEntity>(where).AsEnumerable();
            IQueryable<TEntity> entitiesCollectionToDelete = GetAllAndFilter(where);
            foreach(TEntity entityToDelete in entitiesCollectionToDelete)
                Delete(entityToDelete);
        }

        public virtual int Count(Expression<Func<TEntity, bool>> where) {
            return DbSet.Count(where);
        }

        public bool CheckContains(Expression<Func<TEntity, bool>> predicate) {
            return DbContext.Set<TEntity>().Count<TEntity>(predicate) > 0;
        }

        #endregion implementation methods

        #region support methods

        private string FormatDbEntityValidationExceptionErrorMessage(DbEntityValidationException dbEx) {
            var errorMessage = "";
            foreach(var validationErrors in dbEx.EntityValidationErrors) {
                foreach(var validationError in validationErrors.ValidationErrors)
                    errorMessage += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName,
                        validationError.ErrorMessage)
                        + Environment.NewLine;
            }
            return errorMessage;
        }

        #endregion support methods
    }
}