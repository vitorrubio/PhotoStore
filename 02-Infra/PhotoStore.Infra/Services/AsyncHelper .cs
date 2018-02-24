using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace PhotoStore.Infra.Services
{

    /// <summary>
    /// conforme dicas do https://cpratt.co/async-tips-tricks/
    /// 
    /// </summary>
    public static class AsyncHelper
    {
        private static readonly TaskFactory _taskFactory = new
            TaskFactory(CancellationToken.None,
                        TaskCreationOptions.None,
                        TaskContinuationOptions.None,
                        TaskScheduler.Default);

        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
            => _taskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();

        public static void RunSync(Func<Task> func)
            => _taskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();




        public static TResult RunSyncWithoutContext<TResult>(Func<Task<TResult>> func)
            => _taskFactory
                .StartNew(func)
                .Unwrap()
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

        public static void RunSyncWithoutContext(Func<Task> func)
            => _taskFactory
                .StartNew(func)
                .Unwrap()
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
    }
}