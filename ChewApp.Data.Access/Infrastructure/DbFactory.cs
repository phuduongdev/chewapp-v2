using System;

namespace ChewApp.Data.Access.Infrastructure {

    public interface DbFactory {
        ChewAppContext DbContext { get; }
    }

    public class DbFactoryImplement : DbFactory, IDisposable {
        private bool _disposed = false;
        private ChewAppContext _dbContext;

        public ChewAppContext DbContext {
            get {
                return _dbContext ?? (_dbContext = new ChewAppContext());
            }
        }

        //The Dispose() method is used to free unmanaged resources like files,
        //database connections etc. at any time.
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            try {
                if(!_disposed && disposing)
                    DbContext.Dispose();
                _disposed = true;
            } catch(Exception e) {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}