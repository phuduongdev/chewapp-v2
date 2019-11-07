using ChewApp.Common.Handling.Error;
using System;
using System.Data.Entity.Validation;

namespace ChewApp.Data.Access.Infrastructure {

    public interface UnitOfWork {
        ChewAppContext DbContext { get; }

        //void CreateTransaction();

        //void Commit();

        //void Rollback();

        void Save();
    }

    /// <summary>
    /// The unit of work class serves one purpose: to make sure that
    /// when you use multiple repositories,
    /// they share a single database dbContext
    /// </summary>
    public class UnitOfWorkImplement : UnitOfWork {

        //Here TContext is nothing but your DBContext class
        //In our example it is EmployeeDBContext class
        private ChewAppContext _dbContext;
        private DbFactory _dbFactory;
        private string _errorMessage = string.Empty;
        //private DbContextTransaction _objTran;
        //private Dictionary<string, object> _repositories;

        //Using the Constructor we are initializing the _context variable is nothing but
        //we are storing the DBContext (EmployeeDBContext) object in _context variable
        public UnitOfWorkImplement(DbFactory dbFactory) {
            this._dbFactory = dbFactory;
        }

        #region properties

        //This Context property will return the DBContext object i.e. (EmployeeDBContext) object
        public ChewAppContext DbContext {
            get { return _dbContext ?? (_dbContext = _dbFactory.DbContext); }
        }

        #endregion properties

        ////This CreateTransaction() method will create a database Trnasaction so that we can do database operations by
        ////applying do evrything and do nothing principle
        //public void CreateTransaction() {
        //    _objTran = _context.Database.BeginTransaction();
        //}

        ////If all the Transactions are completed successfuly then we need to call this Commit()
        ////method to Save the changes permanently in the database
        //public void Commit() {
        //    _objTran.Commit();
        //}

        ////If atleast one of the Transaction is Failed then we need to call this Rollback()
        ////method to Rollback the database changes to its previous state
        //public void Rollback() {
        //    _objTran.Rollback();
        //    _objTran.Dispose();
        //}

        //This Save() Method Implement DbContext Class SaveChanges method so whenever we do a transaction we need to
        //call this Save() method so that it will make the changes in the database
        public void Save() {
            try {
                DbContext.SaveChanges();
            } catch(DbEntityValidationException dbEx) {
                _errorMessage = FormatExceptionMessage.FormatDbEntityValidationExceptionErrorMessage(dbEx);
                throw new Exception(_errorMessage, dbEx);
            }
        }

        //public GenericRepository<T> GenericRepository<T>() where T : class {
        //    if(_repositories == null)
        //        _repositories = new Dictionary<string, object>();
        //    var type = typeof(T).Name;
        //    if(!_repositories.ContainsKey(type)) {
        //        var repositoryType = typeof(GenericRepository<T>);
        //        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
        //        _repositories.Add(type, repositoryInstance);
        //    }
        //    return (GenericRepository<T>)_repositories[type];
        //}
    }
}