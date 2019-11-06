using System;

namespace ChewApp.Data.Access.Infrastructure {

    public interface DbFactory {

        ChewAppContext DbContext();
    }

    public class DbFactoryImplement : DbFactory, IDisposable {
        private bool _disposed = false;
        private ChewAppContext _dbContext;

        public ChewAppContext DbContext() {
            return _dbContext ?? (_dbContext = new ChewAppContext());
        }

        //The Dispose() method is used to free unmanaged resources like files,
        //database connections etc. at any time.
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if(!_disposed && disposing)
                _dbContext.Dispose();
            _disposed = true;
        }
    }
}