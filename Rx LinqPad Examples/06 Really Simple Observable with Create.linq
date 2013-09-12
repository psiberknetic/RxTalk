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
	var zero = 0;
	IObservable<int> ob =
    Observable.Create<int>(o =>
        {
            o.OnNext(1);
			o.OnNext(4);
			o.OnNext(17);
			o.OnNext(5/zero);
			o.OnNext(25);
			o.OnCompleted();
            return Disposable.Empty;
        }
    );

	ob.Subscribe(
		i => i.Dump(),
		ex=>Console.WriteLine("Exception occurred: " + ex.Message),
		() => Console.WriteLine("Observable completed")
	);

}