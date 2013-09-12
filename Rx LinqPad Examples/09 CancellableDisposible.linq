<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <NuGetReference>Rx-Core</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
</Query>

void Main()
{
	IObservable<int> ob =
    Observable.Create<int>(o =>
        {
            var cancel = new CancellationDisposable(); // internally creates a new CancellationTokenSource
            NewThreadScheduler.Default.Schedule(() =>
                {
                    int i = 0;
                    while(true)
                    {
                        Thread.Sleep(500);  // here we do the long lasting background operation
                        if (!cancel.Token.IsCancellationRequested)    // check cancel token periodically
                            o.OnNext(i++);
                        else
                        {
                            Console.WriteLine("Aborting because cancel event was signaled!");
                            o.OnCompleted();
                            return;
                        }
                    }
                }
            );

            return cancel;
        }
    );

	IDisposable subscription = ob.Subscribe(i => Console.WriteLine(i));
	Console.WriteLine("Press any key to cancel");
	Console.ReadLine();
	subscription.Dispose();
	Console.WriteLine("Press any key to quit");
	Console.ReadLine();  // give background thread chance to write the cancel acknowledge message
}

// Define other methods and classes here