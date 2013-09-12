<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <NuGetReference>Rx-Core</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
  <Namespace>System.Windows.Threading</Namespace>
</Query>

void Main()
{
	IObservable<int> ob =
    Observable.Create<int>(o =>
        {
            NewThreadScheduler.Default.Schedule(() =>
                {
					var rand = new Random();
					
                    while(true)
                    {
                        Thread.Sleep(500);  // here we do the long lasting background operation
                        o.OnNext(rand.Next(1,10000));
                    }
                }
            );

            return Disposable.Empty;
        }
    );

	Console.WriteLine("UI Thread is ID " + Thread.CurrentThread.ManagedThreadId);
	IDisposable subscription = ob.Subscribe(i => Console.WriteLine(i + " created on thread " + Thread.CurrentThread.ManagedThreadId));
	Console.WriteLine("Press any key to cancel");
	Console.ReadLine();
	subscription.Dispose();
	Console.WriteLine("Press any key to quit");
	Console.ReadLine();
}